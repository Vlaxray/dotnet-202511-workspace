public class Store 
{
	// public Phone phone { get; set; }
     public Phone[] Phones  { get; set; }
     public string Nome     { get; set; }

     public Store()
     {
        Phones = new Phone[10];
        Nome = "Negozio";
     }

     public void StampaTuttiTelefoni()
     {
        Console.WriteLine($"Elenco telefoni in vendita presso {Nome}:");
        foreach (var phone in Phones)
        {
            if (phone != null)
            {
                phone.MostraInformazioni();
                Console.WriteLine("-----------------------");
            }
        }
    }
     public void AddPhone(Phone phone)
    {
        for (int i = 0; i < Phones.Length; i++)
        {
            if (Phones[i] == null)
            {
                Phones[i] = phone;
                break;
            }
        }
    }
}