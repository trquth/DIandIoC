using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIandIocConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------DI and Ioc--------");
            //IoC: Chuyen khoi tao Phone instance ra ngoai Persion --> translating
            //var phone = new Phone();
            //DI
            var stupidPhone = new StupidPhone();
            var smartPhone = new SmartPhone();
            var user1 = new Person(stupidPhone);
            user1.UsePhone();
            var user2 = new Person(smartPhone);
            user2.UsePhone();
            Console.ReadLine();
        }
    }
    public class Person
    {
        //IoC :  Nhieu doi tuong cung dung chung 1 instance Phone ---> translating...
        //private readonly Phone _phone;
        //public Person(Phone phone)
        //{
        //_phone = phone;
        //}
        //DI
        private readonly IPhone _phone;
        public Person(IPhone phone)
        {
            _phone = phone;
        }

        //Truyen thong: Phone phone = new Phone() --> Moi user lai co mot loai dien thoai;
        public void UsePhone()
        {
            _phone.Call();
        }
    }
    //Dependency Injection
    public interface IPhone
    {
        void Call();
    }
    public class Phone
    {
        private int count = 0;
        public void Call()
        {
            Console.WriteLine("Value {0}", count++);
        }
    }
    //Implement IPhone
    public class StupidPhone : IPhone
    {
        private int count = 0;
        public void Call()
        {
            Console.WriteLine("Stupid Phone {0}", count++);
        }
    }
    public class SmartPhone : IPhone
    {
        private int count = 0;
        public void Call()
        {
            Console.WriteLine("Smart Phone {0}", count++);
        }
    }

}
