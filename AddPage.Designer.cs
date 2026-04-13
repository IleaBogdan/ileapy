namespace ileapy
{
    partial class AddPage
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
            this.adding_amount_label = new System.Windows.Forms.Label();
            this.adding_amount_textBox = new System.Windows.Forms.TextBox();
            this.add_money_button = new System.Windows.Forms.Button();
            this.in_euro_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // adding_amount_label
            // 
            this.adding_amount_label.AutoSize = true;
            this.adding_amount_label.Location = new System.Drawing.Point(12, 28);
            this.adding_amount_label.Name = "adding_amount_label";
            this.adding_amount_label.Size = new System.Drawing.Size(82, 13);
            this.adding_amount_label.TabIndex = 0;
            this.adding_amount_label.Text = "Adding Amount:";
            // 
            // adding_amount_textBox
            // 
            this.adding_amount_textBox.Location = new System.Drawing.Point(100, 25);
            this.adding_amount_textBox.Name = "adding_amount_textBox";
            this.adding_amount_textBox.Size = new System.Drawing.Size(73, 20);
            this.adding_amount_textBox.TabIndex = 1;
            // 
            // add_money_button
            // 
            this.add_money_button.Location = new System.Drawing.Point(31, 70);
            this.add_money_button.Name = "add_money_button";
            this.add_money_button.Size = new System.Drawing.Size(190, 78);
            this.add_money_button.TabIndex = 2;
            this.add_money_button.Text = "Add Money";
            this.add_money_button.UseVisualStyleBackColor = true;
            this.add_money_button.Click += new System.EventHandler(this.add_money_button_Click);
            // 
            // in_euro_label
            // 
            this.in_euro_label.AutoSize = true;
            this.in_euro_label.Location = new System.Drawing.Point(179, 28);
            this.in_euro_label.Name = "in_euro_label";
            this.in_euro_label.Size = new System.Drawing.Size(40, 13);
            this.in_euro_label.TabIndex = 3;
            this.in_euro_label.Text = "in Euro";
            // 
            // AddPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 161);
            this.Controls.Add(this.in_euro_label);
            this.Controls.Add(this.add_money_button);
            this.Controls.Add(this.adding_amount_textBox);
            this.Controls.Add(this.adding_amount_label);
            this.Name = "AddPage";
            this.Text = "Add Money";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label adding_amount_label;
        private System.Windows.Forms.TextBox adding_amount_textBox;
        private System.Windows.Forms.Button add_money_button;
        private System.Windows.Forms.Label in_euro_label;
    }
}