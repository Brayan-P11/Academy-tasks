USE task_negozio_270324;
-- DROP  database task_negozio_270324;





CREATE TABLE Categoria(
categoriaID INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100)UNIQUE NOT NULL,
);

CREATE TABLE Prodotto(
prodottoID INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100) NOT NULL,
marca VARCHAR(100) NOT NULL,
galleria VARCHAR(250)NOT NULL,
colore VARCHAR(100) NOT NULL,
taglia VARCHAR(100) NOT NULL,
categoriaRIF INT,
FOREIGN KEY (categoriaRIF) REFERENCES Categoria(categoriaID) ON DELETE SET NULL,
);

CREATE TABLE Utente(
utenteID INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100) NOT NULL,
cognome VARCHAR(100) NOT NULL,
email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Ordine(
ordineID INT PRIMARY KEY IDENTITY(1,1),
stato_ordine VARCHAR(100) NOT NULL CHECK (stato_ordine IN ('in lavorazione','spedito','in transito','consegnato')),
nome_prodotto VARCHAR(100) NOT NULL,
costo DECIMAL(5,2) NOT NULL CHECK (costo > 0.0),
data_emissione DATE NOT NULL,
quantita_ord INT NOT NULL,
utenteRIF INT,
FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID) ON DELETE SET NULL,
);

CREATE TABLE Ordine_Prodotto(
codiceID INT PRIMARY KEY IDENTITY(1,1),
ordineRIF INT NOT NULL,
prodottoRIF INT NOT NULL,
FOREIGN KEY (ordineRIF) REFERENCES Ordine(ordineID) ON DELETE CASCADE,
FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID) ON DELETE CASCADE,

);

CREATE TABLE Variazione(
variazioneID INT PRIMARY KEY IDENTITY(1,1),
prodottoRIF INT,
quantita_finale INT NOT NULL CHECK (quantita_finale > 0), -- quantita_finale - quantita_ord
prezzo_pieno DECIMAL(5,2) NOT NULL CHECK (prezzo_pieno > 0.0),
prezzo_offerta DECIMAL(5,2) CHECK (prezzo_offerta > 0.0),
inizio_offerta DATE,
fine_offerta DATE,
FOREIGN KEY (prodottoRIF) REFERENCES prodotto(prodottoID) ON DELETE SET NULL

);


SELECT * FROM Categoria;
SELECT * FROM Prodotto;
SELECT * FROM Utente;
SELECT * FROM Ordine;
SELECT * FROM Ordine_Prodotto;
SELECT * FROM Variazione;

--DROP TABLE Variazione;
--DROP TABLE Ordine_Prodotto;
--DROP TABLE Ordine;
--DROP TABLE Utente;
--DROP TABLE Prodotto;
--DROP TABLE Categoria;




-- INSERT Categoria
INSERT INTO Categoria (nome) VALUES 
	('Maglieria'),
	('Pantaloni'),
	('Gonne'),
	('Camicie'),
	('Accessori');

-- INSERT Prodotto
INSERT INTO Prodotto (nome, marca, galleria, colore, taglia, categoriaRIF) VALUES
	('Maglione Lana', 'Zara', 'https://picsum.photos/200/300', 'Blu', 'M', 1),
	('Jeans Skinny', 'Levi s', 'https://picsum.photos/200/300', 'Blu Scuro', 'S', 2),
	('Gonna Midi', 'H&M', 'https://picsum.photos/200/300', 'Nero', 'S', 3),
	('Camicia Oxford', 'Gap', 'https://picsum.photos/200/300', 'Bianco', 'L', 4),
	('Sciarpa in Cashmere', 'Uniqlo', 'https://picsum.photos/200/300', 'Grigio', 'Unica', 5),
	('Cardigan', 'Mango', 'https://picsum.photos/200/300', 'Beige', 'S', 1),
	('Pantaloni Chino', 'Dockers', 'https://picsum.photos/200/300', 'Verde Oliva', '32/34', 2),
	('Gonna a Tubino', 'Forever 21', 'https://picsum.photos/200/300', 'Rosso', 'XS', 3),
	('Camicia a Quadri', 'Abercrombie & Fitch', 'https://picsum.photos/200/300', 'Blu/Rosso', 'M', 4),
	('Cappello Fedora', 'Brixton', 'https://picsum.photos/200/300', 'Nero', 'M', 5);

-- INSERT Utente
INSERT INTO Utente (nome, cognome, email) VALUES 
	('Maria', 'Rossi', 'maria.rossi@email.com'),
	('Luca', 'Bianchi', 'luca.bianchi@email.com'),
	('Giulia', 'Verdi', 'giulia.verdi@email.com'),
	('Marco', 'Neri', 'marco.neri@email.com'),
	('Sara', 'Gialli', 'sara.gialli@email.com'),
	('Simone', 'Rosa', 'simone.rosa@email.com'),
	('Alessia', 'Blu', 'alessia.blu@email.com'),
	('Matteo', 'Arancio', 'matteo.arancio@email.com'),
	('Chiara', 'Viola', 'chiara.viola@email.com'),
	('Giovanni', 'Celeste', 'giovanni.celeste@email.com');

-- INSERT Ordine
INSERT INTO Ordine (stato_ordine, nome_prodotto, costo, data_emissione, quantita_ord, utenteRIF) VALUES
	('in lavorazione', 'Maglione Lana', 59.99, '2024-03-19', 1, 1),
	('consegnato', 'Jeans Skinny', 79.99, '2024-03-18', 1, 2),
	('spedito', 'Camicia Oxford', 39.99, '2024-03-17', 1, 3),
	('in transito', 'Gonna Midi', 29.99, '2024-03-16', 1, 4),
	('consegnato', 'Sciarpa in Cashmere', 49.99, '2024-03-15', 1, 5),
	('consegnato', 'Cardigan', 69.99, '2024-03-14', 1, 6),
	('consegnato', 'Pantaloni Chino', 59.99, '2024-03-13', 1, 7),
	('in lavorazione', 'Gonna a Tubino', 39.99, '2024-03-12', 1, 8),
	('consegnato', 'Camicia a Quadri', 44.99, '2024-03-11', 1, 9),
	('consegnato', 'Cappello Fedora', 29.99, '2024-03-10', 1, 10);

-- INSERT Ordine_Prodotto
INSERT INTO Ordine_Prodotto (ordineRIF, prodottoRIF) VALUES
	(1, 1),
	(2, 2),
	(3, 4),
	(4, 3),
	(5, 5),
	(6, 6),
	(7, 7),
	(8, 8),
	(9, 9),
	(10, 10);

-- INSERT Variazione
INSERT INTO Variazione (prodottoRIF, quantita_finale, prezzo_pieno, prezzo_offerta, inizio_offerta, fine_offerta) VALUES
	(1, 10, 79.99, NULL, NULL, NULL),
	(2, 15, 99.99, 79.99, '2024-03-19', '2024-03-26'),
	(3, 8, 59.99, NULL, NULL, NULL),
	(4, 20, 49.99, NULL, NULL, NULL),
	(5, 12, 69.99, NULL, NULL, NULL);


SELECT * FROM Categoria
JOIN Prodotto ON Categoria.categoriaID = Prodotto.categoriaRIF;