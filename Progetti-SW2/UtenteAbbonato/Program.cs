var u = new Utente("Mario Rossi", 600);

u.PrendiInPrestito(new Libro("Il signore degli anelli", 150));
u.PrendiInPrestito(new Libro("I promessi sposi", 170));  
u.PrendiInPrestito(new Libro("La divina commedia", 250));
u.PrendiInPrestito(new Rivista("Gazzetta dello sport", 180, 20));

Console.WriteLine(u);

var libro = u.LibriInPrestito[0];
u.RestituisciLibro(libro);
Console.WriteLine("Restituito: " + libro);
