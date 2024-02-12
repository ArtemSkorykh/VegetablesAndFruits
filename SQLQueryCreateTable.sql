USE VegetablesAndFruits;

CREATE TABLE VegetablesAndFruits
(
	Id      INT PRIMARY KEY IDENTITY(1,1),
	[Name]  NVARCHAR(100) NOT NULL,
	[Type]  NVARCHAR(100) NOT NULL,
	Color   NVARCHAR(100) NOT NULL,
	Kcal    FLOAT NOT NULL
)