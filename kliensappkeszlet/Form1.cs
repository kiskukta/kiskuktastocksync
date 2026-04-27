using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace kliensappkeszlet
{
    public partial class Form1 : Form
    {
        // Kapcsolat a szerviz osztállyal
        private readonly HotcakesService _hotcakes = new HotcakesService();

        public Form1()
        {
            InitializeComponent();
        }

        // --- GOMB ESEMÉNYEK ---

        // 1. ADATOK BETÖLTÉSE
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            try
            {
                var inventory = await _hotcakes.GetAllInventoryAsync();

                if (inventory != null && inventory.Count > 0)
                {
                    dgvInventory.DataSource = inventory;
                    BeallitTablazatot();
                }
                else
                {
                    MessageBox.Show("A kapcsolat sikerült, de nem érkezett adat. Ellenõrizd a webshopban, hogy be van-e kapcsolva a készletkezelés!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}");
            }
            btnLoad.Enabled = true;
        }

        // 2. MÓDOSÍTÁSOK MENTÉSE
        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            int sikeres = 0;
            int hibas = 0;

            try
            {
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    if (row.DataBoundItem is InventoryInfo item)
                    {
                        bool success = await _hotcakes.UpdateInventoryAsync(item);
                        if (success) sikeres++; else hibas++;
                    }
                }
                MessageBox.Show($"Szinkronizálás kész!\nSikeres frissítés: {sikeres}\nHibás: {hibas}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a mentés során: {ex.Message}");
            }
            btnSave.Enabled = true;
        }

        private void BeallitTablazatot()
        {
            if (dgvInventory.Columns["Bvin"] != null) dgvInventory.Columns["Bvin"].ReadOnly = true;
            if (dgvInventory.Columns["ProductBvin"] != null) dgvInventory.Columns["ProductBvin"].Visible = false;
            if (dgvInventory.Columns["QuantityOnHand"] != null)
                dgvInventory.Columns["QuantityOnHand"].HeaderText = "Készlet (Darab)";
        }
    }

    // --- ADATMODELLEK (A JSON feldolgozáshoz) ---

    // Ez az osztály kezeli a "Content" nevû burkolót, amit a képernyõfotón láttunk
    public class HotcakesResponse<T>
    {
        public List<T> Content { get; set; }
    }

    public class InventoryInfo
    {
        public string Bvin { get; set; }
        public string ProductBvin { get; set; }
        public int QuantityOnHand { get; set; }
    }

    // --- API SZERVIZ OSZTÁLY ---

    public class HotcakesService
    {
        private readonly string _apiKey = "1-122fd63f-d8e3-4caa-b6b6-d2c148d5e644";
        private readonly string _baseUrl = "http://20.123.45.147/DesktopModules/Hotcakes/API/rest/v1/";
        private readonly HttpClient _client = new HttpClient();

        // Összes készlet lekérése
        public async Task<List<InventoryInfo>> GetAllInventoryAsync()
        {
            try
            {
                // Itt használjuk a ?key= formátumot, ami a böngészõben is ment
                string url = $"{_baseUrl}productinventory?key={_apiKey}";

                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // A HotcakesResponse-on keresztül olvassuk be a Content mezõt
                    var result = JsonConvert.DeserializeObject<HotcakesResponse<InventoryInfo>>(json);
                    return result?.Content ?? new List<InventoryInfo>();
                }
            }
            catch { }
            return new List<InventoryInfo>();
        }

        // Egyedi készlet frissítése
        public async Task<bool> UpdateInventoryAsync(InventoryInfo info)
        {
            try
            {
                var json = JsonConvert.SerializeObject(info);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Frissítésnél a BVIN kód után tesszük a kulcsot
                string url = $"{_baseUrl}productinventory/{info.Bvin}?key={_apiKey}";

                var response = await _client.PostAsync(url, content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}