﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2_SOAPClient.Droid.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(ServiceSOAP))]
namespace App2_SOAPClient.Droid.service
{
    public class ServiceSOAP : IServiceSOAP
    {
        //public string Somar(int num1, int num2) 
        //{
        //    return (num1 + num2).ToString();
        //}

        public string Somar(int num1, int num2)
        {
            var serv = new com.dneonline.www.Calculator();
            var resultado = serv.Add(num1, num2);

            return "Resultado WS SOAP:" + resultado;
        }
    }
}