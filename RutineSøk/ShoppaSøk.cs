using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RutineSøk
{
    class ShoppaSøk
    {

        public void søk(Epost epost)
        {
            //Hente inn logg filen til shoppa. Den er i konstant bruk så jeg trenger å ta en kopi
            System.IO.File.Delete(@"C:\Users\Bruker\Documents\ShoppaLogg.txt");
            System.IO.File.Copy(@"\\filserver\ShoppaIntegrasjon\Logg.txt", @"C:\Users\Bruker\Documents\ShoppaLogg.txt");

            //Opprette streamreader og writer
            System.IO.StreamReader ShoppaLoggLeser = new System.IO.StreamReader(@"C:\Users\Bruker\Documents\ShoppaLogg.txt");
            System.IO.StreamWriter ShoppaLoggSkriverFull = new System.IO.StreamWriter(@"C:\Users\Bruker\Desktop\ShoppaLogg.txt");
            System.IO.StreamWriter ShoppaLoggSkriverFiltrert = new System.IO.StreamWriter(@"C:\Users\Bruker\Desktop\ShoppaLoggFiltrert.txt");

            //Lese fra loggen og splitte opp linjen
            string ShoppaLoggString = ShoppaLoggLeser.ReadToEnd();
            string[] ShoppaLoggStringSplittet = Regex.Split(ShoppaLoggString, "\r\n");

            //Hente inn datoene for de tre siste dagene
            string DagensDato = DateTime.Today.ToString("yyyy-MM-dd");
            string GårsDagensDato = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string TreDagerSidenDato = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd");

            //Filtrere linjene
            foreach (string split in ShoppaLoggStringSplittet)
            {
                //Henter ut de tre siste dagene fra loggen
                if (split.Contains(DagensDato) || split.Contains(GårsDagensDato) || split.Contains(TreDagerSidenDato))
                {
                    //Skriver linjene inn i tekstdokument som blir opprettet på skrivebordet
                    ShoppaLoggSkriverFull.WriteLine(split);
                    if (!split.Contains("*** STARTER EKSPORT ***") && !split.Contains("*** AVSLUTTER EKSPORT ***") && !split.Contains("automatisk kjede") &&
                        !split.Contains("[DEBUG] VareregisterDatabase: oasen@sql01.fastname.no") && !split.Contains("[DEBUG] Respons webservice:") &&
                        !split.Contains("ring via webservice (ws.mediablob.com)"))
                    {
                        ShoppaLoggSkriverFiltrert.WriteLine(split);
                        epost.Shoppa.Add(split);
                    }
                }
            }

            //Avslutter streamreader og streamwriter
            ShoppaLoggLeser.Close();
            ShoppaLoggSkriverFull.Close();
            ShoppaLoggSkriverFiltrert.Close();

            //Sletter logg filen som ble hentet i startet av søket
            System.IO.File.Delete(@"C:\Users\Bruker\Documents\ShoppaLogg.txt");
        }
    }
}
