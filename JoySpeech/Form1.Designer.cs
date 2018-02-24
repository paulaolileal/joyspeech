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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.rbBox = new System.Windows.Forms.TextBox();
            this.lbBox = new System.Windows.Forms.TextBox();
            this.triggerBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.recognizeBox = new System.Windows.Forms.TextBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftBox
            // 
            this.leftBox.Location = new System.Drawing.Point(208, 242);
            this.leftBox.Name = "leftBox";
            this.leftBox.ReadOnly = true;
            this.leftBox.Size = new System.Drawing.Size(56, 20);
            this.leftBox.TabIndex = 1;
            this.leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // upBox
            // 
            this.upBox.Location = new System.Drawing.Point(236, 216);
            this.upBox.Name = "upBox";
            this.upBox.Size = new System.Drawing.Size(56, 20);
            this.upBox.TabIndex = 2;
            this.upBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightBox
            // 
            this.rightBox.Location = new System.Drawing.Point(267, 242);
            this.rightBox.Name = "rightBox";
            this.rightBox.ReadOnly = true;
            this.rightBox.Size = new System.Drawing.Size(56, 20);
            this.rightBox.TabIndex = 3;
            this.rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // downBox
            // 
            this.downBox.Location = new System.Drawing.Point(236, 270);
            this.downBox.Name = "downBox";
            this.downBox.ReadOnly = true;
            this.downBox.Size = new System.Drawing.Size(56, 20);
            this.downBox.TabIndex = 4;
            this.downBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(314, 84);
            this.logoBox.Name = "logoBox";
            this.logoBox.ReadOnly = true;
            this.logoBox.Size = new System.Drawing.Size(56, 20);
            this.logoBox.TabIndex = 5;
            this.logoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectBox
            // 
            this.selectBox.Location = new System.Drawing.Point(273, 142);
            this.selectBox.Name = "selectBox";
            this.selectBox.ReadOnly = true;
            this.selectBox.Size = new System.Drawing.Size(56, 20);
            this.selectBox.TabIndex = 6;
            this.selectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startBox
            // 
            this.startBox.Location = new System.Drawing.Point(366, 142);
            this.startBox.Name = "startBox";
            this.startBox.ReadOnly = true;
            this.startBox.Size = new System.Drawing.Size(56, 20);
            this.startBox.TabIndex = 7;
            this.startBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(441, 142);
            this.xBox.Name = "xBox";
            this.xBox.ReadOnly = true;
            this.xBox.Size = new System.Drawing.Size(56, 20);
            this.xBox.TabIndex = 8;
            this.xBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yBox
            // 
            this.yBox.BackColor = System.Drawing.SystemColors.Control;
            this.yBox.Location = new System.Drawing.Point(484, 100);
            this.yBox.Name = "yBox";
            this.yBox.ReadOnly = true;
            this.yBox.Size = new System.Drawing.Size(56, 20);
            this.yBox.TabIndex = 9;
            this.yBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bBox
            // 
            this.bBox.Location = new System.Drawing.Point(527, 142);
            this.bBox.Name = "bBox";
            this.bBox.ReadOnly = true;
            this.bBox.Size = new System.Drawing.Size(56, 20);
            this.bBox.TabIndex = 10;
            this.bBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // aBox
            // 
            this.aBox.Location = new System.Drawing.Point(484, 187);
            this.aBox.Name = "aBox";
            this.aBox.ReadOnly = true;
            this.aBox.Size = new System.Drawing.Size(56, 20);
            this.aBox.TabIndex = 11;
            this.aBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hold_MoveBox
            // 
            this.hold_MoveBox.Location = new System.Drawing.Point(239, 372);
            this.hold_MoveBox.Name = "hold_MoveBox";
            this.hold_MoveBox.ReadOnly = true;
            this.hold_MoveBox.Size = new System.Drawing.Size(84, 20);
            this.hold_MoveBox.TabIndex = 12;
            this.hold_MoveBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stopBox
            // 
            this.stopBox.Location = new System.Drawing.Point(354, 371);
            this.stopBox.Name = "stopBox";
            this.stopBox.ReadOnly = true;
            this.stopBox.Size = new System.Drawing.Size(91, 20);
            this.stopBox.TabIndex = 13;
            this.stopBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_upBox
            // 
            this.stick_upBox.Location = new System.Drawing.Point(157, 111);
            this.stick_upBox.Name = "stick_upBox";
            this.stick_upBox.Size = new System.Drawing.Size(56, 20);
            this.stick_upBox.TabIndex = 14;
            this.stick_upBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_rightBox
            // 
            this.stick_rightBox.Location = new System.Drawing.Point(187, 137);
            this.stick_rightBox.Name = "stick_rightBox";
            this.stick_rightBox.Size = new System.Drawing.Size(56, 20);
            this.stick_rightBox.TabIndex = 15;
            this.stick_rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_leftBox
            // 
            this.stick_leftBox.Location = new System.Drawing.Point(125, 137);
            this.stick_leftBox.Name = "stick_leftBox";
            this.stick_leftBox.Size = new System.Drawing.Size(56, 20);
            this.stick_leftBox.TabIndex = 16;
            this.stick_leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stick_downBox
            // 
            this.stick_downBox.Location = new System.Drawing.Point(157, 165);
            this.stick_downBox.Name = "stick_downBox";
            this.stick_downBox.Size = new System.Drawing.Size(56, 20);
            this.stick_downBox.TabIndex = 17;
            this.stick_downBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_upBox
            // 
            this.camera_upBox.Location = new System.Drawing.Point(401, 216);
            this.camera_upBox.Name = "camera_upBox";
            this.camera_upBox.Size = new System.Drawing.Size(56, 20);
            this.camera_upBox.TabIndex = 18;
            this.camera_upBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_rightBox
            // 
            this.camera_rightBox.Location = new System.Drawing.Point(431, 242);
            this.camera_rightBox.Name = "camera_rightBox";
            this.camera_rightBox.Size = new System.Drawing.Size(56, 20);
            this.camera_rightBox.TabIndex = 19;
            this.camera_rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_leftBox
            // 
            this.camera_leftBox.Location = new System.Drawing.Point(370, 242);
            this.camera_leftBox.Name = "camera_leftBox";
            this.camera_leftBox.Size = new System.Drawing.Size(56, 20);
            this.camera_leftBox.TabIndex = 20;
            this.camera_leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // camera_downBox
            // 
            this.camera_downBox.Location = new System.Drawing.Point(401, 270);
            this.camera_downBox.Name = "camera_downBox";
            this.camera_downBox.Size = new System.Drawing.Size(56, 20);
            this.camera_downBox.TabIndex = 21;
            this.camera_downBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cameraBox
            // 
            this.cameraBox.Location = new System.Drawing.Point(412, 412);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.ReadOnly = true;
            this.cameraBox.Size = new System.Drawing.Size(79, 20);
            this.cameraBox.TabIndex = 22;
            this.cameraBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stickBox
            // 
            this.stickBox.Location = new System.Drawing.Point(181, 412);
            this.stickBox.Name = "stickBox";
            this.stickBox.ReadOnly = true;
            this.stickBox.Size = new System.Drawing.Size(84, 20);
            this.stickBox.TabIndex = 23;
            this.stickBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbBox
            // 
            this.rbBox.Location = new System.Drawing.Point(435, 32);
            this.rbBox.Name = "rbBox";
            this.rbBox.ReadOnly = true;
            this.rbBox.Size = new System.Drawing.Size(79, 20);
            this.rbBox.TabIndex = 25;
            this.rbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbBox
            // 
            this.lbBox.Location = new System.Drawing.Point(169, 32);
            this.lbBox.Name = "lbBox";
            this.lbBox.ReadOnly = true;
            this.lbBox.Size = new System.Drawing.Size(79, 20);
            this.lbBox.TabIndex = 27;
            this.lbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // triggerBox
            // 
            this.triggerBox.Location = new System.Drawing.Point(294, 412);
            this.triggerBox.Name = "triggerBox";
            this.triggerBox.ReadOnly = true;
            this.triggerBox.Size = new System.Drawing.Size(91, 20);
            this.triggerBox.TabIndex = 29;
            this.triggerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 464);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler( this.pictureBox_MouseDown );
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.exitButton.Location = new System.Drawing.Point(346, 1);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(24, 24);
            this.exitButton.TabIndex = 30;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // recognizeBox
            // 
            this.recognizeBox.Location = new System.Drawing.Point(314, 58);
            this.recognizeBox.Name = "recognizeBox";
            this.recognizeBox.ReadOnly = true;
            this.recognizeBox.Size = new System.Drawing.Size(56, 20);
            this.recognizeBox.TabIndex = 31;
            this.recognizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimizeButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.minimizeButton.Location = new System.Drawing.Point(314, 1);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(24, 24);
            this.minimizeButton.TabIndex = 32;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(685, 466);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.recognizeBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.triggerBox);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.rbBox);
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
            this.TransparencyKey = this.BackColor;
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
        private System.Windows.Forms.TextBox rbBox;
        private System.Windows.Forms.TextBox lbBox;
        private System.Windows.Forms.TextBox triggerBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox recognizeBox;
        private System.Windows.Forms.Button minimizeButton;
    }
}

