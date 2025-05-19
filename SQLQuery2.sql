SELECT R.Id, MAX(R.Name), AVG(CAST(F.Rate AS FLOAT))
FROM Realties R LEFT JOIN Feedbacks F ON R.Id = F.RealtyId
GROUP BY R.Id

INSERT INTO AccRates SELECT NEWID(), R.Id, AVG(CAST(F.Rate AS FLOAT)), COUNT(*), CURRENT_TIMESTAMP
FROM Realties R JOIN Feedbacks F ON R.Id = F.RealtyId
GROUP BY R.Id

SELECT Sum(CntRates) FROM AccRatesPeriods;

SELECT * FROM AccRatesPeriods;

DELETE FROM AccRates;

DROP TRIGGER trgAccRates;

SELECT R.Name, COALESCE(A.AvgRate,0)
FROM Realties R LEFT JOIN AccRates A ON R.Id = A.RealtyId