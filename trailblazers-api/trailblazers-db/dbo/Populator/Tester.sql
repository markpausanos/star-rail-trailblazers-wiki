SELECT * FROM [dbo].[User]

-- DELETE FROM [dbo].[User]

SELECT * FROM [dbo].PathSR

UPDATE [dbo].[User]
SET [Password] = '$2a$10$MnlG2s/LD9fST3CdtGeS6uSvQDOFfZwfyr3qJw4W8DvAD4Ix9hRbu'
WHERE Id = 1;


SELECT * FROM Build

SELECT * FROM [Like]

SELECT COUNT(*) FROM [Like] WHERE BuildId =3 

 SELECT t.*, e.*, p.*, ed.*, tr.*, s.* 
                FROM Trailblazer t 
                LEFT JOIN Element e ON e.Id = t.ElementId
                LEFT JOIN PathSR p ON p.Id = t.PathSRId
                LEFT JOIN Eidolon ed ON ed.TrailblazerId = t.Id
                LEFT JOIN Trace tr ON tr.TrailblazerId = t.Id
                LEFT JOIN Skill s ON s.TrailblazerId = t.Id
                WHERE t.IsDeleted = 0