using System;

class Kesir
{
    private int tamsayi;
    private int pay;
    private int payda;

    public int Tamsayi
    {
        get { return tamsayi; }
        set { tamsayi = value; }
    }

    public int Pay
    {
        get { return pay; }
        set { pay = value; }
    }

    public int Payda
    {
        get { return payda; }
        set
        {
            if (value != 0)
                payda = value;
            else
                payda = 1;
        }
    }

    public Kesir(int tamsayi, int pay, int payda)
    {
        this.tamsayi = tamsayi;
        this.pay = pay;
        this.Payda = payda;
    }

    public Kesir(int pay, int payda)
    {
        this.tamsayi = 0;
        this.pay = pay;
        this.payda = payda;
    }

    public Kesir()
    {
        this.tamsayi = 0;
        this.pay = 0;
        this.payda = 1;
    }

    public void Reduce()
    {
        int ebob = Ebob(Math.Abs(pay), Math.Abs(payda));
        pay /= ebob;
        payda /= ebob;
    }

    private int Ebob(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static Kesir operator +(Kesir kesir1, Kesir kesir2)
    {
        int yeniPay1 = kesir1.tamsayi * kesir1.payda + kesir1.pay;
        int yeniPay2 = kesir2.tamsayi * kesir2.payda + kesir2.pay;
        int yeniPayda = kesir1.payda * kesir2.payda;

        int toplamPay = yeniPay1 * (yeniPayda / kesir1.payda) + yeniPay2 * (yeniPayda / kesir2.payda);

        Kesir sonuc = new Kesir(toplamPay, yeniPayda);
        sonuc.Reduce();
        return sonuc;
    }

    public override string ToString()
    {
        if (tamsayi == 0)
        {
            if (pay == 0)
                return "0";
            return $"{pay}/{payda}";
        }
        else
        {
            if (pay == 0)
                return tamsayi.ToString();
            return $"{tamsayi} {pay}/{payda}";
        }
    }

    public static Kesir operator *(Kesir kesir1, Kesir kesir2)
    {
        int yeniPay = (kesir1.tamsayi * kesir1.payda + kesir1.pay) * (kesir2.tamsayi * kesir2.payda + kesir2.pay);
        int yeniPayda = kesir1.payda * kesir2.payda;

        Kesir sonuc = new Kesir(yeniPay, yeniPayda);
        sonuc.Reduce();
        return sonuc;
    }
}

class FractionDemo
{
    static void Main()
    {
        Kesir kesir1 = new Kesir(1,1,2);
        Kesir kesir2 = new Kesir(2, 4);
        kesir1.Reduce();
        kesir2.Reduce();

        Console.WriteLine("Kesir 1: " + kesir1);
        Console.WriteLine("Kesir 2: " + kesir2);

        Kesir toplam = kesir1 + kesir2;
        Kesir carpim = kesir1 * kesir2;

        Console.WriteLine("Toplam: " + toplam);
        Console.WriteLine("Çarpım: " + carpim);
        Console.ReadLine();
    }
}
