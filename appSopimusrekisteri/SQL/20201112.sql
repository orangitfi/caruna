CREATE TABLE hlp_Vuokratyyppi (
	VTId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	VTNimi VARCHAR(300) NOT NULL,
	VTLuotu DATETIME NOT NULL,
	VTLuoja VARCHAR(300) NOT NULL,
	VTPaivitetty DATETIME NULL,
	VTPaivittaja VARCHAR(300) NULL
)
GO

INSERT INTO hlp_Vuokratyyppi 
(VTNimi, VTLuotu, VTLuoja) VALUES
('Maavuokra', GETDATE(), 'admin'),
('Kiinteistövuokra', GETDATE(), 'admin')
GO

CREATE TABLE hlp_Korkoprosentti (
	KPId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	KPProsentti DECIMAL(19, 4) NOT NULL,
	KPVuodet INT NOT NULL,
	KPLuotu DATETIME NOT NULL,
	KPLuoja VARCHAR(300) NOT NULL,
	KPPaivitetty DATETIME NULL,
	KPPaivittaja VARCHAR(300) NULL
)
GO

INSERT INTO hlp_Korkoprosentti (KPVuodet, KPProsentti, KPLuotu, KPLuoja) VALUES
(0,0.69, GETDATE(), 'admin'),
(1,0.69, GETDATE(), 'admin'),
(2,0.69, GETDATE(), 'admin'),
(3,0.69, GETDATE(), 'admin'),
(4,0.69, GETDATE(), 'admin'),
(5,0.86, GETDATE(), 'admin'),
(6,1.02, GETDATE(), 'admin'),
(7,1.19, GETDATE(), 'admin'),
(8,1.36, GETDATE(), 'admin'),
(9,1.53, GETDATE(), 'admin'),
(10,1.69, GETDATE(), 'admin'),
(11,1.80, GETDATE(), 'admin'),
(12,1.90, GETDATE(), 'admin'),
(13,2.01, GETDATE(), 'admin'),
(14,2.12, GETDATE(), 'admin'),
(15,2.22, GETDATE(), 'admin'),
(16,2.30, GETDATE(), 'admin'),
(17,2.38, GETDATE(), 'admin'),
(18,2.46, GETDATE(), 'admin'),
(19,2.54, GETDATE(), 'admin'),
(20,2.61, GETDATE(), 'admin'),
(21,2.67, GETDATE(), 'admin'),
(22,2.72, GETDATE(), 'admin'),
(23,2.78, GETDATE(), 'admin'),
(24,2.83, GETDATE(), 'admin'),
(25,2.88, GETDATE(), 'admin'),
(26,2.91, GETDATE(), 'admin'),
(27,2.94, GETDATE(), 'admin'),
(28,2.97, GETDATE(), 'admin'),
(29,3.00, GETDATE(), 'admin'),
(30,3.02, GETDATE(), 'admin'),
(31,3.07, GETDATE(), 'admin'),
(32,3.12, GETDATE(), 'admin'),
(33,3.16, GETDATE(), 'admin'),
(34,3.21, GETDATE(), 'admin'),
(35,3.26, GETDATE(), 'admin'),
(36,3.30, GETDATE(), 'admin'),
(37,3.33, GETDATE(), 'admin'),
(38,3.37, GETDATE(), 'admin'),
(39,3.41, GETDATE(), 'admin'),
(40,3.45, GETDATE(), 'admin'),
(41,3.48, GETDATE(), 'admin'),
(42,3.52, GETDATE(), 'admin'),
(43,3.56, GETDATE(), 'admin'),
(44,3.59, GETDATE(), 'admin'),
(45,3.63, GETDATE(), 'admin'),
(46,3.67, GETDATE(), 'admin'),
(47,3.71, GETDATE(), 'admin'),
(48,3.74, GETDATE(), 'admin'),
(49,3.78, GETDATE(), 'admin'),
(50,3.82, GETDATE(), 'admin')
GO

ALTER TABLE Sopimus ADD SOPVuokratyyppiId INT NULL FOREIGN KEY REFERENCES hlp_Vuokratyyppi(VTId)
GO

ALTER TABLE Sopimus ADD SOPKorkoprosentti DECIMAL(19, 4) NULL
GO

-- Lähde, josta korkoprosentti on alun perin laskettu, ei tulisi käyttää missään kyselyissä. Vain tiedoksi
ALTER TABLE Sopimus ADD SOPLahdeKorkoprosenttiId INT NULL FOREIGN KEY REFERENCES hlp_Korkoprosentti(KPId)
GO

ALTER TABLE Sopimus ADD SOPFAS BIT NOT NULL DEFAULT(0)
GO

ALTER TABLE Sopimus ADD SOPIFRS BIT NOT NULL DEFAULT(0)
GO