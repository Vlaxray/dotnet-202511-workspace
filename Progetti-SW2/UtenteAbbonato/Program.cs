var u = new Utente("Mario Rossi", 600);
var f = new UtenteAbbonato("Luigi Bianchi", 600);

u.PrendiInPrestito(new Libro("Il signore degli anelli", 150));
u.PrendiInPrestito(new Libro("I promessi sposi", 170));  
u.PrendiInPrestito(new Libro("La divina commedia", 250));
u.PrendiInPrestito(new Rivista("Gazzetta dello sport", 180, 20));
u.PrendiInPrestito(new Rivista("Gazzetta dello sport", 230, 20));
f.PrendiInPrestito(new Libro("Il signore degli anelli", 150));
f.PrendiInPrestito(new Libro("I promessi sposi", 170));  
f.PrendiInPrestito(new Libro("La divina commedia", 250));
f.PrendiInPrestito(new Libro("La divina commedia", 250));
f.PrendiInPrestito(new Libro("La divina commedia", 250));
f.PrendiInPrestito(new Rivista("Gazzetta dello sport", 180, 20));
f.PrendiInPrestito(new Rivista("Gazzetta dello sport", 230, 20));


Console.WriteLine(u);
Console.WriteLine(f);

var libro = u.LibriInPrestito[0];
libro= f.LibriInPrestito[0];
u.RestituisciLibro(libro);
f.RestituisciLibro(libro);
Console.WriteLine("Restituito: " + libro);
