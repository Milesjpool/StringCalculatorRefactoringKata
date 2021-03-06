using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Collections;
using System.Text.RegularExpressions;

namespace Stringcalculator
{
    public abstract class Csv
    {
        protected string CsvText;

        protected Csv(string csvText)
        {
            CsvText = csvText;
        }

        public static Csv Read(string csvText)
        {
            //if (csvText.StartsWith(CustomDelimiterIndicator))
            //{
            //    return new CustomDelimitedCsv(csvText);
            //}
            return new DefaultDelimitedCsv(csvText);
        }

        protected abstract char[] Delimiters { get; }

        protected abstract string Text { get; }

        public IList<string> GetIndividualElements()
        {
            return Text.Split(Delimiters);
        }
    }


    public class DefaultDelimitedCsv : Csv
    {
        private static readonly char[] DefaultDelimiters = {'\n', ','};

        public DefaultDelimitedCsv(string csvText)
            : base(csvText)
        {
        }

        protected override char[] Delimiters
        {
            get { return DefaultDelimiters; }
        }

        protected override string Text
        {
            get { return CsvText; }
        }
    }

    public class CustomDelimitedCsv
    {
        private const int DelimiterSpecifierLength = 4;
        private static readonly Regex CustomDelimiterCapture = new Regex(@"//(.)\n");

        //public CustomDelimitedCsv(string csvText)
        //    : base(csvText)
        //{
        //}

        //protected override char[] Delimiters
        //{
        //    get { return GetCustomDelimiter(CsvText); }
        //}

        //protected override string Text
        //{
        //    get { return CsvText.Substring(DelimiterSpecifierLength); }
        //}

        private static char[] GetCustomDelimiter(string csv)
        {
            return CustomDelimiterCapture.Match(csv).Captures[0].Value.ToCharArray();
        }
    }
}