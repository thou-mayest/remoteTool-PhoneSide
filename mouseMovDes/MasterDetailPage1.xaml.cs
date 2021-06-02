using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mouseMovDes.repos;

namespace mouseMovDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public Dictionary<int, Page> pages = new Dictionary<int, Page>();
        //private readonly Irepos interfaceRepos;
        public MasterDetailPage1()
        {
            InitializeComponent();

            
            pages.Add(2, new optionsPage());
            pages.Add(1, new Page1());
            pages.Add(0, new MainPage());

            Page startPage;
            pages.TryGetValue(2,out startPage);

            startPage.Title = "Option";
            Detail = new NavigationPage(startPage) { BarBackgroundColor = Color.FromHex("#6D1313") };



            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        Page page;
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage1MasterMenuItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            pages.TryGetValue(item.Id, out page);
            if(item.Title != null)
            {
                //DisplayAlert("titel", item.Title.ToString(), "cancel");
                page.Title = item.Title;
                
            }

            Detail = new NavigationPage(page) { BarBackgroundColor = Color.FromHex("#6D1313") } ;
           
            //DisplayAlert("titel", item.Id.ToString(),"cancel") ;
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

     
    }
}