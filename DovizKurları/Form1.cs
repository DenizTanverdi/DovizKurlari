using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizKurları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            listBox1.Items.Clear();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("http://www.tcmb.gov.tr/kurlar/today.xml");// xml dosyasını load ettik.
            XmlElement rooteleman = xmldoc.DocumentElement;// tüm dokumanı getirdik
            XmlNodeList liste = rooteleman.GetElementsByTagName("Currency");//dügüm baslangıcını belirttik.
            List<Doviz> dlist = new List<Doviz>();
            foreach (XmlElement item in liste)
            {
                Doviz d = new Doviz();
                XmlElement currency = item;
                string code = currency.Attributes["CurrencyCode"].Value;
                string isim = currency.GetElementsByTagName("Isim").Item(0).InnerText;

                d.CurrencyName = isim;
                string alisFiyat = currency.GetElementsByTagName("ForexBuying").Item(0).InnerText;
                string satisFiyat = currency.GetElementsByTagName("ForexSelling").Item(0).InnerText;
                string birim= currency.GetElementsByTagName("Unit").Item(0).InnerText;

                if (!string.IsNullOrEmpty(satisFiyat))
                {
                    d.ForexSelling = Convert.ToDecimal(satisFiyat)/10000;

                }
                if (!string.IsNullOrEmpty(alisFiyat))
                {
                    d.ForexBuying = Convert.ToDecimal(alisFiyat) / 10000;

                }
                if (!string.IsNullOrEmpty(code))
                {
                    d.CurrencyCode = code;

                }
                listBox1.Items.Add(d);
                dlist.Add(d);
               

               
            }
            dataGridView1.DataSource = dlist;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doviz secilenDoviz = (Doviz)listBox1.SelectedItem;
            lblAlis.Text = secilenDoviz.ForexBuying.ToString();
            lblSatıs.Text = secilenDoviz.ForexSelling.ToString();
            lblbirim.Text = secilenDoviz.CurrencyCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet doviz = new DataSet();
            doviz.ReadXml("https://www.w3schools.com/xml/cd_catalog.xml");
            dataGridView1.DataSource = doviz.Tables[0];
        }
    }
}
