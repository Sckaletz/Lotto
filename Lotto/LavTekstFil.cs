using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class LavTekstFil
    {
        private LottoKupon Kupon;
        private string Sti;
        private string filNavn = "kupon";

        public LavTekstFil(LottoKupon kupon, string sti)
        {
            this.Kupon = kupon;
            this.Sti = sti;
            if (Directory.Exists(Sti) == false)
            {
                Directory.CreateDirectory(Sti);
            }
        }

        public void TilTekstFil()
        {
            string tmpFilNavn = filNavn;
            int increment = 0;
            Directory.SetCurrentDirectory(Sti);
            while (File.Exists(tmpFilNavn + ".txt"))
            {
                increment++;
                if (File.Exists(tmpFilNavn + increment + ".txt") == false)
                {
                    tmpFilNavn += increment;
                }
            }
            using (StreamWriter sw = new StreamWriter(tmpFilNavn + ".txt"))
            {
                sw.WriteLine("     LOTTO " + Kupon.TimeStamp + "\n");
                sw.WriteLine("          " + Kupon.Week);
                sw.WriteLine("        " + Kupon.Title + "\n");
                int count = 1;
                foreach (var row in Kupon.Rows)
                {
                    if (count < 10)
                        sw.Write(" " + count + ". ");
                    else
                        sw.Write(count + ". ");
                    count++;
                    foreach (var item in row)
                    {
                        if (item > 9)
                            sw.Write(item + " ");
                        else 
                            sw.Write("0" + item + " ");
                    }
                    sw.WriteLine();
                }
                if (Kupon.JokerRows.Length > 0)
                {
                    sw.WriteLine("\n***** JOKER TAL *****");
                    foreach (var row in Kupon.JokerRows)
                    {
                        sw.Write("     ");
                        foreach (var item in row)
                        {
                            sw.Write(item + " ");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
