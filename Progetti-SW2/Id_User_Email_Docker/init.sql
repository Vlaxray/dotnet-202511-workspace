-- Crea database
CREATE DATABASE IF NOT EXISTS LibreriaDB;
USE CredenzialiDB;

-- Tabella Autori
CREATE TABLE IF NOT EXISTS CredenzialiDB (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Email VARCHAR(135) NOT NULL,
   
);


-- Dati di esempio
INSERT INTO CredenzialiDB (Id,Username, Email) VALUES
(1,'pincopallino', 'pincopallino@gmail.com'), 
(2,'mariorossi', 'mariorossi@hotmail.it'),
(3,'luigiverdi', 'luigiverdi@yahoo.it');
