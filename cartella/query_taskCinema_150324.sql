CREATE TABLE Cinema (
	CinemaID INT PRIMARY KEY,
	Nome VARCHAR (100) NOT NULL,
	Indirizzo VARCHAR (255) NOT NULL,
	Phone VARCHAR (20)
);
 

CREATE TABLE Theater (
	TheaterID INT PRIMARY KEY,
	CinemaID INT,
	Nome VARCHAR(50) NOT NULL,
	Capacity INT NOT NULL,
	ScreenType VARCHAR(50),
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);


CREATE TABLE Movie (
	MovieID INT PRIMARY KEY,
	Title VARCHAR(255) NOT NULL,
	Director VARCHAR(100),
	ReleaseDate DATE,
	DurationMinutes INT,
	Rating VARCHAR(5)
);


CREATE TABLE Showtime (
	ShowtimeID INT PRIMARY KEY,
	MovieID INT,
	TheaterID INT,
	ShowDateTime DATETIME NOT NULL,
	Price DECIMAL(5,2) NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
);


CREATE TABLE Customer (
	CustomerID INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100),
	PhoneNumber VARCHAR(20)
);


CREATE TABLE Ticket (
	TicketID INT PRIMARY KEY,
	ShowtimeID INT,
	SeatNumber VARCHAR(10) NOT NULL,
	PurchasedDateTime DATETIME NOT NULL,
	CustomerID INT,
	FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);


CREATE TABLE Review (
	ReviewID INT PRIMARY KEY,
	MovieID INT,
	CustomerID INT,
	ReviewText TEXT,
	Rating INT CHECK (Rating >= 1 AND Rating <= 5),
	ReviewDate DATETIME NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);


CREATE TABLE Employee (
	EmployeeID INT PRIMARY KEY,
	CinemaID INT,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Position VARCHAR(50),
	HireDate DATE,
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);



-- INSERT 
/*
Cinema
Theater
Movie
Showtime
Customer
Ticket
Review
Employee
*/

USE task_albergo_130324;
SELECT * FROM Cinema;
SELECT * FROM Theater;
SELECT * FROM Movie;
SELECT * FROM Showtime;
SELECT * FROM Customer;
SELECT * FROM Ticket;
SELECT * FROM Review;
SELECT * FROM Employee;

DROP TABLE Employee;
DROP TABLE Review;
DROP TABLE Ticket;
DROP TABLE Customer;
DROP TABLE Showtime;
DROP TABLE Movie;
DROP TABLE Theater;
DROP TABLE Cinema;


-- CREATE VIEW 
INSERT INTO Cinema (CinemaID, Nome, Indirizzo, Phone) VALUES 
(1,'nome1','via della mela 1', '1234567891'),
(2,'nome2','via della pera 2', '1234567892'),
(3,'nome3','via della banana 3', '1234567893');

INSERT INTO Theater (TheaterID, CinemaID, Nome, Capacity, ScreenType) VALUES
(1, 1, 'sala 1', 200,  'screentype1'),
(2, 1, 'sala 2', 400,  'screentype2'),
(3, 1, 'sala 3', 300,  'screentype4'),
(4, 2, 'sala 1', 150,  'screentype1'),
(5, 2, 'sala 2', 210,  'screentype2'),
(6, 3, 'sala 1', 300,  'screentype3'),
(7, 3, 'sala 2', 350,  'screentype4');

INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating)
VALUES 
    (1, 'Interstellar', 'Christopher Nolan', '2014-11-05', 169, 'PG-13'),
    (2, 'The Matrix', 'Lana Wachowski, Lilly Wachowski', '1999-03-31', 136, 'R'),
    (3, 'The Lord of the Rings: The Return of the King', 'Peter Jackson', '2003-12-17', 201, 'PG-13'),
    (4, 'The Dark Knight Rises', 'Christopher Nolan', '2012-07-20', 164, 'PG-13'),
    (5, 'Avatar', 'James Cameron', '2009-12-18', 162, 'PG-13'),
    (6, 'Inglourious Basterds', 'Quentin Tarantino', '2009-08-21', 153, 'R'),
    (7, 'The Shawshank Redemption', 'Frank Darabont', '1994-10-14', 142, 'R'),
    (8, 'The Godfather', 'Francis Ford Coppola', '1972-03-24', 175, 'R'),
    (9, 'Forrest Gump', 'Robert Zemeckis', '1994-07-06', 142, 'PG-13'),
    (10, 'Pulp Fiction', 'Quentin Tarantino', '1994-10-14', 154, 'R');



INSERT INTO Showtime (ShowtimeID, MovieID, TheaterID, ShowDateTime, Price)
VALUES 
    (1, 1, 1, '2024-15.03 18:00:00', 10.00),
    (2, 2, 1, '2024-15-03 20:30:00', 12.50),
    (3, 3, 2, '2024-16-03 15:45:00', 9.00),
    (4, 4, 2, '2024-16-03 19:00:00', 11.00),
    (5, 5, 3, '2024-17-03 21:15:00', 13.50),
    (6, 1, 3, '2024-17-03 17:30:00', 10.00),
    (7, 2, 4, '2024-18-03 16:00:00', 12.50),
    (8, 3, 4, '2024-18-03 20:45:00', 9.00),
    (9, 4, 5, '2024-19-03 18:20:00', 11.00),
    (10, 5, 5, '2024-19-03 21:00:00', 13.50);


INSERT INTO Customer (CustomerID, FirstName, LastName, Email, PhoneNumber)
VALUES
    (1, 'Marco', 'Rossi', 'marco.rossi@example.com', '1234567890'),
    (2, 'Anna', 'Bianchi', 'anna.bianchi@example.com', '0987654321'),
    (3, 'Luca', 'Verdi', 'luca.verdi@example.com', '111222333'),
    (4, 'Giulia', 'Ferrari', 'giulia.ferrari@example.com', '444555666'),
    (5, 'Simone', 'Russo', 'simone.russo@example.com', '777888999'),
    (6, 'Laura', 'Esposito', 'laura.esposito@example.com', '222333444'),
    (7, 'Giovanni', 'Romano', 'giovanni.romano@example.com', '555666777'),
    (8, 'Sara', 'Gallo', 'sara.gallo@example.com', '888999000'),
    (9, 'Alessandro', 'Costa', 'alessandro.costa@example.com', '999000111'),
    (10, 'Elena', 'Barbieri', 'elena.barbieri@example.com', '333444555');


INSERT INTO Ticket (TicketID, ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID)
VALUES
    (1, 1, 'A1', '2024-15-03 17:45:00', 1),
    (2, 2, 'B3', '2024-15-03 20:00:00', 2),
    (3, 3, 'C5', '2024-16-03 15:30:00', 3),
    (4, 4, 'D2', '2024-16-03 18:45:00', 4),
    (5, 5, 'E7', '2024-17-03 20:45:00', 5),
    (6, 6, 'F9', '2024-17-03 17:15:00', 6),
    (7, 7, 'G4', '2024-18-03 16:30:00', 7),
    (8, 8, 'H8', '2024-18-03 20:00:00', 8),
    (9, 9, 'I10', '2024-19-03 17:45:00', 9),
    (10, 10, 'J6', '2024-19-03 21:30:00', 10);


