public class Person {
	public int Eta { get; set; }
    public string Nome { get; set; }
    public bool HasHouse { get; set; }

    public Person()
    {
        Nome = "Mario";
        Eta = 25;   
        HasHouse = false;
    }
    public Person(string nome, int eta, bool house)
    {
        Nome = nome;
        Eta = eta;   
        HasHouse = house;
    }
    public override string ToString()
    {
        return $"Nome: {Nome}, Età: {Eta}, Casa: {HasHouse}";
    }
    
}