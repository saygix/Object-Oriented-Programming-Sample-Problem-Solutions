using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NypOdev2
{
    class Program
    {
        public class Urun
        {
            public int UrunKimligi { get; set; }
            public string Ad { get; set; }
            public decimal Fiyat { get; set; }
            public int StokMiktari { get; set; }
            public Urun(int urunkimligi, string ad,decimal fiyat, int stokmiktari)
            {
                UrunKimligi = urunkimligi;
                Ad = ad;
                Fiyat = fiyat;
                StokMiktari = stokmiktari;
            }
            public void YenidenStok(int miktar)
            {
                StokMiktari += miktar;
            }
            public void Sat(int miktar)
            {
                StokMiktari -= miktar;
            }
        }
        public class Envanter
        {
            private List<Urun> urunler = new List<Urun>();
            public void AddProduct(Urun urun)
            {
                urunler.Add(urun);
                Console.WriteLine($"{urun.Ad} envantere eklendi.");
            }
            public void RemoveProduct(int urunID)
            {
                Urun urun = urunler.Find(u => u.UrunKimligi == urunID);
                if (urun != null)
                {
                    urunler.Remove(urun);
                    Console.WriteLine($"{urun.Ad} envanterden kaldırıldı.");
                }
                else
                {
                    Console.WriteLine($"Ürün kimliği {urunID} olan bir ürün bulunamadı.");
                }
            }
            public Urun GetProduct(int productID)
            {
                return urunler.Find(u => u.UrunKimligi == productID);
            }
            public decimal TotalValue()
            {
                decimal toplamDeger = 0;
                foreach (Urun urun in urunler)
                {
                    toplamDeger += urun.Fiyat * urun.StokMiktari;
                }
                return toplamDeger;
            }
        }
        static void Main(string[] args)
        {
            Envanter envanter = new Envanter();

            Urun urun1 = new Urun(1, "Laptop", 1500, 10);
            Urun urun2 = new Urun(2, "Telefon", 800, 20);
            Urun urun3 = new Urun(3, "Tablet", 500, 15);

            envanter.AddProduct(urun1);
            envanter.AddProduct(urun2);
            envanter.AddProduct(urun3);

            urun1.Sat(5);
            urun2.YenidenStok(10);
            urun3.Sat(20);

            Console.WriteLine($"Envanterin Toplam Değeri: ${envanter.TotalValue()}");

            // Ürünü envanterden kaldırma örneği
            envanter.RemoveProduct(2);
            // Ürünü envanterden kaldırdıktan sonra tekrar envantere eklemek
            Urun urun4 = new Urun(4, "Masaüstü Bilgisayar", 2000, 5);
            envanter.AddProduct(urun4);

            // Ürünü kimliğine göre almak
            int arananUrunID = 1;
            Urun arananUrun = envanter.GetProduct(arananUrunID);
            if (arananUrun != null)
            {
                Console.WriteLine($"Aranan ürün: {arananUrun.Ad}, Fiyat: {arananUrun.Fiyat}, Stok Miktarı: {arananUrun.StokMiktari}");
            }
            else
            {
                Console.WriteLine($"Ürün kimliği {arananUrunID} olan bir ürün bulunamadı.");
            }
            Console.ReadLine();
        }
    }
}
