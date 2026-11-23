using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace MiniBrauzer
{
    public partial class Form1 : Form
    {
        private const string HomeUrl = "https://www.example.com";
        private const int MaxHistory = 50;

        private readonly TabPage _plusTab = new TabPage("+");
        private readonly string _favFile = Path.Combine(AppContext.BaseDirectory, "favorites.txt");
        private Task<CoreWebView2Environment> _envTask;
        private bool _busy; // tab əlavə/silinərkən SelectedIndexChanged-i əngəlləmək üçün

        public Form1()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------
        //  Form yüklənəndə
        // ---------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFavorites();
            tabControl1.TabPages.Add(_plusTab);   // "+" tabı həmişə sonda durur
            AddNewTab(HomeUrl);                   // ilk tab (Tab 1)
        }

        // ---------------------------------------------------------------
        //  WebView2 mühiti (bir dəfə yaradılır, bütün tablar paylaşır)
        // ---------------------------------------------------------------
        private Task<CoreWebView2Environment> GetEnvAsync()
        {
            if (_envTask == null)
            {
                string dataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "MiniBrauzer");
                _envTask = CoreWebView2Environment.CreateAsync(null, dataFolder);
            }
            return _envTask;
        }

        // ---------------------------------------------------------------
        //  Tab əməliyyatları
        // ---------------------------------------------------------------
        private WebView2 CurrentWebView()
        {
            TabPage page = tabControl1.SelectedTab;
            if (page == null || page == _plusTab) return null;
            return page.Controls.OfType<WebView2>().FirstOrDefault();
        }

        private async void AddNewTab(string url)
        {
            var page = new TabPage("Yeni tab");
            var wv = new WebView2 { Dock = DockStyle.Fill };
            page.Controls.Add(wv);

            int idx = tabControl1.TabPages.IndexOf(_plusTab);
            if (idx < 0) idx = tabControl1.TabPages.Count;

            _busy = true;
            tabControl1.TabPages.Insert(idx, page);
            tabControl1.SelectedTab = page;
            _busy = false;
            txtUrl.Text = url;

            try
            {
                CoreWebView2Environment env = await GetEnvAsync();
                await wv.EnsureCoreWebView2Async(env);

                wv.CoreWebView2.DocumentTitleChanged += (s, e) =>
                {
                    string title = wv.CoreWebView2.DocumentTitle;
                    if (string.IsNullOrWhiteSpace(title)) title = "Tab";
                    page.Text = title.Length > 18 ? title.Substring(0, 18) + "…" : title;
                };

                wv.CoreWebView2.SourceChanged += (s, e) =>
                {
                    if (tabControl1.SelectedTab == page)
                        txtUrl.Text = wv.CoreWebView2.Source;
                };

                wv.CoreWebView2.NavigationCompleted += (s, e) =>
                {
                    if (e.IsSuccess) AddToHistory(GetHost(wv.CoreWebView2.Source));
                };

                // target="_blank" və yeni pəncərə sorğuları yeni tabda açılsın
                wv.CoreWebView2.NewWindowRequested += (s, e) =>
                {
                    e.Handled = true;
                    AddNewTab(e.Uri);
                };

                wv.CoreWebView2.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "WebView2 işə salına bilmədi.\nMicrosoft Edge WebView2 Runtime quraşdırıldığından əmin olun.\n\n" + ex.Message,
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseTab(TabPage page)
        {
            if (page == null || page == _plusTab) return;

            int idx = tabControl1.TabPages.IndexOf(page);

            _busy = true;
            tabControl1.TabPages.Remove(page);
            foreach (WebView2 w in page.Controls.OfType<WebView2>().ToList())
                w.Dispose();
            page.Dispose();
            _busy = false;

            // yalnız "+" tabı qalıbsa, yeni tab aç
            if (tabControl1.TabPages.Count == 1)
            {
                AddNewTab(HomeUrl);
                return;
            }

            tabControl1.SelectedIndex = Math.Max(0, idx - 1);
            SyncUrlBox();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_busy) return;

            if (tabControl1.SelectedTab == _plusTab)
            {
                AddNewTab(HomeUrl);
                return;
            }
            SyncUrlBox();
        }

        // Orta düymə (təkər) ilə tabı bağlamaq
        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle) return;

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                if (tabControl1.GetTabRect(i).Contains(e.Location))
                {
                    CloseTab(tabControl1.TabPages[i]);
                    break;
                }
            }
        }

        private void SyncUrlBox()
        {
            WebView2 wv = CurrentWebView();
            if (wv != null && wv.CoreWebView2 != null)
                txtUrl.Text = wv.CoreWebView2.Source;
        }

        // ---------------------------------------------------------------
        //  Naviqasiya düymələri
        // ---------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            WebView2 wv = CurrentWebView();
            if (wv?.CoreWebView2 != null && wv.CoreWebView2.CanGoBack)
                wv.CoreWebView2.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            WebView2 wv = CurrentWebView();
            if (wv?.CoreWebView2 != null && wv.CoreWebView2.CanGoForward)
                wv.CoreWebView2.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WebView2 wv = CurrentWebView();
            if (wv?.CoreWebView2 != null)
                wv.CoreWebView2.Reload();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            NavigateTo(HomeUrl);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            NavigateTo(txtUrl.Text);
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NavigateTo(txtUrl.Text);
            }
        }

        private void NavigateTo(string input)
        {
            WebView2 wv = CurrentWebView();
            if (wv?.CoreWebView2 == null) return;

            string url = NormalizeUrl(input);
            if (url == null) return;

            wv.CoreWebView2.Navigate(url);
        }

        // İstifadəçinin yazdığı mətni düzgün URL-ə çevirir
        private static string NormalizeUrl(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            input = input.Trim();

            // artıq tam ünvandır (http://, https://, file://, about: ...)
            if (input.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                input.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
                input.StartsWith("file://", StringComparison.OrdinalIgnoreCase) ||
                input.StartsWith("about:", StringComparison.OrdinalIgnoreCase))
            {
                return input;
            }

            // boşluq varsa və ya nöqtə yoxdursa -> axtarış
            if (input.Contains(' ') || !input.Contains('.'))
                return "https://www.google.com/search?q=" + Uri.EscapeDataString(input);

            return "https://" + input;
        }

        // ---------------------------------------------------------------
        //  Seçilmişlər (Favorites)
        // ---------------------------------------------------------------
        private void LoadFavorites()
        {
            listFavorites.Items.Clear();
            try
            {
                if (File.Exists(_favFile))
                {
                    foreach (string line in File.ReadAllLines(_favFile))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            listFavorites.Items.Add(line.Trim());
                    }
                    return;
                }
            }
            catch
            {
                // fayl oxunmasa, default siyahı ilə davam edirik
                listFavorites.Items.Clear();
            }

            listFavorites.Items.AddRange(new object[]
            {
                "google.com", "wikipedia.org", "youtube.com", "azertag.az"
            });
        }

        private void SaveFavorites()
        {
            try
            {
                File.WriteAllLines(_favFile, listFavorites.Items.Cast<object>().Select(x => x.ToString()));
            }
            catch
            {
                // yazma icazəsi yoxdursa, proqram işləməyə davam edir
            }
        }

        private void btnAddFav_Click(object sender, EventArgs e)
        {
            WebView2 wv = CurrentWebView();
            string host = (wv?.CoreWebView2 != null) ? GetHost(wv.CoreWebView2.Source) : null;

            if (host == null)
            {
                MessageBox.Show("Əlavə ediləcək açıq səhifə yoxdur.", "Məlumat",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listFavorites.Items.Contains(host))
            {
                MessageBox.Show("Bu sayt artıq seçilmişlərdədir.", "Məlumat",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listFavorites.Items.Add(host);
            SaveFavorites();
        }

        private void listFavorites_DoubleClick(object sender, EventArgs e)
        {
            if (listFavorites.SelectedItem != null)
                NavigateTo(listFavorites.SelectedItem.ToString());
        }

        // Delete düyməsi ilə seçilmişdən silmək
        private void listFavorites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listFavorites.SelectedIndex >= 0)
            {
                listFavorites.Items.RemoveAt(listFavorites.SelectedIndex);
                SaveFavorites();
            }
        }

        // ---------------------------------------------------------------
        //  Tarixçə (History)
        // ---------------------------------------------------------------
        private void AddToHistory(string host)
        {
            if (string.IsNullOrEmpty(host)) return;

            // ardıcıl təkrarı əlavə etmə
            if (listHistory.Items.Count > 0 && listHistory.Items[0].ToString() == host)
                return;

            listHistory.Items.Insert(0, host);

            while (listHistory.Items.Count > MaxHistory)
                listHistory.Items.RemoveAt(listHistory.Items.Count - 1);
        }

        private void listHistory_DoubleClick(object sender, EventArgs e)
        {
            if (listHistory.SelectedItem != null)
                NavigateTo(listHistory.SelectedItem.ToString());
        }

        // ---------------------------------------------------------------
        //  Köməkçi
        // ---------------------------------------------------------------
        // "https://www.google.com/x" -> "google.com"
        private static string GetHost(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri)) return null;
            if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps) return null;

            string host = uri.Host;
            if (host.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
                host = host.Substring(4);
            return host;
        }
    }
}
