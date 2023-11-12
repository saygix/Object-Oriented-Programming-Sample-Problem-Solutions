using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Finalsorusu
{
    class Program
    {
        abstract class Employee: IPayable
        {
            public string Adi { get; }
            public string Soyadi { get; }
            public string SosyalGuvenlikNo { get; }

            public Employee(string adi, string soyadi, string sgn)
            {
                Adi = adi;
                Soyadi = soyadi;
                SosyalGuvenlikNo = sgn;
            }

            public abstract decimal Earnings();

            public override string ToString()
            {
                return "Adı ve Soyadı: " + Adi + " " + Soyadi + "\nSosyal Güvenlik Numarası: " + SosyalGuvenlikNo;
            }
            public abstract decimal GetPaymentAmount();
        }

        class SalariedEmployee : Employee
        {
            public decimal Weeklysalary { get; }

            public SalariedEmployee(string adi, string soyadi, string sgn, decimal weeklysalary) : base(adi, soyadi, sgn)
            {
                Weeklysalary = weeklysalary;
            }

            public override decimal Earnings()
            {
                return Weeklysalary;
            }

            public override string ToString()
            {
                return base.ToString() + "\nHaftalık Çalışma Saati: " + Weeklysalary;
            }
            public override decimal GetPaymentAmount()
            {
                return Earnings();
            }
        }

        class HourlyEmployee : Employee
        {
            public decimal Wage;
            public decimal Hours;

            public decimal wage
            {
                get { return Wage; }
                set
                {
                    if (value < 0) Console.WriteLine("Ücret negatif olamaz.");
                    Wage = value;
                }
            }

            public decimal hours
            {
                get { return Hours; }
                set
                {
                    if (value < 0 || value > 168) Console.WriteLine("Saatler 0 ile 168 arasında olmalıdır.");
                    Hours = value;
                }
            }

            public HourlyEmployee(string adi, string soyadi, string sgn, decimal wage, decimal hours) : base(adi, soyadi, sgn)
            {
                Wage = wage;
                Hours = hours;
            }
            public override decimal Earnings()
            {
                if (Hours <= 40)
                {
                    return Wage * Hours;
                }
                else
                {
                    return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
                }
            }
            public override string ToString()
            {
                return base.ToString() + "Ucret:" + Wage + "Haftalık Toplam Çalışma Süresi:" + Hours;
            }
            public override decimal GetPaymentAmount()
            {
                return Earnings();
            }
        }
        class CommissionEmployee : Employee
        {
            public decimal SatısMiktari { get; }
            public decimal KomisyonOrani { get; }
            public CommissionEmployee(string adi, string soyadi, string sgn, decimal satismiktari, decimal komisyonorani) : base(adi, soyadi, sgn)
            {
                SatısMiktari = satismiktari;
                KomisyonOrani = komisyonorani;
            }
            public override decimal Earnings()
            {
                return SatısMiktari * KomisyonOrani;
            }
            public override string ToString()
            {
                return base.ToString() + "Satış Miktarı" + SatısMiktari + "Komisyon Oranı:" + KomisyonOrani;
            }
            public override decimal GetPaymentAmount()
            {
                return Earnings();
            }

        }
        public interface IPayable
        {
            decimal GetPaymentAmount();
        }
        static void Main(string[] args)
        {
            // Çalışan nesnelerini oluşturun
            Employee salariedEmployee = new SalariedEmployee("John", "Doe", "123-45-6789", 1000.00M);
            Employee hourlyEmployee = new HourlyEmployee("Jane", "Smith", "987-65-4321", 12.50M, 45);
            Employee commissionEmployee = new CommissionEmployee("Bob", "Johnson", "456-78-9012", 5000.00M, 0.05M);

            // Her çalışanın bilgilerini görüntüleyin
            Console.WriteLine(salariedEmployee.ToString());
            Console.WriteLine($"Kazanç: {salariedEmployee.GetPaymentAmount():C}");

            Console.WriteLine(hourlyEmployee.ToString());
            Console.WriteLine($"Kazanç: {hourlyEmployee.GetPaymentAmount():C}");

            Console.WriteLine(commissionEmployee.ToString());
            Console.WriteLine($"Kazanç: {commissionEmployee.GetPaymentAmount():C}");
            Console.ReadLine();
        }
    }
}


