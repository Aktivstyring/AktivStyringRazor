
-- Indeholder de fikses der blev lavet da vi fandt ud af at NVARCHAR blev defaulted til 1 char.

Create Table Personer(
PersonID int identity(1,1) not null primary key,
Navn nvarchar(50) default null,
Telefon nvarchar(25) default null,
Email nvarchar(50) default null,
Adresse nvarchar(255) default null,
);

Create table Placeringer (
PlaceringID int not null identity(1,1) primary key,
Placering nvarchar(255) default null,
PlaceringSort int default null,
);

CREATE TABLE AktiverStatus(
AktivStatusID		int IDENTITY(1,1)	NOT NULL,
AktivStatus			NVARCHAR(255)		NOT NULL	DEFAULT '',
AktivStatusGrad		int	DEFAULT NULL /*COMMENT "Angiver hvilken stand aktivet er i"*/,
AktivStatusOrder	int DEFAULT NULL,
primary key (AktivStatusID)
);


CREATE TABLE AktivType(
AktivType		nvarchar(255) DEFAULT NULL,
AktivTypeOrder	tinyint default NULL,
AktivTypeID		int IDENTITY(1,1) NOT NULL,
primary key (AktivTypeID)
);


Create Table Aktiver(
AktivID int identity(1,1) not null Primary Key,
AktivTypeID int Not null,
Maerke nvarchar(40) default null,
Model nvarchar(40) default null,
ModelUddyb nvarchar(255) default null,
SerieNr nvarchar(30) default null,
Kaldenavn nvarchar(40) default null,
AktivstatusID int default null,
Detaljer nvarchar(255),
HarStregkode bit default '0',
FraKommando bit default '0',
Privat bit default '0', /*'0=Gardens instrument, 1=pigens privatejede instrument'*/
Købt datetime default null, /*'null = købsdato ukendt'*/
Udskrevet datetime DEFAULT NULL, /*'Dato for hvornår aktivet er smidt ud / solgt / etc. fra databasen'*/
Oprettet datetime NULL DEFAULT Null,
Opdateret datetime NULL DEFAULT NULL
foreign key (AktivTypeID) REFERENCES AktivType(AktivTypeID) on update cascade
);


CREATE TABLE EFTERSYN(
AktivID int default NULL,
EftersynDato datetime default NULL,
EftersynNote nvarchar(1000),
EftersynID int IDENTITY(1,1) NOT NULL,
Oprettet datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
primary key (EftersynID),
foreign key (AktivID) REFERENCES Aktiver (AktivID) on update cascade
);
/*
  KEY `Eftersyn_AktivID` (`AktivID`),
  CONSTRAINT `Eftersyn_AktivID` FOREIGN KEY (`AktivID`) REFERENCES `Aktiver` (`AktivID`) ON DELETE CASCADE ON UPDATE CASCADE
*/


CREATE TABLE Lageroptælling (
AktivID int not NULL,
PlaceringID int not null,
PlaceringDato datetime default NULL,
PlaceringNote nvarchar(255) default NULL,
LinkID int IDENTITY (1,1) NOT NULL,
primary key (LinkID),
foreign key (AktivID) REFERENCES Aktiver (AktivID) on update cascade,
foreign key (PlaceringID) REFERENCES Placeringer (PlaceringID) on update cascade
);


Create Table AktivUdleveringer(
AktivID int default null foreign key references Aktiver on update cascade,
PersonID int default null foreign key references Personer on update cascade,
AktivUddelt datetime default Null,
AktivIndsamlet datetime default null,
UdleveringsID int identity(1,1) primary key,
);



Create Table Ensembler(
EnsembleID int identity(1,1) not null primary key,
Navn nvarchar(50) default null,
Noter nvarchar(600) default null
);

Create Table Roller(
RolleID int identity (1,1) not null primary key,
Rolle nvarchar(50) default null
);

