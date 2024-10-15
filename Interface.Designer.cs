using System.Windows.Forms;

namespace Expert_system
{
    partial class Interface
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
            pictureBoxAkinator = new PictureBox();
            labelTop = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            richTextBoxFact = new RichTextBox();
            panel = new Panel();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAkinator).BeginInit();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxAkinator
            // 
            pictureBoxAkinator.Image = Properties.Resources.clipart873210;
            pictureBoxAkinator.Location = new Point(12, 12);
            pictureBoxAkinator.Name = "pictureBoxAkinator";
            pictureBoxAkinator.Size = new Size(261, 447);
            pictureBoxAkinator.TabIndex = 0;
            pictureBoxAkinator.TabStop = false;
            // 
            // labelTop
            // 
            labelTop.AutoSize = true;
            labelTop.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTop.Location = new Point(294, 68);
            labelTop.Name = "labelTop";
            labelTop.Size = new Size(288, 50);
            labelTop.TabIndex = 1;
            labelTop.Text = "Это утверждение характерно\r\nвашему персонажу?";
            labelTop.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonYes
            // 
            buttonYes.BackColor = Color.Tan;
            buttonYes.Font = new Font("Segoe UI", 14F);
            buttonYes.Location = new Point(399, 292);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(70, 35);
            buttonYes.TabIndex = 3;
            buttonYes.Text = "Да";
            buttonYes.UseVisualStyleBackColor = false;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.BackColor = Color.Tan;
            buttonNo.Font = new Font("Segoe UI", 14F);
            buttonNo.Location = new Point(399, 343);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(70, 34);
            buttonNo.TabIndex = 4;
            buttonNo.Text = "Нет";
            buttonNo.UseVisualStyleBackColor = false;
            buttonNo.Click += buttonNo_Click;
            // 
            // richTextBoxFact
            // 
            richTextBoxFact.BackColor = SystemColors.Info;
            richTextBoxFact.BorderStyle = BorderStyle.None;
            richTextBoxFact.Font = new Font("Segoe UI", 14F);
            richTextBoxFact.Location = new Point(294, 178);
            richTextBoxFact.Name = "richTextBoxFact";
            richTextBoxFact.Size = new Size(288, 54);
            richTextBoxFact.TabIndex = 6;
            richTextBoxFact.Text = "Ищет ответы на сложные вопросы ";
            // 
            // panel
            // 
            panel.BackColor = SystemColors.Info;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(pictureBox);
            panel.Location = new Point(593, 12);
            panel.Name = "panel";
            panel.Size = new Size(238, 447);
            panel.TabIndex = 8;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(-2, -1);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(239, 448);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 12;
            pictureBox.TabStop = false;
            pictureBox.Visible = false;
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(843, 472);
            Controls.Add(panel);
            Controls.Add(richTextBoxFact);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(labelTop);
            Controls.Add(pictureBoxAkinator);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Interface";
            Text = "Экспертная система";
            Load += Interface_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxAkinator).EndInit();
            panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxAkinator;
        private Label labelTop;
        private Button buttonYes;
        private Button buttonNo;
        private RichTextBox richTextBoxFact;
        private Panel panel;
        private PictureBox pictureBox;
    }
}
