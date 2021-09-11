using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Xml.Linq;

namespace Infraestructure.Crosscutting
{
    public static class VersionHelper
    {
        public static string GetVersionOfObject(string currentVersion, string stringSource, string stringDestination, bool IsNewVersion)
        {
            var objectSource = JToken.Parse(JsonConvert.SerializeXNode(XDocument.Parse(stringSource).FirstNode,
                Formatting.Indented, true));

            var objectDestination = JToken.Parse(JsonConvert.SerializeXNode(XDocument.Parse(stringDestination).FirstNode,
                Formatting.Indented, true));

            var diff = new JsonDiffPatch();
            JToken diffResult = diff.Diff(objectSource, objectDestination);

            return GetVersionNumber(diffResult, currentVersion, IsNewVersion);
        }

        private static string GetVersionNumber(JToken difference, string currentVersion, bool IsNewVersion)
        {
            int differenceNumbers = 0;
            if (difference != null)
                differenceNumbers = difference.Children().Count();


            var numbersVersion = currentVersion.Split(".").Select(p => int.Parse(p)).ToList();

            if (differenceNumbers == 0 && !IsNewVersion)
                return currentVersion;
            else if (differenceNumbers == 0 && IsNewVersion)
                numbersVersion[2] += 1;
            else if (differenceNumbers < 10)
                numbersVersion[2] += 1;
            else if (differenceNumbers > 10 && differenceNumbers < 20)
                numbersVersion[1] += 1;
            else numbersVersion[0] += 1;

            return string.Join(".", numbersVersion);
        }
    }
}