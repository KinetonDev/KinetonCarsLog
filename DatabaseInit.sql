USE master
DROP DATABASE IF EXISTS KinetonCarsLog;
CREATE DATABASE KinetonCarsLog;
USE KinetonCarsLog;
CREATE TABLE Manufacturers (id INT PRIMARY KEY IDENTITY, name NVARCHAR(40) NOT NULL UNIQUE, country NVARCHAR(40) NOT NULl);
CREATE TABLE CarColors (id INT PRIMARY KEY IDENTITY, color_name NVARCHAR(40) NOT NULL UNIQUE);
CREATE TABLE CarTypes (id INT PRIMARY KEY IDENTITY, type NVARCHAR(40) NOT NULL UNIQUE);
CREATE TABLE FuelTypes (id INT PRIMARY KEY IDENTITY, type NVARCHAR(40) NOT NULL UNIQUE);
CREATE TABLE Engines (id INT PRIMARY KEY IDENTITY, fuel_type_id INT NOT NULL, Name NVARCHAR(40) NOT NULL, rpm INT NOT NULL CHECK(RPM > 0),
	fuel_consumption int check(fuel_consumption > 0) NOT NULL, capacity INT CHECK(capacity > 0) NOT NULL, 
	FOREIGN KEY(fuel_type_id) REFERENCES FuelTypes(id));
CREATE TABLE Cars (id INT PRIMARY KEY IDENTITY, manufacturer_id INT NOT NULL, car_type_id INT NOT NULL, engine_id INT NOT NULL, color_id INT NOT NULL,
	model NVARCHAR(20) NOT NULL, seat_count int check(seat_count > 0) NOT NULL,
	FOREIGN KEY(manufacturer_id) REFERENCES Manufacturers(id) ON UPDATE CASCADE,
	FOREIGN KEY(car_type_id) REFERENCES CarTypes(id),	
	FOREIGN KEY(color_id) REFERENCES CarColors(id) ON UPDATE CASCADE,	
	FOREIGN KEY(engine_id) REFERENCES Engines(id) ON UPDATE CASCADE);	
CREATE TABLE Reports (id INT PRIMARY KEY IDENTITY, created_UTC Date NOT NULL)
CREATE TABLE Reports_Cars (report_id INT, car_id int, count_of_cars int not null check (count_of_cars > 0), 
	PRIMARY KEY(report_id, car_id), 
	FOREIGN KEY (report_id) REFERENCES Reports(id) ON DELETE CASCADE,
	FOREIGN KEY (car_id) REFERENCES Cars(id) ON DELETE CASCADE);	

INSERT INTO CarTypes(type) VALUES('sedan'),( 'coupe' ), ('sports car' ), ('hatch back'), ('convertible'),( 'minivan'), ('pickup truck'),( 'cuv'), ('suv'), ('limousine');
INSERT INTO FuelTypes(type) VALUES('petrol 95') , ('petrol 92'), ('diesel'), ('petrol 98');