using System;
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone1 = new Phone();
            Console.WriteLine(phone1.ToString());
            
            Phone phone2 = new Phone("Samsung", "Galaxy S21", 799, false);
            Console.WriteLine(phone2.ToString());
            
            if(phone2.Prezzo < phone1.Prezzo)
            {
                Console.WriteLine("Samsung costa meno di Nokia");
                phone2.MostraInformazioni();
            }
            else
            {
                Console.WriteLine("Nokia costa meno di Samsung");
                phone1.MostraInformazioni();
            }
            
        }
    }
