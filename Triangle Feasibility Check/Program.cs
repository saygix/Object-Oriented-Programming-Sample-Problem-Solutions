using System;
namespace Example
{
    class Program
    {
        class Ucgen
        {
            public double Kenar1 { get; set; }
            public double Kenar2 { get; set; }
            public double Kenar3 { get; set; }
            public Ucgen(double kenar1, double kenar2, double kenar3)
            {
                Kenar1 = kenar1;
                Kenar2 = kenar2;
                Kenar3 = kenar3;
            }
            public bool CizilirMi()
            {
                if (Kenar1 + Kenar2 > Kenar3 && Kenar1 + Kenar3 > Kenar2 && Kenar2 + Kenar3 > Kenar1)
                    if (Math.Abs(Kenar1 - Kenar2) < Kenar3 && Math.Abs(Kenar1 - Kenar3) < Kenar2 && Math.Abs(Kenar2 - Kenar3) < Kenar1)
                        return true;
                return false;
            }
        }
        static void Main(string[] args)
        {
            Ucgen ucgen = new Ucgen(6, 2, 13);
            Ucgen ucgen2 = new Ucgen(3, 4, 5);
            Console.WriteLine(ucgen.CizilirMi()+"\n"+ucgen2.CizilirMi());
            Console.Read();
        }
    }
}
