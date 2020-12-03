using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginXamarinMVOP
{
    public class NameRecord
    {
        public string Name { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        private NameRecord nr { get; set; }
        public string Jmeno { get; set; }
        public string Heslo { get; set; }
        public string Chyba { get; set; }

        public MainPage()
        {
            InitializeComponent();
            nr = new NameRecord();
            BindingContext = nr;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Jmeno = e_jmeno.Text;
            Heslo = e_heslo.Text;
            if (Kontrola(Heslo))
            {
                Application.Current.MainPage.Navigation.PushAsync(new Hello(nr));
            }
            else
            {
                DisplayAlert("Chyba", Chyba, "OK");
            }
        }

        private bool Kontrola(string heslo)
        {
            if (heslo.Length < 8)
            {
                Chyba = "Heslo musí mít alespoň 8 znaků";
                return false;
            }
            int pocet_cislic = 0;
            int pocet_sz = 0;
            foreach (var item in heslo)
            {
                if (item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9' || item == '0') pocet_cislic++;
                else
                {
                    byte i1 = Encoding.Default.GetBytes(item.ToString())[0];
                    for (int i = 32; i <= 64; i++)
                    {
                        if (i1 == i)
                        {
                            pocet_sz++;
                        }
                    }
                }
            }
            if (pocet_cislic == 0)
            {
                Chyba = "Heslo musí mít alespoň 1 číslici";
                return false;
            }
            if (pocet_sz == 0)
            {
                Chyba = "Heslo musí mít alespoň 1 speciální znak";
                return false;
            }
            return true;
        }
    }
}
