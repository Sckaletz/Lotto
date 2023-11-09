using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Lotto
{
    public partial class SeKupon : Window
    {
        public string Sti;

        public SeKupon(string sti)
        {
            this.Sti = sti;
            InitializeComponent();

            DirectoryInfo dinfo = new DirectoryInfo(sti);
            FileInfo[] Filer = dinfo.GetFiles("*.txt");

            foreach (FileInfo fil in Filer)
            {
                StreamReader sr = new StreamReader(fil.FullName);
                List<string> linje = new List<string>();
                while (!sr.EndOfStream)
                {
                    linje.Add(sr.ReadLine());
                }

                if (fil.OpenText().ReadToEnd().Contains("*"))
                {
                    kuponListBoks.Items.Add((linje[0] + "\n\n" + linje[1] + "    " + linje[2] + "\n" + " " + linje[3] + "\n" + linje[4] + "\n" + " " + linje[5] + "\n" + " " + linje[6] + "\n" + " " + linje[7] + "\n" + " " + linje[8] + "\n" + " " + linje[9] + "\n" + " " + linje[10] + "\n" + " " + linje[11] + "\n" + " " + linje[12] + "\n" + " " + linje[13] + "\n" + linje[14] + "\n\n" + linje[16] + "\n" + linje[17] + "\n" + linje[18] + "\n\n\n\n"));
                }
                else
                {
                    kuponListBoks.Items.Add(("\n\n" + linje[0] + "\n\n" + linje[1] + "    " + linje[2] + "\n" + " " + linje[3] + "\n" + linje[4] + "\n" + " " + linje[5] + "\n" + " " + linje[6] + "\n" + " " + linje[7] + "\n" + " " + linje[8] + "\n" + " " + linje[9] + "\n" + " " + linje[10] + "\n" + " " + linje[11] + "\n" + " " + linje[12] + "\n" + " " + linje[13] + "\n" + linje[14] + "\n\n\n\n"));
                }
            }
        }

        private void rydFolderKnap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Sti);
            FileInfo[] filer = dinfo.GetFiles();
            foreach (var fil in filer)
            {
                fil.Delete();
            }
            kuponListBoks.Items.Clear();
        }

        private void tilbageKnap_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gemTekstKnap_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", Sti);
        }

        private void gemPfdKnap_Click(object sender, RoutedEventArgs e)
        {
            var lavPdf = new KuponPDF(Sti);
            lavPdf.AddKupon();
            Process.Start("explorer.exe", Sti);
        }
    }

}