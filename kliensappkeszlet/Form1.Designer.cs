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
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1002, 127);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(112, 50);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "button1";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1002, 203);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "button2";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(12, 23);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.Size = new Size(907, 628);
            dgvInventory.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 690);
            Controls.Add(dgvInventory);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private Button btnSave;
        private DataGridView dgvInventory;
    }
}
