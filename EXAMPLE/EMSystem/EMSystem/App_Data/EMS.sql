CREATE DATABASE [EMS]
GO
USE [EMS]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 18/08/2016 01:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](5) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[DateOfJoin] [date] NOT NULL,
	[PosItion] [nvarchar](20) NOT NULL,
	[Office] [nvarchar](20) NOT NULL,
	[Division] [nvarchar](20) NOT NULL,
	[Salary] [money] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Herrod','Daniels','1963-12-11','1977-08-16','Executive','Colombo','QA',18864);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Steel','Mayo','1959-11-18','1971-08-11','Assistant','Melbourne','Development',201718);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Finn','Herrera','1964-12-15','1970-09-24','Manager','Colombo','HR',230771);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Rooney','English','1964-10-13','1982-01-14','Consultant','Melbourne','QA',161202);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Knox','Frost','1962-11-24','1986-08-18','Executive','Colombo','Development',68236);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Clinton','Randolph','1963-07-15','1976-09-27','Assistant','Melbourne','HR',161086);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Tad','Morrison','1959-01-31','1982-02-07','Manager','Colombo','QA',80257);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Oleg','Cortez','1959-03-27','1982-12-21','Consultant','Melbourne','Development',233753);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Howard','Fowler','1965-04-09','1973-06-19','Executive','Colombo','HR',24846);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Tad','Fry','1964-06-20','1995-05-15','Assistant','Melbourne','QA',193429);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Camden','Lambert','1961-11-18','1992-07-23','Manager','Colombo','Development',176645);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Eric','Hester','1958-11-22','1983-07-25','Consultant','Melbourne','HR',101375);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Macaulay','Lucas','1965-02-25','1974-08-05','Executive','Colombo','QA',150697);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Troy','Holland','1959-12-27','1973-03-14','Assistant','Melbourne','Development',41039);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Gannon','Frazier','1959-05-04','1989-02-06','Manager','Colombo','HR',246335);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Kaseem','Parsons','1965-01-23','1977-09-30','Consultant','Melbourne','QA',34972);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Rafael','Keller','1959-01-01','1987-10-02','Executive','Colombo','Development',189878);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Upton','Joyce','1962-07-02','1981-11-22','Assistant','Melbourne','HR',212453);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Cooper','Mack','1965-03-20','1989-09-18','Manager','Colombo','QA',85139);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Stewart','May','1964-06-25','1985-12-17','Consultant','Melbourne','Development',210051);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Lee','Thompson','1965-03-29','1973-03-11','Executive','Colombo','HR',192224);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Chadwick','Roy','1962-02-01','1990-12-11','Assistant','Melbourne','QA',87327);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Roth','Moon','1963-01-27','1971-07-05','Manager','Colombo','Development',111121);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Joseph','Torres','1959-06-17','1978-09-21','Consultant','Melbourne','HR',183698);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Elvis','Arnold','1964-10-06','1971-07-21','Executive','Colombo','QA',98617);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Ali','Donovan','1959-10-17','1992-07-21','Assistant','Melbourne','Development',73582);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Brent','Mcfarland','1965-12-26','1972-01-26','Manager','Colombo','HR',19796);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Steel','Price','1961-03-29','1981-07-27','Consultant','Melbourne','QA',211920);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Dylan','Stevenson','1961-03-04','1988-05-07','Executive','Colombo','Development',22525);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Elvis','Cabrera','1958-12-19','1973-06-20','Assistant','Melbourne','HR',200624);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Sylvester','Thompson','1964-02-08','1994-12-17','Manager','Colombo','QA',113017);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Cooper','Bates','1963-04-09','1985-11-23','Consultant','Melbourne','Development',173667);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Fitzgerald','Guzman','1963-10-05','1986-08-17','Executive','Colombo','HR',188964);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Hall','French','1959-06-29','1973-02-26','Assistant','Melbourne','QA',74000);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Orson','Mcintosh','1959-10-11','1986-05-04','Manager','Colombo','Development',231888);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Addison','Fleming','1962-02-17','1978-05-26','Consultant','Melbourne','HR',204773);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Steel','Jordan','1962-10-12','1990-11-16','Executive','Colombo','QA',96902);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Kibo','Murray','1963-09-28','1983-08-04','Assistant','Melbourne','Development',87740);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Nehru','Harmon','1959-10-04','1987-07-20','Manager','Colombo','HR',87553);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Gage','Barber','1964-08-26','1981-05-29','Consultant','Melbourne','QA',160858);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Bruce','Sharp','1962-01-09','1970-11-26','Executive','Colombo','Development',48027);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Cameron','Atkinson','1964-02-17','1982-06-09','Assistant','Melbourne','HR',50088);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Ezra','Lee','1961-10-24','1994-06-28','Manager','Colombo','QA',73433);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Troy','Moss','1964-08-11','1995-11-17','Consultant','Melbourne','Development',140675);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Thaddeus','Finch','1960-11-27','1978-12-24','Executive','Colombo','HR',189955);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Aidan','Drake','1962-05-13','1987-11-19','Assistant','Melbourne','QA',172882);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Conan','Joyce','1963-02-08','1979-05-26','Manager','Colombo','Development',189830);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Damian','Collier','1960-09-09','1980-09-18','Consultant','Melbourne','HR',157835);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Hall','Wiggins','1960-01-19','1994-05-13','Executive','Colombo','QA',191088);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Brendan','Leonard','1965-03-31','1984-01-17','Assistant','Melbourne','Development',39423);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Gil','Pitts','1963-06-17','1976-04-13','Manager','Colombo','HR',234496);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Elijah','Silva','1963-06-25','1971-09-16','Consultant','Melbourne','QA',141973);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Mufutau','Levy','1965-07-14','1976-12-09','Executive','Colombo','Development',31589);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Phillip','Brock','1964-05-15','1981-03-30','Assistant','Melbourne','HR',181338);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Nero','Rodriguez','1965-07-07','1983-04-11','Manager','Colombo','QA',178680);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Wing','Mueller','1962-06-24','1976-11-19','Consultant','Melbourne','Development',38700);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Jacob','Schmidt','1962-09-21','1976-05-27','Executive','Colombo','HR',223985);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Kenyon','Livingston','1962-02-02','1975-05-16','Assistant','Melbourne','QA',207648);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Randall','Villarreal','1964-09-11','1984-03-02','Manager','Colombo','Development',194531);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Hamish','Norman','1961-06-03','1979-02-19','Consultant','Melbourne','HR',30264);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Eagan','King','1965-08-06','1979-09-20','Executive','Colombo','QA',59026);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','William','Elliott','1961-12-22','1978-06-06','Assistant','Melbourne','Development',99903);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Joel','Gregory','1960-03-23','1991-12-06','Manager','Colombo','HR',126235);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Otto','Combs','1966-03-13','1976-02-24','Consultant','Melbourne','QA',82896);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Chase','Dalton','1960-03-26','1977-11-28','Executive','Colombo','Development',206417);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','John','Melendez','1963-08-25','1973-01-05','Assistant','Melbourne','HR',99866);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Alexander','Ochoa','1962-10-24','1985-10-20','Manager','Colombo','QA',230283);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Zephania','Oneil','1962-10-08','1990-10-11','Consultant','Melbourne','Development',185223);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Jamal','Perry','1960-04-29','1986-12-12','Executive','Colombo','HR',233684);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Wing','Kirkland','1963-09-19','1974-10-03','Assistant','Melbourne','QA',184897);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Grant','Tucker','1962-02-12','1980-03-05','Manager','Colombo','Development',222863);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Judah','Short','1965-05-09','1985-11-18','Consultant','Melbourne','HR',216542);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Lamar','Marsh','1963-10-21','1989-06-13','Executive','Colombo','QA',29888);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Rogan','Mathis','1960-07-06','1986-09-10','Assistant','Melbourne','Development',54342);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Linus','West','1960-11-12','1987-04-22','Manager','Colombo','HR',121110);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Boris','Rowland','1964-08-01','1994-10-24','Consultant','Melbourne','QA',110070);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Flynn','Wilcox','1960-03-20','1990-05-07','Executive','Colombo','Development',159862);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Gary','Rosario','1965-10-23','1993-02-03','Assistant','Melbourne','HR',123120);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Guy','Mendoza','1965-12-13','1994-11-16','Manager','Colombo','QA',54173);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Abdul','Figueroa','1963-04-30','1971-09-13','Consultant','Melbourne','Development',240549);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Zane','Ortiz','1959-04-15','1993-10-24','Executive','Colombo','HR',81250);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Plato','Suarez','1963-10-26','1987-01-01','Assistant','Melbourne','QA',239886);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Palmer','Bentley','1964-05-18','1980-12-14','Manager','Colombo','Development',233390);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Nero','Fields','1963-11-10','1990-10-06','Consultant','Melbourne','HR',106261);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Aristotle','Moon','1961-12-19','1980-03-24','Executive','Colombo','QA',234022);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Geoffrey','Berg','1958-12-25','1989-10-05','Assistant','Melbourne','Development',123940);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Hector','Weaver','1958-09-06','1982-03-23','Manager','Colombo','HR',192328);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Elvis','Moses','1964-10-22','1981-04-20','Consultant','Melbourne','QA',33964);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','William','Small','1961-01-10','1993-03-09','Executive','Colombo','Development',65321);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Cedric','Mcintosh','1960-08-08','1975-12-15','Assistant','Melbourne','HR',64096);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Darius','Dejesus','1965-05-29','1984-04-13','Manager','Colombo','QA',174296);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Hunter','Tyson','1964-07-03','1978-11-03','Consultant','Melbourne','Development',128624);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Magee','Chavez','1959-07-24','1994-05-13','Executive','Colombo','HR',68227);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Ms','Ian','Osborn','1961-03-07','1986-08-21','Assistant','Melbourne','QA',37671);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Calvin','Martin','1959-07-16','1976-04-10','Manager','Colombo','Development',191315);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Dr','Troy','Bush','1964-11-17','1977-12-15','Consultant','Melbourne','HR',20258);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Kermit','Vargas','1962-08-20','1991-07-10','Executive','Colombo','QA',203936);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mr','Lance','Kidd','1963-03-04','1971-10-09','Assistant','Melbourne','Development',103109);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Kenneth','Zimmerman','1961-09-09','1972-08-24','Manager','Colombo','HR',25005);
INSERT INTO Employee([Title],[FirstName],[LastName],[DateOfBirth],[DateOfJoin],[PosItion],[Office],[Division],[Salary]) VALUES('Mrs','Clark','Finch','1961-08-25','1990-06-29','Consultant','Melbourne','QA',190289);

