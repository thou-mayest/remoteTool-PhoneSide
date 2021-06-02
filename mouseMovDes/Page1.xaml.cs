using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Sockets;
using System.Net;
using Xamarin.Essentials;
using System.Threading;

namespace mouseMovDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            
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
            catch (Exception)
            {

                DisplayAlert("Error", "invalid ip adress specified please check options page", "Ok");
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

        private void VolUp_Clicked(object sender, EventArgs e)
        {
            SenderVoid("volum_up");
        }

        private void Mute_Clicked(object sender, EventArgs e)
        {
            SenderVoid("volum_mute");
        }

        private void VolDown_Clicked(object sender, EventArgs e)
        {
            SenderVoid("volum_down");
        }

        private void SendTxt_Clicked(object sender, EventArgs e)
        {
            SenderVoid("Butt_" + KeyboardEntry.Text);
        }

        private void BackSpce_Clicked(object sender, EventArgs e)
        {

            SenderVoid("Butt_" + "__backspace");
            KeyboardEntry.Text = "";
        }

        private void Enter_Clicked(object sender, EventArgs e)
        {
            SenderVoid("ENTER_sim");
        }
    }
}