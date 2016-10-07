DECLARE @cnt int
SELECT @cnt = 0
DECLARE @u varchar(15)

WHILE @cnt<1000 BEGIN
  SELECT @cnt = @cnt + 1 
  SELECT @u = 'user' + CAST(@cnt as varchar)

  INSERT INTO [User] 
    VALUES(NEWID(), @u, 'mypassword', 'Gustavo', 'Morande', GETDATE(),
           '(999) 999-9999', '(999) 999-9999', '7th. Avenue 1234, NY, USA',
           'gmorande@clariusconsulting.net', 0)
END