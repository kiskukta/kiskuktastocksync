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
            label7 = new Label();
            listBox2 = new ListBox();
            label6 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            label5 = new Label();
            label4 = new Label();
            listBox1 = new ListBox();
            btnRemove = new Button();
            btnAdd = new Button();
            dgvMassUpdate = new DataGridView();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            tabPage4 = new TabPage();
            txtSearch = new TextBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label8 = new Label();
            numericUpDown2 = new NumericUpDown();
            label9 = new Label();
            numericUpDown3 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            Készletek.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMassUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(456, 77);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(89, 37);
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
            dgvInventory.Location = new Point(12, 120);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.Size = new Size(533, 531);
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
            lblSelectedProduct.Size = new Size(50, 20);
            lblSelectedProduct.TabIndex = 5;
            lblSelectedProduct.Text = "label1";
            // 
            // Készletek
            // 
            Készletek.Controls.Add(tabPage1);
            Készletek.Controls.Add(tabPage2);
            Készletek.Controls.Add(tabPage4);
            Készletek.Font = new Font("Segoe UI Historic", 9F);
            Készletek.Location = new Point(551, 120);
            Készletek.Name = "Készletek";
            Készletek.SelectedIndex = 0;
            Készletek.Size = new Size(759, 531);
            Készletek.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(numericUpDown3);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(listBox2);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtQuantity);
            tabPage1.Controls.Add(btnApplyChange);
            tabPage1.Controls.Add(btnSave);
            tabPage1.Controls.Add(lblSelectedProduct);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(751, 503);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Egyedi készlet/ár";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Historic", 12F);
            label7.Location = new Point(16, 285);
            label7.Name = "label7";
            label7.Size = new Size(52, 21);
            label7.TabIndex = 9;
            label7.Text = "Napló";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(18, 309);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(319, 169);
            listBox2.TabIndex = 8;
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
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(18, 41);
            label1.Name = "label1";
            label1.Size = new Size(157, 25);
            label1.TabIndex = 6;
            label1.Text = "Készletmódosítás";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(numericUpDown2);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(numericUpDown1);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Controls.Add(btnRemove);
            tabPage2.Controls.Add(btnAdd);
            tabPage2.Controls.Add(dgvMassUpdate);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(751, 503);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Csoportos készlet/ár";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Historic", 10F);
            label5.Location = new Point(13, 99);
            label5.Name = "label5";
            label5.Size = new Size(128, 19);
            label5.TabIndex = 10;
            label5.Text = "Mennyiségváltozás:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 11F);
            label4.Location = new Point(13, 280);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 9;
            label4.Text = "Napló";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(13, 303);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(319, 169);
            listBox1.TabIndex = 8;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(605, 353);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 31);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "töröl";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(373, 353);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 31);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "hozzáad";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvMassUpdate
            // 
            dgvMassUpdate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMassUpdate.Location = new Point(373, 42);
            dgvMassUpdate.Name = "dgvMassUpdate";
            dgvMassUpdate.Size = new Size(307, 305);
            dgvMassUpdate.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(13, 197);
            button3.Name = "button3";
            button3.Size = new Size(259, 46);
            button3.TabIndex = 4;
            button3.Text = "Módosítás mentése";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(13, 136);
            button2.Name = "button2";
            button2.Size = new Size(121, 37);
            button2.TabIndex = 3;
            button2.Text = "Növekedés (+)";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(151, 136);
            button1.Name = "button1";
            button1.Size = new Size(121, 37);
            button1.TabIndex = 2;
            button1.Text = " Csökkenés (-)";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 14F);
            label3.Location = new Point(13, 22);
            label3.Name = "label3";
            label3.Size = new Size(245, 25);
            label3.TabIndex = 0;
            label3.Text = "Csoportos készletmódosítás";
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(751, 503);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Statisztika";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 91);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(142, 23);
            txtSearch.TabIndex = 7;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 8;
            label2.Text = "Keresés";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(147, 70);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(125, 23);
            numericUpDown1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Historic", 10F);
            label8.Location = new Point(13, 67);
            label8.Name = "label8";
            label8.Size = new Size(75, 19);
            label8.TabIndex = 12;
            label8.Text = "Árváltozás:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(147, 99);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(125, 23);
            numericUpDown2.TabIndex = 13;
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
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(158, 144);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(117, 23);
            numericUpDown3.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 690);
            Controls.Add(label2);
            Controls.Add(txtSearch);
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
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMassUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
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
        private Button button3;
        private Button button2;
        private Button button1;
        private ListBox listBox1;
        private Button btnRemove;
        private Button btnAdd;
        private DataGridView dgvMassUpdate;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label7;
        private ListBox listBox2;
        private TabPage tabPage4;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label8;
        private NumericUpDown numericUpDown3;
        private Label label9;
    }
}
