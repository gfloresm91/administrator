IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
    WHERE name = N'$(MSSQL_DB)'
    )
BEGIN
    SELECT 'Database name already exist' AS Message
END
ELSE
BEGIN
    CREATE DATABASE $(MSSQL_DB)
    SELECT 'New database is created'
END