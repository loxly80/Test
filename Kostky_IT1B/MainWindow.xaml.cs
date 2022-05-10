using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kostky_IT1B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Kostka[] kostky = new Kostka[6];
        //kostky[0] = new Kostka();
        //kostky[1] = new Kostka();
        //kostky[2] = new Kostka();
        //kostky[3] = new Kostka();
        //kostky[4] = new Kostka();
        //kostky[5] = new Kostka();

        Kostka[] kostky = new Kostka[] {
            new Kostka(),
            new Kostka(),
            new Kostka(),
            new Kostka(),
            new Kostka(),
            new Kostka()
        };

        public MainWindow()
        {
            InitializeComponent();
            ZobrazKostky();

        }

        private ImageSource GetImage(byte[] resource)
        {
            MemoryStream memoryStream = new MemoryStream(resource);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }

        private void ZobrazKostku(Rectangle rectangle, int cislo)
        {
            if (cislo == 1)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_one));
            }
            else if (cislo == 2)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_two));
            }
            else if (cislo == 3)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_three));
            }
            else if (cislo == 4)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_four));
            }
            else if (cislo == 5)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_five));
            }
            else if (cislo == 6)
            {
                rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.dice_six));
            }
        }

        private void ZobrazKostky()
        {
            ZobrazKostku(k1, kostky[0].Hodnota);
            ZobrazKostku(k2, kostky[1].Hodnota);
            ZobrazKostku(k3, kostky[2].Hodnota);
            ZobrazKostku(k4, kostky[3].Hodnota);
            ZobrazKostku(k5, kostky[4].Hodnota);
            ZobrazKostku(k6, kostky[5].Hodnota);
        }

        private void btnHod_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var kostka in kostky)
            //{
            //    kostka.Hod();
            //}
            kostky[0].Hodnota = 4;
            kostky[1].Hodnota = 4;
            kostky[2].Hodnota = 4;
            kostky[3].Hodnota = 4;
            kostky[4].Hodnota = 1;
            kostky[5].Hodnota = 5;
            ZobrazKostky();
            lblBody.Content = $"Body: {SpocitejBody(kostky)}";
        }

        private int SpocitejBody(Kostka[] kostky)
        {
            int body = 0;
            Dictionary<int, int> pocty = new Dictionary<int, int>();
            pocty.Add(1, 0);
            pocty.Add(2, 0);
            pocty.Add(3, 0);
            pocty.Add(4, 0);
            pocty.Add(5, 0);
            pocty.Add(6, 0);

            foreach (var kostka in kostky)
            {
                pocty[kostka.Hodnota]++;
            }

            if (pocty.ContainsValue(6)) //něceho je 6
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 6).Key;
                if (kostka == 1)
                {
                    body = 8000;
                }
                else
                {
                    body = kostka * 800;
                }
            }
            else if (pocty.ContainsValue(5)) //něčeho je 5
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 5).Key;
                if (kostka == 1) //je 5 jedniček
                {
                    body = 4000;                   
                }
                else
                {
                    body = kostka * 400;
                    body += 100 * pocty[1];                    
                }
                body += 50 * pocty[5];
            }
            else if (pocty.ContainsValue(4)) //něčeho je 4
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 4).Key;
                if (kostka == 1) //je 4 jedniček
                {
                    body = 2000;                    
                }
                else
                {
                    body = kostka * 200;
                    body += 100 * pocty[1];                    
                }
                body += 50 * pocty[5];
            }
            else if (pocty.ContainsValue(3)) //něčeho je 3
            {
                var kostka = pocty.First(hodnota => hodnota.Value == 3).Key;
                if (kostka == 1) //je 3 jedniček
                {
                    body = 1000;
                }
                else
                {
                    body = kostka * 100;
                }
                int pocetTrojic = 0;
                foreach(var pocet in pocty)
                {
                    if(pocet.Value == 3)
                    {
                        pocetTrojic++;
                    }
                }
            }
            return body;
        }

        public int PocetHodnot(Dictionary<int,int> pocty, int hodnota)
        {
            int pocetHodnot = 0;
            foreach (var pocet in pocty)
            {
                if (pocet.Value == hodnota)
                {
                    pocetHodnot++;
                }
            }
            return pocetHodnot;
        }
    }
}
