using System;

class Alna // primitive example
{
    static int ConvertHoursToDeg(int h)
    {
        int res = 0;
        if (h >= 0 && h < 12)
            res = 30 * h;
        else if (h < 24)
            res = 30 * h / 2;
        else if (h == 12 || h == 24)
            res = 0;
        else Console.WriteLine("Error, enter hours in 24 hour format (0-24).");

        return res;
    }

    static int ConvertMinutesToDeg(int m)
    {
        int res = 0;
        if (m >= 0 && m < 60)
            res = m * 6;
        else Console.WriteLine("Error, enter minutes between 0 and 59.");
        return res;
    }

    static double CalculateDegrees(int h, int m)
    {
        double hExtraDegFromMinutes = m * 0.5; // 1 minute = 0.5 deg on hour arrow.
        double Hdeg = Convert.ToDouble(ConvertHoursToDeg(h)) + hExtraDegFromMinutes;
        double Mdeg = Convert.ToDouble(ConvertMinutesToDeg(m));
        double res = Math.Abs(Hdeg - Mdeg);
        if (res > 180) res = 360 - res;
        return res;
    }

    static int DealWithInput(string str)
    {
        int res;
        while (!Int32.TryParse(str, out res))
        {
            Console.WriteLine("Error write only numbers");
            str = Console.ReadLine();
        }

        return res;
    }

    static void Menu() {

        int h, m;

        Console.WriteLine("Enter hours in 24 hour format.");

        Console.WriteLine("Hours:");
        h = DealWithInput(Console.ReadLine());
      
        Console.WriteLine("Minutes:");
        m = DealWithInput(Console.ReadLine());

        var res = CalculateDegrees(h, m);

        Console.WriteLine("result : " + String.Format("{0:0.00}", res));
    }

    static void Main(string[] args)
    {
        Menu();
    }
}