using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uppgift6MedKlasser
{

    public class inlägget  //deklarerar en klass med fyra element 
    {
        //jag vet inte vad är skillnaden mellan de här två sätt deklaration
        /*
        public string tid;
        public string titel;
        public string meddelande;
        public string mobilNummer;
        */
        public DateTime tid { get; set; }//DateTime variabel för tid.
        public string titel { get; set; }//string variabler för titeln och meddelandet.
        public string meddelande { get; set; }
        public int MobilNummer { get; set; } //int variabel för siffror.


    }
    class Program
    {


        static void Main(string[] args)
        {

            bool isRunning = true; //  deklarering isRunning for att använda med While loop

            List<inlägget> loggBok = new List<inlägget> { };// deklarerar en list typ "inlägget"

            DateTime tid = DateTime.Now;//deklarerar en "DateTime" variabel och Och sätta realtid i den för att använda med vektoren. 

            int menyVal = 0;//menyVal för att tillåta användaren välja

            while (isRunning) //använda while för att programmet ska förtsätta.
            {
                Console.Write("\n\n\n\tVälkommen till loggboken." +         //visa alla varianter för användaren.
                    "\n\t[1] Skriv ut alla loggar i loggboken." +
                    "\n\t[2] Skriv ett nytt inlägg i loggboken." +
                    "\n\t[3] Sök efter inlägg i loggboken." +
                    "\n\t[4] Rensa loggboken." +
                    "\n\t[5] Rensa specifik loggbok." +
                    "\n\t[6] Redigera specifik loggbok." +
                    "\n\t[7] Avsluta." +
                    "\n\t välj ett nummer : ");

                try  //använda try-catch metoden för att lösa fel inmatning problem och det hör till hela programmet ... och det är bättre än TryParse() och lättare, tror jag.
                {
                    menyVal = Convert.ToInt32(Console.ReadLine());  //användaren ska välja.


                    switch (menyVal)
                    {
                        case 1:  // visa alla loggar 
                                 // Jag har försökt med två "foreach" och två "for-loop" och med bara en "for-loop" med jag bara har lyckats med den här metoden. 
                            if (loggBok.Count == 0)
                            {
                                Console.WriteLine("\n\tÄr du seriös? Loggen är tom");
                            }
                            else
                            {


                                foreach (var item in loggBok)
                                {
                                    Console.WriteLine("\t" + item.tid + "\t" + item.titel + "\t" + item.meddelande + "\t" + item.MobilNummer);

                                }
                            }
                            break;

                        case 2:
                            inlägget myInlägg = new inlägget();//deklarerar en variabel av typ "inlägget"


                            myInlägg.tid = tid; //sätta in tiden i första element.

                            Console.Write("\tskriv in titeln: ");
                            myInlägg.titel = Console.ReadLine();//sätta in titeln i andra element.

                            Console.Write("\n\tskriv in ett meddelandet: ");
                            myInlägg.meddelande = Console.ReadLine();//sätta in meddelandet i tredje element.


                            //sätta in mobilnummer i sista element.
                            Console.Write("\n\tskriv in ett mobilnummer: ");
                            int mobilnummer = int.Parse(Console.ReadLine());
                            myInlägg.MobilNummer = mobilnummer;

                            //sätta in  "myInlägg" som är "inlägget-variabel" i "loggBok" som är list of "inlägget".
                            loggBok.Add(myInlägg);
                            break;

                        case 3:

                            Console.Write("\tVad letar du efter? ");

                            string sökord = Convert.ToString(Console.ReadLine()); //användaren ska skriva sökordet.
                            Console.WriteLine();//organisering syfte
                            bool hittaOrdet = false;//bool variabel för att använda med if-sats.

                            foreach (var item in loggBok)//för att gå igenom alla listor.
                            {
                                for (int i = 0; i < 4; i++)//att gå igenom alla elementer.
                                {
                                    if (Convert.ToString(item.tid) == sökord || item.titel == sökord || item.meddelande == sökord || Convert.ToString(item.MobilNummer) == sökord)
                                    {
                                        Console.WriteLine("\t" + item.tid + "\t" + item.titel + "\t" + item.meddelande + "\t" + item.MobilNummer);
                                        hittaOrdet = true;//för att undvika if-sata
                                        break;

                                    }
                                }

                            }
                            if (!hittaOrdet)//om programmet inte hitta sökordet ska programmet visa det
                                Console.WriteLine("\n\t {0} finns inte i loggboken!", sökord);


                            break;

                        case 4:
                            loggBok.Clear();//rensa loggboken
                            Console.WriteLine("\n\tLoggboken har rensats!");


                            break;


                        case 5:
                            Console.Write("\n\tdet finns {0} loggar, vilken vill du rensa? ", loggBok.Count);
                            int inläggSkarensa = Convert.ToInt16(Console.ReadLine());//avändaren ska välja vilken logg ska rensas.
                            if (inläggSkarensa <= loggBok.Count)//för att vara säker att användaren ska skriva ett nummer Inom intervallet.
                            {
                                Console.WriteLine("\tloggen nummer {0} har rensats!", inläggSkarensa);
                                loggBok.RemoveAt(inläggSkarensa - 1);//Rensa ett specifikt index.
                            }
                            else
                                Console.WriteLine("\tdet finns bara {0} loggar!", loggBok.Count());

                            break;

                        case 6:
                            Console.Write("\n\tdet finns {0} loggar, vilken vill du redigera? ", loggBok.Count);
                            int indexSkaRedigera = Convert.ToInt16(Console.ReadLine());//avändaren ska välja vilken logg ska ändras.
                            if (indexSkaRedigera <= loggBok.Count)//för att vara säker att användaren ska skriva ett nummer Inom intervallet.
                            {
                                //matta in en logg på samma sätt i "case 2"
                                inlägget nyInlägg = new inlägget();


                                nyInlägg.tid = tid;

                                Console.Write("\tskriv in titeln: ");
                                nyInlägg.titel = Console.ReadLine();

                                Console.Write("\n\tskriv in ett meddelandet: ");
                                nyInlägg.meddelande = Console.ReadLine();


                                Console.Write("\n\tskriv in ett mobilnummer: ");
                                int nymobilnummer = int.Parse(Console.ReadLine());
                                nyInlägg.MobilNummer = nymobilnummer;

                                //jag har rensat loggen och göra "insert" i samma plats
                                loggBok.Insert(indexSkaRedigera, nyInlägg);
                                loggBok.RemoveAt(indexSkaRedigera - 1);


                            }
                            else
                                Console.WriteLine("\tdet finns bara {0} loggar!", loggBok.Count());


                            break;

                        case 7:
                            isRunning = false;//ge while loop false värde för att avsluta loopet.
                            break;
                        default: // om användaren skriver ett annat nummer.
                            Console.WriteLine("\t matta in ett nummer mellan 1 och 7!");
                            break;
                    }
                }
                //programmet hoppar alltid till "catch" när det finns nåt fel 
                catch (FormatException)//FormatException betyder att användaren har inmatat  bokstaver istället av siffror.
                {
                    Console.WriteLine("\t\t\afel : inmatning foramt var felaktig, inmata siffror");
                }
                catch (Exception)//om nåt annat fel har hänt.
                {
                    Console.WriteLine("\t\t\afel : någonting gick fel, försök igen!");
                }

            }
        }
    }
}
