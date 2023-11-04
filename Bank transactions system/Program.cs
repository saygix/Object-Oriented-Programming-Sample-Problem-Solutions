using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bir bankanın müşterilerin banka hesaplarını göstermede kullanabileceği bir miras hiyerarşisi oluşturun.
//Bu bankadaki tüm müşteriler hesaplarına para yatırabilir ve hesaplarından para çekebilir.
//Daha spesifik hesap türleri de ayrıca bulunmaktadır.Örneğin müşteri parasını hesapta tuttukça mevduat miktarı artmaktadır.
//Hesap isminde bir ana sınıf ve bu sınıftan miras alan MevduatHesabi isimli sınıfı oluşturun.
//Hesap sınıfında bir decimal türde, private değişken tanımlayın, bu değişkende müşteri bakiyelerini tutun.
//Hesap sınıfında bir kurucu yazın, bu kurucu kanalı ile müşteriler ilk bakiyelerini tanımlayabilmektedirler. 
//Bir Özellik (property) yazın bu özellik kanalı ile hesap bakiyesinin 0'dan büyük veya eşit olup olmadığı kontrol edilmektedir.
namespace Bakiye
{
    class Program
    {
        public class Hesap
        {
            private decimal Bakiye;
            public Hesap(decimal baslangicbakiye)
            {
                Bakiye = baslangicbakiye;

            }
            public decimal bakiye
            {
                get { return Bakiye; }
                set { Bakiye = 0; if (value > 0) { Bakiye = value; } }
            }

//Public türde ParaYatir ve ParaCek metotlarını yazın.
//ParaCek metodu çekilmek istenen miktarı parametre olarak alsın ve hesapta bulunan 
//para miktarı çekilmek istenen tutar için yeterli ise(para çekildiğinde e'dan büyük bir meblağ kalıyorsa) 
//para çekmeye izin versin değilse işlemi gerçekleştirmesin ve kullanıcıya "Hesap yeterli değil" uyarısı versin.
//Parayatir metotu isminde anlaşıldığı üzere yatırılacak miktarı parametre olarak alsın ve mevduata bu değeri eklesin.
            public void ParaCek(decimal Cek_para)
            {
                if (Bakiye >= Cek_para)
                {
                    Bakiye -= Cek_para;
                }
                else
                {
                    Console.WriteLine("Hesap Yeterli Değil");
                }
            }
            public void ParaYatir(decimal Yat_para)
            {
                Bakiye += Yat_para;
            }
        }
//MevduatHesabı sınıfı Hesap sınıfından miras alsın 
//ve bu hesap içinde bir karoranı adlı bir değişken tanımlı olsun 
//bu oran mevduat hesabı sınıfından bir nesne yaratıldığında yapıcı(constructor) ile girilsin.
//Anlaşıldığı üzere bir mevduat hesabı oluşturulduğunda hem ilk mevduat miktarı hem de kar oranı 
//kullanıcı tarafından yapıcı (constructor) kanalı ile oluşturulmaktadır.
        public class MevduatHesabi:Hesap
        {
            private decimal KarOrani;
            public MevduatHesabi(decimal baslangicbakiye, decimal karorani):base(baslangicbakiye)
            {
                KarOrani = karorani;
            }
            //MevduatHesabı sınıfı içinde ayrıca FaizHesapla isimli bir metot yazın.
            //Bu metot geriye hesabın ne kadar kar getirdiğini göndersin.
            //Bu metotun geriye dönderdiği değer, karorani ile mevduatın çarpılması sonuci oluşturulsun. 
            //[NOT: MevduatHesabı sınıfı içinde parayatir ve paracek metotları oluşturulmayacak onlar Hesap sınıfından kullanılacaktır.]
            public decimal FaizHesapla()
            {
                return bakiye * KarOrani;
            }
        }
        static void Main(string[] args)
        {
            MevduatHesabi m = new MevduatHesabi(0, 1.2M);
            Console.WriteLine("Bakiye: " + m.bakiye);
            m.ParaYatir(10M);
            Console.WriteLine(m.bakiye);
            m.ParaCek(16M);
            Console.WriteLine(m.bakiye);
            Console.WriteLine("Faiz:" + m.FaizHesapla());
            Console.ReadLine();
        }
    }
}
