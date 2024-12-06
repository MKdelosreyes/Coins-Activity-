using System.Windows.Forms;

namespace DigitalImageProcessing
{
    partial class CoinsForm
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
            menuStrip1 = new MenuStrip();
            label1 = new Label();
            label2 = new Label();
            tbNumCoins = new TextBox();
            tbTotalValue = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnUploadImage = new Button();
            btnCountCoins = new Button();
            openFileDialog1 = new OpenFileDialog();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 3, 0, 3);
            menuStrip1.Size = new Size(1175, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(834, 98);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(145, 22);
            label1.TabIndex = 1;
            label1.Text = "Number of coins:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(834, 171);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 22);
            label2.TabIndex = 2;
            label2.Text = "Total Value:";
            // 
            // tbNumCoins
            // 
            tbNumCoins.Enabled = false;
            tbNumCoins.ForeColor = Color.Maroon;
            tbNumCoins.Location = new Point(838, 126);
            tbNumCoins.Name = "tbNumCoins";
            tbNumCoins.Size = new Size(322, 28);
            tbNumCoins.TabIndex = 3;
            tbNumCoins.TextChanged += tbNumCoins_TextChanged;
            // 
            // tbTotalValue
            // 
            tbTotalValue.Enabled = false;
            tbTotalValue.Location = new Point(838, 196);
            tbTotalValue.Name = "tbTotalValue";
            tbTotalValue.Size = new Size(322, 28);
            tbTotalValue.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(11, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(810, 455);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(12, 96);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(809, 455);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // btnUploadImage
            // 
            btnUploadImage.BackColor = SystemColors.ControlLight;
            btnUploadImage.Location = new Point(12, 38);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(138, 35);
            btnUploadImage.TabIndex = 7;
            btnUploadImage.Text = "Open";
            btnUploadImage.UseVisualStyleBackColor = false;
            btnUploadImage.Click += btnUploadImage_Click;
            // 
            // btnCountCoins
            // 
            btnCountCoins.BackColor = SystemColors.GradientInactiveCaption;
            btnCountCoins.Location = new Point(672, 35);
            btnCountCoins.Name = "btnCountCoins";
            btnCountCoins.Size = new Size(149, 47);
            btnCountCoins.TabIndex = 8;
            btnCountCoins.Text = "Count Coins";
            btnCountCoins.UseVisualStyleBackColor = false;
            btnCountCoins.Click += btnCountCoins_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 22;
            listBox1.Location = new Point(838, 371);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(322, 180);
            listBox1.TabIndex = 11;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 22;
            listBox2.Location = new Point(838, 268);
            listBox2.Name = "listBox2";
            listBox2.ScrollAlwaysVisible = true;
            listBox2.Size = new Size(322, 92);
            listBox2.TabIndex = 13;
            // 
            // CoinsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1175, 563);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(btnCountCoins);
            Controls.Add(btnUploadImage);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(tbTotalValue);
            Controls.Add(tbNumCoins);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "CoinsForm";
            Text = "Coins";
            FormClosing += Coins_Closing;
            Load += Coins_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumCoins;
        private System.Windows.Forms.TextBox tbTotalValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnCountCoins;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ListBox listBox1;
        private ListBox listBox2;
    }
}