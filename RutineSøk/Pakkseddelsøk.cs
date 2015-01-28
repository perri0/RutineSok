using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutineSøk
{
    public class Pakkseddelsøk
    {
        //Oppretter liste for alle filplasseringene
        public List<FileInfo> DirectoryList = new List<FileInfo>();

        //Oppretter en string liste for alle filplasseringene uner en path
        List<string> aktiv = new List<string>();

        public bool FeilMelding = false;

        public void PakkseddelSøkFunksjon(Epost epost)
        {
            try
            {
                //Definerer plasseringene og henter filene fra forskjellige fillokasjoner
                //Hoved handlingen. Endrer filplasseringene og kjører filtret. Til slutt skriver den ned til en fil
                aktiv.AddRange(System.IO.Directory.GetFiles(@"\\filserver\Oasen\LocalUser", "*", System.IO.SearchOption.AllDirectories).ToList());
                aktiv.AddRange(System.IO.Directory.GetFiles(@"\\filserver\Interflora\LocalUser", "*", System.IO.SearchOption.AllDirectories).ToList());
                aktiv.AddRange(System.IO.Directory.GetFiles(@"\\filserver\Floriss\LocalUser", "*", System.IO.SearchOption.AllDirectories).ToList());
                aktiv.AddRange(System.IO.Directory.GetFiles(@"\\filserver\Blomsterkroken\LocalUser", "*", System.IO.SearchOption.AllDirectories).ToList());
                FilFilter();
                ListeSkriver(epost);      
            }
            catch(Exception e) 
            {
               MessageBox.Show("Det oppstod en feil: " + e.Message);
               FeilMelding = true;
            }
        }

        public void FilFilter()
        {
            foreach (var Fil in aktiv)
            {
                try
                {
                    //Henter fil informasjonen til filen som er hentet.
                    var fileInfo = new FileInfo(Fil);

                    //Filtrerer vekk alle filer som ligger i mapper vi ikke ønsker.
                    if (!Fil.ToLower().Contains(@"\ikke innlest\") && !Fil.Contains(@"\bck\") && !Fil.Contains(@"\ListeSkriver\") && !Fil.ToLower().Contains(@"\sendt\") && !Fil.ToLower().Contains(@"\manuelt stoppet\"))
                    {
                        //Filtrerer ut filer som ikke er det vi er ute etter
                        if (fileInfo.CreationTime.Date != DateTime.Today && fileInfo.Length != 0 && fileInfo.Extension != ".jpg" && fileInfo.Extension != ".jpeg" && fileInfo.Extension != ".db")
                        {
                            //Legge til i listen
                            DirectoryList.Add(fileInfo);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Det oppstod en feil: " + e.Message);
                    FeilMelding = true;
                }

            }
        }

        public void ListeSkriver(Epost epost)
        {
            //starter en streamwriter
            System.IO.StreamWriter PakkseddelWriter = new System.IO.StreamWriter(@"C:\Users\Bruker\Desktop\RutinePakkseddelsøk.txt", true);

            //opprette en string for å unngå flere strings til samme mappe
            string DirectoryNameString = "";

            try
            {
                foreach (var Directory in DirectoryList)
                {
                    //Filtrerer vekk filer fra samme mappe
                    if (!Directory.DirectoryName.Equals(DirectoryNameString))
                    {
                        //Skriver path inn i tekst fil
                        PakkseddelWriter.WriteLine(Directory.DirectoryName);
                        //Noterer ned det siste path som gikk gjennom
                        DirectoryNameString = Directory.DirectoryName;
                        //
                        epost.Pakkseddel.Add(Directory.DirectoryName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Det oppstod en feil: " + e.Message);
                FeilMelding = true;
            }

            //avslutter streamwriter
            PakkseddelWriter.Close();
        }
    }
}