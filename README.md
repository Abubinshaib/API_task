database Side:


Create Database Test_DB;

Use Test_DB;

CREATE TABLE User_Details(
ID INT IDENTITY(1,1) PRIMARY KEY,
FullName VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(10) NOT NULL,
Email VARCHAR(50) NOT NULL,
Gender VARCHAR(10) NOT NULL
);

Select * from User_Details
