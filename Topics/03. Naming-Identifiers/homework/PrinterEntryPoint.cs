//Task 1. class_123 in C#

using System;

class PrinterEntryPoint
{
    const int MaxCount = 6;
    class Printer
    {
        public void ConsolePrinter(bool valueToPrint)
        {
            string variableAsString = valueToPrint.ToString();
            Console.WriteLine(variableAsString);
        }
    }

    public static void Main()
    {
        EntryPoint.Printer printer = new EntryPoint.Printer();
        printer.ConsolePrinter(true);
    }
}

