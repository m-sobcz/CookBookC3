CREATE ROLE dbStoredProceduresAccess
GRANT EXECUTE TO dbStoredProceduresAccess
CREATE LOGIN spUser   
    WITH PASSWORD = 'spUser!@#'; 
ALTER ROLE dbStoredProceduresAccess ADD MEMBER spUser; 