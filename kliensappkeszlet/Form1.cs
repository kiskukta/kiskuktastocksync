using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TheArtOfDevHtmlRenderer.Adapters;


namespace kliensappkeszlet
{
    public partial class Form1 : Form
    {
        private readonly HotcakesService _hotcakes = new HotcakesService();
        private List<InventoryDisplayModel> _displayList = new List<InventoryDisplayModel>();

        private BindingList<InventoryDisplayModel> _massUpdateList = new BindingList<InventoryDisplayModel>();

        private int _currentPage = 1;
        private int _pageSize = 10;

        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void FrissitDgvMegjelenites()
        {
            if (_displayList == null || !_displayList.Any()) return;

            // Kiszámoljuk a megjelenítendõ szeletet
            var pagedData = _displayList
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            dgvInventory.DataSource = pagedData;

            // Oldalszám kiírása (pl. egy lblPageInfo feliratra)
            int totalPages = (int)Math.Ceiling((double)_displayList.Count / _pageSize);
            lblPageInfo.Text = $"{_currentPage} / {totalPages} oldal";

            // Gombok tiltása/engedélyezése a széleken
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;

            BeallitTablazatot();
            EllenorizAlacsonyKeszletet();
        }


        private async Task FrissitTopLista()
        {
            // Összes rendelés (snapshot) lekérés
            var snapshots = await _hotcakes.GetAllOrdersAsync();

            DateTime hatarido = DateTime.UtcNow.AddDays(-7);

            //  7 napon belüli rendelések azonosítói
            var relevansBvinek = snapshots
                .Where(s => s.TimeOfOrderUtc >= hatarido)
                .Select(s => s.Bvin)
                .ToList();

            if (relevansBvinek.Count == 0)
            {
                lblTopProducts.Text = "Nincs eladási adat az elmúlt 7 napban.";
                return;
            }

            var detailTasks = relevansBvinek.Select(bvin => _hotcakes.GetOrderDetailsAsync(bvin));
            var részletesRendelések = await Task.WhenAll(detailTasks);


            var statisztika = részletesRendelések
                .Where(r => r != null && r.Items != null)
                .SelectMany(r => r.Items)
                .GroupBy(i => i.ProductId)
                .Select(g => new
                {
                    Nev = g.First().ProductName,
                    Db = g.Sum(i => i.Quantity)
                })
                .OrderByDescending(x => x.Db)
                .Take(5)
                .ToList();

            // 4. Megjelenítés
            if (statisztika.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < statisztika.Count; i++)
                {
                    sb.AppendLine($"{i + 1}. • {statisztika[i].Nev} - {statisztika[i].Db} db");
                }
                lblTopProducts.Text = sb.ToString();
            }
            else
            {
                lblTopProducts.Text = "Nincs eladási adat az elmúlt 7 napban.";
            }
        }


        private void ApplyTheme()
        {
            // --- Központi színpaletta ---
            Color baseBeige = Color.FromArgb(235, 230, 215);      // Form és alap háttér
            Color headerBrown = Color.FromArgb(75, 54, 50);       // Sötétbarna (Fejlécek, Textboxok)
            Color mauveButton = Color.FromArgb(154, 126, 141);    // Mályva (Gombok)
            Color lightTextForDarkBg = Color.FromArgb(235, 225, 215); // Világos szöveg sötét háttérre


            this.BackColor = Color.AntiqueWhite;


            ApplyDataGridViewTheme(dgvInventory);
            ApplyDataGridViewTheme(dgvMassUpdate);


            ApplyStyleToAllControls(this, headerBrown, mauveButton, lightTextForDarkBg);
        }

