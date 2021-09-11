using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Crosscutting
{
    public static class UtilsFunction
    {
        public static string getPrice(decimal precio, decimal precioconDescuento)
        {
            if (precioconDescuento>0)
            {
                var total = precio - precioconDescuento;
                var currency = total.ToString("n2");
                return currency;
            }
            else
            {
                return precio.ToString("n2");
            }
        }

        public static string getDiscount(decimal precio, decimal precioconDescuento)
        {
            if (precio>0 && precioconDescuento>0)
            {
                var cal = (precioconDescuento * 100) / precio;
                return $"{Math.Round(cal)}%";
            }
            else
            {
                return "0%";
            }
        }
    }
}
