CREATE TABLE Country(
    Id int identity not null,
    Name varchar(200) not null,
    CONSTRAINT Country_name_uk UNIQUE (Name),
    CONSTRAINT Country_pk PRIMARY KEY (Id) 
);

CREATE TABLE City (
    Id int identity not null,
    CountryId int not null,
    Name varchar(200) not null,
    Latitude decimal(8,6) not null,
    Longitude decimal(9,6) not null,
    CONSTRAINT City_pk PRIMARY KEY (Id),
    CONSTRAINT FK_City_Country FOREIGN KEY (CountryId) REFERENCES Country(Id)
);


CREATE TABLE WeatherType (
    Id int identity not null,
    Name varchar(200) not null,
    CONSTRAINT WeatherType_name_uk UNIQUE (Name),
    CONSTRAINT WeatherType_pk PRIMARY KEY (Id)
);

CREATE TABLE WeatherRecord (
    Id int identity not null,
    CityId int not null,
    WeatherTypeId int not null,
    Temperature int not null,
    DateHappened datetime2 not null,
    Description varchar(2000),
    CONSTRAINT WeatherRecord_pk PRIMARY KEY (Id),
    CONSTRAINT FK_WeatherRecord_WeatherType FOREIGN KEY (WeatherTypeId) REFERENCES WeatherType(Id),
    CONSTRAINT FK_WeatherRecord_City FOREIGN KEY (CityId) REFERENCES City(Id)
);