using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutineSøk
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        Pakkseddelsøk pakkseddelsøk = new Pakkseddelsøk();
        ShoppaSøk shoppasøk = new ShoppaSøk();
        Epost epost = new Epost();

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PakkseddelLabel.Visible = false;
            pakkseddelsøk.FinneFiler(epost);
            if (pakkseddelsøk.FeilMelding == false)
            { PakkseddelLabel.Text = "Ferdig"; }
            else { PakkseddelLabel.Text = "Feilet"; }
            PakkseddelLabel.Visible = true;
            epost.pakkseddelkjørt = true;
        }

        private void WebrapportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://webrapport.touchsoft.no/logedin/Status.aspx");
        }

        private void ShoppaButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"\\filserver\ShoppaIntegrasjon\Logg.txt");

            ShoppaLabel.Visible = false;
            shoppasøk.søk(epost);
            ShoppaLabel.Text = "Ferdig";
            ShoppaLabel.Visible = true;
            epost.shoppakjørt = true;
        }

        private void EpostButton_Click(object sender, EventArgs e)
        {
            epost.OpprettEpost();
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
