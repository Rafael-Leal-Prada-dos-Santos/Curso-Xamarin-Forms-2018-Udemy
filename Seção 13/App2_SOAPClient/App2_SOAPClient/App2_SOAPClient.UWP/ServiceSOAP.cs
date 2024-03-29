﻿using App2_SOAPClient.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ServiceSOAP))]
namespace App2_SOAPClient.UWP
{
    public class ServiceSOAP : IServiceSOAP
    {
        //public string Somar(int num1, int num2)
        //{
        //    return (num1 + num2).ToString();
        //}

        public string Somar(int num1, int num2)
        {
            var serv = new ServicoWS.CalculatorSoapClient();
            var resultado = serv.AddAsync(num1, num2).GetAwaiter().GetResult();

            return "Resultado WS SOAP (UWP):" + resultado;
        }
    }
}
