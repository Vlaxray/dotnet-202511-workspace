using System;
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona2 = new();
            Console.WriteLine(persona2.ToString());   
            persona2.MostraInformazioni();
            Cane cane2 = new("Rex", "Grande", 5);
            Console.WriteLine(cane2.ToString());
            cane2.MostraInformazioni();
            Cane cane3 = new("Alfa", "Media", 3);
            Console.WriteLine(cane3.ToString());
            cane3.MostraInformazioni();
        }
    }
