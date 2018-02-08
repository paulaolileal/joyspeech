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
            this.hold_MoveBox = new System.Windows.Forms.TextBox();
            this.stopBox = new System.Windows.Forms.TextBox();
            this.stick_upBox = new System.Windows.Forms.TextBox();
            this.stick_rightBox = new System.Windows.Forms.TextBox();
            this.stick_leftBox = new System.Windows.Forms.TextBox();
            this.stick_downBox = new System.Windows.Forms.TextBox();
            this.camera_upBox = new System.Windows.Forms.TextBox();
            this.camera_rightBox = new System.Windows.Forms.TextBox();
            this.camera_leftBox = new System.Windows.Forms.TextBox();
            this.camera_downBox = new System.Windows.Forms.TextBox();
            this.cameraBox = new System.Windows.Forms.TextBox();
            this.stickBox = new System.Windows.Forms.TextBox();
            this.rtBox = new System.Windows.Forms.TextBox();
            this.rbBox = new System.Windows.Forms.TextBox();
            this.ltBox = new System.Windows.Forms.TextBox();
            this.lbBox = new System.Windows.Forms.TextBox();
            this.hold_ActionBox = new System.Windows.Forms.TextBox();
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
            // hold_MoveBox
            // 
            this.hold_MoveBox.Location = new System.Drawing.Point(252, 320);
            this.hold_MoveBox.Name = "hold_MoveBox";
            this.hold_MoveBox.ReadOnly = true;
            this.hold_MoveBox.Size = new System.Drawing.Size(56, 20);
            this.hold_MoveBox.TabIndex = 12;
            this.hold_MoveBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stopBox
            // 
            this.stopBox.Location = new System.Drawing.Point(323, 320);
            this.stopBox.Name = "stopBox";
            this.stopBox.ReadOnly = true;
            this.stopBox.Size = new System.Drawing.Size(56, 20);
            this.stopBox.TabIndex = 13;
            this.stopBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_upBox
            // 
            this.stick_upBox.Location = new System.Drawing.Point(135, 96);
            this.stick_upBox.Name = "stick_upBox";
            this.stick_upBox.Size = new System.Drawing.Size(56, 20);
            this.stick_upBox.TabIndex = 14;
            this.stick_upBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_rightBox
            // 
            this.stick_rightBox.Location = new System.Drawing.Point(166, 122);
            this.stick_rightBox.Name = "stick_rightBox";
            this.stick_rightBox.Size = new System.Drawing.Size(56, 20);
            this.stick_rightBox.TabIndex = 15;
            this.stick_rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_leftBox
            // 
            this.stick_leftBox.Location = new System.Drawing.Point(104, 122);
            this.stick_leftBox.Name = "stick_leftBox";
            this.stick_leftBox.Size = new System.Drawing.Size(56, 20);
            this.stick_leftBox.TabIndex = 16;
            this.stick_leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_downBox
            // 
            this.stick_downBox.Location = new System.Drawing.Point(135, 149);
            this.stick_downBox.Name = "stick_downBox";
            this.stick_downBox.Size = new System.Drawing.Size(56, 20);
            this.stick_downBox.TabIndex = 17;
            this.stick_downBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_upBox
            // 
            this.camera_upBox.Location = new System.Drawing.Point(379, 193);
            this.camera_upBox.Name = "camera_upBox";
            this.camera_upBox.Size = new System.Drawing.Size(56, 20);
            this.camera_upBox.TabIndex = 18;
            this.camera_upBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_rightBox
            // 
            this.camera_rightBox.Location = new System.Drawing.Point(409, 222);
            this.camera_rightBox.Name = "camera_rightBox";
            this.camera_rightBox.Size = new System.Drawing.Size(56, 20);
            this.camera_rightBox.TabIndex = 19;
            this.camera_rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_leftBox
            // 
            this.camera_leftBox.Location = new System.Drawing.Point(346, 222);
            this.camera_leftBox.Name = "camera_leftBox";
            this.camera_leftBox.Size = new System.Drawing.Size(56, 20);
            this.camera_leftBox.TabIndex = 20;
            this.camera_leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_downBox
            // 
            this.camera_downBox.Location = new System.Drawing.Point(380, 250);
            this.camera_downBox.Name = "camera_downBox";
            this.camera_downBox.Size = new System.Drawing.Size(56, 20);
            this.camera_downBox.TabIndex = 21;
            this.camera_downBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cameraBox
            // 
            this.cameraBox.Location = new System.Drawing.Point(395, 320);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.ReadOnly = true;
            this.cameraBox.Size = new System.Drawing.Size(56, 20);
            this.cameraBox.TabIndex = 22;
            this.cameraBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stickBox
            // 
            this.stickBox.Location = new System.Drawing.Point(181, 320);
            this.stickBox.Name = "stickBox";
            this.stickBox.ReadOnly = true;
            this.stickBox.Size = new System.Drawing.Size(56, 20);
            this.stickBox.TabIndex = 23;
            this.stickBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtBox
            // 
            this.rtBox.Location = new System.Drawing.Point(483, 31);
            this.rtBox.Name = "rtBox";
            this.rtBox.ReadOnly = true;
            this.rtBox.Size = new System.Drawing.Size(56, 20);
            this.rtBox.TabIndex = 24;
            this.rtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbBox
            // 
            this.rbBox.Location = new System.Drawing.Point(449, 9);
            this.rbBox.Name = "rbBox";
            this.rbBox.ReadOnly = true;
            this.rbBox.Size = new System.Drawing.Size(56, 20);
            this.rbBox.TabIndex = 25;
            this.rbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ltBox
            // 
            this.ltBox.Location = new System.Drawing.Point(104, 35);
            this.ltBox.Name = "ltBox";
            this.ltBox.ReadOnly = true;
            this.ltBox.Size = new System.Drawing.Size(56, 20);
            this.ltBox.TabIndex = 26;
            this.ltBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbBox
            // 
            this.lbBox.Location = new System.Drawing.Point(135, 12);
            this.lbBox.Name = "lbBox";
            this.lbBox.ReadOnly = true;
            this.lbBox.Size = new System.Drawing.Size(56, 20);
            this.lbBox.TabIndex = 27;
            this.lbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hold_ActionBox
            // 
            this.hold_ActionBox.Location = new System.Drawing.Point(395, 357);
            this.hold_ActionBox.Name = "hold_ActionBox";
            this.hold_ActionBox.ReadOnly = true;
            this.hold_ActionBox.Size = new System.Drawing.Size(56, 20);
            this.hold_ActionBox.TabIndex = 28;
            this.hold_ActionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(645, 435);
            this.Controls.Add(this.hold_ActionBox);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.ltBox);
            this.Controls.Add(this.rbBox);
            this.Controls.Add(this.rtBox);
            this.Controls.Add(this.stickBox);
            this.Controls.Add(this.cameraBox);
            this.Controls.Add(this.camera_downBox);
            this.Controls.Add(this.camera_leftBox);
            this.Controls.Add(this.camera_rightBox);
            this.Controls.Add(this.camera_upBox);
            this.Controls.Add(this.stick_downBox);
            this.Controls.Add(this.stick_leftBox);
            this.Controls.Add(this.stick_rightBox);
            this.Controls.Add(this.stick_upBox);
            this.Controls.Add(this.stopBox);
            this.Controls.Add(this.hold_MoveBox);
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
        private System.Windows.Forms.TextBox hold_MoveBox;
        private System.Windows.Forms.TextBox stopBox;
        private System.Windows.Forms.TextBox stick_upBox;
        private System.Windows.Forms.TextBox stick_rightBox;
        private System.Windows.Forms.TextBox stick_leftBox;
        private System.Windows.Forms.TextBox stick_downBox;
        private System.Windows.Forms.TextBox camera_upBox;
        private System.Windows.Forms.TextBox camera_rightBox;
        private System.Windows.Forms.TextBox camera_leftBox;
        private System.Windows.Forms.TextBox camera_downBox;
        private System.Windows.Forms.TextBox cameraBox;
        private System.Windows.Forms.TextBox stickBox;
        private System.Windows.Forms.TextBox rtBox;
        private System.Windows.Forms.TextBox rbBox;
        private System.Windows.Forms.TextBox ltBox;
        private System.Windows.Forms.TextBox lbBox;
        private System.Windows.Forms.TextBox hold_ActionBox;
    }
}

