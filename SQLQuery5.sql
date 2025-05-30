﻿INSERT INTO AccRatesPeriods
SELECT 
	NEWID(), 
	YEAR(F.Moment) * 100 + MONTH(F.Moment),
	R.Id, 
	AVG(CAST(F.Rate AS FLOAT)), 
	COUNT(*), 
	CURRENT_TIMESTAMP
FROM Realties R JOIN Feedbacks F ON R.Id = F.RealtyId
GROUP BY R.Id, YEAR(F.Moment) * 100 + MONTH(F.Moment)


SELECT * FROM AccRatesPeriods
WHERE RealtyId = '095469EA-E1B2-4C74-9001-3B50D9A3F4BD'
ORDER BY [Period] DESC;

UPDATE Feedbacks
SET Rate = 5 WHERE Id = 'BCE5E60F-37C9-4CA6-B008-0180C0962A3A';

DELETE FROM Feedbacks
WHERE Id = 'BCE5E60F-37C9-4CA6-B008-0180C0962A3A';

