using System;
using System.Linq;

namespace Infraestructure.Crosscutting
{
    public class NameHelper
    {
        public static string GetNameCopy(string name, string[] allName, bool copy = true)
        {
            var nameCopy = string.Empty;
            string copia = copy ? "- copia" : "";
            if (allName.Length > 0)
            {
                for (int i = 2; i < allName.Length + 3; i++)
                {

                    if (!allName.Contains($"{name} {copia} ({i})"))
                    {
                        nameCopy = $"{name} {copia} ({i})";
                        break;
                    }

                }
            }
            else
            {
                nameCopy = $"{name} {copia}";
            }

            return nameCopy;
        }


    }
}
