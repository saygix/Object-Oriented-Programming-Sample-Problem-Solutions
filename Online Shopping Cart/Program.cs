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
            public string UrunKimligi { get; set; }
            public string UrunAdi { get; set; }
            public double Fiyat { get; set; }

            public Urun(string urunKimligi, string urunAdi, double fiyat)
            {
                UrunKimligi = urunKimligi;
                UrunAdi = urunAdi;
                Fiyat = fiyat;
            }
        }

        public class ShoppingCart
        {
            private List<Urun> sepet;

            public ShoppingCart()
            {
                sepet = new List<Urun>();
            }

            public void AddToCart(Urun urun)
            {
                sepet.Add(urun);
            }

            public void RemoveFromCart(string urunKimligi)
            {
                Urun urun = sepet.Find(x => x.UrunKimligi == urunKimligi);
                if (urun != null)
                {
                    sepet.Remove(urun);
                }
            }

            public double CalculateTotal()
            {
                double toplamMaliyet = 0;
                foreach (Urun urun in sepet)
                {
                    toplamMaliyet += urun.Fiyat;
                }
                return toplamMaliyet;
            }
        }

        static void Main(string[] args)
        {
            ShoppingCart sepet = new ShoppingCart();
            Urun yeniUrun = new Urun("444ab", "elbise", 100);

            // Ürünü sepete ekleyin
            sepet.AddToCart(yeniUrun);
            Console.WriteLine($"{yeniUrun.UrunAdi} sepete eklendi.");

            // Ürünü sepette bulup çıkarın
            sepet.RemoveFromCart("444ab");
            Console.WriteLine($"{yeniUrun.UrunAdi} sepetten çıkarıldı.");

            double toplamMaliyet = sepet.CalculateTotal();
            Console.WriteLine($"Toplam Maliyet: {toplamMaliyet:C}");
            Console.ReadLine();
        }
    }
}
