using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace challengecalculator.Classes
{
    public class Delimeters
    {
        private List<string> delimeters = new List<string> { ",", "\n" };
        private string[] delimeterFormatList = { @"^\/\/(.)\n", @"^\/\/(\[(.*?)\])+\n" };

        private string inputArgs;

        public Delimeters(string inputArgs, string delimeter)
        {
            this.inputArgs = inputArgs;

            if (!string.IsNullOrEmpty(delimeter))
            {
                this.delimeters.Add(delimeter);
            }
        }

        /*
         * Gets a list of delimeters
         *
         * @return []<string>
         */
        public string[] Get()
        {
            foreach (var delimeterFormat in delimeterFormatList)
            {
                var matchResult = Regex.Match(this.inputArgs, delimeterFormat);

                if (matchResult.Success)
                {
                    var regexCapturesList = matchResult.Groups[matchResult.Groups.Count - 1].Captures;

                    foreach (var capture in regexCapturesList)
                    {
                        delimeters.Add(capture.ToString());
                    }
                }
            }

            return delimeters.ToArray();
        }
    }
}
