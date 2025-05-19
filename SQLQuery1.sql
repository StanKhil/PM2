CREATE TABLE Realties (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Name VARCHAR(255),
);
DROP TABLE Feedbacks;
CREATE TABLE Feedbacks (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	RealtyId UNIQUEIDENTIFIER,
	Comment VARCHAR(255),
	Rate INT,
	Moment DATETIME,
);

CREATE TABLE AccRates (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	RealtyId UNIQUEIDENTIFIER,
	AvgRate FLOAT,
	CntRates INT,
	LastRateAt DATETIME,
);

INSERT INTO Realties (Id, Name) VALUES
	(NEWID(), 'Realty 1'),
	(NEWID(), 'Realty 2'),
	(NEWID(), 'Realty 3'),
	(NEWID(), 'Realty 4');

INSERT INTO Realties (Id, Name) VALUES
	(NEWID(), 'Realty 5');

Declare @n int;
Set @n = 1000;
SET NOCOUNT ON;
While(@n > 0)
Begin
    Insert into Feedbacks values
    (Newid(), (Select top 1 Id from Realties Order by Newid()),
    N'Comment', 
	ABS(Checksum(newid())) % 5 + 1,
	DATEADD(HOUR, (ABS( CHECKSUM( NEWID() ) ) %24*365) , '2024-01-01'));
    Set @n = @n - 1;
End;

SELECT * FROM Feedbacks;

Insert into Feedbacks values
    (Newid(), '095469EA-E1B2-4C74-9001-3B50D9A3F4BD',
    N'Comment', 4, '2025-10-12 07:08:09');


UPDATE Feedbacks
SET Rate = 5 WHERE Id = 'BCE5E60F-37C9-4CA6-B008-0180C0962A3A';

DELETE FROM Feedbacks
WHERE Id = 'BCE5E60F-37C9-4CA6-B008-0180C0962A3A';

DROP TABLE Realties;

SELECT Id FROM Realties;