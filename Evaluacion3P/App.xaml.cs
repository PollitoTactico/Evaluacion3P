using System;
using Evaluacion3P.Services;
namespace Evaluacion3P
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var paisService = new PaisSer();

            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
