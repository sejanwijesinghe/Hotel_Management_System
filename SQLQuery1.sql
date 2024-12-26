USE HotelManagementSystem;

CREATE TABLE UserData(
	UserID INT PRIMARY KEY IDENTITY(1, 1),
	Username VARCHAR(20) NOT NULL UNIQUE,
	Password NVARCHAR(20) NOT NULL,
	UserRole VARCHAR(20) DEFAULT 'User'
);

CREATE TABLE Customers(
	CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
    Email VARCHAR(50) UNIQUE,
    PhoneNumber VARCHAR(15),
	Address VARCHAR(250),
	Nationality VARCHAR(50),
	IDNumber VARCHAR(20),

);

CREATE TABLE Staff(
	StaffID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
	Position VARCHAR(30) NOT NULL,
	HireDate DATE NOT NULL,
	Email NVARCHAR(100),
    PhoneNumber VARCHAR(15),
    IDNumber VARCHAR(20)
);

CREATE TABLE Rooms(
	RoomID INT IDENTITY(1,1) PRIMARY KEY,
	RoomNo INT UNIQUE NOT NULL,
	Status VARCHAR(20) CHECK (Status IN ('Available', 'Occupied', 'Maintenance')) DEFAULT 'Available',
	Type VARCHAR(20),
    PricePerNight DECIMAL(10, 2) NOT NULL,
    MaxOccupancy INT NOT NULL,
);

CREATE TABLE Reservations(
	ReservationID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerID INT,
	RoomID INT,
	CheckInDate DATE NOT NULL,
	CheckOutDate DATE NOT NULL,
    TotalAmount DECIMAL(10, 2),
    DateOfReservation DATE DEFAULT GETDATE(),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);

select * from Customers;


























delete from Customers;

delete from Reservations;


delete from Billing;



CREATE TABLE Billing(
	BillingID INT IDENTITY(1,1) PRIMARY KEY,
	ReservationID INT,
	BillDate DATE DEFAULT GETDATE(),
	TotalAmount DECIMAL(10, 2) NOT NULL,
	PaymentStatus VARCHAR(20) CHECK (PaymentStatus IN ('Paid', 'Pending', 'Overdue')) DEFAULT 'Pending',
    PaymentMethod VARCHAR(20) CHECK (PaymentMethod IN ('Credit Card', 'Cash', 'Online Payment')) NOT NULL,
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID)
);


INSERT INTO UserData(Username, Password)
VALUES ('sejan', 'sadev');

select * from Rooms;
select * from Customers;
select * from Staff;



drop table Billing;

SELECT * FROM sys.dm_exec_requests WHERE status = 'running';

ALTER TABLE Rooms
ALTER COLUMN MaxOccupancy VARCHAR(50) NOT NULL;

UPDATE Rooms
SET MaxOccupancy = 0
WHERE MaxOccupancy = 'Single';

SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Rooms' AND COLUMN_NAME = 'MaxOccupancy';

SELECT MaxOccupancy FROM Rooms;
SELECT * FROM Rooms WHERE MaxOccupancy LIKE '%';
