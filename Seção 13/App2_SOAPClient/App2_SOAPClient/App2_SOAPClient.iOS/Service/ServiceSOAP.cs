using App2_SOAPClient.iOS.Service;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ServiceSOAP))]
namespace App2_SOAPClient.iOS.Service
{
    //public class ServiceSOAP : IServiceSOAP
    //{
    //    public string Somar(int num1, int num2)
    //    {
    //        return (num1 + num2).ToString();
    //    }
    //}
    public string Somar(int num1, int num2)
    {
        var serv = new com.dneonline.www.Calculator();
        var resultado = serv.Add(num1, num2);

        return "Resultado WS SOAP:" + resultado;
    }

}