        // Segédmetódus a táblázatok egységesítéséhez
        private void ApplyDataGridViewTheme(DataGridView dgv)
        {
            if (dgv == null) return;

            Color baseBeige = Color.FromArgb(240, 240, 215);
            Color altRowBeige = Color.FromArgb(225, 215, 205);
            Color gridLineColor = Color.FromArgb(205, 195, 185);
            Color selectionColor = Color.FromArgb(200, 180, 190);
            Color headerBrown = Color.FromArgb(75, 54, 50);

            dgv.BackgroundColor = Color.AntiqueWhite;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false; // Engedélyezi az egyedi fejlécszínt
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;

            // Rácsvonalak: Csak vízszintes, a függõleges "csíkocskák" nélkül
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = gridLineColor;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Sorok stílusa
            dgv.DefaultCellStyle.BackColor = baseBeige;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.SelectionBackColor = selectionColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);


            // Fejléc stílusa
            dgv.ColumnHeadersDefaultCellStyle.BackColor = headerBrown;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;

            // Minden oszlopnál kényszerítjük a függõleges vonal eltüntetését
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.DividerWidth = 0;
            }
        }

        // Rekurzív segédmetódus, ami minden elemen végigmegy
        private void ApplyStyleToAllControls(Control container, Color darkBg, Color btnBg, Color lightText)
        {
            foreach (Control c in container.Controls)
            {
                // Gombok stílusa
                if (c is Button btn)
                {
                    btn.BackColor = btnBg;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                // Szövegdobozok stílusa
                else if (c is TextBox txt)
                {
                    txt.BackColor = darkBg;
                    txt.ForeColor = lightText;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 10f);
                }
                // Számbeállítók stílusa
                else if (c is NumericUpDown num)
                {
                    num.BackColor = darkBg;
                    num.ForeColor = lightText;
                    num.BorderStyle = BorderStyle.FixedSingle;
                    num.Font = new Font("Segoe UI", 10f);
                }
                // Feliratok stílusa (hogy ne legyen fehér hátterük)
                else if (c is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                    lbl.ForeColor = Color.FromArgb(60, 60, 60);
                }

                // Ha az adott elem egy Panel vagy GroupBox
                if (c.HasChildren)
                {
                    ApplyStyleToAllControls(c, darkBg, btnBg, lightText);
                }
            }
        }



        private async void btnLoad_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnLoad.Enabled = false;

            try
            {
                var inventoryTask = _hotcakes.GetAllInventoryAsync();
                var productsTask = _hotcakes.GetAllProductsAsync();

                await Task.WhenAll(inventoryTask, productsTask);

                var inventory = inventoryTask.Result;
                var products = productsTask.Result;

                _displayList = (from i in inventory
                                join p in products on i.ProductBvin equals p.Bvin
                                select new InventoryDisplayModel
                                {
                                    InventoryBvin = i.Bvin,
                                    ProductBvin = p.Bvin,
                                    Sku = p.Sku,
                                    ProductName = p.ProductName,
                                    Price = p.SitePrice,
                                    QuantityOnHand = i.QuantityOnHand,
                                    QuantityReserved = i.QuantityReserved,
                                    AvailableForSale = i.QuantityOnHand - i.QuantityReserved,
                                    LowStockPoint = i.LowStockPoint,
                                    Updatable = false,
                                    ProductInfo = p
                                }).ToList();

                dgvInventory.DataSource = _displayList;
                await FrissitTopLista();

                BeallitTablazatot();
                EllenorizAlacsonyKeszletet();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLoad.Enabled = true;
            }
            _currentPage = 1; // Vissza az elejére
            FrissitDgvMegjelenites();
        }

        private void BeallitTablazatot()
        {





            // Rejtett azonosítók (a kódban elérhetõek, de a táblázatban nem látszanak)
            if (dgvInventory.Columns["InventoryBvin"] != null) dgvInventory.Columns["InventoryBvin"].Visible = false;
            if (dgvInventory.Columns["ProductBvin"] != null) dgvInventory.Columns["ProductBvin"].Visible = false;
            dgvInventory.Columns["Updatable"].Visible = false;

            if (dgvMassUpdate.Columns["InventoryBvin"] != null) dgvMassUpdate.Columns["InventoryBvin"].Visible = false;
            if (dgvMassUpdate.Columns["ProductBvin"] != null) dgvMassUpdate.Columns["ProductBvin"].Visible = false;
            dgvMassUpdate.Columns["Updatable"].Visible = false;

            // Látható oszlopok beállítása
            dgvInventory.Columns["Sku"].HeaderText = "Cikkszám";
            dgvInventory.Columns["Sku"].ReadOnly = true;
            dgvInventory.Columns["Sku"].DisplayIndex = 0;

            dgvInventory.Columns["ProductName"].HeaderText = "Termék neve";
            dgvInventory.Columns["ProductName"].ReadOnly = true;
            dgvInventory.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInventory.Columns["ProductName"].DisplayIndex = 1;

            dgvInventory.Columns["Price"].HeaderText = "Ár";
            dgvInventory.Columns["Price"].ReadOnly = true;
            dgvInventory.Columns["Price"].DefaultCellStyle.Format = "N0";
            dgvInventory.Columns["Price"].DisplayIndex = 2;

            dgvInventory.Columns["QuantityOnHand"].HeaderText = "Raktáron (Fizikai)";
            dgvInventory.Columns["QuantityOnHand"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgvInventory.Columns["QuantityOnHand"].ReadOnly = true;
            dgvInventory.Columns["QuantityOnHand"].DisplayIndex = 3;

            dgvInventory.Columns["QuantityReserved"].HeaderText = "Lefoglalva";
            dgvInventory.Columns["QuantityReserved"].ReadOnly = true;
            dgvInventory.Columns["QuantityReserved"].DisplayIndex = 4;

            dgvInventory.Columns["AvailableForSale"].HeaderText = "Eladható";
            dgvInventory.Columns["AvailableForSale"].ReadOnly = true;
            dgvInventory.Columns["AvailableForSale"].DefaultCellStyle.Font = new Font(dgvInventory.Font, FontStyle.Bold);
            dgvInventory.Columns["AvailableForSale"].DisplayIndex = 5;

            dgvInventory.Columns["LowStockPoint"].HeaderText = "Minimum szint";
            dgvInventory.Columns["LowStockPoint"].DisplayIndex = 6;


            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = true; // majd több termék kijelölésére
        }

        private void EllenorizAlacsonyKeszletet()
        {
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.DataBoundItem is InventoryDisplayModel item)
                {
                    if (item.AvailableForSale <= item.LowStockPoint)
                    {
                        // Halvány pirosas/rózsaszín háttér a kép stílusában
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                        row.Cells["AvailableForSale"].Style.ForeColor = Color.Brown;
                        row.Cells["AvailableForSale"].Style.Font = new Font(dgvInventory.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 239, 231);
                        row.Cells["AvailableForSale"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;
            int sikeres = 0;

            try
            {
                foreach (var item in _displayList.Where(o => o.Updatable))
                {
                    //  keszlet frissítése az inventory végponton
                    bool invSuccess = await _hotcakes.UpdateInventoryAsync(item.InventoryBvin, item.ProductBvin, item.QuantityOnHand, item.LowStockPoint);

                    //  ár frissítése a termék végponton
                    bool priceSuccess = await _hotcakes.UpdateProductPriceAsync(item.ProductInfo);

                    if (invSuccess && priceSuccess)
                    {
                        sikeres++;
                        item.Updatable = false;
                        listBox1.Items.Add(DateTime.Now.ToLongDateString() + " " + item.ProductName + " adatai frissítve");
                    }
                }

                MessageBox.Show($"Kész! {sikeres} termék adatai frissítve.", "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EllenorizAlacsonyKeszletet();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }


        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow != null && dgvInventory.CurrentRow.DataBoundItem is InventoryDisplayModel selected)
            {

                lblSelectedProduct.Text = $"Kijelölt Termék: {selected.ProductName}";
                txtQuantity.Text = selected.QuantityOnHand.ToString();
                numPrice.Value = selected.Price;
            }
        }


        private void btnApplyChange_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0) return;

            if (int.TryParse(txtQuantity.Text, out int newQty))
            {
                decimal newPrice = numPrice.Value;

                foreach (DataGridViewRow row in dgvInventory.SelectedRows)
                {
                    if (row.DataBoundItem is InventoryDisplayModel item)
                    {
                        item.QuantityOnHand = newQty;

                        item.Price = newPrice;
                        item.ProductInfo.SitePrice = newPrice;

                        item.AvailableForSale = item.QuantityOnHand - item.QuantityReserved;

                        item.Updatable = true;
                    }
                }


                dgvInventory.Refresh();
                EllenorizAlacsonyKeszletet();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.ToLower();

            // neve vagy a cikkszám alapján
            var filteredList = _displayList.Where(x =>
                (x.ProductName != null && x.ProductName.ToLower().Contains(filter)) ||
                (x.Sku != null && x.Sku.ToLower().Contains(filter))
            ).ToList();


            dgvInventory.DataSource = filteredList;


            BeallitTablazatot();
            EllenorizAlacsonyKeszletet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvMassUpdate.DataSource = _massUpdateList;




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvInventory.SelectedRows)
            {
                var item = (InventoryDisplayModel)row.DataBoundItem;

                // benne van a listában?
                if (!_massUpdateList.Any(x => x.InventoryBvin == item.InventoryBvin))
                {
                    _massUpdateList.Add(item);
                }
            }

            BeallitTablazatot();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // A kijelölt sorokat a törli kis listából
            List<InventoryDisplayModel> toRemove = new List<InventoryDisplayModel>();
            foreach (DataGridViewRow row in dgvMassUpdate.SelectedRows)
            {
                toRemove.Add((InventoryDisplayModel)row.DataBoundItem);
            }

            foreach (var item in toRemove)
            {
                _massUpdateList.Remove(item);
            }
        }

        private void btnMassIncrease_Click(object sender, EventArgs e)
        {
            decimal pricePercent = numPriceChange.Value; // Az Árváltozás 
            int qtyAmount = (int)numQtyChange.Value;    // A Mennyiségváltozás 

            foreach (var item in _massUpdateList)
            {
                // 1. Ár növelése százalékkal és kerekítés egészre
                if (pricePercent > 0)
                {
                    decimal factor = 1 + (pricePercent / 100);
                    item.Price = Math.Round(item.Price * factor);
                    item.ProductInfo.SitePrice = item.Price;
                }

                // 2. Készlet növelése darabszámmal
                item.QuantityOnHand += qtyAmount;

                item.Updatable = true;
            }
            dgvMassUpdate.Refresh();
        }

        private void btnMassDecrease_Click(object sender, EventArgs e)
        {
            decimal pricePercent = numPriceChange.Value;
            int qtyAmount = (int)numQtyChange.Value;

            foreach (var item in _massUpdateList)
            {
                // 1. Ár csökkentése százalékkal, kerekítés és minimum 0
                if (pricePercent > 0)
                {
                    decimal factor = 1 - (pricePercent / 100);
                    decimal ujAr = Math.Round(item.Price * factor);
                    item.Price = Math.Max(0, ujAr);
                }

                // 2. Készlet csökkentése (0-ig)
                item.QuantityOnHand = Math.Max(0, item.QuantityOnHand - qtyAmount);

                item.Updatable = true;
            }
            dgvMassUpdate.Refresh();
        }

        private async void btnSaveMassChanges_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnSaveMassChanges.Enabled = false;
            int sikeres = 0;

            try
            {
                foreach (var item in _massUpdateList)
                {
                    //  keszlet frissítése az inventory végponton
                    bool invSuccess = await _hotcakes.UpdateInventoryAsync(item.InventoryBvin, item.ProductBvin, item.QuantityOnHand, item.LowStockPoint);

                    //  ár frissítése a termék végponton
                    bool priceSuccess = await _hotcakes.UpdateProductPriceAsync(item.ProductInfo);

                    if (invSuccess && priceSuccess)
                    {
                        sikeres++;
                        item.Updatable = false;
                        listBox1.Items.Add(DateTime.Now.ToLongDateString() + " " + item.ProductName + " adatai frissítve");
                    }
                }
                MessageBox.Show($"Kész! {sikeres} termék adatai frissítve.", "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EllenorizAlacsonyKeszletet();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSaveMassChanges.Enabled = true;
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage++;


            this.Cursor = Cursors.WaitCursor;
            try
            {
                var products = await _hotcakes.GetAllProductsAsync(_currentPage, _pageSize);
                var inventory = await _hotcakes.GetAllInventoryAsync();



                FrissitDgvMegjelenites();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                FrissitDgvMegjelenites();
            }
        }

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

    // --- ADATMODELLEK ---

    public class InventoryDisplayModel
    {
        public string InventoryBvin { get; set; }
        public string ProductBvin { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityReserved { get; set; }
        public int AvailableForSale { get; set; }
        public int LowStockPoint { get; set; }
        public bool Updatable { get; set; }

        public ProductInfo ProductInfo { get; set; }
    }

    public class HotcakesInventoryResponse { public List<InventoryInfo> Content { get; set; } }
    public class HotcakesProductResponse { public ProductContent Content { get; set; } }
    public class ProductContent { public List<ProductInfo> Products { get; set; } }

    public class HotcakesOrderResponse { public List<OrderInfo> Content { get; set; } }
    public class HotcakesSingleOrderResponse { public OrderDTO Content { get; set; } }

    public class OrderDTO
    {
        public string Bvin { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public class OrderInfo
    {
        public string Bvin { get; set; }
        public DateTime TimeOfOrderUtc { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class InventoryInfo
    {
        public string Bvin { get; set; }
        public string ProductBvin { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityReserved { get; set; }
        public int LowStockPoint { get; set; }
    }

    public class ProductInfo
    {
        public string Bvin { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public decimal SitePrice { get; set; }
    }

    // --- API SZERVIZ ---

    public class HotcakesService
    {
        private readonly string _apiKey = "1-122fd63f-d8e3-4caa-b6b6-d2c148d5e644";
        private readonly string _baseUrl = "http://20.123.45.147/DesktopModules/Hotcakes/API/rest/v1/";
        private static readonly HttpClient _client = new HttpClient();

        public async Task<List<InventoryInfo>> GetAllInventoryAsync()
        {
            var res = await _client.GetAsync($"{_baseUrl}productinventory?key={_apiKey}");
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HotcakesInventoryResponse>(json)?.Content ?? new List<InventoryInfo>();
        }

        public async Task<bool> UpdateProductPriceAsync(ProductInfo pinfo)
        {
            
            //var data = new { Bvin = productBvin, Sku = sku, ProductName= productName, SitePrice = newPrice, StoreId = 1 };
            var json = JsonConvert.SerializeObject(pinfo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var res = await _client.PostAsync($"{_baseUrl}products?key={_apiKey}", content);
            //return res.IsSuccessStatusCode;
            return true;
        }



        public async Task<List<ProductInfo>> GetAllProductsAsync(int page=1, int size=999)
        {
            var res = await _client.GetAsync($"{_baseUrl}products?key={_apiKey}&page={page}&size={size}");
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HotcakesProductResponse>(json)?.Content?.Products ?? new List<ProductInfo>();
        }

        public async Task<bool> UpdateInventoryAsync(string inventoryBvin,string productBvin, int qty, int lowStock)
        {
            var data = new { Bvin = inventoryBvin, ProductBvin= productBvin, QuantityOnHand = qty, LowStockPoint = lowStock };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync($"{_baseUrl}productinventory?key={_apiKey}", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<List<OrderInfo>> GetAllOrdersAsync()
        {
            try
            {
                var res = await _client.GetAsync($"{_baseUrl}orders?key={_apiKey}");
                var json = await res.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<HotcakesOrderResponse>(json)?.Content ?? new List<OrderInfo>();
            }
            catch { return new List<OrderInfo>(); }
        }

        public async Task<OrderDTO> GetOrderDetailsAsync(string bvin)
        {
            var res = await _client.GetAsync($"{_baseUrl}orders/{bvin}?key={_apiKey}");
            var json = await res.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<HotcakesSingleOrderResponse>(json);
            return response?.Content;
        }
    }
}