Create Table EnsembleDeltagere(
EnsDeltagerID int identity (1,1) not null primary key,
PersonID int NOT NULL FOREIGN KEY REFERENCES Personer(PersonID),
EnsembleID int NOT NULL FOREIGN KEY REFERENCES Ensembler(EnsembleID),
RolleID int default null FOREIGN KEY REFERENCES Roller(RolleID),
Tilmeldt datetime default null,
Udmeldt datetime default null
);



CREATE Table StemmeBogType(
StemmeBogTypeID INT identity (1,1) primary key,
BogType nvarchar(50) default null
);

Create Table StemmmeBogStatus(
StemmmeBogStatusID INT identity(1,1) primary key,
BogStatus nvarchar(50) default null
);

Create Table StemmeNummer(
StemmeNummerID INT identity (1,1) primary key,
StemmeNummerTal nvarchar(4) default null
);

Create Table Noder(
MusikID INT identity (1,1) primary key,
Titel nvarchar(80),
Komponist nvarchar(80),
Forfatter nvarchar(80),
Forlag nvarchar(80),
);

/* 
legacy og ubrugte henvisninger. tænkt brugt i et senere sprint til at hjælpe med at klassificerer musikken når denne skal indtastes.
Men som systemet ser ud i sprint 4 er de ikke brugbare
Samlinger INT foreign key
Genre INT foreign key
*/

Create Table StemmeBogSide(
StemmeBogSideID INT identity (1,1) primary key,
MusikID INT foreign key references Noder(MusikID),
StemmeBogTypeID INT foreign key references StemmeBogType(StemmeBogTypeID),
Sidetal INT default null
);

Create Table StemmeBøger(
StemmeBogID INT identity (1,1) primary key, --Hæftenummer
StemmeBogType INT foreign key references StemmeBogType(StemmeBogTypeID),
BogStatus INT foreign key references StemmmeBogStatus(StemmmeBogStatusID),
UddeltTil INT foreign key references Personer(PersonID),
Instrument INT foreign key references AktivType(AktivTypeID),
StemmeType INT foreign key references StemmeNummer(StemmeNummerID)
);



ALTER TABLE Personer
Add Keyphrase nvarchar(50);













Insert into Personer(Navn, Telefon, Email, Adresse)Values
	('Thomas Fogh', '+28515297', 'thom20m1@edu.easj.dk', 'roskildevej 3'),
	('Nemo d. Navnløse', '+55555555','gmail@gmail.com','bovej 3'),
	('Margrethe Rex', '+52505094', 'danmark@yahoo.dk','kronborg');


INSERT INTO AktiverStatus (AktivStatus, AktivStatusGrad)VALUES
	('!! MANGLER // SKAL FINDES !!',1),
	('Bør kasseres',70),
	('Defekt',50),
	('Hos instrumentmager',2),
	('Kasseret (Stadig i beholdning)',95),
	('Kasseret // Bruges som reservedele',71),
	('Ok',10),
	('Optælles, nummereres og oprettes i database',200),
	('Reserveinstrument',30),
	('Skal efterses',20),
	('Skal rengøres',21),
	('Skal repareres // Til instrumentmager',3),
	('Slettet // Udskrevet // Solgt',100),
	('STJÅLET',80);



SET IDENTITY_INSERT [dbo].[AktivType] ON
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Nodetaske', NULL, 1)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Mundstykke', NULL, 2)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Nodelyre', NULL, 3)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Nodestativ', NULL, 4)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Instrumentstativ', NULL, 5)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Dæmper', NULL, 6)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Instrumentkasse', NULL, 7)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Instrument', NULL, 8)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Piccolofløjte', NULL, 9)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Marchfløjte', NULL, 10)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Tværfløjte', NULL, 11)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Klarinet', NULL, 12)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Altsax', NULL, 13)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Tenorsax', NULL, 14)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Kornet', NULL, 15)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Trompet', NULL, 16)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Fanfaretrompet', NULL, 17)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Flygelhorn', NULL, 18)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Signalhorn', NULL, 19)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Althorn', NULL, 20)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Bariton', NULL, 21)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Mellofon', NULL, 22)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Tenorhorn', NULL, 23)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Tenortrombone', NULL, 24)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Bastrombone', NULL, 25)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Valdhorn', NULL, 26)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Tuba Eb', NULL, 27)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Tuba Bb', NULL, 28)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Lyre', NULL, 29)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Marchtromme', NULL, 30)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Lilletromme', NULL, 31)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Marimba', NULL, 32)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Nodestativ', NULL, 33)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Instrumentstativ', NULL, 34)
INSERT INTO [dbo].[AktivType] ([AktivType], [AktivTypeOrder], [AktivTypeID]) VALUES (N'Øveplade', NULL, 35)
SET IDENTITY_INSERT [dbo].[AktivType] OFF



