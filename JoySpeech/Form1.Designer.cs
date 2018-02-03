using System.Drawing;

namespace JoySpeech {
    partial class Form1 {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftBox = new System.Windows.Forms.TextBox();
            this.upBox = new System.Windows.Forms.TextBox();
            this.rightBox = new System.Windows.Forms.TextBox();
            this.downBox = new System.Windows.Forms.TextBox();
            this.logoBox = new System.Windows.Forms.TextBox();
            this.selectBox = new System.Windows.Forms.TextBox();
            this.startBox = new System.Windows.Forms.TextBox();
            this.xBox = new System.Windows.Forms.TextBox();
            this.yBox = new System.Windows.Forms.TextBox();
            this.bBox = new System.Windows.Forms.TextBox();
            this.aBox = new System.Windows.Forms.TextBox();
            this.holdBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::JoySpeech.Properties.Resources.controller_1827840_640;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(645, 435);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // leftBox
            // 
            this.leftBox.Location = new System.Drawing.Point(178, 222);
            this.leftBox.Name = "leftBox";
            this.leftBox.ReadOnly = true;
            this.leftBox.Size = new System.Drawing.Size(56, 20);
            this.leftBox.TabIndex = 1;
            this.leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // upBox
            // 
            this.upBox.Location = new System.Drawing.Point(214, 193);
            this.upBox.Name = "upBox";
            this.upBox.Size = new System.Drawing.Size(56, 20);
            this.upBox.TabIndex = 2;
            this.upBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightBox
            // 
            this.rightBox.Location = new System.Drawing.Point(249, 222);
            this.rightBox.Name = "rightBox";
            this.rightBox.ReadOnly = true;
            this.rightBox.Size = new System.Drawing.Size(56, 20);
            this.rightBox.TabIndex = 3;
            this.rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // downBox
            // 
            this.downBox.Location = new System.Drawing.Point(214, 250);
            this.downBox.Name = "downBox";
            this.downBox.ReadOnly = true;
            this.downBox.Size = new System.Drawing.Size(56, 20);
            this.downBox.TabIndex = 4;
            this.downBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(292, 50);
            this.logoBox.Name = "logoBox";
            this.logoBox.ReadOnly = true;
            this.logoBox.Size = new System.Drawing.Size(56, 20);
            this.logoBox.TabIndex = 5;
            this.logoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectBox
            // 
            this.selectBox.Location = new System.Drawing.Point(249, 122);
            this.selectBox.Name = "selectBox";
            this.selectBox.ReadOnly = true;
            this.selectBox.Size = new System.Drawing.Size(56, 20);
            this.selectBox.TabIndex = 6;
            this.selectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startBox
            // 
            this.startBox.Location = new System.Drawing.Point(342, 122);
            this.startBox.Name = "startBox";
            this.startBox.ReadOnly = true;
            this.startBox.Size = new System.Drawing.Size(56, 20);
            this.startBox.TabIndex = 7;
            this.startBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(418, 122);
            this.xBox.Name = "xBox";
            this.xBox.ReadOnly = true;
            this.xBox.Size = new System.Drawing.Size(56, 20);
            this.xBox.TabIndex = 8;
            this.xBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(461, 79);
            this.yBox.Name = "yBox";
            this.yBox.ReadOnly = true;
            this.yBox.Size = new System.Drawing.Size(56, 20);
            this.yBox.TabIndex = 9;
            this.yBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bBox
            // 
            this.bBox.Location = new System.Drawing.Point(506, 122);
            this.bBox.Name = "bBox";
            this.bBox.ReadOnly = true;
            this.bBox.Size = new System.Drawing.Size(56, 20);
            this.bBox.TabIndex = 10;
            this.bBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // aBox
            // 
            this.aBox.Location = new System.Drawing.Point(462, 165);
            this.aBox.Name = "aBox";
            this.aBox.ReadOnly = true;
            this.aBox.Size = new System.Drawing.Size(56, 20);
            this.aBox.TabIndex = 11;
            this.aBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // holdBox
            // 
            this.holdBox.Location = new System.Drawing.Point(178, 346);
            this.holdBox.Name = "holdBox";
            this.holdBox.ReadOnly = true;
            this.holdBox.Size = new System.Drawing.Size(56, 20);
            this.holdBox.TabIndex = 12;
            this.holdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(645, 435);
            this.Controls.Add(this.holdBox);
            this.Controls.Add(this.aBox);
            this.Controls.Add(this.bBox);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.startBox);
            this.Controls.Add(this.selectBox);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.downBox);
            this.Controls.Add(this.rightBox);
            this.Controls.Add(this.upBox);
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox leftBox;
        private System.Windows.Forms.TextBox upBox;
        private System.Windows.Forms.TextBox rightBox;
        private System.Windows.Forms.TextBox downBox;
        private System.Windows.Forms.TextBox logoBox;
        private System.Windows.Forms.TextBox selectBox;
        private System.Windows.Forms.TextBox startBox;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox bBox;
        private System.Windows.Forms.TextBox aBox;
        private System.Windows.Forms.TextBox holdBox;
    }
}

