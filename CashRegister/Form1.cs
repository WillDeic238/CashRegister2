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

        private void totalButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player1 = new SoundPlayer(Properties.Resources.CashRegister);
            player1.Play();
            try
            {
               
                numOfUrus = Convert.ToInt32(urusInput.Text);
                numOfHuracan = Convert.ToInt32(huracanInput.Text);
                numOfAventador = Convert.ToInt32(aventadorInput.Text);

                subtotal = (numOfAventador * aventadorPrice) + (numOfUrus * urusPrice) + (numOfHuracan * huracanPrice);
                taxAmount = subtotal * taxRate;
                total = taxAmount + subtotal;

                subtotalOutput.Text = $"{subtotal.ToString("C")}";
                taxOutput.Text = $"{taxAmount.ToString("C")}";
                totalOutput.Text = $"{total.ToString("C")}";

            }
            catch
            {
                subtotalOutput.Text = "ERROR";
                taxOutput.Text = "";
                totalOutput.Text = "";
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {

            tendered = Convert.ToDouble(tenderedInput.Text);
            change = tendered - total;
            changeOutput.Text = $"{change.ToString("C")}";
            if(tendered > total || tendered == total)
            { 
                changeOutput.Text = $"{ change.ToString("C")}"; 
            }

            if (tendered < total)
            {
            changeOutput.Text = $"Insufficient Funds";
            }
           
        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            receiptLabel.Text = "                                                     Wills Car Shop.";
            receiptLabel.Text += $"\n\n   June 29, 2020";
            receiptLabel.Text += $"\n\n   Aventadors x{numOfAventador} @ ${aventadorPrice}.00";
            receiptLabel.Text += $"\n   Huracans x{numOfHuracan} @ ${huracanPrice}.00";
            receiptLabel.Text += $"\n   urus x{numOfUrus} @ ${huracanPrice}.00";
            receiptLabel.Text += $"\n\n   Subtotal:          ${subtotal}";
            receiptLabel.Text += $"\n   Tax:                 ${taxAmount}";
            receiptLabel.Text += $"\n   Total:               ${total}";
            receiptLabel.Text += $"\n\n   Tendered            ${tendered}";
            receiptLabel.Text += $"\n   Change               ${change}";
            receiptLabel.Text += $"\n\n   Thank you for your purchase of {numOfAventador} Aventador, {numOfHuracan} Huracan and {numOfUrus} Urus";
            receiptLabel.Text += $"\n   Have a nice day.";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer player2 = new SoundPlayer(Properties.Resources.SVJTrimmed);
            player2.Play();
        }

        private void resetButton_Click(object sender, EventArgs e)
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

        }
    }
}
