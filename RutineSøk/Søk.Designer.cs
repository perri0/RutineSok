namespace RutineSøk
{
    partial class Window
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
            this.PakkseddelSøkButton = new System.Windows.Forms.Button();
            this.PakkseddelLabel = new System.Windows.Forms.Label();
            this.WebrapportButton = new System.Windows.Forms.Button();
            this.ShoppaSøkButton = new System.Windows.Forms.Button();
            this.ShoppaLabel = new System.Windows.Forms.Label();
            this.EpostButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PakkseddelSøkButton
            // 
            this.PakkseddelSøkButton.Location = new System.Drawing.Point(12, 12);
            this.PakkseddelSøkButton.Name = "PakkseddelSøkButton";
            this.PakkseddelSøkButton.Size = new System.Drawing.Size(129, 23);
            this.PakkseddelSøkButton.TabIndex = 1;
            this.PakkseddelSøkButton.Text = "PakkseddelSøk";
            this.PakkseddelSøkButton.UseVisualStyleBackColor = true;
            this.PakkseddelSøkButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // PakkseddelLabel
            // 
            this.PakkseddelLabel.AutoSize = true;
            this.PakkseddelLabel.Location = new System.Drawing.Point(24, 49);
            this.PakkseddelLabel.Name = "PakkseddelLabel";
            this.PakkseddelLabel.Size = new System.Drawing.Size(107, 17);
            this.PakkseddelLabel.TabIndex = 2;
            this.PakkseddelLabel.Text = "Søk ikke Startet";
            // 
            // WebrapportButton
            // 
            this.WebrapportButton.Location = new System.Drawing.Point(147, 12);
            this.WebrapportButton.Name = "WebrapportButton";
            this.WebrapportButton.Size = new System.Drawing.Size(129, 23);
            this.WebrapportButton.TabIndex = 3;
            this.WebrapportButton.Text = "Webrapport";
            this.WebrapportButton.UseVisualStyleBackColor = true;
            this.WebrapportButton.Click += new System.EventHandler(this.WebrapportButton_Click);
            // 
            // ShoppaSøkButton
            // 
            this.ShoppaSøkButton.Location = new System.Drawing.Point(282, 12);
            this.ShoppaSøkButton.Name = "ShoppaSøkButton";
            this.ShoppaSøkButton.Size = new System.Drawing.Size(129, 23);
            this.ShoppaSøkButton.TabIndex = 4;
            this.ShoppaSøkButton.Text = "ShoppaSøk";
            this.ShoppaSøkButton.UseVisualStyleBackColor = true;
            this.ShoppaSøkButton.Click += new System.EventHandler(this.ShoppaButton_Click);
            // 
            // ShoppaLabel
            // 
            this.ShoppaLabel.AutoSize = true;
            this.ShoppaLabel.Location = new System.Drawing.Point(295, 49);
            this.ShoppaLabel.Name = "ShoppaLabel";
            this.ShoppaLabel.Size = new System.Drawing.Size(107, 17);
            this.ShoppaLabel.TabIndex = 5;
            this.ShoppaLabel.Text = "Søk ikke Startet";
            // 
            // EpostButton
            // 
            this.EpostButton.Location = new System.Drawing.Point(12, 87);
            this.EpostButton.Name = "EpostButton";
            this.EpostButton.Size = new System.Drawing.Size(129, 23);
            this.EpostButton.TabIndex = 6;
            this.EpostButton.Text = "Epost";
            this.EpostButton.UseVisualStyleBackColor = true;
            this.EpostButton.Click += new System.EventHandler(this.EpostButton_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 122);
            this.Controls.Add(this.EpostButton);
            this.Controls.Add(this.ShoppaLabel);
            this.Controls.Add(this.ShoppaSøkButton);
            this.Controls.Add(this.WebrapportButton);
            this.Controls.Add(this.PakkseddelLabel);
            this.Controls.Add(this.PakkseddelSøkButton);
            this.Name = "Window";
            this.Load += new System.EventHandler(this.Window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PakkseddelSøkButton;
        private System.Windows.Forms.Label PakkseddelLabel;
        private System.Windows.Forms.Button WebrapportButton;
        private System.Windows.Forms.Button ShoppaSøkButton;
        private System.Windows.Forms.Label ShoppaLabel;
        private System.Windows.Forms.Button EpostButton;
    }
}

