namespace GameNim
{
    partial class FormMoDau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbChoiNgay = new System.Windows.Forms.PictureBox();
            this.pbChoiTiep = new System.Windows.Forms.PictureBox();
            this.pbLuatChoi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiTiep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLuatChoi)).BeginInit();
            this.SuspendLayout();
            // 
            // pbChoiNgay
            // 
            this.pbChoiNgay.BackColor = System.Drawing.Color.Transparent;
            this.pbChoiNgay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChoiNgay.Location = new System.Drawing.Point(484, 208);
            this.pbChoiNgay.Name = "pbChoiNgay";
            this.pbChoiNgay.Size = new System.Drawing.Size(150, 55);
            this.pbChoiNgay.TabIndex = 2;
            this.pbChoiNgay.TabStop = false;
            this.pbChoiNgay.Click += new System.EventHandler(this.pbChoiNgay_Click);
            // 
            // pbChoiTiep
            // 
            this.pbChoiTiep.BackColor = System.Drawing.Color.Transparent;
            this.pbChoiTiep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChoiTiep.Location = new System.Drawing.Point(484, 292);
            this.pbChoiTiep.Name = "pbChoiTiep";
            this.pbChoiTiep.Size = new System.Drawing.Size(150, 55);
            this.pbChoiTiep.TabIndex = 3;
            this.pbChoiTiep.TabStop = false;
            this.pbChoiTiep.Click += new System.EventHandler(this.pbChoiTiep_Click);
            // 
            // pbLuatChoi
            // 
            this.pbLuatChoi.BackColor = System.Drawing.Color.Transparent;
            this.pbLuatChoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLuatChoi.Location = new System.Drawing.Point(484, 362);
            this.pbLuatChoi.Name = "pbLuatChoi";
            this.pbLuatChoi.Size = new System.Drawing.Size(150, 55);
            this.pbLuatChoi.TabIndex = 4;
            this.pbLuatChoi.TabStop = false;
            this.pbLuatChoi.Click += new System.EventHandler(this.pbLuatChoi_Click);
            // 
            // FormMoDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameNim.Properties.Resources.nen_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1129, 639);
            this.Controls.Add(this.pbLuatChoi);
            this.Controls.Add(this.pbChoiTiep);
            this.Controls.Add(this.pbChoiNgay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMoDau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMoDau";
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoiTiep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLuatChoi)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pbChoiNgay;
        private System.Windows.Forms.PictureBox pbChoiTiep;
        private System.Windows.Forms.PictureBox pbLuatChoi;
    }
}