-- Crea database
CREATE DATABASE IF NOT EXISTS LibreriaDB;
USE LibreriaDB;

-- Tabella Autori
CREATE TABLE IF NOT EXISTS Autori (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Cognome VARCHAR(100) NOT NULL,
    DataNascita DATE,
    Nazionalita VARCHAR(50),
    Email VARCHAR(150),
    DataCreazione TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    DataModifica TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Tabella Libri
CREATE TABLE IF NOT EXISTS Libri (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Titolo VARCHAR(200) NOT NULL,
    ISBN VARCHAR(13) UNIQUE NOT NULL,
    AnnoPubblicazione INT,
    Genere VARCHAR(50),
    Prezzo DECIMAL(10,2) DEFAULT 0.00,
    QuantitaDisponibile INT DEFAULT 0,
    AutoreId INT NULL,
    DataCreazione TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    DataModifica TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (AutoreId) REFERENCES Autori(Id) ON DELETE SET NULL
);

-- Dati di esempio
INSERT INTO Autori (Nome, Cognome, DataNascita, Nazionalita, Email) VALUES
('Umberto', 'Eco', '1932-01-05', 'Italiana', 'umberto.eco@example.com'),
('Italo', 'Calvino', '1923-10-15', 'Italiana', 'italo.calvino@example.com'),
('Alessandro', 'Manzoni', '1785-03-07', 'Italiana', 'alessandro.manzoni@example.com');

INSERT INTO Libri (Titolo, ISBN, AnnoPubblicazione, Genere, Prezzo, QuantitaDisponibile, AutoreId) VALUES
('Il Nome della Rosa', '9788804680385', 1980, 'Giallo Storico', 15.90, 10, 1),
('Il Pendolo di Foucault', '9788806146033', 1988, 'Romanzo', 18.50, 5, 1),
('Il Barone Rampante', '9788804667669', 1957, 'Romanzo', 12.99, 8, 2),
('Marcovaldo', '9788804579559', 1963, 'Racconti', 11.50, 12, 2),
('I Promessi Sposi', '9788804678528', 1827, 'Romanzo Storico', 14.99, 15, 3);