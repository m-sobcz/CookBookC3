CREATE ROLE dbStoreProceduresAccess;  

CREATE LOGIN spUser   
    WITH PASSWORD = 'spUser!@#';  
USE CookBookDB;  
CREATE USER spUser FOR LOGIN spUser 
ALTER ROLE dbStoreProceduresAccess ADD MEMBER spUser;  