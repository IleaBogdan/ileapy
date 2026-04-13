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
        public System.Windows.Forms.Button Refresh_Button;
        public System.Windows.Forms.Button AddMoney_Button;
        public System.Windows.Forms.Label balance_label;
        public System.Windows.Forms.ComboBox Currency_ComboBox;
        private TabPage parentTabPage;
        public TabButtons()
        {
            this.Convert_Button = new System.Windows.Forms.Button();
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.AddMoney_Button = new System.Windows.Forms.Button();
            this.balance_label = new System.Windows.Forms.Label();
            this.Currency_ComboBox = new System.Windows.Forms.ComboBox();

            // Convert_Button
            this.Convert_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                //| System.Windows.Forms.AnchorStyles.Bottom
                )
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Convert_Button.Location = new System.Drawing.Point(100, 110);
            this.Convert_Button.Name = "Convert_Button";
            this.Convert_Button.Size = new System.Drawing.Size(62, 40);
            this.Convert_Button.TabIndex = 0;
            this.Convert_Button.Text = "Convert";
            this.Convert_Button.UseVisualStyleBackColor = true;

            // Refresh_Button
            this.Refresh_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                //| System.Windows.Forms.AnchorStyles.Bottom
                )
            | System.Windows.Forms.AnchorStyles.Left)
                //| System.Windows.Forms.AnchorStyles.Right
            )));
            this.Refresh_Button.Location = new System.Drawing.Point(10, 10);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(60, 20);
            this.Refresh_Button.TabIndex = 4;
            this.Refresh_Button.Text = "Refrash";
            this.Refresh_Button.UseVisualStyleBackColor = true;

            // balance_label
            this.balance_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.balance_label.AutoSize = true;
            this.balance_label.Font = new System.Drawing.Font("Arial", 24F);
            this.balance_label.Location = new System.Drawing.Point(35, 40);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(40, 40);
            this.balance_label.TabIndex = 1;
            this.balance_label.Text = "label1";
            this.balance_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Currency_ComboBox
            this.Currency_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Currency_ComboBox.FormattingEnabled = true;
            this.Currency_ComboBox.Location = new System.Drawing.Point(100, 80);
            this.Currency_ComboBox.Name = "Currency_ComboBox";
            this.Currency_ComboBox.Size = new System.Drawing.Size(60, 21);
            this.Currency_ComboBox.TabIndex = 2;

            this.Currency_ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.Currency_ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.Currency_ComboBox.DropDownStyle = ComboBoxStyle.DropDown;

            // AddMoney_Button
            this.AddMoney_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                //| System.Windows.Forms.AnchorStyles.Bottom
                )
            // | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right
            ))));
            this.AddMoney_Button.Location = new System.Drawing.Point(10, 10);
            this.AddMoney_Button.Name = "AddMoney_Button";
            this.AddMoney_Button.Size = new System.Drawing.Size(60, 40);
            this.AddMoney_Button.TabIndex = 4;
            this.AddMoney_Button.Text = "Add Money";
            this.AddMoney_Button.UseVisualStyleBackColor = true;
        }
        public void CenterControls(TabPage parentPage)
        {
            parentTabPage = parentPage;

            // Get the client size of the tab page
            int tabWidth = parentPage.ClientSize.Width;
            int tabHeight = parentPage.ClientSize.Height;

            // Calculate center X position
            int centerX = tabWidth / 2;

            // Position controls vertically with appropriate spacing
            // Use percentages of tab height to ensure visibility
            int balanceY = (int)(tabHeight * 0.25); // 25% from top
            int comboBoxY = (int)(tabHeight * 0.45); // 45% from top
            int buttonY = (int)(tabHeight * 0.60); // 60% from top

            // Position balance label
            balance_label.Location = new System.Drawing.Point(
                centerX - (balance_label.Width / 2),
                balanceY
            );

            // Position ComboBox below balance label
            Currency_ComboBox.Location = new System.Drawing.Point(
                centerX - (Currency_ComboBox.Width / 2),
                comboBoxY
            );

            // Position Convert button below ComboBox
            Convert_Button.Location = new System.Drawing.Point(
                centerX - (Convert_Button.Width / 2),
                buttonY
            );

            // Position Refresh button in top-left corner
            Refresh_Button.Location = new System.Drawing.Point(10, 10);

            AddMoney_Button.Location = new System.Drawing.Point(
                tabWidth-AddMoney_Button.Width-10,
                10
            );
        }

        public void UpdateControlPositions()
        {
            if (parentTabPage != null)
            {
                CenterControls(parentTabPage);
            }
        }
    }
}
