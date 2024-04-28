namespace XAXBgame
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
            label1 = new Label();
            guessbotton = new Button();
            UserInput = new TextBox();
            results = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(388, 35);
            label1.TabIndex = 0;
            label1.Text = "請輸入不重複的三個數字(0~9):";
            // 
            // guessbotton
            // 
            guessbotton.Location = new Point(12, 76);
            guessbotton.Name = "guessbotton";
            guessbotton.Size = new Size(75, 23);
            guessbotton.TabIndex = 1;
            guessbotton.Text = "猜";
            guessbotton.UseVisualStyleBackColor = true;
            guessbotton.Click += button1_Click;
            // 
            // UserInput
            // 
            UserInput.Location = new Point(12, 47);
            UserInput.Name = "UserInput";
            UserInput.Size = new Size(150, 23);
            UserInput.TabIndex = 2;
            // 
            // results
            // 
            results.FormattingEnabled = true;
            results.ItemHeight = 15;
            results.Location = new Point(12, 105);
            results.Name = "results";
            results.Size = new Size(388, 334);
            results.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(results);
            Controls.Add(UserInput);
            Controls.Add(guessbotton);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button guessbotton;
        private TextBox UserInput;
        private ListBox results;
    }
}