INSERT INTO Review (ReviewID, MovieID, CustomerID, ReviewText, Rating, ReviewDate)
VALUES
    (1, 1, 1, 'Un capolavoro assoluto. Perfetto in ogni aspetto.', 5, '2024-15-03 21:00:00'),
    (2, 2, 2, 'Emozionante e coinvolgente. Uno dei miei preferiti.', 4, '2024-16-03 10:30:00'),
    (3, 3, 3, 'Bellissimo film. Mi ha toccato profondamente.', 5, '2024-17-03 14:45:00'),
    (4, 4, 4, 'Un classico del cinema. Grandi interpretazioni.', 5, '2024-18-03 19:20:00'),
    (5, 5, 5, 'Incredibile! Christopher Nolan non delude mai.', 4, '2024-19-03 22:15:00'),
    (6, 1, 6, 'Un film che ha lasciato il segno. Bravi tutti.', 4, '2024-20-03 11:00:00'),
    (7, 2, 7, 'Davvero bello. Un film che fa riflettere.', 4, '2024-21-03 09:30:00'),
    (8, 3, 8, 'Emozionante e commovente. Assolutamente da vedere.', 5, '2024-22-03 16:45:00'),
    (9, 4, 9, 'Un capolavoro del cinema. Iconico.', 5, '2024-23-03 20:30:00'),
    (10, 5, 10, 'Fantastico! Effetti speciali incredibili.', 4, '2024-24-03 23:00:00');


INSERT INTO Employee (EmployeeID, CinemaID, FirstName, LastName, Position, HireDate)
VALUES
    (1, 1, 'Giovanni', 'Russo', 'Manager', '2020-05-15'),
    (2, 1, 'Maria', 'Ferrari', 'Cassiere', '2021-01-10'),
    (3, 2, 'Luca', 'Bianchi', 'Usciere', '2022-03-20'),
    (4, 2, 'Giulia', 'Romano', 'Addetto pulizie', '2023-07-05'),
    (5, 3, 'Marco', 'Verdi', 'Guardia', '2021-11-30'),
    (6, 3, 'Alessia', 'Gallo', 'Venditore snack', '2022-09-18'),
    (7, 3, 'Matteo', 'Costa', 'Proiezionista', '2020-12-15'),
    (8, 1, 'Sara', 'Esposito', 'Venditore biglietti', '2023-02-28'),
    (9, 2, 'Elena', 'Barbieri', 'Manager', '2019-08-20'),
    (10, 3, 'Lorenzo', 'Martini', 'Cassiere', '2020-04-10');

-- VISTE
-- 1. Film in programmazione
CREATE VIEW FilmsInProgrammation AS 
SELECT Movie.Title, ShowTime.ShowDateTime, Movie.DurationMinutes, Movie.Rating
FROM Movie
JOIN ShowTime ON Movie.MovieID = ShowTime.MovieID;

SELECT * FROM FilmsInProgrammation;

-- 2. Vista Posti disponibili per spettacolo
-- CREATE VIEW AvailableSeatForShow
--SELECT Theater.Capacity , ShowTime.ShowTimeID, Movie.Title, Ticket.ShowTimeID
--FROM Theater
--JOIN ShowTime ON Theater.TheaterID = ShowTime.TheaterID
--JOIN Movie ON Showtime.MovieID = Movie.MovieID
--JOIN Ticket ON ShowTime.ShowTimeID = Ticket.ShowTimeID;


--posti disponibili: capacita - numeri di biglietti comprati per quello specifico spettacolo
CREATE VIEW AvailableSeatForShow AS
SELECT Theater.Capacity,Theater.Capacity - COUNT(Ticket.TicketID) AS PostiDisponibili, Movie.Title
FROM Theater
JOIN ShowTime ON Theater.TheaterID = ShowTime.TheaterID
JOIN Movie ON Showtime.MovieID = Movie.MovieID
JOIN Ticket ON ShowTime.ShowTimeID = Ticket.ShowTimeID
GROUP BY Theater.Nome, Theater.Capacity, ShowTime.ShowTimeID, Movie.Title, Ticket.ShowTimeID;

SELECT * FROM AvailableSeatForShow;

-- 3. Vista incassi totali per film
SELECT * FROM Movie
JOIN ShowTime ON Movie.MovieID = ShowTime.MovieID
JOIN Ticket ON ShowTime.ShowTimeID = Ticket.ShowTimeID;


