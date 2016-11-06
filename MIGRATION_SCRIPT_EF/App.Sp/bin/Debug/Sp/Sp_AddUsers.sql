CREATE PROCEDURE Sp_AddUsers
 @Name varchar(50),
 @Email varchar(50),
 @Nic varchar(50),
 @Password varchar(50),
 @State int,
 @Active bit
AS
BEGIN
	 
INSERT INTO Users (Name, Email, Nic, Password, State, RegDate, Active)
VALUES        (@Name,@Email,@Nic,@Password,@State,getdate(),@Active)

END
 
