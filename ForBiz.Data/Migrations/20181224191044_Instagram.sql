CREATE TABLE Instagram(
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
Fio NVARCHAR(200),
Url NVARCHAR(MAX),
EndPoint TINYINT,
TimeStamp DATETIME NOT NULL DEFAULT (GETDATE())
  )