using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace kliensappkeszlet
{
    public partial class Form1 : Form
    {
        private readonly HotcakesService _hotcakes = new HotcakesService();
        private List<InventoryDisplayModel> _displayList = new List<InventoryDisplayModel>();

        public Form1()
        {
            InitializeComponent();
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
                                    Updatable = false
                                }).ToList();

                dgvInventory.DataSource = _displayList;
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
        }

        private void BeallitTablazatot()
        {
            // Rejtett azonosítók (a kódban elérhetõek, de a táblázatban nem látszanak)
            if (dgvInventory.Columns["InventoryBvin"] != null) dgvInventory.Columns["InventoryBvin"].Visible = false;
            if (dgvInventory.Columns["ProductBvin"] != null) dgvInventory.Columns["ProductBvin"].Visible = false;
            dgvInventory.Columns["Updatable"].Visible = false;

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
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.Cells["AvailableForSale"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
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
                    bool success = await _hotcakes.UpdateInventoryAsync(item.InventoryBvin, item.ProductBvin, item.QuantityOnHand, item.LowStockPoint);
                    if (success) sikeres++;
                    item.Updatable = false;
                }
                MessageBox.Show($"Kész! {sikeres} tétel frissítve.", "Sikeres mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);


                EllenorizAlacsonyKeszletet();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a mentés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Megjelenítjük a kijelölt termék nevét és jelenlegi mennyiségét a beviteli mezõkben
                lblSelectedProduct.Text = $"Kijelölt Termék: {selected.ProductName}";
                txtQuantity.Text = selected.QuantityOnHand.ToString();
            }
        }


        private void btnApplyChange_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0) return;

            if (int.TryParse(txtQuantity.Text, out int newQty))
            {

                foreach (DataGridViewRow row in dgvInventory.SelectedRows)
                {
                    if (row.DataBoundItem is InventoryDisplayModel item)
                    {
                        item.QuantityOnHand = newQty;

                        item.AvailableForSale = item.QuantityOnHand - item.QuantityReserved;

                        item.Updatable = true;
                    }
                }


                dgvInventory.Refresh();
                EllenorizAlacsonyKeszletet();
            }
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
    }

    public class HotcakesInventoryResponse { public List<InventoryInfo> Content { get; set; } }
    public class HotcakesProductResponse { public ProductContent Content { get; set; } }
    public class ProductContent { public List<ProductInfo> Products { get; set; } }

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

        public async Task<List<ProductInfo>> GetAllProductsAsync()
        {
            var res = await _client.GetAsync($"{_baseUrl}products?key={_apiKey}");
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
    }
}