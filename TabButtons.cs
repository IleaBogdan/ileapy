using ileapy;
using ileapy.ileapyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ileapy
{
    internal class TabButtons
    {
        public System.Windows.Forms.Button Convert_Button;
        public System.Windows.Forms.Label balance_label;
        public System.Windows.Forms.ComboBox Currency_ComboBox;
        public TabButtons()
        {
            this.Convert_Button = new System.Windows.Forms.Button();
            this.balance_label = new System.Windows.Forms.Label();
            this.Currency_ComboBox = new System.Windows.Forms.ComboBox();
            
            // Convert_Button
            this.Convert_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Convert_Button.Location = new System.Drawing.Point(248, 140);
            this.Convert_Button.Name = "Convert_Button";
            this.Convert_Button.Size = new System.Drawing.Size(62, 84);
            this.Convert_Button.TabIndex = 0;
            this.Convert_Button.Text = "Convert";
            this.Convert_Button.UseVisualStyleBackColor = true;
            
            // balance_label
            this.balance_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.balance_label.AutoSize = true;
            this.balance_label.Font = new System.Drawing.Font("Arial", 34F);
            this.balance_label.Location = new System.Drawing.Point(208, 46);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(146, 52);
            this.balance_label.TabIndex = 1;
            this.balance_label.Text = "label1";
            this.balance_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // Currency_ComboBox
            this.Currency_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Currency_ComboBox.FormattingEnabled = true;
            this.Currency_ComboBox.Location = new System.Drawing.Point(217, 113);
            this.Currency_ComboBox.Name = "Currency_ComboBox";
            this.Currency_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Currency_ComboBox.TabIndex = 2;

            this.Currency_ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.Currency_ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.Currency_ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
        }
    }
}
