using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 RealEstateSalesperson ve GirlScout adlı sınıfları kullanarak nesneleri örnekleyen
SalespersonDemo adında bir program yazın. Her nesnenin bir SalesSpeech() yöntemini uygun
şekilde kullanabileceğini gösterin. Ayrıca her nesne için MakeSale() yöntemini iki veya üç
kez kullanın ve her nesnenin veri alanlarının son içeriğini görüntüleyin. Öncelikle Satış
Görevlisi adında soyut bir sınıf oluşturun. Alanlar ad ve soyadları içerir; Satış Görevlisi
yapıcısı bu değerlerin her ikisini de gerektirir. Alanlara ilişkin özellikleri ekleyin. Satış
Görevlisinin tam adını (boşlukla ayrılmış ad ve soyadı) içeren bir string döndüren bir yöntem
ekleyin. Daha sonra aşağıdaki görevleri gerçekleştirin:
•• Satış Görevlisinin iki alt sınıfını oluşturun: RealEstateSalesperson ve GirlScout.
RealEstateSalesperson sınıfı, dolar cinsinden satılan toplam değer ve kazanılan toplam
komisyona ilişkin alanları (her ikisi de 0 olarak başlatılmıştır) ve sınıf yapıcısının gerektirdiği
bir komisyon oranı alanını içerir. GirlScout sınıfı, satılan çerez kutularının sayısını tutacak ve
0 olarak başlatılan bir alan içerir. Her alan için özellikler ekleyin.
 •• İki yöntem içeren ISellable adında bir arayüz oluşturun: SalesSpeech() ve MakeSale().
Her RealEstateSalesperson ve GirlScout sınıfında, sınıftaki nesnelerin kullanabileceği uygun
bir veya iki cümlelik satış konuşmasını görüntülemek için SalesSpeech() uygulamasını
uygulayın.
RealEstateSalesperson sınıfında, bir ev için tamsayı dolar değerini kabul etmek, değeri
RealEstateSalesperson'ın satılan toplam değerine eklemek ve kazanılan toplam komisyonu
hesaplamak için MakeSale() yöntemini uygulayın. GirlScout sınıfında, satılan çerez
kutularının sayısını temsil eden bir tamsayıyı kabul etmek ve bunu toplam alana eklemek için
MakeSale() yöntemini uygulayın.
 */
namespace SalespersonQuestion
{
    class Program
    {
        abstract class Salesperson
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public Salesperson(string ad, string soyad)
            {
                Ad = ad;
                Soyad = soyad;
            }
            public string GetFullName()
            {
                return $"{Ad} {Soyad}";
            }
        }
        class RealEstateSalesperson: Salesperson, ISellable
        {
            public double ToplamDeger { get; private set; }
            public double ToplamKomisyon { get; private set; }
            public double KomisyonOrani { get; }
            public RealEstateSalesperson(string ad, string soyad, double komoran):base(ad, soyad)
            {
                KomisyonOrani = komoran;
            }
            public void MakeSale(int evdeger)
            {
                ToplamDeger += evdeger;
                ToplamKomisyon += evdeger * KomisyonOrani;
            }
            public string SalesSpeech()
            {
                return "Hayalinizdeki evi bulmanıza yardımcı olabilirim!";
            }
        }
        class GirlScout: Salesperson, ISellable
        {
            public double SatilanKutu { get; private set; }
            public GirlScout(string ad, string soyad):base(ad, soyad)
            {
                SatilanKutu =0;
            }
            public void MakeSale(int kutu)
            {
                SatilanKutu += kutu;
            }
            public string SalesSpeech()
            {
                return "Birkaç lezzetli kurabiye almak ister misin?";
            }
        }
        interface ISellable
        {
            string SalesSpeech();
            void MakeSale(int value);
        }

        static void Main(string[] args)
        {
            RealEstateSalesperson realEstateSalesperson = new RealEstateSalesperson("Ayşegül", "Saygı", 0.05);
            GirlScout girlScout = new GirlScout("Emma", "Smith");
            Console.WriteLine("Gayrimenkul Satış Elemanı:");
            Console.WriteLine(realEstateSalesperson.GetFullName());
            Console.WriteLine(realEstateSalesperson.SalesSpeech());
            realEstateSalesperson.MakeSale(250000); // Sell a house
            realEstateSalesperson.MakeSale(180000); // Sell another house
            Console.WriteLine("Toplam Satılan Değer: $" +
           realEstateSalesperson.ToplamDeger);
            Console.WriteLine("Kazanılan Toplam Komisyon: $" +
           realEstateSalesperson.ToplamKomisyon);
            Console.WriteLine();
            Console.WriteLine("Gözcü:");
            Console.WriteLine(girlScout.GetFullName());
            Console.WriteLine(girlScout.SalesSpeech());
            girlScout.MakeSale(50); 
            girlScout.MakeSale(30); 
            Console.WriteLine("Satılan Toplam Kutu: " + girlScout.SatilanKutu);
            Console.ReadLine();
        }
    }
}
