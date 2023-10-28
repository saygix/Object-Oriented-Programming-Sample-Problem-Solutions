using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize_Final
{
    class Program
    {
        //Dersi ilk defa alan öğrenciler için; derse gelmenin ve yapılan uygulamalarda artı almak, 
        //ödev notunu belirli oranda etkileyecektir. 
        //Dersi alttan alan öğrenciler içinse ödev notunun sadece ödevlerin ortalamasından verileceği belirtilmiştir.
        //Bu bilgiler işığı altında aşağıda kuralları belirtilen, başka sınıflar tarafından miras alınamayan sınıfı 
        //ve bu sınıfın bağlı olduğu(miras verdiği) interface'i oluşturun. 
        //(Sinif adı: DersHesap, Interface Adı: IDersHesap)

        //Vize (double), Ödev (double bir dizi şeklinde), Final (double), Derse Geliş Saat(int), 
        //Uygulama Artisi Sayısı (int), Dersi Alttan Alan (bool) değerlerini constructor(yapıcı) ile alın.
        public interface IDersHesap
        {
            double Vize { get; }
            double[] Odev { get; }
            double Final { get; }
            int DerseGelisSaati { get; }
            int UygulamaArtisi { get; }
            bool DersiAlttanAlan { get; }
        }
        public class DersHesap: IDersHesap
        {
            public double Vize { get; }
            public double[] Odev { get; }
            public double Final { get; }
            public int DerseGelisSaati { get; }
            public int UygulamaArtisi { get; }
            public bool DersiAlttanAlan { get; }
            public DersHesap(double vize, double[] odev, double final, int dersgelis, int uygulamaartisi, bool dersalt)
            {
                Vize = vize;
                Odev = odev;
                Final = final;
                DerseGelisSaati = dersgelis;
                UygulamaArtisi = uygulamaartisi;
                DersiAlttanAlan = dersalt;
            }
            //Uygulama notu hesaplayan fonksiyonu yazın. 
            //(Fonksiyon Adı: Uygulama NotHesapla). 
            //Derse geliş değerini 0.5 ile, uygulama artısını 3 ile çarpıp uygulama notunu double şeklinde gönderin. 
            //Hata yakalama kullanarak herhangi bir hata oluşması durumunda 0 dönderin. 
            //(Örneğin, 40 saat derse gelmiş ve 7 uygulama artısı almış bir öğrenci 40*0.5+7*3=41 puan kazanır.) 
            //Eğer, uygulama notu 100'den büyükse 100 değerini döndürün.
            public double UygulamaNotHesapla()
            {
                try
                {
                    double UygulamaNotu = DerseGelisSaati * 0.5 + UygulamaArtisi * 3;
                    if (UygulamaNotu>100)
                        return 100;
                    else       
                        return UygulamaNotu;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            //Odev notunu hesaplayan double tipinde property'i yazın. 
            //(Property adı: OdevNotu) Eğer dersi alttan alan bir oğrenci ise 
            //sadece dizi şeklinde gelen ödevlere verilen puanların ortalamasını alın. 
            //(Örneğin, 4 ödev verilmişse 80, 90, 70, 100 notlarını alan bir öğrencinin ortalaması 85'tir. 
            //Gelen dizideki ödevleri alıp ortalamasını hesaplayın. foreach döngüsü kullanılacaktır).
            //Dersi ilk defa alan bir öğrencinin uygulama notu fonksiyonundan dönen değer ve ödev notunu 
            //0.4 katsayısı ile çarparak toplayın.
            //(Yukarıdan 41 puan uygulama notu ve ödevden 85 alan bir öğrenci için 41+ 85 0.4 75 odev notunu alır.) 
            //Eğer, ödev notu 100'den büyükse 100 değerini döndürün.
            public double OdevNotu
            {
                get
                {
                   
                    if (Odev.Length == 0)
                        return 0;
                    double toplam = 0;
                    foreach (var not in Odev)
                    {
                        toplam += not;
                    }
                    double ortalama = toplam / Odev.Length;
                    if(ortalama>100)
                    {
                        return 100;
                    }
                    else
                    {
                        if (DersiAlttanAlan==true)
                            return ortalama;
                        else
                            
                        return UygulamaNotHesapla() + ortalama * 0.4;
                    }
                }
            }
            //Başarı notunu hesaplayan property'i yazın. 
            //(Property Adı: BasariNot) Ödev notu özelliğini (property) ve contructordan alınan vize ve final değerlerini 
            //kullanıp yukarıdaki şarta göre hesaplayın.
            public double BasariNot
            {
                get
                {
                    return OdevNotu * 0.2 + Vize * 0.3 + Final * 0.5;
                }
            }   
        }

        static void Main(string[] args)
        {
            // Örnek nesneleri oluşturun
            DersHesap dersiIlkDefaAlan = new DersHesap(70, new double[] { 80, 90, 70, 100 }, 75, 40, 7, false);
            DersHesap dersiAlttanAlan = new DersHesap(70, new double[] { 80, 90, 70, 100 }, 75, 40, 7, true);

            // Başarı notlarını ekrana yazdırın
            
            Console.WriteLine("Dersi İlk Defa Alan Öğrenci Başarı Notu: " + dersiIlkDefaAlan.BasariNot);
            Console.WriteLine("Dersi Alttan Alan Öğrenci Başarı Notu: " + dersiAlttanAlan.BasariNot);
            Console.WriteLine("Dersi İlk Defa Alan Öğrenci Odev Notu: " + dersiIlkDefaAlan.OdevNotu);
            Console.WriteLine("Dersi Alttan Alan Öğrenci Odev Notu: " + dersiAlttanAlan.OdevNotu);

            Console.ReadLine();
        }
    }
}
