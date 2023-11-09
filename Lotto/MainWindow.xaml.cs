using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Lotto
{
    public partial class MainWindow : Window
    {
        List<LottoKupon> kupon = new List<LottoKupon>();
        public string stiTilKuponer = @"c:\lotto_kuponer\";

        private readonly SnowEngine snow = null;
        public MainWindow()
        {
            InitializeComponent();
            // Links skal rettes til korrekt placering på pc.
            snow = new SnowEngine(canvas, "G:\\Lotto\\Lotto\\graphics\\snow1.png",
                "G:\\Lotto\\Lotto\\graphics\\snow2.png",
                "G:\\Lotto\\Lotto\\graphics\\snow3.png",
                "G:\\Lotto\\Lotto\\graphics\\snow4.png",
                "G:\\Lotto\\Lotto\\graphics\\snow5.png",
                "G:\\Lotto\\Lotto\\graphics\\snow6.png",
                "G:\\Lotto\\Lotto\\graphics\\snow7.png",
                "G:\\Lotto\\Lotto\\graphics\\snow8.png",
                "G:\\Lotto\\Lotto\\graphics\\snow9.png");
            snow.Start();
        }

        

        private void Print_Knap_Click(object sender, RoutedEventArgs e)
        {
            printKnap.IsEnabled = false;
            printKnap.Visibility = Visibility.Hidden;
            doneLabel.Content = "";
            jokerJa.IsEnabled = false;
            jokerNej.IsEnabled = false;
            kuponSlider.IsEnabled = false;
            var rowGenerator = new RowsGenerator();

            for (int i = 0; i < kuponSlider.Value; i++)
            {
                DateTime date = DateTime.Now;
                string dateStr = date.ToString("dd-MM-yyyy");
                if (jokerJa.IsChecked == true)
                {
                    int[][] kuponNum = rowGenerator.GenerateRowsTilKupon();
                    int[][] jokerKuponNum = rowGenerator.GenerateJokerRowsTilKupon();
                    var kupon = new LottoKupon(dateStr, kuponNum, jokerKuponNum);
                    this.kupon.Add(kupon);
                }
                else
                {
                    int[][] kuponNum = rowGenerator.GenerateRowsTilKupon();
                    var kupon = new LottoKupon(dateStr, kuponNum);
                    this.kupon.Add(kupon);
                }
            }

            foreach (var kupon in kupon)
            {
                var tilTekst = new LavTekstFil(kupon, stiTilKuponer);
                tilTekst.TilTekstFil();
            }
            kupon.Clear();
            doneLabel.Content = "Udført";
            mineKuponer.IsEnabled = true;
        }

        private void afslut_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void minKupon_Click(object sender, RoutedEventArgs e)
        {
            SeKupon seWindow = new SeKupon(stiTilKuponer);
            seWindow.kuponListBoks.Items.Refresh();
            if (seWindow.kuponListBoks.Items.IndexOf(0).ToString() == "")
            {
                //seWindow.kuponListBoks.Items.Remove();
            }
            seWindow.Show();
        }
    }
}
