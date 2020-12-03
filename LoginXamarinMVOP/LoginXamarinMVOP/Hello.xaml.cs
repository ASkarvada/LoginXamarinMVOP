using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginXamarinMVOP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hello : ContentPage
    {
        public Hello()
        {
            InitializeComponent();
        }

        public Hello(NameRecord nr)
        {
            InitializeComponent();
            BindingContext = nr;
        }
    }
}