SET IDENTITY_INSERT [dbo].[Aktiver] ON
INSERT INTO Aktiver (AktivID, AktivTypeID, Maerke, Model, ModelUddyb, SerieNr, Kaldenavn, AktivStatusID, Detaljer, HarStregkode, FraKommando, Privat, Købt, Udskrevet, Oprettet, Opdateret)
VALUES
	(1, 12,'Buffet','B-12',NULL,'582345',NULL,3,'Gottfrieds liste / Ullas liste',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:12:38'),
	(2, 12,'Bundy',NULL,NULL,'972588',NULL,7,'Ullas liste',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:18:32'),
	(3, 4,'Ukendt',NULL,NULL,NULL,NULL,3,NULL,1,0,0,NULL,NULL,'2016-11-27 23:31:09','2020-08-21 02:43:28'),
	(4, 4,'K&M','11950/55',NULL,NULL,NULL,7,'One Hand Music Stand\n(Dirigent-nodestativet)',1,0,0,NULL,NULL,'2016-11-27 22:15:52','2020-08-21 02:43:28'),
	(5, 12,'Buffet','B-12',NULL,'582345',NULL,3,'Gottfrieds liste / Ullas liste',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:12:38'),
	(6, 12,'Bundy',NULL,NULL,'972588',NULL,7,'Ullas liste',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:18:32'),
	(7, 12,'Buffet','B-12',NULL,'582345',NULL,3,'Gottfrieds liste / Ullas liste',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:12:38'),
	(8, 12,'Bundy',NULL,NULL,'972588',NULL,7,'Ullas liste',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:18:32'),
	(9, 29,'Nikkon',NULL,NULL,NULL,NULL,1,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(10, 27,'Nikkon',NULL,NULL,NULL,NULL,1,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(11, 15,'Yamaha','YCR-2330S',NULL,'003626',NULL,12,'Mundstykke:	Nej\nNodelyre:		Ja',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(12, 15,'Yamaha','YCR-2330S',NULL,'692120',NULL,7,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(13, 15,'Yamaha','YCR-4330G',NULL,'992802',NULL,7,'Nodelyre:		Ja (clips) – Sofia har lånt 2\nKasse:		Original, god stand\n',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(14, 20,'Yamaha','YAH-203S',NULL,'C 85850','Agate',7,'Købt 2014-10\n\n(Olivia har eget mundstykke)',0,1,0,'2014-10-01',NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(15, 20,'Yamaha','YAH-203S',NULL,'C 85853','Augusta',7,'Købt 2014-10\nInkl. Yamaha-mundstykke',0,1,0,'2014-10-01',NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(16, 23,'Besson','757',NULL,'754806','Joey',7,'Nodelyre:		Ja\n',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-12-21 20:29:53'),
	(17, 23,'Besson','757',NULL,'826149','Berta',7,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(18, 25,'Yamaha','YBL-421G',NULL,'437973','Basdyret',7,'Godt instrument!',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(19, 24,'Bach','1001',NULL,'ML 371683','Bob Benzon',7,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:00:07'),
	(20, 24,'Getzen','Capri',NULL,'KT 13 605',NULL,1,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(21, 28,'Yamaha','YBB-105',NULL,'307788','Bunny',7,'4/4 size\nMundstykke: Yamaha 67',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(22, 27,'Besson','Westminster',NULL,'524250','Bossen',7,'Kasse:		Sort Besson-kasse (hjul er defekte)\n',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-12-21 20:48:28'),
	(23, 27,'Besson','700',NULL,'777-784498','Tilde',7,'Kasse:		Ja (gigbag – lyserød/multifarvet, nylon. Hjul virker. Håndtag mangler)',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-12-21 20:48:45'),
	(24, 10,'Sandner',NULL,NULL,NULL,NULL,8,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(25, 10,'Sandner',NULL,NULL,NULL,NULL,8,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(26, 10,'Sandner',NULL,NULL,NULL,NULL,8,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(27, 30,NULL,NULL,NULL,NULL,NULL,8,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(28, 30,'Remo',NULL,NULL,NULL,NULL,8,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(29, 30,'Remo',NULL,NULL,NULL,NULL,8,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(30, 9,'Yamaha','YPF',NULL,'68809','Pippi',7,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:43:28'),
	(31, 13,'Yamaha',NULL,NULL,NULL,NULL,NULL,NULL,0,1,1,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 02:44:36'),
	(32, 16,'Makis','de luxe',NULL,'LP 311511',NULL,13,'Mundstykke:	Nej\nNodelyre:		Nej\nKasse:		Gammel Yamaha-kasse',0,1,0,NULL,'2017-10-01','2016-06-28 21:03:11','2020-08-21 03:13:08'),
	(33, 16,'Yamaha','YTR-734',NULL,'5036',NULL,5,'Mundstykke:	Nej\nNodelyre:		Nej\nKasse:		Gammel / slidt',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:38:04'),
	(34, 17,'Getzen',NULL,NULL,'R11822',NULL,7,'Kasse indeholder:\n- Nodelyre\n- Flag / Banner\n- Triggerbøjle til 3.ventil\n- Mundstykke (Getzen 7C)\n',0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-08-21 03:01:31'),
	(35, 9,'Armstrong',NULL,NULL,'29 62102',NULL,5,'Mundstykket i kassen er til Yamaha!',0,0,0,NULL,NULL,'2016-09-29 00:28:03','2020-11-05 22:36:04'),
	(36, 9,'Yamaha','YPF',NULL,'69239','Petra',9,NULL,0,0,0,NULL,NULL,'2016-09-29 00:28:04','2020-08-21 02:43:28'),
	(37, 11,'Conservarté',NULL,NULL,'21653',NULL,5,NULL,0,0,0,NULL,NULL,'2016-10-10 14:58:28','2020-11-05 23:22:32'),
	(38, 11,'Yamaha','YFL-211S',NULL,'207190',NULL,1,NULL,0,0,0,NULL,NULL,'2016-10-10 14:59:19','2020-08-21 02:43:28'),
	(39, 11,'Yamaha','YFL-211S',NULL,'180143',NULL,9,NULL,0,0,0,NULL,NULL,'2016-10-10 15:00:45','2020-11-06 00:31:50'),
	(40, 11,'Yamaha','YFL-211S II',NULL,'548539',NULL,6,NULL,0,0,0,NULL,NULL,'2016-10-10 15:01:59','2020-11-06 00:04:31'),
	(41, 12,'Yamaha',NULL,NULL,'M 39774',NULL,7,'Ullas liste',0,0,0,'2016-01-01',NULL,'2016-10-12 01:32:15','2020-08-21 03:18:30'),
	(42, 9,'John Packer','214 MK II',NULL,'%',NULL,5,NULL,0,1,0,NULL,NULL,'2016-06-28 21:03:11','2020-11-05 22:33:24'),
	(43, 24,'Yamaha','YSL-354',NULL,'386241',NULL,7,'Kasse:		Original (fin stand)\nMundstykke:	Nej',0,0,0,NULL,NULL,'2016-11-24 23:38:11','2020-08-21 03:01:58'),
	(44, 33,'K&M','101 Nickel',NULL,NULL,NULL,3,NULL,1,0,0,NULL,NULL,'2016-11-27 22:15:52','2020-08-21 02:43:28'),
	(45, 33,'K&M','101 Nickel',NULL,NULL,NULL,3,NULL,1,0,0,NULL,NULL,'2016-11-27 22:15:52','2020-08-21 02:43:28'),
	(46, 34,'K&M','149/85 Sort','Trombone','0',NULL,7,'Lærerstativ',0,0,0,NULL,NULL,'2016-11-28 15:09:43','2020-08-21 03:03:23'),
	(47, 35,'K&M','151/4','Valdhorn',NULL,NULL,7,NULL,0,0,0,NULL,NULL,'2016-11-28 15:09:43','2020-08-21 02:43:28'),
	(48, 33,'K&M','10065 Sort',NULL,NULL,NULL,7,'Ullas private stativ',0,0,1,NULL,NULL,'2016-11-28 15:15:24','2020-08-21 03:09:34'),
	(49, 26,'Hans Hoyer, Meister',NULL,NULL,'30618M',NULL,7,NULL,0,0,0,NULL,NULL,'2016-12-03 01:39:47','2020-08-21 03:03:35');
SET IDENTITY_INSERT [dbo].[Aktiver] OFF
	
SET IDENTITY_INSERT [dbo].[Placeringer] ON
INSERT INTO Placeringer(PlaceringID, Placering, PlaceringSort)
VALUES
	(1, 'Rigsarkivet',1),
	(2, 'Skattekammeret',2),
	(3, 'Sibirien (Depotet)',6),
	(4, 'Loftet',7),
	(5, 'Udlånt',10),
	(6, 'Borupgårdskolen',4),
	(7, 'Hulen (Lokale A)',3),
	(8, 'Instrumentmager: Gottfried',8),
	(9, 'Instrumentmager: Brass Centrum',8);
SET IDENTITY_INSERT [dbo].[Placeringer] OFF

SET IDENTITY_INSERT [dbo].[EFTERSYN] ON
INSERT INTO Eftersyn (AktivID, EftersynDato, EftersynNote, Oprettet) VALUES
	(1,'2016-10-13','(ok)','2016-10-13 22:43:22'),
	(2,'2016-10-12','Defekt','2016-10-12 01:42:24'),
	(3,'2016-10-12','Ok','2016-10-12 01:29:35'),
	(4,'2014-09-27','Fin stand.','2017-10-13 03:12:10'),
	(5,'2014-09-27','Fin stand.','2017-10-13 03:12:13'),
	(6,'2016-10-12',NULL,'2016-10-12 01:19:53'),
	(7,'2016-10-12',NULL,'2016-10-12 01:25:22'),
	(8,'2014-09-27','Gottfried:\n\"Eftersyn, div kork, smøring.\"','2017-10-13 03:14:16'),
	(9,'2016-10-12',NULL,'2016-10-12 01:19:54'),
	(10,'2016-10-12','Instrumentstatus opdateret på baggrund af Ullas uddelingsliste\n–Bør efterses!','2016-10-12 01:38:01');
SET IDENTITY_INSERT [dbo].[EFTERSYN] OFF


SET IDENTITY_INSERT [dbo].[Lageroptælling] ON
INSERT INTO Lageroptælling (AktivID, PlaceringID, PlaceringDato, PlaceringNote, LinkID) VALUES
	(1,1,'2017-10-13 04:49:47',NULL, 1),
	(45,2,'2019-01-16 21:44:51','Lokaliseret ved uddeling til:\n2) nemo sørensen', 2),
	(40,3,'2019-01-16 22:06:45',NULL, 3),
	(30,4,'2016-06-29 23:32:06','Auto-insert på baggrund af seneste eftersyn',4),
	(35,5,'2016-06-29 23:35:02','Auto-insert på baggrund af seneste eftersyn',5),
	(32,6,'2016-10-04 19:52:24','Auto-insert på baggrund af seneste eftersyn',6),
	(25,7,'2016-10-04 20:39:55','Auto-insert på baggrund af seneste eftersyn',7),
	(20,8,'2016-10-04 19:55:50','Auto-insert på baggrund af seneste eftersyn',8),
	(18,9,'2016-06-29 23:59:19','Auto-insert på baggrund af seneste eftersyn',9),
	(19,4,'2016-06-30 00:03:41','Auto-insert på baggrund af seneste eftersyn',10);
SET IDENTITY_INSERT [dbo].[Lageroptælling] OFF

INSERT INTO AktivUdleveringer(AktivID, PersonID, AktivUddelt, AktivIndsamlet)
VALUES
	(1,1,'2017-10-24 00:00:00','2019-10-09 21:53:56'),
	(2,3,'2017-10-24 00:00:00','2018-07-10 00:00:00'),
	(3,2,'2017-10-24 00:00:00','2017-12-14 00:00:00'),
	(4,2,'2017-10-24 00:00:00','2018-10-03 00:00:00'),
	(5,2,'2017-10-24 00:00:00','2017-12-12 00:00:00'),
	(6,1,'2017-10-24 00:00:00','2018-04-23 00:00:00');



SET IDENTITY_INSERT [dbo].[Ensembler] ON
insert into Ensembler(EnsembleID, Navn, Noter) VALUES 
(1, 'Orkester', NULL),
(2, 'TambourKorps', NULL),
(3, 'FanfareGruppe', NULL),
(4, 'LowBrass', NULL);
SET IDENTITY_INSERT [dbo].[Ensembler] OFF


SET IDENTITY_INSERT [dbo].[Roller] ON
insert into Roller(RolleID, Rolle)VALUES
(1, 'Musikchef'),
(2, 'Assisterende dirigent'),
(3, 'Førstedirigent'),
(4, 'Visedirigent'),
(5, 'Dirigentlinje'), --Elever på Dirigentlinjen
(6, 'Tambourmajor'),
(7, 'Kaptajn'),
(8, 'Visetambourmajor'),
(9, 'Fanebærer'),
(10, 'Koncertmester'), --Foretager indstemning af orkesteret
(11, 'Lærer'),
(12, 'Leder'),
(13, 'Musiker'),
(14, 'Elev');
SET IDENTITY_INSERT [dbo].[Roller] OFF

/* Tom men klar til at fylde på som nødvendigt
SET IDENTITY_INSERT [dbo].[EnsembleDeltagere] ON
insert into EnsembleDeltagere(EnsDeltager, PersonID, EnsembleID, RolleID, TilMeldt, UdMeldt) VALUES 
();
SET IDENTITY_INSERT [dbo].[EnsembleDeltagere] OFF
*/





SET IDENTITY_INSERT [dbo].[StemmeBogType] ON
insert into StemmeBogType (StemmeBogTypeID, BogType) values
(1, 'March'),
(2, 'Sang'),
(3, 'Koncert'),
(4, 'Jul'),
(5, 'Projekt'),
(6, 'Fanfare');
SET IDENTITY_INSERT [dbo].[StemmeBogType] OFF


SET IDENTITY_INSERT [dbo].[StemmeNummer] ON
insert into StemmeNummer (StemmeNummerID, StemmeNummerTal) values
(1, 'I'),
(2, 'II'),
(3, 'III'),
(4, 'IV'),
(5, 'V'),
(6, 'VI'),
(7, 'VII'),
(8, 'VIII'),
(9, 'IX'),
(10, 'X');
SET IDENTITY_INSERT [dbo].[StemmeNummer] OFF


SET IDENTITY_INSERT [dbo].[StemmmeBogStatus] ON
insert into StemmmeBogStatus (StemmmeBogStatusID, BogStatus) values
(1, 'Uddelt'),
(2, 'Til Uddeling'),
(3, 'På Lager'),
(4, 'Uddelt skal Indhentes'), --(eventuelt kryds med stoppede medlemmer)
(5, 'Mistet');
SET IDENTITY_INSERT [dbo].[StemmmeBogStatus] OFF


SET IDENTITY_INSERT [dbo].[Noder] ON
insert into Noder (MusikID, Titel, Komponist, Forfatter, Forlag) values
(1, 'KrykHus Galloppen', 'Frede Fed', 'Frede Fed', 'Lyriske fejltagelser'),
(2, 'A Kilo Gallop', 'A. Kiel', 'A. Kiel', 'Nemo Publishing'),
(3, 'AT Turen', 'Andre Turlet', 'Andre Turlet','Nemo Publishing'),
(4, 'A Van', 'A. van Veluwen', 'A. van Veluwen', 'Nemo Publishing'),
(5, 'W Ben', 'A. W. Benoy', 'A. W. Benoy', 'Lyriske fejltagelser'),
(6, 'Vinter stemning', 'A. Winter', 'A. Winter', 'Nemo Publishing'),
(7, 'Manzimmer', 'Charles A. Zimmermann', 'Charles A. Zimmermann', 'Lyriske fejltagelser'),
(8, 'Vandkloset', 'Abba', 'Abba', 'Nemo Publishing'),
(9, 'Drisiebert', 'Adrich Siebert', 'Adrich Siebert', 'Lyriske fejltagelser'),
(10, 'Armenken', 'Alan Irwin Menken', 'Alan Irwin Menken', 'Nemo Publishing'),
(11, 'Mancini March', 'Albert Mancini', 'Albert Mancini', 'Lyriske fejltagelser'),
(12, 'Cigaroo', 'Alessandro Cicognini', 'Alessandro Cicognini', 'Nemo Publishing'),
(13, 'Miles Alhart', 'Alfred Hart Miles', 'Alfred Hart Miles', 'Lyriske fejltagelser'),
(14, 'Gade Allan', 'Allan Street', 'Allan Street', 'Nemo Publishing'),
(15, 'LundMund', 'Amund Björklund', 'Amund Björklund', 'Lyriske fejltagelser'),
(16, 'Hornez', 'André Hornez', 'André Hornez', 'Nemo Publishing'),
(17, 'Balance', 'Andrew Balent', 'Andrew Balent', 'Lyriske fejltagelser'),
(18, 'Den Hvide Dame', 'Andrew Lloyd Webber', 'Andrew Lloyd Webber', 'Nemo Publishing'),
(19, 'Newley', 'Anthony Newley', 'Anthony Newley', 'Lyriske fejltagelser'),
(20, 'Ølstein', 'Arne Ole Stein', 'Arne Ole Stein', 'Nemo Publishing'),
(21, 'Riesling', 'August Reckling', 'August Reckling', 'Lyriske fejltagelser'),
(22, 'Karls Aksel', 'Axel Carl Christian Frederiksen', 'Axel Carl Christian Frederiksen', 'Nemo Publishing'),
(23, 'Børgeling', 'Børge Bøhling-Petersen', 'Børge Bøhling-Petersen', 'Lyriske fejltagelser'),
(24, 'Crumpton Club', 'Barry Alan Crompton Gibb', 'Barry Alan Crompton Gibb', 'Nemo Publishing'),
(25, 'A hoy hoy', 'Bjarne Hoyer', 'Bjarne Hoyer', 'Lyriske fejltagelser'),
(26, 'Bern bernt', 'Ben Bern', 'Ben Bern', 'Nemo Publishing'),
(27, 'Anderben', 'Benny Andersson', 'Benny Andersson', 'Lyriske fejltagelser'),
(28, 'Roadrunner', 'Bent Fabricius-Bjerre', 'Bent Fabricius-Bjerre', 'Nemo Publishing'),
(29, 'Bearkam', 'Bert Kaempfert', 'Bert Kaempfert', 'Lyriske fejltagelser'),
(30, 'Dr. Who', 'Bil Mofit', 'Bil Mofit', 'Nemo Publishing'),
(31, 'Blitz', 'Bill E. Klitz', 'Bill E. Klitz', 'Lyriske fejltagelser'),
(32, 'Combehol', 'Bill Holcombe', 'Bill Holcombe', 'Nemo Publishing');
SET IDENTITY_INSERT [dbo].[Noder] OFF


SET IDENTITY_INSERT [dbo].[StemmeBøger] ON
insert into StemmeBøger (StemmeBogID, StemmeBogType, BogStatus, UddeltTil, Instrument, StemmeType) values
(1, 1, 1, 2, 12, 1),
(2, 1, 2, null, 12, 1),
(3, 1, 3, null, 12, 1),
(4, 1, 4, 3, 12, 1);
SET IDENTITY_INSERT [dbo].[StemmeBøger] OFF


