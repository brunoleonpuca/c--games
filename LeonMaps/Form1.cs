using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonMaps
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string street = streetTxt.Text;
            string city = cityTxt.Text;
            string state = stateTxt.Text;
            string zip = zipTxt.Text;

            try
            {
                StringBuilder querydata = new StringBuilder();
                querydata.Append("https://www.google.com.ar/maps/search/");

                if (street != string.Empty)
                {
                    querydata.Append(street + "," + "+");
                }
                if (city != string.Empty)
                {
                    querydata.Append(city + "," + "+");
                }
                if (state != string.Empty)
                {
                    querydata.Append(state + "," + "+");
                }
                if (zip != string.Empty)
                {
                    querydata.Append(zip + "," + "+");
                }

                webBrowser1.Navigate(querydata.ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), "Error");
                
            }
        }
    }
}
