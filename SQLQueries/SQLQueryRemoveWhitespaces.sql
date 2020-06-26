update Ingredients
set Name = LTRIM(RTRIM(Name))
go
update Ingredients 
set Description = LTRIM(RTRIM(Description))
go
update Ingredients 
set Unit = LTRIM(RTRIM(Unit))
go
update Ingredients 
set Cost = LTRIM(RTRIM(Cost))
go
update Ingredients 
set Callories = LTRIM(RTRIM(Callories))
