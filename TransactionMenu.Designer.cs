namespace ileapy
{
    partial class TransactionMenu
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
            this.transaction_progressBar = new System.Windows.Forms.ProgressBar();
            this.from_select_label = new System.Windows.Forms.Label();
            this.from_card_comboBox = new System.Windows.Forms.ComboBox();
            this.transfer_sum_textBox = new System.Windows.Forms.TextBox();
            this.transfer_amount_label = new System.Windows.Forms.Label();
            this.max_amount_label = new System.Windows.Forms.Label();
            this.next_button1 = new System.Windows.Forms.Button();
            this.next_button2 = new System.Windows.Forms.Button();
            this.to_who_label = new System.Windows.Forms.Label();
            this.user_select_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // transaction_progressBar
            // 
            this.transaction_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transaction_progressBar.Location = new System.Drawing.Point(12, 225);
            this.transaction_progressBar.Name = "transaction_progressBar";
            this.transaction_progressBar.Size = new System.Drawing.Size(263, 47);
            this.transaction_progressBar.TabIndex = 0;
            // 
            // from_select_label
            // 
            this.from_select_label.AutoSize = true;
            this.from_select_label.Location = new System.Drawing.Point(12, 13);
            this.from_select_label.Name = "from_select_label";
            this.from_select_label.Size = new System.Drawing.Size(137, 13);
            this.from_select_label.TabIndex = 1;
            this.from_select_label.Text = "Select card to transfer from:";
            // 
            // from_card_comboBox
            // 
            this.from_card_comboBox.FormattingEnabled = true;
            this.from_card_comboBox.Location = new System.Drawing.Point(13, 29);
            this.from_card_comboBox.Name = "from_card_comboBox";
            this.from_card_comboBox.Size = new System.Drawing.Size(264, 21);
            this.from_card_comboBox.TabIndex = 2;
            this.from_card_comboBox.SelectedIndexChanged += new System.EventHandler(this.from_card_comboBox_SelectedIndexChanged);
            // 
            // transfer_sum_textBox
            // 
            this.transfer_sum_textBox.Location = new System.Drawing.Point(104, 56);
            this.transfer_sum_textBox.Name = "transfer_sum_textBox";
            this.transfer_sum_textBox.Size = new System.Drawing.Size(120, 20);
            this.transfer_sum_textBox.TabIndex = 3;
            // 
            // transfer_amount_label
            // 
            this.transfer_amount_label.AutoSize = true;
            this.transfer_amount_label.Location = new System.Drawing.Point(10, 59);
            this.transfer_amount_label.Name = "transfer_amount_label";
            this.transfer_amount_label.Size = new System.Drawing.Size(88, 13);
            this.transfer_amount_label.TabIndex = 4;
            this.transfer_amount_label.Text = "Transfer Amount:";
            // 
            // max_amount_label
            // 
            this.max_amount_label.AutoSize = true;
            this.max_amount_label.Location = new System.Drawing.Point(230, 59);
            this.max_amount_label.Name = "max_amount_label";
            this.max_amount_label.Size = new System.Drawing.Size(43, 13);
            this.max_amount_label.TabIndex = 5;
            this.max_amount_label.Text = "<= 0.00";
            // 
            // next_button1
            // 
            this.next_button1.Location = new System.Drawing.Point(12, 179);
            this.next_button1.Name = "next_button1";
            this.next_button1.Size = new System.Drawing.Size(166, 40);
            this.next_button1.TabIndex = 6;
            this.next_button1.Text = "Next";
            this.next_button1.UseVisualStyleBackColor = true;
            this.next_button1.Click += new System.EventHandler(this.next_button1_Click);
            // 
            // next_button2
            // 
            this.next_button2.Location = new System.Drawing.Point(12, 179);
            this.next_button2.Name = "next_button2";
            this.next_button2.Size = new System.Drawing.Size(166, 40);
            this.next_button2.TabIndex = 7;
            this.next_button2.Text = "Next";
            this.next_button2.UseVisualStyleBackColor = true;
            this.next_button2.Click += new System.EventHandler(this.next_button2_Click);
            // 
            // to_who_label
            // 
            this.to_who_label.AutoSize = true;
            this.to_who_label.Location = new System.Drawing.Point(12, 13);
            this.to_who_label.Name = "to_who_label";
            this.to_who_label.Size = new System.Drawing.Size(125, 13);
            this.to_who_label.TabIndex = 7;
            this.to_who_label.Text = "Select to who to transfer:";
            // 
            // user_select_comboBox
            // 
            this.user_select_comboBox.FormattingEnabled = true;
            this.user_select_comboBox.Location = new System.Drawing.Point(12, 29);
            this.user_select_comboBox.Name = "user_select_comboBox";
            this.user_select_comboBox.Size = new System.Drawing.Size(264, 21);
            this.user_select_comboBox.TabIndex = 7;
            this.user_select_comboBox.SelectedIndexChanged+= new System.EventHandler(this.user_select_comboBox_SelectedIndexChanged);
            // 
            // TransactionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 282);
            this.Controls.Add(this.next_button1);
            this.Controls.Add(this.max_amount_label);
            this.Controls.Add(this.transfer_amount_label);
            this.Controls.Add(this.transfer_sum_textBox);
            this.Controls.Add(this.from_card_comboBox);
            this.Controls.Add(this.from_select_label);
            this.Controls.Add(this.transaction_progressBar);
            this.Name = "TransactionMenu";
            this.Text = "Transaction Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar transaction_progressBar;
        private System.Windows.Forms.Label from_select_label;
        private System.Windows.Forms.ComboBox from_card_comboBox;
        private System.Windows.Forms.TextBox transfer_sum_textBox;
        private System.Windows.Forms.Label transfer_amount_label;
        private System.Windows.Forms.Label max_amount_label;
        private System.Windows.Forms.Button next_button1;
        private System.Windows.Forms.Button next_button2;
        private System.Windows.Forms.Label to_who_label;
        private System.Windows.Forms.ComboBox user_select_comboBox;
    }
}