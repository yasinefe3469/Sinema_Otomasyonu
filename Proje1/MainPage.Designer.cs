namespace Proje1
{
    partial class MainPage
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
            this.lblDate = new System.Windows.Forms.Label();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDate.Location = new System.Drawing.Point(311, 25);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 29);
            this.lblDate.TabIndex = 0;
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(836, 12);
            this.btnnext.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(120, 29);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = "İleri";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnback
            // 
            this.btnback.Enabled = false;
            this.btnback.Location = new System.Drawing.Point(712, 12);
            this.btnback.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(120, 29);
            this.btnback.TabIndex = 3;
            this.btnback.Text = "Geri";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1155, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 152);
            this.button1.TabIndex = 4;
            this.button1.Text = "Biletler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1388, 666);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.lblDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.IndianRed;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button button1;
    }
}