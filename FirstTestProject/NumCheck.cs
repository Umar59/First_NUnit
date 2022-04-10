using System;

namespace NumCheck
{
    public class NumCheck
    {
        static void Main(string[] args)
        {
            ScanRepository scanner = new ScanRepository();
           Console.WriteLine( scanner.ScanSplitter(new MobliePhoneScan()));

        }

    }
    public class NumChercker
    {
        public bool isGreaterThanOne(int number)
        {
            if (number > 1) return true;
            return false;
        }
    }
    public interface IScanner
    {
        public string Scanner();
    }

    public class PrinterScan : IScanner
    {
        public string Scanner()
        {
            return "PrinterScan";
        }
    }
    public class LaserScan : IScanner
    {
        public string Scanner()
        {
            return "LaserScan";
        }
    }
    public class MobliePhoneScan : IScanner
    {
        public string Scanner()
        {
            return "MobliePhoneScan";
        }
    }
    public class ScanRepository
    {
        public string ScanSplitter(IScanner scan)
        {
            string originalString = scan.Scanner();
            string splittedString = originalString;

            for (int i = 0; i < originalString.Length; i++)
            {
                char ch = originalString[i];
                if (((ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9')) && i > 0)
                {
                    splittedString = originalString.Insert(i , " ");
                    originalString = splittedString;
                    i++;
                }
            }

            return splittedString;

        }
    }

}
