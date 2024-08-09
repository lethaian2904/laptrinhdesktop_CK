namespace QLThueNha1
{
    partial class frmMain
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
            this.btnNha = new System.Windows.Forms.Button();
            this.btnQLHopDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNha
            // 
            this.btnNha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNha.Location = new System.Drawing.Point(130, 76);
            this.btnNha.Name = "btnNha";
            this.btnNha.Size = new System.Drawing.Size(215, 196);
            this.btnNha.TabIndex = 0;
            this.btnNha.Text = "Nhà";
            this.btnNha.UseVisualStyleBackColor = true;
            this.btnNha.Click += new System.EventHandler(this.btnNha_Click);
            // 
            // btnQLHopDong
            // 
            this.btnQLHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLHopDong.Location = new System.Drawing.Point(503, 76);
            this.btnQLHopDong.Name = "btnQLHopDong";
            this.btnQLHopDong.Size = new System.Drawing.Size(201, 196);
            this.btnQLHopDong.TabIndex = 1;
            this.btnQLHopDong.Text = "Quản Lý Hợp Đồng";
            this.btnQLHopDong.UseVisualStyleBackColor = true;
            this.btnQLHopDong.Click += new System.EventHandler(this.btnQLHopDong_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQLHopDong);
            this.Controls.Add(this.btnNha);
            this.Name = "frmMain";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNha;
        private System.Windows.Forms.Button btnQLHopDong;
    }
}