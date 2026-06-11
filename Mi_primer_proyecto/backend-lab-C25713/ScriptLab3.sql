Create Database Countries;
GO
Use Countries;

Create table Country (
    Id int primary key identity(1,1),
    Name varchar(100) not null,
    Continent varchar(100) not null,
    OfficialLanguage varchar(100) not null
)

Drop table Country;