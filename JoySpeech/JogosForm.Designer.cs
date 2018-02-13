namespace JoySpeech
{
    partial class JogosForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.rightBox = new System.Windows.Forms.TextBox();
            this.chooseBox = new System.Windows.Forms.TextBox();
            this.leftBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.Location = new System.Drawing.Point(13, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(701, 237);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // rightBox
            // 
            this.rightBox.Location = new System.Drawing.Point(613, 229);
            this.rightBox.Name = "rightBox";
            this.rightBox.ReadOnly = true;
            this.rightBox.Size = new System.Drawing.Size(91, 20);
            this.rightBox.TabIndex = 14;
            this.rightBox.Text = "DIREITA";
            this.rightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chooseBox
            // 
            this.chooseBox.Location = new System.Drawing.Point(317, 229);
            this.chooseBox.Name = "chooseBox";
            this.chooseBox.ReadOnly = true;
            this.chooseBox.Size = new System.Drawing.Size(91, 20);
            this.chooseBox.TabIndex = 15;
            this.chooseBox.Text = "ESCOLHER";
            this.chooseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leftBox
            // 
            this.leftBox.Location = new System.Drawing.Point(23, 229);
            this.leftBox.Name = "leftBox";
            this.leftBox.ReadOnly = true;
            this.leftBox.Size = new System.Drawing.Size(91, 20);
            this.leftBox.TabIndex = 16;
            this.leftBox.Text = "ESQUERDA";
            this.leftBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // JogosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(726, 261);
            this.ControlBox = false;
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.chooseBox);
            this.Controls.Add(this.rightBox);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JogosForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jogos";
            this.Load += new System.EventHandler(this.JogosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox rightBox;
        private System.Windows.Forms.TextBox chooseBox;
        private System.Windows.Forms.TextBox leftBox;
    }
}