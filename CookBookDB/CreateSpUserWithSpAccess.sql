CREATE ROLE dbStoreProceduresAccess;  
GO
CREATE LOGIN spUser WITH PASSWORD = 'spUser!@#';  
GO
GO
CREATE USER spUser FOR LOGIN spUser 
GO
ALTER ROLE dbStoreProceduresAccess ADD MEMBER spUser;  