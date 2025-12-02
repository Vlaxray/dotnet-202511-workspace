-- Crea il database
CREATE DATABASE PalestraDB;
GO

USE PalestraDB;
GO

-- Tabella TipoAbbonamento (enum)
CREATE TABLE TipoAbbonamento (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL
);

-- Tabella StatoAbbonamento (enum)
CREATE TABLE StatoAbbonamento (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL
);

-- Tabella Abbonamenti
CREATE TABLE Abbonamento (
    Id INT PRIMARY KEY IDENTITY,
    Tipo INT NOT NULL,
    DataInizio DATE NOT NULL,
    DataScadenza DATE NULL,
    Prezzo DECIMAL(10,2) NOT NULL,
    Stato INT NOT NULL,
    FOREIGN KEY (Tipo) REFERENCES TipoAbbonamento(Id),
    FOREIGN KEY (Stato) REFERENCES StatoAbbonamento(Id)
);

-- Tabella Palestra
CREATE TABLE Palestra (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Indirizzo NVARCHAR(200),
    Telefono NVARCHAR(20),
    CapienzaMassima INT
);

-- Tabella Istruttore
CREATE TABLE Istruttore (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL,
    Cognome NVARCHAR(50),
    Specializzazione NVARCHAR(100),
    DataAssunzione DATE,
    PalestraId INT,
    FOREIGN KEY (PalestraId) REFERENCES Palestra(Id)
);

-- Tabella Corso
CREATE TABLE Corso (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Descrizione NVARCHAR(500),
    Orario NVARCHAR(50),
    DurataMinuti INT,
    MaxPartecipanti INT,
    PostiOccupati INT,
    IstruttoreId INT,
    FOREIGN KEY (IstruttoreId) REFERENCES Istruttore(Id)
);

-- Tabella Membro
CREATE TABLE Membro (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL,
    Cognome NVARCHAR(50),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
    DataIscrizione DATE,
    DataNascita DATE,
    AbbonamentoId INT,
    FOREIGN KEY (AbbonamentoId) REFERENCES Abbonamento(Id)
);

-- Tabella Notifica
CREATE TABLE Notifica (
    Id INT PRIMARY KEY IDENTITY,
    Tipo NVARCHAR(50),
    Messaggio NVARCHAR(500),
    DataInvio DATETIME,
    Letta BIT
);

-- Tabella Pagamento
CREATE TABLE Pagamento (
    Id INT PRIMARY KEY IDENTITY,
    DataPagamento DATETIME,
    Importo DECIMAL(10,2),
    MetodoPagamento NVARCHAR(50),
    Pagato BIT,
    AbbonamentoId INT,
    FOREIGN KEY (AbbonamentoId) REFERENCES Abbonamento(Id)
);

-- Tabella Esercizio
CREATE TABLE Esercizio (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    Descrizione NVARCHAR(500),
    Serie INT,
    Ripetizioni INT,
    RecuperoSecondi INT,
    Attrezzatura NVARCHAR(100),
    Tonnellaggio INT
);

-- Tabella SchedaAllenamento
CREATE TABLE SchedaAllenamento (
    Id INT PRIMARY KEY IDENTITY,
    Obbiettivi NVARCHAR(500),
    DataCreazione DATE,
    Livello NVARCHAR(50)
);

-- Tabella PartecipazioneCorso
CREATE TABLE PartecipazioneCorso (
    Id INT PRIMARY KEY IDENTITY,
    DataCorso DATETIME,
    Presente BIT,
    CorsoId INT,
    MembroId INT,
    FOREIGN KEY (CorsoId) REFERENCES Corso(Id),
    FOREIGN KEY (MembroId) REFERENCES Membro(Id)
);

-- Tabella esercizi per scheda (many-to-many)
CREATE TABLE SchedaEsercizio (
    SchedaId INT,
    EsercizioId INT,
    PRIMARY KEY (SchedaId, EsercizioId),
    FOREIGN KEY (SchedaId) REFERENCES SchedaAllenamento(Id),
    FOREIGN KEY (EsercizioId) REFERENCES Esercizio(Id)
);
