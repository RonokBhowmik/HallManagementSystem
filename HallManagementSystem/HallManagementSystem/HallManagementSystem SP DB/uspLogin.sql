Use MyHallDatabase
go
Alter procedure uspLogin
(
@ProvostName nvarchar(20),
@ProfessorRank nvarchar(20),
@Password int
)
As 
begin
SELECT *
 FROM Provosts
  WHERE ProvostName=@ProvostName AND ProfessorRankId=@ProfessorRank AND Password=@Password
end
go