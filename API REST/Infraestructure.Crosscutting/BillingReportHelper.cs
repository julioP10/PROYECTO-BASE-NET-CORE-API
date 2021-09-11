using System;
using System.Globalization;

namespace Infraestructure.Crosscutting
{
    public class BillingReportHelper
    {

        public static string GetTitleReport(string reporttype, DateTime sendDate, string country, string additionalText)
        {
            var dataTime = sendDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            return $"{BillingReportConstant.TituloInformeFacturacion.ToUpper()} {dataTime} {country} {reporttype} {additionalText}";
        }

        public static string GetColor(string valueReal, string valueSla)
        {
            if (string.IsNullOrEmpty(valueSla))
                return string.Empty;

            if (string.IsNullOrEmpty(valueReal))
                return "color: red;";

            var diferencia = CalculateDifferenceInMinutes(valueReal, valueSla);

            return diferencia > 0 ? "color: red;" : string.Empty;
        }

        public static double CalculateDifferenceInMinutes(string hour1, string hour2)
        {
            if (string.IsNullOrEmpty(hour1) || string.IsNullOrEmpty(hour2))
                return 0;

            var timeSpan1 = TimeSpan.Parse(hour1);
            var timeSpan2 = TimeSpan.Parse(hour2);

            if (timeSpan1.Hours >= 0 && timeSpan1.Hours <= 12)
                timeSpan1 = timeSpan1.Add(new TimeSpan(0, 24, 0, 0));

            if (timeSpan2.Hours >= 0 && timeSpan2.Hours <= 12)
                timeSpan2 = timeSpan2.Add(new TimeSpan(0, 24, 0, 0));

            return timeSpan1.Subtract(timeSpan2).TotalMinutes;
        }


        public static string CalculateSpaceSecuence(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var quantityPoints = value.Split('.');
            string spaces = "";
            for (int i = 0; i < quantityPoints.Length - 1; i++)
            {
                spaces = spaces + "&nbsp;";
            }
            return $"{spaces}{value}";
        }


    }
    public class BillingReportConstant
    {

        public const string TituloInformeFacturacion = "Informe Factueración";

    }
}
