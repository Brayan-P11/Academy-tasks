USE task_ferramenta_030424;

CREATE TABLE Prodotto(
prodottoID INT PRIMARY KEY IDENTITY(1,1),
codice VARCHAR(250) NOT NULL DEFAULT NEWID(),
nome VARCHAR(250) NOT NULL,
descrizione TEXT,
prezzo DECIMAL(10,2) NOT NULL CHECK (prezzo >= 0),
quantita INTEGER DEFAULT 0 CHECK (quantita >= 0),
categoria VARCHAR(250) NOT NUll UNIQUE ,
dataCreazione DATE DEFAULT CURRENT_TIMESTAMP,
);

DROP TABLE Prodotto;

INSERT INTO Prodotto (nome, descrizione, prezzo, quantita, categoria) VALUES
('chiave inglese', 'non è francese', 12.99 , 9, 'attrezzi'),
('trapano', 'trapanando...', 34.99 , 5, 'elettrico'),
('serratura', 'non si apre', 20.00 , 3, 'ferramenta');

SELECT * FROM Prodotto;