-- ============================================================
-- Script creare baza de date: BibliotecaDB
-- Server: Azure SQL Database
-- ============================================================

-- Rulati acest script in Azure Query Editor sau SSMS

CREATE DATABASE BibliotecaDB;
GO

USE BibliotecaDB;
GO

-- ============================================================
-- Tabelul AUTORI
-- ============================================================
CREATE TABLE Autori (
    AutorID       INT IDENTITY(1,1) PRIMARY KEY,
    Nume          NVARCHAR(100) NOT NULL,
    Prenume       NVARCHAR(100) NOT NULL,
    DataNasterii  DATE          NULL,
    Nationalitate NVARCHAR(50)  NOT NULL DEFAULT 'Română',
    Biografie     NVARCHAR(MAX) NULL,
    DataAdaugare  DATETIME      NOT NULL DEFAULT GETDATE()
);

-- ============================================================
-- Tabelul CARTI
-- ============================================================
CREATE TABLE Carti (
    CarteID      INT IDENTITY(1,1) PRIMARY KEY,
    Titlu        NVARCHAR(200) NOT NULL,
    AutorID      INT           NOT NULL,
    ISBN         NVARCHAR(20)  NOT NULL UNIQUE,
    AnPublicare  INT           NOT NULL CHECK (AnPublicare >= 1000 AND AnPublicare <= 2100),
    Gen          NVARCHAR(50)  NOT NULL DEFAULT 'Roman',
    NrExemplare  INT           NOT NULL DEFAULT 1 CHECK (NrExemplare >= 0),
    NrDisponibil INT           NOT NULL DEFAULT 1 CHECK (NrDisponibil >= 0),
    DataAdaugare DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Carti_Autori FOREIGN KEY (AutorID) REFERENCES Autori(AutorID)
        ON UPDATE CASCADE ON DELETE RESTRICT
);

-- ============================================================
-- Tabelul IMPRUMUTURI
-- ============================================================
CREATE TABLE Imprumuturi (
    ImprumutID           INT IDENTITY(1,1) PRIMARY KEY,
    CarteID              INT           NOT NULL,
    NumeCititor          NVARCHAR(150) NOT NULL,
    CNPCititor           NVARCHAR(13)  NOT NULL,
    TelefonCititor       NVARCHAR(15)  NULL,
    DataImprumut         DATE          NOT NULL DEFAULT GETDATE(),
    DataReturnareEstimata DATE         NOT NULL,
    DataReturnareReala   DATE          NULL,
    Returnat             BIT           NOT NULL DEFAULT 0,
    TarifPenalitate      DECIMAL(6,2)  NOT NULL DEFAULT 0.50,  -- USD per zi
    DataInregistrare     DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Imprumuturi_Carti FOREIGN KEY (CarteID) REFERENCES Carti(CarteID)
        ON UPDATE CASCADE ON DELETE RESTRICT
);

GO

-- ============================================================
-- Date de test (seed data)
-- ============================================================
INSERT INTO Autori (Nume, Prenume, DataNasterii, Nationalitate, Biografie) VALUES
('Eminescu',  'Mihai',    '1850-01-15', 'Română',    'Poet național al României.'),
('Rebreanu',  'Liviu',    '1885-11-27', 'Română',    'Prozator realist, autor al romanului Ion.'),
('Tolkien',   'J.R.R.',   '1892-01-03', 'Britanică', 'Autor al Stăpânul Inelelor.'),
('Dostoievski','Feodor',  '1821-11-11', 'Rusă',      'Romancier clasic rus.'),
('Caragiale', 'I.L.',     '1852-01-30', 'Română',    'Dramaturg și prozator român.');

INSERT INTO Carti (Titlu, AutorID, ISBN, AnPublicare, Gen, NrExemplare, NrDisponibil) VALUES
('Luceafărul și alte poezii', 1, '978-973-46-0001-1', 1883, 'Poezie',   5, 4),
('Ion',                        2, '978-973-46-0002-2', 1920, 'Roman',    3, 3),
('Stăpânul Inelelor',          3, '978-973-46-0003-3', 1954, 'Fantasy',  4, 2),
('Crimă și Pedeapsă',          4, '978-973-46-0004-4', 1866, 'Roman',    2, 2),
('O scrisoare pierdută',       5, '978-973-46-0005-5', 1884, 'Dramă',    6, 6),
('Idiotul',                    4, '978-973-46-0006-6', 1869, 'Roman',    2, 1),
('Hobbit-ul',                  3, '978-973-46-0007-7', 1937, 'Fantasy',  3, 2);

INSERT INTO Imprumuturi (CarteID, NumeCititor, CNPCititor, TelefonCititor, DataImprumut, DataReturnareEstimata, DataReturnareReala, Returnat, TarifPenalitate) VALUES
(1, 'Popescu Ion',      '1900115123456', '0721000001', '2025-11-01', '2025-11-15', '2025-11-14', 1, 0.50),
(3, 'Ionescu Maria',    '2850227654321', '0731000002', '2025-12-01', '2025-12-15', NULL,          0, 0.50),
(6, 'Dumitrescu Andrei','1780503987654', '0741000003', '2025-12-10', '2025-12-24', NULL,          0, 0.75),
(7, 'Constantin Elena', '2920814246810', '0751000004', '2026-01-05', '2026-01-19', NULL,          0, 0.50),
(2, 'Stanescu Vlad',    '1850630135790', '0761000005', '2026-02-01', '2026-02-15', '2026-02-20', 1, 0.50);
GO

-- Index pentru cautari frecvente
CREATE INDEX IX_Carti_AutorID ON Carti(AutorID);
CREATE INDEX IX_Imprumuturi_CarteID ON Imprumuturi(CarteID);
CREATE INDEX IX_Imprumuturi_Returnat ON Imprumuturi(Returnat);
GO

PRINT 'Baza de date BibliotecaDB a fost creată cu succes!';
