use master
if exists(select * from sys.databases where name = 'Bank')
begin
	drop database Bank
	print 'Databasen er droppet'
end
go
create database Bank