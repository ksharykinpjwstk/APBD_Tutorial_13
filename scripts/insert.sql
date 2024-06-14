-- Insert data into the Country table
INSERT INTO Country (Name)
VALUES 
('United States'),
('Canada'),
('United Kingdom'),
('Australia'),
('Germany');

-- Insert data into the City table
INSERT INTO City (CountryId, Name, Latitude, Longitude)
VALUES 
(1, 'New York', 40.712776, -74.005974),
(1, 'Los Angeles', 34.052235, -118.243683),
(2, 'Toronto', 43.651070, -79.347015),
(3, 'London', 51.507351, -0.127758),
(4, 'Sydney', -33.868820, 151.209290),
(5, 'Berlin', 52.520008, 13.404954);

-- Insert data into the WeatherType table
INSERT INTO WeatherType (Name)
VALUES 
('Sunny'),
('Rainy'),
('Cloudy'),
('Snowy'),
('Windy');

-- Insert data into the WeatherRecord table
INSERT INTO WeatherRecord (CityId, WeatherTypeId, Temperature, DateHappened, Description)
VALUES 
(1, 1, 25, '2023-06-01 14:00:00', 'Clear skies and warm.'),
(1, 2, 18, '2023-06-02 14:00:00', 'Light rain showers.'),
(2, 1, 30, '2023-06-01 14:00:00', 'Hot and sunny.'),
(3, 3, 22, '2023-06-01 14:00:00', 'Overcast but dry.'),
(4, 4, 10, '2023-06-01 14:00:00', 'Snowfall throughout the day.'),
(5, 5, 15, '2023-06-01 14:00:00', 'Strong winds and chilly.');