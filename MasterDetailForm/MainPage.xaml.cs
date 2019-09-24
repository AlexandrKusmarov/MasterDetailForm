using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetailForm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public static Dictionary<String, String> currencies = new Dictionary<String, String>();
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new NoteEntryPage())
            {
                BarBackgroundColor = Color.FromHex("#8ea6e2")
            };

            IsPresented = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Calculator())
            {
                BarBackgroundColor = Color.FromHex("#8ea6e2")
            };
            IsPresented = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new NoteEntryPage())
            {
                BarBackgroundColor = Color.FromHex("#8ea6e2")
            };
            IsPresented = false;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Currencies())
            {
                BarBackgroundColor = Color.FromHex("#8ea6e2")
            };
            IsPresented = false;
            Currencies curr = new Currencies();
            currencies = curr.parseCurrency();
        }
    }
}
