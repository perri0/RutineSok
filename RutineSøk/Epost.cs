using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RutineSøk
{
    public class Epost

    {
        // Listene blir lagt inn i eposten for å lett bli redigert
        // Da trengs begge funksjonene å bli kjørt først
        public bool pakkseddelkjørt = false;
        public bool shoppakjørt = false;

        public List<string> Pakkseddel = new List<string>();
        public List<string> Shoppa = new List<string>();

        public void OpprettEpost()
        {
            var mail = new MailMessage();

            if (pakkseddelkjørt == true && shoppakjørt == true)
            {
                // Splittet listene opp i 2 strings for lettere å bli redigert
                string pakkseddelstring = "";
                foreach (string pakkseddellinje in Pakkseddel)
                {
                    pakkseddelstring += pakkseddellinje + System.Environment.NewLine;
                }
                string shoppa = "";
                foreach (string shoppalinje in Shoppa)
                {
                    shoppa += shoppalinje + System.Environment.NewLine;
                }

                // Sette inn info på selve mailen
                mail.To.Add("per.oddbjorn@touchsoft.no");
                System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("per.oddbjorn@touchsoft.no");
                mail.From = mailfrom;
                mail.Subject = "Ukentlig Rutine";

                // Body teksten
                string mailbody = "trond@touchsoft.no; kristoffer@touchsoft.no" + System.Environment.NewLine + "Vareregister:" + System.Environment.NewLine + pakkseddelstring + System.Environment.NewLine + "Shoppa:" + System.Environment.NewLine +
                    shoppa + System.Environment.NewLine + "Webrapport:" + System.Environment.NewLine + "Hageland:" + System.Environment.NewLine + System.Environment.NewLine + 
                    "Blomsterkroken:";
                mail.Body = mailbody;

                // Lagrer eposten som fil på skrivebordet for redigering
                SmtpClient client = new SmtpClient("smtp.domeneshop.no");
                client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                client.PickupDirectoryLocation = @"C:\Users\Bruker\Desktop\";
                client.Send(mail);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Du må først kjøre pakkseddelsøk og shoppasøk.");
            }
        }
    }
}
