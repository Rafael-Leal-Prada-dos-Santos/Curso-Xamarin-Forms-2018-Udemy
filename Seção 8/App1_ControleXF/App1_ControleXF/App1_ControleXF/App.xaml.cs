﻿using App1_ControleXF.Menu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Master());
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
