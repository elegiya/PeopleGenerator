using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using PeopleGenerator.ViewModels;
using Xamarin.Forms;

namespace PeopleGenerator.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new PeopleViewModel();
        }
    }
}
