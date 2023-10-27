using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NypOdev2
{
    class Program
    {
        public class LibraryBook
        {
            public string KitapKimligi { get; set; }
            public string Baslik { get; set; }
            public string Yazar { get; set; }
            public bool IsAvailable { get; set; }

            public LibraryBook(string kitapKimligi, string baslik, string yazar)
            {
                KitapKimligi = kitapKimligi;
                Baslik = baslik;
                Yazar = yazar;
                IsAvailable = true; // Kitap başlangıçta mevcut
            }
        }
        //Kütüphaneyi boş bir kitap koleksiyonuyla başlatan bir yapıcı.
        public class Kutuphane
        {
            private List<LibraryBook> kitapKoleksiyonu;

            public Kutuphane()
            {
                kitapKoleksiyonu = new List<LibraryBook>();
            }
            //Bir LibraryBook nesnesini parametre olarak alıp kütüphanenin koleksiyonuna ekleyen "AddBook" adlı bir yöntem.
            public void AddBook(LibraryBook kitap)
            {
                kitapKoleksiyonu.Add(kitap);
                Console.WriteLine($"{kitap.Baslik} kitabı kütüphaneye eklendi.");
            }
            //Belirtilen bir kitabı kütüphanenin koleksiyonundan kaldıran "RemoveBook" adlı yöntem.
            public void RemoveBook(string kitapKimligi)
            {
                LibraryBook kitap = kitapKoleksiyonu.Find(x => x.KitapKimligi == kitapKimligi);
                if (kitap != null)
                {
                    kitapKoleksiyonu.Remove(kitap);
                    Console.WriteLine($"{kitap.Baslik} kitabı kütüphaneden kaldırıldı.");
                }
                else
                {
                    Console.WriteLine("Belirtilen kitap kütüphanede bulunamadı.");
                }
            }
            //Kullanıcının kitap ödünç almasına olanak tanıyan "BorrowBook" adlı bir yöntem. 
            //Kitap mevcutsa kullanılabilirlik durumunu güncelleyin. 
            //Kitap mevcut değilse kitabın zaten ödünç alındığını belirten bir mesaj görüntüleyin.
            public void BorrowBook(string kitapKimligi)
            {
                LibraryBook kitap = kitapKoleksiyonu.Find(x => x.KitapKimligi == kitapKimligi);
                if (kitap != null)
                {
                    if (kitap.IsAvailable)
                    {
                        kitap.IsAvailable = false;
                        Console.WriteLine($"{kitap.Baslik} kitabı ödünç alındı.");
                    }
                    else
                    {
                        Console.WriteLine($"{kitap.Baslik} kitabı zaten ödünç alınmış.");
                    }
                }
                else
                {
                    Console.WriteLine("Belirtilen kitap kütüphanede bulunamadı.");
                }
            }
            //Kullanıcının ödünç aldığı kitabı iade etmesini sağlayan "ReturnBook" isimli yöntem.Kitabın kullanılabilirlik durumunu güncelleyin.
            public void ReturnBook(string kitapKimligi)
            {
                LibraryBook kitap = kitapKoleksiyonu.Find(x => x.KitapKimligi == kitapKimligi);
                if (kitap != null)
                {
                    kitap.IsAvailable = true;
                    Console.WriteLine($"{kitap.Baslik} kitabı iade edildi.");
                }
                else
                {
                    Console.WriteLine("Belirtilen kitap kütüphanede bulunamadı.");
                }
            }
        }
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();

            LibraryBook kitap1 = new LibraryBook("1", "Fatih Harbiye", "Peyami Safa");
            LibraryBook kitap2 = new LibraryBook("2", "Tutunamayanlar", "Oguz Atay");

            kutuphane.AddBook(kitap1);
            kutuphane.AddBook(kitap2);

            kutuphane.BorrowBook("1");
            kutuphane.BorrowBook("2");

            kutuphane.ReturnBook("1");

            kutuphane.RemoveBook("2");
            Console.ReadLine();
        }
    }
}
