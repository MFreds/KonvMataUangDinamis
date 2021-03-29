using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KonversiMataUangDinamis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double getRate(string fromCurrency, string toCurrency)
        {
            var json = "";
            string rate = "";
            try
            {
                string url = string.Format("https://free.currconv.com/api/v7/convert?q={0}_{1}&compact=ultra&apiKey=f6223b079ecfefd9b8b6", fromCurrency.ToUpper(), toCurrency.ToUpper());
                string key = string.Format("{0}_{1}", fromCurrency.ToUpper(), toCurrency.ToUpper());

                json = new WebClient().DownloadString(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                rate = stuff[key];
            }
            catch
            {
                rate = "0";
            }

            return double.Parse(rate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    label5.Text = "Masukkan angka di IDR!";
                    label5.ForeColor = Color.Red;
                }
                else
                {

                    double rate = getRate(label2.Text, radioButton1.Text);
                    double output = double.Parse(textBox1.Text) * rate;

                    textBox2.Text = output.ToString();
                }
            }

            else if (radioButton2.Checked == true)
            {

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    label5.Text = "Masukkan angka di IDR!";
                    label5.ForeColor = Color.Red;
                }
                else
                {

                    double rate = getRate(label2.Text, radioButton2.Text);
                    double output = double.Parse(textBox1.Text) * rate;

                    textBox2.Text = output.ToString();
                }
            }

            else
            {
                label3.Text = "Pilih Salah Satu :(";
                label3.ForeColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
