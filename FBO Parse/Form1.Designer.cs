namespace FBO_Parse
{
    partial class Form1
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
            panel3 = new Panel();
            panel4 = new Panel();
            textBox2 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            panel6 = new Panel();
            panel5 = new Panel();
            panel2 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            label2 = new Label();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(128, 255, 128);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(118, 98);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(3);
            panel3.Size = new Size(654, 80);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(textBox2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3);
            panel4.Size = new Size(648, 74);
            panel4.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("서울남산체 M", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(3, 3);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(642, 68);
            textBox2.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("나눔스퀘어라운드 Bold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(692, 12);
            button1.Name = "button1";
            button1.Size = new Size(80, 80);
            button1.TabIndex = 4;
            button1.Text = "계산";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("서울남산체 M", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(88, 68);
            label1.TabIndex = 0;
            label1.Text = "수식 입력";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(562, 74);
            panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("서울남산체 M", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(3, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(556, 68);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(255, 224, 192);
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3);
            panel6.Size = new Size(94, 74);
            panel6.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 224, 192);
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(12, 12);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(3);
            panel5.Size = new Size(100, 80);
            panel5.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 224, 192);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(118, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(3);
            panel2.Size = new Size(568, 80);
            panel2.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(192, 255, 192);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(12, 98);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3);
            panel7.Size = new Size(100, 80);
            panel7.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(192, 255, 192);
            panel8.Controls.Add(label2);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(3);
            panel8.Size = new Size(94, 74);
            panel8.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("서울남산체 M", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 3);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(88, 68);
            label2.TabIndex = 0;
            label2.Text = "계산 결과";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 190);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(panel3);
            Font = new Font("나눔스퀘어라운드 Regular", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "Form1";
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Panel panel4;
        private Button button1;
        private Label label1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel2;
        private Panel panel1;
        private Panel panel7;
        private Panel panel8;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
