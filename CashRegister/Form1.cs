//Cash register Program
//Will Deichert
//Marcg 6, 2024

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace CashRegister
{
    public partial class CashRegister : Form
    {
        double urusPrice = 200000;
        double huracanPrice = 300000;
        double aventadorPrice = 400000;
        int numOfUrus = 0;
        int numOfHuracan = 0;
        int numOfAventador = 0;
        double subtotal = 0;
        double taxRate = 0.13;
        double taxAmount = 0;
        double total = 0;
        double change = 0;
        double tendered = 0;
        public CashRegister()
        {
            InitializeComponent();
        }
        private void totalButton_Click(object sender, EventArgs e) //Calculates Subtotal, Tax Amount and Total Cost of the purchase

        {
            SoundPlayer player1 = new SoundPlayer(Properties.Resources.CashRegister);
            player1.Play();
            try
            {
                numOfUrus = Convert.ToInt32(urusInput.Text); //The number of each car purchased
                numOfHuracan = Convert.ToInt32(huracanInput.Text);
                numOfAventador = Convert.ToInt32(aventadorInput.Text);

                subtotal = (numOfAventador * aventadorPrice) + (numOfUrus * urusPrice) + (numOfHuracan * huracanPrice); // Calculates total, subtotal and tax amount
                taxAmount = subtotal * taxRate;
                total = taxAmount + subtotal;

                subtotalOutput.Text = $"{subtotal.ToString("C")}"; //Output text for subtotal total and tax amount.
                taxOutput.Text = $"{taxAmount.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";

                changeButton.Enabled = true;
            }
            catch
            {
                subtotalOutput.Text = "ERROR"; //error message that gets displayed when a letter is part of the input.
                taxOutput.Text = "";
                totalOutput.Text = "";
            }
        }
        private void changeButton_Click(object sender, EventArgs e) //After paying this button calculates your change based off of the tendered amount.
        {
            try
            {
                tendered = Convert.ToDouble(tenderedInput.Text);
                change = tendered - total; //calculation for the amount of change that is owed

                changeOutput.Text = $"{change.ToString("C")}";

                if (tendered > total || tendered == total)
                {
                    changeOutput.Text = $"{ change.ToString("C")}"; // Output text for the change amount
                }
                if (tendered < total)
                {
                    changeOutput.Text = $"Insufficient Funds"; // Message to display insufficeint funds when Tendered is less than total.
                }
                receiptButton.Enabled = true;
            }
            catch 
            {
                changeOutput.Text = "ERROR"; // Error code incase letters are part of the input
            }

        }
        private void receiptButton_Click(object sender, EventArgs e) //Prints receipt with all purchase info
        {
            SoundPlayer player4 = new SoundPlayer(Properties.Resources.Printer); // plays printing sound
            player4.Play();
          
            Refresh();
            Thread.Sleep(500);// makes recepit print line by line
            receiptLabel.Text = "                             Will's Car Shop."; // text for recepit
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n   June 29, 2020";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n   Aventadors x{numOfAventador} @   ${aventadorPrice}.00";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n   Huracans x{numOfHuracan} @        ${huracanPrice}.00";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n   Urus x{numOfUrus} @                 ${huracanPrice}.00";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n   Subtotal:                     ${subtotal}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n   Tax:                              ${taxAmount}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n   Total:                           ${total}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n   Tendered:                 ${tendered}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n   Change:                     ${change}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n   Thank you for your purchase";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n   Have a nice day.";
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer player2 = new SoundPlayer(Properties.Resources.SVJTrimmed);
            player2.Play(); // easter egg code
        }
        private void resetButton_Click(object sender, EventArgs e) //resets the code for all variables and text.
        {
            urusInput.Text = "";
            aventadorInput.Text = "";
            huracanInput.Text = "";
            subtotalOutput.Text = "";
            totalOutput.Text = "";
            taxOutput.Text = "";
            receiptLabel.Text = "";
            changeOutput.Text = "";
            tenderedInput.Text = "";
            numOfAventador = 0;
            numOfHuracan = 0;
            numOfUrus = 0;
            total = 0;
            change = 0;
            tendered = 0;
            taxAmount = 0;
            subtotal = 0;
            changeButton.Enabled = false;
            receiptButton.Enabled = false;

        }


    }
}
