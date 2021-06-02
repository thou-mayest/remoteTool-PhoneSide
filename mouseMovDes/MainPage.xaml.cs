using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;
using Xamarin.Essentials;
using System.Threading;

namespace mouseMovDes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string ipString;
        public MainPage()
        {
            InitializeComponent();

            //NavigationPage options = new NavigationPage(new optionsPage());


            ////Navigation.PushModalAsync(options);




            //Application.Current.Properties.TryGetValue("ip", out object test);
            //DebugLabel.Text = test.ToString();


        }
        static IPEndPoint ip;
        public void SenderVoid(string msg)
        {
            //DebugLabel.Text = Preferences.Get("ip", "EROR");
            //DisplayAlert("titel", Preferences.Get("ip", "error"), "cancel"); 
            try
            {
                 ip = new IPEndPoint(IPAddress.Parse(Preferences.Get("ip", "default val")), 1997); // THIS SHOULD BE FIGURED OUT 
            }
            catch (Exception x)
            {

                DisplayAlert("Error","invalid ip adress specified please check options page","Ok") ;
            }
           

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (!server.Connected)
            {
                try
                {
                    server.SendTimeout = 100;
                    server.Connect(ip);
                }
                catch (Exception)
                {

                }
            }


            try
            {
                server.Send(Encoding.ASCII.GetBytes(msg));
            }
            catch (Exception x)
            {

            }
            server.Close();
            Thread.Sleep(10);

        }

        private void Button_Hold(object sender,EventArgs e)
        {
            SenderVoid("drag_");
        }

        private void Button_RightClick(object sender,EventArgs e)
        {
            SenderVoid("Rc_");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SenderVoid("click");
        }

        double LX, LY = 0;
        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType != GestureStatus.Completed)
            {
                SenderVoid("mmov_" + (e.TotalX - LX).ToString() + "_" + (e.TotalY - LY).ToString());
                //ERROR_LABEL.Text = e.TotalX.ToString();
            }
            else
            {
                //    LX = 0;
                //    LY = 0;
                //    ERROR_LABEL.Text = "complete " + e.TotalX.ToString();
            }


            LX = e.TotalX;
            LY = e.TotalY;

        }
    }
}
