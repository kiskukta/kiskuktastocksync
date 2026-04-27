using System;
using System.Collections.Generic;
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

        // 1. ADATOK BETÖLTÉSE ÉS ÖSSZEFÉSÜLÉSE
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnLoad.Enabled = false;

            try
            {
                // Párhuzamosan indít a két lekérést (hátha így gyorsabb)
                var inventoryTask = _hotcakes.GetAllInventoryAsync();
                var productsTask = _hotcakes.GetAllProductsAsync();

                await Task.WhenAll(inventoryTask, productsTask);

                var inventory = inventoryTask.Result;
                var products = productsTask.Result;

                // LINQ Join:  név, ár, SKU a készletadattal a BVIN alapján
                _displayList = (from i in inventory
                                join p in products on i.ProductBvin equals p.Bvin
                                select new InventoryDisplayModel
                                {
                                    InventoryBvin = i.Bvin,
                                    ProductBvin = p.Bvin,
                                    Sku = p.Sku,
                                    ProductName = p.ProductName,
                                    Price = p.SitePrice,
                                    QuantityOnHand = i.QuantityOnHand
                                }).ToList();

                if (_displayList.Count > 0)
                {
                    dgvInventory.DataSource = _displayList;
                    BeallitTablazatot();
                }
                else
                {
                    MessageBox.Show("Nincs megjeleníthetõ adat. Ellenõrizd a termékeket a webshopban!", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        // 2. MÓDOSÍTÁSOK MENTÉSE
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_displayList.Count == 0) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;
            int sikeres = 0;

            try
            {
                foreach (var item in _displayList)
                {
                    bool success = await _hotcakes.UpdateInventoryAsync(item.InventoryBvin, item.QuantityOnHand);
                    if (success) sikeres++;
                }
                MessageBox.Show($"Sikeres mentés! {sikeres} tétel frissítve.", "Eredmény", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BeallitTablazatot()
        {
            // Oszlopok finomhangolás
            dgvInventory.Columns["InventoryBvin"].Visible = true;
            dgvInventory.Columns["InventoryBvin"].HeaderText = "Készlet ID";
            dgvInventory.Columns["InventoryBvin"].ReadOnly = true;

            dgvInventory.Columns["ProductBvin"].Visible = true;
            dgvInventory.Columns["ProductBvin"].HeaderText = "Termék BVIN";
            dgvInventory.Columns["ProductBvin"].ReadOnly = true;

            dgvInventory.Columns["Sku"].HeaderText = "Cikkszám (SKU)";
            dgvInventory.Columns["Sku"].ReadOnly = true;

            dgvInventory.Columns["ProductName"].HeaderText = "Termék neve";
            dgvInventory.Columns["ProductName"].ReadOnly = true;
            dgvInventory.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvInventory.Columns["Price"].HeaderText = "Ár";
            dgvInventory.Columns["Price"].ReadOnly = true;
            dgvInventory.Columns["Price"].DefaultCellStyle.Format = "N0";

            dgvInventory.Columns["QuantityOnHand"].HeaderText = "Készlet";
            dgvInventory.Columns["QuantityOnHand"].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
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
    }

    // Speciális válasz a készlethez (lista a Contentben)
    public class HotcakesInventoryResponse { public List<InventoryInfo> Content { get; set; } }

    // Speciális válasz a termékekhez (Products lista a Contenten belül)
    public class HotcakesProductResponse { public ProductContent Content { get; set; } }
    public class ProductContent { public List<ProductInfo> Products { get; set; } }

    public class InventoryInfo { public string Bvin { get; set; } public string ProductBvin { get; set; } public int QuantityOnHand { get; set; } }
    public class ProductInfo { public string Bvin { get; set; } public string ProductName { get; set; } public string Sku { get; set; } public decimal SitePrice { get; set; } }

    // --- API SZERVIZ ---

    public class HotcakesService
    {
        private readonly string _apiKey = "1-122fd63f-d8e3-4caa-b6b6-d2c148d5e644";
        private readonly string _baseUrl = "http://20.123.45.147/DesktopModules/Hotcakes/API/rest/v1/";
        private static readonly HttpClient _client = new HttpClient();

        public async Task<List<InventoryInfo>> GetAllInventoryAsync()
        {
            var res = await _client.GetAsync($"{_baseUrl}productinventory?key={_apiKey}");
            if (!res.IsSuccessStatusCode) return new List<InventoryInfo>();

            var json = await res.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HotcakesInventoryResponse>(json);
            return result?.Content ?? new List<InventoryInfo>();
        }

        public async Task<List<ProductInfo>> GetAllProductsAsync()
        {
            var res = await _client.GetAsync($"{_baseUrl}products?key={_apiKey}");
            if (!res.IsSuccessStatusCode) return new List<ProductInfo>();

            var json = await res.Content.ReadAsStringAsync();
            // Itt használjuk a trükkös deszerializációt
            var result = JsonConvert.DeserializeObject<HotcakesProductResponse>(json);
            return result?.Content?.Products ?? new List<ProductInfo>();
        }

        public async Task<bool> UpdateInventoryAsync(string inventoryBvin, int qty)
        {
            var data = new { Bvin = inventoryBvin, QuantityOnHand = qty };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync($"{_baseUrl}productinventory/{inventoryBvin}?key={_apiKey}", content);
            return res.IsSuccessStatusCode;
        }
    }
}