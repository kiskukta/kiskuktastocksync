namespace kliensappkeszlet
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnSave = new Button();
            dgvInventory = new DataGridView();
            btnApplyChange = new Button();
            txtQuantity = new TextBox();
            lblSelectedProduct = new Label();
            Készletek = new TabControl();
            tabPage1 = new TabPage();
            numPrice = new NumericUpDown();
            label9 = new Label();
            label6 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            numQtyChange = new NumericUpDown();
            btnRemove = new Button();
            btnAdd = new Button();
            label8 = new Label();
            dgvMassUpdate = new DataGridView();
            btnSaveMassChanges = new Button();
            numPriceChange = new NumericUpDown();
            btnMassIncrease = new Button();
            label5 = new Label();
            btnMassDecrease = new Button();
            label3 = new Label();
            tabPage4 = new TabPage();
            pnlStatCard = new Panel();
            lblTopProducts = new Label();
            lblStatTitle = new Label();
            label4 = new Label();
            listBox1 = new ListBox();
            txtSearch = new TextBox();
            label2 = new Label();
            btnPrev = new Button();
            btnNext = new Button();
            lblPageInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            Készletek.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQtyChange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMassUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPriceChange).BeginInit();
            tabPage4.SuspendLayout();
            pnlStatCard.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(487, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(89, 23);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Betöltés";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(18, 199);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(240, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Módosítás mentése";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(5, 32);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.Size = new Size(571, 370);
            dgvInventory.TabIndex = 2;
            dgvInventory.SelectionChanged += dgvInventory_SelectionChanged;
            // 
            // btnApplyChange
            // 
            btnApplyChange.Location = new Point(298, 143);
            btnApplyChange.Name = "btnApplyChange";
            btnApplyChange.Size = new Size(101, 23);
            btnApplyChange.TabIndex = 3;
            btnApplyChange.Text = "Módosítás";
            btnApplyChange.UseVisualStyleBackColor = true;
            btnApplyChange.Click += btnApplyChange_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(16, 143);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(126, 23);
            txtQuantity.TabIndex = 4;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 11F);
            lblSelectedProduct.Location = new Point(18, 79);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(136, 20);
            lblSelectedProduct.TabIndex = 5;
            lblSelectedProduct.Text = "Kiválasztott termék";
            // 
            // Készletek
            // 
            Készletek.Controls.Add(tabPage1);
            Készletek.Controls.Add(tabPage2);
            Készletek.Controls.Add(tabPage4);
            Készletek.Font = new Font("Segoe UI Historic", 9F);
            Készletek.ImeMode = ImeMode.Katakana;
            Készletek.Location = new Point(591, 5);
            Készletek.Name = "Készletek";
            Készletek.SelectedIndex = 0;
            Készletek.Size = new Size(705, 397);
            Készletek.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(numPrice);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtQuantity);
            tabPage1.Controls.Add(btnApplyChange);
            tabPage1.Controls.Add(btnSave);
            tabPage1.Controls.Add(lblSelectedProduct);
            tabPage1.ForeColor = SystemColors.WindowText;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(697, 588);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Egyedi készlet/ár";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(158, 144);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(117, 23);
            numPrice.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Historic", 10F);
            label9.Location = new Point(158, 121);
            label9.Name = "label9";
            label9.Size = new Size(26, 19);
            label9.TabIndex = 10;
            label9.Text = "Ár:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Historic", 10F);
            label6.Location = new Point(14, 121);
            label6.Name = "label6";
            label6.Size = new Size(79, 19);
            label6.TabIndex = 7;
            label6.Text = "Mennyiség:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(18, 41);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 6;
            label1.Text = "Módosítás";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(numQtyChange);
            tabPage2.Controls.Add(btnRemove);
            tabPage2.Controls.Add(btnAdd);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(dgvMassUpdate);
            tabPage2.Controls.Add(btnSaveMassChanges);
            tabPage2.Controls.Add(numPriceChange);
            tabPage2.Controls.Add(btnMassIncrease);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(btnMassDecrease);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(697, 369);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Csoportos készlet/ár";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // numQtyChange
            // 
            numQtyChange.Location = new Point(565, 133);
            numQtyChange.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQtyChange.Name = "numQtyChange";
            numQtyChange.Size = new Size(125, 23);
            numQtyChange.TabIndex = 13;
            // 
            // btnRemove
            // 
            btnRemove.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemove.Location = new Point(389, 36);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(27, 305);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "<";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(9, 36);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(27, 305);
            btnAdd.TabIndex = 6;
            btnAdd.Text = ">";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Historic", 10F);
            label8.Location = new Point(431, 101);
            label8.Name = "label8";
            label8.Size = new Size(102, 19);
            label8.TabIndex = 12;
            label8.Text = "Árváltozás (%) :";
            // 
            // dgvMassUpdate
            // 
            dgvMassUpdate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMassUpdate.Location = new Point(33, 36);
            dgvMassUpdate.Name = "dgvMassUpdate";
            dgvMassUpdate.Size = new Size(359, 305);
            dgvMassUpdate.TabIndex = 5;
            // 
            // btnSaveMassChanges
            // 
            btnSaveMassChanges.Location = new Point(431, 231);
            btnSaveMassChanges.Name = "btnSaveMassChanges";
            btnSaveMassChanges.Size = new Size(259, 46);
            btnSaveMassChanges.TabIndex = 4;
            btnSaveMassChanges.Text = "Módosítás mentése";
            btnSaveMassChanges.UseVisualStyleBackColor = true;
            btnSaveMassChanges.Click += btnSaveMassChanges_Click;
            // 
            // numPriceChange
            // 
            numPriceChange.Location = new Point(565, 104);
            numPriceChange.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPriceChange.Name = "numPriceChange";
            numPriceChange.Size = new Size(125, 23);
            numPriceChange.TabIndex = 11;
            // 
            // btnMassIncrease
            // 
            btnMassIncrease.Location = new Point(431, 170);
            btnMassIncrease.Name = "btnMassIncrease";
            btnMassIncrease.Size = new Size(121, 37);
            btnMassIncrease.TabIndex = 3;
            btnMassIncrease.Text = "Növekedés (+)";
            btnMassIncrease.UseVisualStyleBackColor = true;
            btnMassIncrease.Click += btnMassIncrease_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Historic", 10F);
            label5.Location = new Point(431, 133);
            label5.Name = "label5";
            label5.Size = new Size(128, 19);
            label5.TabIndex = 10;
            label5.Text = "Mennyiségváltozás:";
            // 
            // btnMassDecrease
            // 
            btnMassDecrease.Location = new Point(565, 170);
            btnMassDecrease.Name = "btnMassDecrease";
            btnMassDecrease.Size = new Size(121, 37);
            btnMassDecrease.TabIndex = 2;
            btnMassDecrease.Text = " Csökkenés (-)";
            btnMassDecrease.UseVisualStyleBackColor = true;
            btnMassDecrease.Click += btnMassDecrease_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.Indigo;
            label3.Location = new Point(431, 55);
            label3.Name = "label3";
            label3.Size = new Size(200, 25);
            label3.TabIndex = 0;
            label3.Text = "Csoportos módosítás";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(pnlStatCard);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(697, 588);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Statisztika";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // pnlStatCard
            // 
            pnlStatCard.BackColor = Color.AntiqueWhite;
            pnlStatCard.Controls.Add(lblTopProducts);
            pnlStatCard.Controls.Add(lblStatTitle);
            pnlStatCard.Location = new Point(33, 87);
            pnlStatCard.Name = "pnlStatCard";
            pnlStatCard.Size = new Size(624, 325);
            pnlStatCard.TabIndex = 0;
            // 
            // lblTopProducts
            // 
            lblTopProducts.AutoSize = true;
            lblTopProducts.Location = new Point(13, 47);
            lblTopProducts.Name = "lblTopProducts";
            lblTopProducts.Size = new Size(44, 15);
            lblTopProducts.TabIndex = 1;
            lblTopProducts.Text = "label10";
            // 
            // lblStatTitle
            // 
            lblStatTitle.AutoSize = true;
            lblStatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblStatTitle.Location = new Point(5, 13);
            lblStatTitle.Name = "lblStatTitle";
            lblStatTitle.Size = new Size(331, 21);
            lblStatTitle.TabIndex = 0;
            lblStatTitle.Text = "Top 5 Leggyorsabban Fogyó Termék (Heti)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(591, 402);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 9;
            label4.Text = "Napló";
            label4.Click += label4_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(591, 425);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(568, 169);
            listBox1.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(117, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(142, 23);
            txtSearch.TabIndex = 7;
            txtSearch.Text = "🔎︎ Keresés...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.Indigo;
            label2.Location = new Point(5, 1);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 8;
            label2.Text = "Terméklista";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(103, 400);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(79, 28);
            btnPrev.TabIndex = 9;
            btnPrev.Text = "Előző";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(178, 400);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(79, 28);
            btnNext.TabIndex = 10;
            btnNext.Text = "Következő";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblPageInfo.ForeColor = Color.Indigo;
            lblPageInfo.Location = new Point(7, 405);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(57, 17);
            lblPageInfo.TabIndex = 11;
            lblPageInfo.Text = "Lapozás";
            lblPageInfo.Click += lblPageInfo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 596);
            Controls.Add(lblPageInfo);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtSearch);
            Controls.Add(listBox1);
            Controls.Add(Készletek);
            Controls.Add(dgvInventory);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            Készletek.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQtyChange).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMassUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPriceChange).EndInit();
            tabPage4.ResumeLayout(false);
            pnlStatCard.ResumeLayout(false);
            pnlStatCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private Button btnSave;
        private DataGridView dgvInventory;
        private Button btnApplyChange;
        private TextBox txtQuantity;
        private Label lblSelectedProduct;
        private TabControl Készletek;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private TextBox txtSearch;
        private Label label2;
        private Label label3;
        private Button btnSaveMassChanges;
        private Button btnMassIncrease;
        private Button btnMassDecrease;
        private ListBox listBox1;
        private Button btnRemove;
        private Button btnAdd;
        private DataGridView dgvMassUpdate;
        private Label label6;
        private Label label5;
        private Label label4;
        private TabPage tabPage4;
        private NumericUpDown numPriceChange;
        private NumericUpDown numQtyChange;
        private Label label8;
        private NumericUpDown numPrice;
        private Label label9;
        private Panel pnlStatCard;
        private Label lblStatTitle;
        private Label lblTopProducts;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPageInfo;
    }
}
