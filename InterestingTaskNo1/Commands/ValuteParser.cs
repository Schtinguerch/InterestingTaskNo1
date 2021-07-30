using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace InterestingTaskNo1
{
    class ValuteParser : Command
    {
        private const string _url = "http://www.cbr.ru/scripts/XML_daily.asp";

        public override string Name { get; set; } = "valute";

        public override void Run(List<string> arguments)
        {
            var date = arguments[0].Replace(".", "/");
            var valuteCode = arguments[1].ToUpper();

            var client = new WebClient();
            var data = client.DownloadString($"{_url}?date_req={date}").Replace("\\", "");

            var xmlPattern = $"<CharCode>{valuteCode}</CharCode><Nominal>(.*?)</Nominal><Name>(.*?)</Name><Value>(.*?)</Value>";
            var match = Regex.Match(data, xmlPattern);

            var valuteNominal = Convert.ToDouble(match.Groups[1].Value);
            var valuteValue = Convert.ToDouble(match.Groups[3].Value);

            Console.WriteLine($"In {date}: 1 {valuteCode} = {valuteValue / valuteNominal} RUB");
        }
    }
}
