using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mouseMovDes.repos;
using Xamarin.Essentials;

namespace mouseMovDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class optionsPage : ContentPage
    {

        //private readonly Irepos interfaceRepso;
        
        

        MasterDetailPage main { get => Application.Current.MainPage as MasterDetailPage1; }

        public string IpString;
        public optionsPage()
        {
        
            InitializeComponent();

            ipEntry.Text = Preferences.Get("ip", "not set");

            //interfaceRepso = reposInerface;
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("ip", ipEntry.Text);
            

            //interfaceRepso.SenderVoid("Rc_");
            main.IsPresented = true;
        }
    }
}