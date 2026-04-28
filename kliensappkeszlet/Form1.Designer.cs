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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(423, 77);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(89, 37);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Betöltés";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(62, 173);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(149, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Mentés";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(12, 120);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.Size = new Size(500, 531);
            dgvInventory.TabIndex = 2;
            dgvInventory.SelectionChanged += dgvInventory_SelectionChanged;
            // 
            // btnApplyChange
            // 
            btnApplyChange.Location = new Point(145, 122);
            btnApplyChange.Name = "btnApplyChange";
            btnApplyChange.Size = new Size(101, 23);
            btnApplyChange.TabIndex = 3;
            btnApplyChange.Text = "Módosítás";
            btnApplyChange.UseVisualStyleBackColor = true;
            btnApplyChange.Click += btnApplyChange_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(4, 122);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(126, 23);
            txtQuantity.TabIndex = 4;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 11F);
            lblSelectedProduct.Location = new Point(6, 89);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(50, 20);
            lblSelectedProduct.TabIndex = 5;
            lblSelectedProduct.Text = "label1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(551, 120);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(759, 531);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
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
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(751, 503);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(6, 17);
            label1.Name = "label1";
            label1.Size = new Size(157, 25);
            label1.TabIndex = 6;
            label1.Text = "Készletmódosítás";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 690);
            Controls.Add(tabControl1);
            Controls.Add(dgvInventory);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private Button btnSave;
        private DataGridView dgvInventory;
        private Button btnApplyChange;
        private TextBox txtQuantity;
        private Label lblSelectedProduct;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
    }
}
