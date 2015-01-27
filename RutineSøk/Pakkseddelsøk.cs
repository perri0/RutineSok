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
        public List<FileInfo> directory = new List<FileInfo>();
        //Oppretter en string array for alle filplasseringene uner en path
        string[] aktiv { get; set; }

        public bool FeilMelding = false;

        public void FinneFiler(Epost epost)
        {
            try
            {
                //Definerer plasseringene og henter filene fra forskjellige fillokasjoner
                //Hoved handlingen. Endrer filplasseringene og kjører filtret. Til slutt skriver den ned til en fil
                aktiv = System.IO.Directory.GetFiles(@"\\filserver\Oasen\LocalUser", "*", System.IO.SearchOption.AllDirectories); 
                Filtrer();

                aktiv = System.IO.Directory.GetFiles(@"\\filserver\Interflora\LocalUser", "*", System.IO.SearchOption.AllDirectories); 
                Filtrer();

                aktiv = System.IO.Directory.GetFiles(@"\\filserver\Floriss\LocalUser", "*", System.IO.SearchOption.AllDirectories); 
                Filtrer();

                aktiv = System.IO.Directory.GetFiles(@"\\filserver\Blomsterkroken\LocalUser", "*", System.IO.SearchOption.AllDirectories);
                Filtrer();

                NoterNedPath(epost);      
            }
            catch(Exception e) 
            {
               MessageBox.Show("Det oppstod en feil: " + e.Message);
               FeilMelding = true;
            }
        }

        public void Filtrer()
        {
            foreach (var filedirectory in aktiv)
            {
                try
                {
                    //Henter fil informasjonen til filen som er hentet.
                    var fileInfo = new FileInfo(filedirectory);

                    //Filtrerer vekk alle filer som ligger i mapper vi ikke ønsker.
                    if (!filedirectory.ToLower().Contains(@"\ikke innlest\") && !filedirectory.Contains(@"\bck\") && !filedirectory.Contains(@"\NoterNedPath\") && !filedirectory.ToLower().Contains(@"\sendt\") && !filedirectory.ToLower().Contains(@"\manuelt stoppet\"))
                    {
                        //Filtrerer ut filer som ikke er det vi er ute etter
                        if (fileInfo.CreationTime.Date != DateTime.Today && fileInfo.Length != 0 && fileInfo.Extension != ".jpg" && fileInfo.Extension != ".jpeg" && fileInfo.Extension != ".db")
                        {
                            //Legge til i listen
                            directory.Add(fileInfo);
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

        public void NoterNedPath(Epost epost)
        {
            //starter en streamwriter
            System.IO.StreamWriter rutine = new System.IO.StreamWriter(@"C:\Users\Bruker\Desktop\RutinePakkseddelsøk.txt", true);

            //opprette en string for å unngå flere strings til samme mappe
            string DirectoryNameString = "";

            try
            {
                foreach (var linje in directory)
                {
                    //Filtrerer vekk filer fra samme mappe
                    if (!linje.DirectoryName.Equals(DirectoryNameString))
                    {
                        //Skriver path inn i tekst fil
                        rutine.WriteLine(linje.DirectoryName);
                        //Noterer ned det siste path som gikk gjennom
                        DirectoryNameString = linje.DirectoryName;
                        //
                        epost.Pakkseddel.Add(linje.DirectoryName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Det oppstod en feil: " + e.Message);
                FeilMelding = true;
            }

            //avslutter streamwriter
            rutine.Close();
        }
    }
}