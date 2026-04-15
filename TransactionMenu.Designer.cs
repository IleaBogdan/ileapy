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
            this.select_to_card_label_label = new System.Windows.Forms.Label();
            this.select_to_card_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // transaction_progressBar
            // 
            this.transaction_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transaction_progressBar.Location = new System.Drawing.Point(16, 277);
            this.transaction_progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.transaction_progressBar.Name = "transaction_progressBar";
            this.transaction_progressBar.Size = new System.Drawing.Size(351, 58);
            this.transaction_progressBar.TabIndex = 0;
            // 
            // from_select_label
            // 
            this.from_select_label.AutoSize = true;
            this.from_select_label.Location = new System.Drawing.Point(16, 16);
            this.from_select_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.from_select_label.Name = "from_select_label";
            this.from_select_label.Size = new System.Drawing.Size(168, 16);
            this.from_select_label.TabIndex = 1;
            this.from_select_label.Text = "Select card to transfer from:";
            // 
            // from_card_comboBox
            // 
            this.from_card_comboBox.FormattingEnabled = true;
            this.from_card_comboBox.Location = new System.Drawing.Point(17, 36);
            this.from_card_comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.from_card_comboBox.Name = "from_card_comboBox";
            this.from_card_comboBox.Size = new System.Drawing.Size(351, 24);
            this.from_card_comboBox.TabIndex = 2;
            this.from_card_comboBox.SelectedIndexChanged += new System.EventHandler(this.from_card_comboBox_SelectedIndexChanged);
            // 
            // transfer_sum_textBox
            // 
            this.transfer_sum_textBox.Location = new System.Drawing.Point(139, 69);
            this.transfer_sum_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.transfer_sum_textBox.Name = "transfer_sum_textBox";
            this.transfer_sum_textBox.Size = new System.Drawing.Size(159, 22);
            this.transfer_sum_textBox.TabIndex = 3;
            // 
            // transfer_amount_label
            // 
            this.transfer_amount_label.AutoSize = true;
            this.transfer_amount_label.Location = new System.Drawing.Point(13, 73);
            this.transfer_amount_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transfer_amount_label.Name = "transfer_amount_label";
            this.transfer_amount_label.Size = new System.Drawing.Size(108, 16);
            this.transfer_amount_label.TabIndex = 4;
            this.transfer_amount_label.Text = "Transfer Amount:";
            // 
            // max_amount_label
            // 
            this.max_amount_label.AutoSize = true;
            this.max_amount_label.Location = new System.Drawing.Point(307, 73);
            this.max_amount_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.max_amount_label.Name = "max_amount_label";
            this.max_amount_label.Size = new System.Drawing.Size(48, 16);
            this.max_amount_label.TabIndex = 5;
            this.max_amount_label.Text = "<= 0.00";
            // 
            // next_button1
            // 
            this.next_button1.Location = new System.Drawing.Point(16, 220);
            this.next_button1.Margin = new System.Windows.Forms.Padding(4);
            this.next_button1.Name = "next_button1";
            this.next_button1.Size = new System.Drawing.Size(221, 49);
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
            this.user_select_comboBox.Size = new System.Drawing.Size(264, 24);
            this.user_select_comboBox.TabIndex = 7;
            this.user_select_comboBox.SelectedIndexChanged += new System.EventHandler(this.user_select_comboBox_SelectedIndexChanged);
            // 
            // select_to_card_label_label
            // 
            this.select_to_card_label_label.AutoSize = true;
            this.select_to_card_label_label.Location = new System.Drawing.Point(18, 75);
            this.select_to_card_label_label.Name = "select_to_card_label_label";
            this.select_to_card_label_label.Size = new System.Drawing.Size(183, 15);
            this.select_to_card_label_label.TabIndex = 7;
            this.select_to_card_label_label.Text = "Select to what card to transfer:";
            // 
            // select_to_card_comboBox
            // 
            this.select_to_card_comboBox.FormattingEnabled = true;
            this.select_to_card_comboBox.Location = new System.Drawing.Point(12, 95);
            this.select_to_card_comboBox.Name = "select_to_card_comboBox";
            this.select_to_card_comboBox.Size = new System.Drawing.Size(264, 24);
            this.select_to_card_comboBox.TabIndex = 7;
            // 
            // TransactionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 347);
            this.Controls.Add(this.next_button1);
            this.Controls.Add(this.max_amount_label);
            this.Controls.Add(this.transfer_amount_label);
            this.Controls.Add(this.transfer_sum_textBox);
            this.Controls.Add(this.from_card_comboBox);
            this.Controls.Add(this.from_select_label);
            this.Controls.Add(this.transaction_progressBar);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label select_to_card_label_label;
        private System.Windows.Forms.ComboBox select_to_card_comboBox;
    }
}