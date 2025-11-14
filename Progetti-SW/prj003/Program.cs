
{
string msg = "";

{ // inizio blocco
    int x = 100;
    Console.WriteLine(x);
    msg = "Ciaoo!";
} // fine blocco

{ // inizio blocco
    int x = 200; 
    Console.WriteLine(x);
    msg = msg + "Mondo!";
} // fine blocco

Console.WriteLine(msg);
}