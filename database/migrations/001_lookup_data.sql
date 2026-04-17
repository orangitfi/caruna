-- Lookup/Reference Data
-- Auto-generated from Fortum database
-- Tables: hlp_* and hlps_* (< 100 rows each)

SET NOCOUNT ON;
GO

-- Table: hlp_AktiviteetinLaji (3 rows)
SET IDENTITY_INSERT [hlp_AktiviteetinLaji] ON;
INSERT INTO [hlp_AktiviteetinLaji] ([ALId], [ALLaji], [ALLuotu], [ALLuoja], [ALPaivitetty], [ALPaivittaja]) VALUES ('1', 'Tiedustelu', '2013-12-23 15:29:03.957', 'admin', '2013-12-23 15:29:03.957', 'admin');
INSERT INTO [hlp_AktiviteetinLaji] ([ALId], [ALLaji], [ALLuotu], [ALLuoja], [ALPaivitetty], [ALPaivittaja]) VALUES ('2', 'Ilmoitus', '2013-12-31 08:24:55.580', 'admin', '2013-12-31 08:24:55.580', 'admin');
INSERT INTO [hlp_AktiviteetinLaji] ([ALId], [ALLaji], [ALLuotu], [ALLuoja], [ALPaivitetty], [ALPaivittaja]) VALUES ('3', 'CaCe', '2013-12-31 08:25:02.383', 'admin', '2013-12-31 08:25:02.383', 'admin');
SET IDENTITY_INSERT [hlp_AktiviteetinLaji] OFF;
GO

-- Table: hlp_AktiviteetinStatus (2 rows)
SET IDENTITY_INSERT [hlp_AktiviteetinStatus] ON;
INSERT INTO [hlp_AktiviteetinStatus] ([ASId], [ASAktiviteetinStatus], [ASLuotu], [ASLuoja], [ASPaivitetty], [ASPaivittaja]) VALUES ('1', 'Avoin', '2013-12-23 15:29:46.803', 'admin', '2013-12-23 15:29:46.803', 'admin');
INSERT INTO [hlp_AktiviteetinStatus] ([ASId], [ASAktiviteetinStatus], [ASLuotu], [ASLuoja], [ASPaivitetty], [ASPaivittaja]) VALUES ('2', 'Valmis', '2013-12-23 15:29:55.393', 'admin', '2013-12-23 15:29:55.393', 'admin');
SET IDENTITY_INSERT [hlp_AktiviteetinStatus] OFF;
GO

-- Table: hlp_AktiviteettiYhteystapa (6 rows)
SET IDENTITY_INSERT [hlp_AktiviteettiYhteystapa] ON;
INSERT INTO [hlp_AktiviteettiYhteystapa] ([YTAId], [YTAYhteystapa], [YTALuotu], [YTALuoja], [YTAPaivitetty], [YTAPaivittaja]) VALUES ('1', 'Puhelu', '2013-12-23 15:42:15.753', 'admin', '2013-12-23 15:42:15.753', 'admin');
INSERT INTO [hlp_AktiviteettiYhteystapa] ([YTAId], [YTAYhteystapa], [YTALuotu], [YTALuoja], [YTAPaivitetty], [YTAPaivittaja]) VALUES ('2', 'Tapaaminen', '2013-12-23 15:42:15.753', 'admin', '2013-12-23 15:42:15.753', 'admin');
INSERT INTO [hlp_AktiviteettiYhteystapa] ([YTAId], [YTAYhteystapa], [YTALuotu], [YTALuoja], [YTAPaivitetty], [YTAPaivittaja]) VALUES ('3', 'Sähköpostiviesti', '2013-12-23 15:42:15.753', 'admin', '2013-12-23 15:42:15.753', 'admin');
INSERT INTO [hlp_AktiviteettiYhteystapa] ([YTAId], [YTAYhteystapa], [YTALuotu], [YTALuoja], [YTAPaivitetty], [YTAPaivittaja]) VALUES ('4', 'Faksi', '2013-12-23 15:42:15.753', 'admin', '2013-12-23 15:42:15.753', 'admin');
INSERT INTO [hlp_AktiviteettiYhteystapa] ([YTAId], [YTAYhteystapa], [YTALuotu], [YTALuoja], [YTAPaivitetty], [YTAPaivittaja]) VALUES ('5', 'Kirje', '2013-12-23 15:42:15.753', 'admin', '2013-12-23 15:42:15.753', 'admin');
INSERT INTO [hlp_AktiviteettiYhteystapa] ([YTAId], [YTAYhteystapa], [YTALuotu], [YTALuoja], [YTAPaivitetty], [YTAPaivittaja]) VALUES ('6', 'Maksu', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_AktiviteettiYhteystapa] OFF;
GO

-- Table: hlp_Alv (2 rows)
SET IDENTITY_INSERT [hlp_Alv] ON;
INSERT INTO [hlp_Alv] ([ALVId], [ALVProsentti], [ALVOletus], [ALVLuoja], [ALVLuotu], [ALVPaivittaja], [ALVPaivitetty]) VALUES ('1', '24.00', '0', 'admin', '2015-03-13 16:36:03.190', NULL, NULL);
INSERT INTO [hlp_Alv] ([ALVId], [ALVProsentti], [ALVOletus], [ALVLuoja], [ALVLuotu], [ALVPaivittaja], [ALVPaivitetty]) VALUES ('2', '25.50', '1', 'admin', '2024-10-18 18:00:00.000', NULL, NULL);
SET IDENTITY_INSERT [hlp_Alv] OFF;
GO

-- Table: hlp_ArkistonSijainti (3 rows)
SET IDENTITY_INSERT [hlp_ArkistonSijainti] ON;
INSERT INTO [hlp_ArkistonSijainti] ([ASIId], [ASIArkistonSijainti], [ASILuotu], [ASILuoja], [ASIPaivitetty], [ASIPaivittaja]) VALUES ('3', 'Keskusarkisto', '2013-12-30 10:08:32.043', 'admin', '2013-12-30 10:08:32.043', 'admin');
INSERT INTO [hlp_ArkistonSijainti] ([ASIId], [ASIArkistonSijainti], [ASILuotu], [ASILuoja], [ASIPaivitetty], [ASIPaivittaja]) VALUES ('4', 'Aluetoimisto', '2013-12-31 08:45:39.640', 'admin', '2013-12-31 08:45:39.640', 'admin');
INSERT INTO [hlp_ArkistonSijainti] ([ASIId], [ASIArkistonSijainti], [ASILuotu], [ASILuoja], [ASIPaivitetty], [ASIPaivittaja]) VALUES ('5', 'SharePoint (vain)', '2013-12-31 08:45:49.730', 'admin', '2013-12-31 08:45:49.730', 'admin');
SET IDENTITY_INSERT [hlp_ArkistonSijainti] OFF;
GO

-- Table: hlp_Asiakastyyppi (7 rows)
SET IDENTITY_INSERT [hlp_Asiakastyyppi] ON;
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('1', 'Alkuperäinen osapuoli', '2013-12-31 08:47:52.053', 'admin', '2013-12-31 08:47:52.053', 'admin');
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('2', 'Nykyinen osapuoli', '2013-12-31 08:47:59.650', 'admin', '2013-12-31 08:47:59.650', 'admin');
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('3', 'Haltija', '2013-12-31 08:48:08.633', 'admin', '2013-12-31 08:48:08.633', 'admin');
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('4', 'Vuokralainen', '2013-12-31 08:48:17.807', 'admin', '2013-12-31 08:48:17.807', 'admin');
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('5', 'Omistaja', '2014-02-12 15:19:06.217', 'admin', '2014-02-12 15:19:06.217', 'admin');
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('7', 'Kuolinpesän osakas', '2015-06-26 14:36:01.217', 'forseout', NULL, NULL);
INSERT INTO [hlp_Asiakastyyppi] ([ATYId], [ATYAsiakastyyppi], [ATYLuotu], [ATYLuoja], [ATYPaivitetty], [ATYPaivittaja]) VALUES ('8', 'Edunvalvoja', '2015-06-26 14:36:13.183', 'forseout', NULL, NULL);
SET IDENTITY_INSERT [hlp_Asiakastyyppi] OFF;
GO

-- Table: hlp_BicKoodi (16 rows)
SET IDENTITY_INSERT [hlp_BicKoodi] ON;
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('1', 'CITIFIHX', 'Citibank', '713', '2014-03-25 13:37:16.597', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('2', 'DABAFIHH', 'Danske Bank', '8', '2014-03-25 13:37:16.600', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('3', 'DABAFIHX', 'Danske Bank', '34', '2014-03-25 13:37:16.603', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('4', 'DNBAFIHX', 'DNB Bank ASA, Finland Branch', '37', '2014-03-25 13:37:16.603', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('5', 'HANDFIHH', 'Handelsbanken', '31', '2014-03-25 13:37:16.607', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('6', 'ITELFIHH', 'Säästöpankkien Keskuspankki, Säästöpankit (Sp) ja Oma Säästöpankki', '715,400,402,403,406,407,408,410,411,412,414,415,416,417,418,419,420,421,423,424,425,426,427,428,429,430,431,432,435,436,437,438,439,440,441,442,443,444,445,446,447,448,449,450,451,452,454,455,456,457,458,459,460,461,462,463,464,483,484,485,486,487,488,489,490,491,492,493,495,496', '2014-03-25 13:37:16.610', 'admin', '2018-11-06 15:57:56.650', 'admin');
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('7', 'NDEAFIHH', 'Nordea Pankki (Nordea)', '1,2', '2014-03-25 13:37:16.610', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('8', 'OKOYFIHH', 'Pohjola Pankki (OP-Pohjola-ryhmän pankkien keskusrahalaitos)', '5', '2014-03-25 13:37:16.613', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('9', 'ESSEFIHX', 'Skandinaviska Enskilda Banken (SEB)', '33', '2014-03-25 13:37:16.613', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('10', 'SBANFIHH', 'S-Pankki', '39,36', '2014-03-25 13:37:16.617', 'admin', '2018-11-06 15:57:53.680', 'admin');
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('11', 'SWEDFIHH', 'Swedbank', '38', '2014-03-25 13:37:16.617', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('12', 'HELSFIHH', 'Aktia Pankki', '405,497', '2014-03-25 13:37:16.620', 'admin', '2018-11-06 15:57:47.643', 'admin');
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('14', 'AABAFI22', 'Ålandsbanken (ÅAB)', '6', '2014-03-25 13:37:16.623', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('15', 'BIGKFIH1', 'Bigbank', '717', '2018-11-06 15:58:07.710', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('16', 'POPFFI22', 'POP Pankit (POP), Bonum Pankki', '470,471,472,473,474,475,476,477,478', '2018-11-06 15:58:07.710', 'admin', NULL, NULL);
INSERT INTO [hlp_BicKoodi] ([BKId], [BKKoodi], [BKPankki], [BKRahalaitosTunnus], [BKLuotu], [BKLuoja], [BKPaivitetty], [BKPaivittaja]) VALUES ('17', 'HOLVFIHH', 'Holvi', '799', '2018-11-06 15:58:07.710', 'admin', NULL, NULL);
SET IDENTITY_INSERT [hlp_BicKoodi] OFF;
GO

-- Table: hlp_DFRooli (6 rows)
SET IDENTITY_INSERT [hlp_DFRooli] ON;
INSERT INTO [hlp_DFRooli] ([DFRId], [DFRRooli], [DFRLuotu], [DFRLuoja], [DFRPaivittaja], [DFRPaivitetty]) VALUES ('1', 'Omistaja', '2013-12-30 17:04:15.223', 'admin', 'admin', '2013-12-30 17:04:15.223');
INSERT INTO [hlp_DFRooli] ([DFRId], [DFRRooli], [DFRLuotu], [DFRLuoja], [DFRPaivittaja], [DFRPaivitetty]) VALUES ('2', 'Vuokranantaja', '2013-12-30 17:04:26.190', 'admin', 'admin', '2013-12-30 17:04:26.190');
INSERT INTO [hlp_DFRooli] ([DFRId], [DFRRooli], [DFRLuotu], [DFRLuoja], [DFRPaivittaja], [DFRPaivitetty]) VALUES ('3', 'Vuokralainen', '2013-12-30 17:04:39.970', 'admin', 'admin', '2013-12-30 17:04:39.970');
INSERT INTO [hlp_DFRooli] ([DFRId], [DFRRooli], [DFRLuotu], [DFRLuoja], [DFRPaivittaja], [DFRPaivitetty]) VALUES ('4', 'Käyttöoikeuden saaja', '2013-12-30 17:04:52.520', 'admin', 'admin', '2013-12-30 17:04:52.520');
INSERT INTO [hlp_DFRooli] ([DFRId], [DFRRooli], [DFRLuotu], [DFRLuoja], [DFRPaivittaja], [DFRPaivitetty]) VALUES ('5', 'Käyttöoikeuden antaja', '2013-12-30 17:05:03.217', 'admin', 'admin', '2013-12-30 17:05:03.217');
INSERT INTO [hlp_DFRooli] ([DFRId], [DFRRooli], [DFRLuotu], [DFRLuoja], [DFRPaivittaja], [DFRPaivitetty]) VALUES ('6', 'Myyjä', '2016-06-29 13:51:58.227', 'admin', NULL, '2016-06-29 13:51:58.227');
SET IDENTITY_INSERT [hlp_DFRooli] OFF;
GO

-- Table: hlp_HinnastoAlakategoria (9 rows)
SET IDENTITY_INSERT [hlp_HinnastoAlakategoria] ON;
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('1', 'Jakokaapit', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('2', 'Kiinteistömmo', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('3', 'Metsä', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('4', 'Pelto', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('5', 'Puistommo', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('6', 'Pylväsmmo', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('7', 'Tontti', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('8', 'Vesistö', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
INSERT INTO [hlp_HinnastoAlakategoria] ([HAKId], [HAKHinnastoAlakategoria], [HAKLuotu], [HAKLuoja], [HAKPaivitetty], [HAKPaivittaja]) VALUES ('9', 'Yleinen', '2014-01-02 09:37:45.263', 'admin', '2014-01-02 09:37:45.263', 'admin');
SET IDENTITY_INSERT [hlp_HinnastoAlakategoria] OFF;
GO

-- Table: hlp_HinnastoKategoria (3 rows)
SET IDENTITY_INSERT [hlp_HinnastoKategoria] ON;
INSERT INTO [hlp_HinnastoKategoria] ([HKAId], [HKAHinnastoKategoria], [HKALuotu], [HKALuoja], [HKAPaivitetty], [HKAPaivittaja]) VALUES ('1', 'JAS', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_HinnastoKategoria] ([HKAId], [HKAHinnastoKategoria], [HKALuotu], [HKALuoja], [HKAPaivitetty], [HKAPaivittaja]) VALUES ('2', 'Muuntamot', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_HinnastoKategoria] ([HKAId], [HKAHinnastoKategoria], [HKALuotu], [HKALuoja], [HKAPaivitetty], [HKAPaivittaja]) VALUES ('3', 'Vesistö', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_HinnastoKategoria] OFF;
GO

-- Table: hlp_Indeksi (6 rows)
SET IDENTITY_INSERT [hlp_Indeksi] ON;
INSERT INTO [hlp_Indeksi] ([IKDId], [IKDIndeksityyppiId], [IKDKuukausiId], [IKDVuosi], [IKDArvo], [IKDLuoja], [IKDLuotu], [IKDPaivittaja], [IKDPaivitetty]) VALUES ('1', '2', '4', '2015', '1654', 'admin', '2016-06-08 14:39:23.457', 'admin', '2016-06-09 09:13:36.297');
INSERT INTO [hlp_Indeksi] ([IKDId], [IKDIndeksityyppiId], [IKDKuukausiId], [IKDVuosi], [IKDArvo], [IKDLuoja], [IKDLuotu], [IKDPaivittaja], [IKDPaivitetty]) VALUES ('2', '2', '4', '2016', '1654', 'admin', '2016-10-31 10:34:04.583', 'admin', '2016-10-31 10:34:04.583');
INSERT INTO [hlp_Indeksi] ([IKDId], [IKDIndeksityyppiId], [IKDKuukausiId], [IKDVuosi], [IKDArvo], [IKDLuoja], [IKDLuotu], [IKDPaivittaja], [IKDPaivitetty]) VALUES ('3', '2', '4', '2017', '1654', 'admin', '2017-09-11 14:34:41.243', 'admin', '2017-09-11 14:34:49.477');
INSERT INTO [hlp_Indeksi] ([IKDId], [IKDIndeksityyppiId], [IKDKuukausiId], [IKDVuosi], [IKDArvo], [IKDLuoja], [IKDLuotu], [IKDPaivittaja], [IKDPaivitetty]) VALUES ('4', '3', '9', '2017', '1900', 'admin', '2017-09-11 15:10:12.870', 'admin', '2017-09-11 15:10:12.870');
INSERT INTO [hlp_Indeksi] ([IKDId], [IKDIndeksityyppiId], [IKDKuukausiId], [IKDVuosi], [IKDArvo], [IKDLuoja], [IKDLuotu], [IKDPaivittaja], [IKDPaivitetty]) VALUES ('5', '4', '9', '2017', '1950', 'admin', '2017-09-11 15:10:29.717', 'admin', '2017-09-11 15:10:29.717');
INSERT INTO [hlp_Indeksi] ([IKDId], [IKDIndeksityyppiId], [IKDKuukausiId], [IKDVuosi], [IKDArvo], [IKDLuoja], [IKDLuotu], [IKDPaivittaja], [IKDPaivitetty]) VALUES ('6', '2', '6', '2017', '1900', 'admin', '2017-09-12 09:02:15.070', 'admin', '2017-09-12 12:22:23.150');
SET IDENTITY_INSERT [hlp_Indeksi] OFF;
GO

-- Table: hlp_Indeksityyppi (3 rows)
SET IDENTITY_INSERT [hlp_Indeksityyppi] ON;
INSERT INTO [hlp_Indeksityyppi] ([ITYId], [ITYIndeksityyppi], [ITYLuoja], [ITYLuotu], [ITYPaivittaja], [ITYPaivitetty]) VALUES ('2', 'Elinkustannusindeksi', 'admin', '2013-12-31 08:49:33.523', 'admin', '2013-12-31 08:49:33.523');
INSERT INTO [hlp_Indeksityyppi] ([ITYId], [ITYIndeksityyppi], [ITYLuoja], [ITYLuotu], [ITYPaivittaja], [ITYPaivitetty]) VALUES ('3', 'Kuluttajahintaindeksi', 'admin', '2013-12-31 08:49:41.583', 'admin', '2013-12-31 08:49:41.583');
INSERT INTO [hlp_Indeksityyppi] ([ITYId], [ITYIndeksityyppi], [ITYLuoja], [ITYLuotu], [ITYPaivittaja], [ITYPaivitetty]) VALUES ('4', 'Rakennuskustannusindeksi', 'admin', '2013-12-31 08:49:48.687', 'admin', '2013-12-31 08:49:48.687');
SET IDENTITY_INSERT [hlp_Indeksityyppi] OFF;
GO

-- Table: hlp_InvCost (2 rows)
SET IDENTITY_INSERT [hlp_InvCost] ON;
INSERT INTO [hlp_InvCost] ([ICOId], [ICONimi], [ICOLuotu], [ICOLuoja], [ICOPaivitetty], [ICOPaivittaja]) VALUES ('1', '-', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_InvCost] ([ICOId], [ICONimi], [ICOLuotu], [ICOLuoja], [ICOPaivitetty], [ICOPaivittaja]) VALUES ('2', 'EAS', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_InvCost] OFF;
GO

-- Table: hlp_Julkisuusaste (1 rows)
SET IDENTITY_INSERT [hlp_Julkisuusaste] ON;
INSERT INTO [hlp_Julkisuusaste] ([JASId], [JASJulkisuusaste], [JASLuotu], [JASLuoja], [JASPaivitetty], [JASPaivittaja]) VALUES ('1', 'Sisäinen ja asiakirjan osapuolet', '2013-12-27 18:44:53.933', 'admin', '2013-12-27 18:44:53.933', 'admin');
SET IDENTITY_INSERT [hlp_Julkisuusaste] OFF;
GO

-- Table: hlp_Kieli (3 rows)
SET IDENTITY_INSERT [hlp_Kieli] ON;
INSERT INTO [hlp_Kieli] ([KIEId], [KIEKieli], [KIELuoja], [KIELuotu], [KIEPaivittaja], [KIEPaivitetty], [KIEKieliTunniste]) VALUES ('1', 'Suomi', 'admin', '2014-04-08 17:04:30.303', 'admin', '2014-04-08 17:04:30.303', 'FIN');
INSERT INTO [hlp_Kieli] ([KIEId], [KIEKieli], [KIELuoja], [KIELuotu], [KIEPaivittaja], [KIEPaivitetty], [KIEKieliTunniste]) VALUES ('2', 'Ruotsi', 'admin', '2014-04-08 17:04:30.307', 'admin', '2014-04-08 17:04:30.307', 'SWE');
INSERT INTO [hlp_Kieli] ([KIEId], [KIEKieli], [KIELuoja], [KIELuotu], [KIEPaivittaja], [KIEPaivitetty], [KIEKieliTunniste]) VALUES ('3', 'Englanti', 'admin', '2016-02-14 22:03:23.110', NULL, '2016-02-14 22:03:23.110', 'ENG');
SET IDENTITY_INSERT [hlp_Kieli] OFF;
GO

-- Table: hlp_KirjanpidonKustannuspaikka (10 rows)
SET IDENTITY_INSERT [hlp_KirjanpidonKustannuspaikka] ON;
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('1', 'D2040', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'AMD Head ja Vahvaverkko', NULL);
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('2', 'D2041', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Kupisuunn. Alueverkko', NULL);
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('3', 'D2042', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Kupisuunn. Jakeluverkko', NULL);
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('4', 'D2045', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Asset Owner City', '2045');
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('5', 'D2050', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Network Planning City', '2050');
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('6', 'D2055', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Asset Owner Rural', '2055');
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('7', 'D2060', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Network planning Rural', '2060');
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('8', 'D2065', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Sopimukset ja Dokumentointi', '2065');
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('9', 'D2105', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Network Planning', NULL);
INSERT INTO [hlp_KirjanpidonKustannuspaikka] ([KPKId], [KPKKirjanpidonKustannuspaikka], [KPKLuotu], [KPKLuoja], [KPKPaivitetty], [KPKPaivittaja], [KPKSelite], [_responsId]) VALUES ('10', 'D2105', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', NULL, NULL);
SET IDENTITY_INSERT [hlp_KirjanpidonKustannuspaikka] OFF;
GO

-- Table: hlp_Kirjanpidontili (3 rows)
SET IDENTITY_INSERT [hlp_Kirjanpidontili] ON;
INSERT INTO [hlp_Kirjanpidontili] ([KPTId], [KPTKirjanpidonTili], [KPTLuotu], [KPTLuoja], [KPTPaivitetty], [KPTPaivittaja], [KPTSelite]) VALUES ('3', '1284', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Kertakorvauksen tili');
INSERT INTO [hlp_Kirjanpidontili] ([KPTId], [KPTKirjanpidonTili], [KPTLuotu], [KPTLuoja], [KPTPaivitetty], [KPTPaivittaja], [KPTSelite]) VALUES ('4', '5110', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Kuukausi- ja Vuosikorvaukset');
INSERT INTO [hlp_Kirjanpidontili] ([KPTId], [KPTKirjanpidonTili], [KPTLuotu], [KPTLuoja], [KPTPaivitetty], [KPTPaivittaja], [KPTSelite]) VALUES ('5', '3911', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon', 'Pylväiden yhteiskäyttö');
SET IDENTITY_INSERT [hlp_Kirjanpidontili] OFF;
GO

-- Table: hlp_Kohdekategoria (4 rows)
SET IDENTITY_INSERT [hlp_Kohdekategoria] ON;
INSERT INTO [hlp_Kohdekategoria] ([KDKId], [KDKKohdeKategoria], [KDKLuotu], [KDKLuoja], [KDKPaivitetty], [KDKPaivittaja]) VALUES ('1', 'Maa', '2014-03-11 13:46:51.813', 'admin', '2014-03-11 13:46:51.813', 'admin');
INSERT INTO [hlp_Kohdekategoria] ([KDKId], [KDKKohdeKategoria], [KDKLuotu], [KDKLuoja], [KDKPaivitetty], [KDKPaivittaja]) VALUES ('2', 'Rakennukset', '2014-03-11 13:46:51.830', 'admin', '2014-03-11 13:46:51.830', 'admin');
INSERT INTO [hlp_Kohdekategoria] ([KDKId], [KDKKohdeKategoria], [KDKLuotu], [KDKLuoja], [KDKPaivitetty], [KDKPaivittaja]) VALUES ('3', 'Muu', '2014-03-11 13:46:51.830', 'admin', '2014-03-11 13:46:51.830', 'admin');
INSERT INTO [hlp_Kohdekategoria] ([KDKId], [KDKKohdeKategoria], [KDKLuotu], [KDKLuoja], [KDKPaivitetty], [KDKPaivittaja]) VALUES ('4', 'Sähköverkko', '2014-03-11 13:46:51.830', 'admin', '2014-03-11 13:46:51.830', 'admin');
SET IDENTITY_INSERT [hlp_Kohdekategoria] OFF;
GO

-- Table: hlp_Kyla (1 rows)
SET IDENTITY_INSERT [hlp_Kyla] ON;
INSERT INTO [hlp_Kyla] ([KYLId], [KYLKyla], [KYLLuoja], [KYLLuotu], [KYLPaivitetty], [KYLPaivittaja]) VALUES ('1', 'Mikkilä', 'admin', '2013-12-31 08:52:03.113', '2013-12-31 08:52:03.113', 'admin');
SET IDENTITY_INSERT [hlp_Kyla] OFF;
GO

-- Table: hlp_LiiketoiminnanTarve (4 rows)
SET IDENTITY_INSERT [hlp_LiiketoiminnanTarve] ON;
INSERT INTO [hlp_LiiketoiminnanTarve] ([LTOId], [LTOLiiketoiminnanTarve], [LTOLuotu], [LTOLuoja], [LTOPaivitetty], [LTOPaivittaja]) VALUES ('1', 'Ei arvioitu', '2013-12-30 15:07:49.783', 'admin', '2013-12-30 15:07:49.783', 'admin');
INSERT INTO [hlp_LiiketoiminnanTarve] ([LTOId], [LTOLiiketoiminnanTarve], [LTOLuotu], [LTOLuoja], [LTOPaivitetty], [LTOPaivittaja]) VALUES ('2', 'Ei tarpeellinen', '2013-12-30 15:08:02.940', 'admin', '2013-12-30 15:08:02.940', 'admin');
INSERT INTO [hlp_LiiketoiminnanTarve] ([LTOId], [LTOLiiketoiminnanTarve], [LTOLuotu], [LTOLuoja], [LTOPaivitetty], [LTOPaivittaja]) VALUES ('3', 'Tarpeellinen', '2013-12-30 15:08:12.387', 'admin', '2013-12-30 15:08:12.387', 'admin');
INSERT INTO [hlp_LiiketoiminnanTarve] ([LTOId], [LTOLiiketoiminnanTarve], [LTOLuotu], [LTOLuoja], [LTOPaivitetty], [LTOPaivittaja]) VALUES ('4', 'Osin tarpeellinen', '2013-12-30 15:08:22.610', 'admin', '2013-12-30 15:08:22.610', 'admin');
SET IDENTITY_INSERT [hlp_LiiketoiminnanTarve] OFF;
GO

-- Table: hlp_Local1 (3 rows)
SET IDENTITY_INSERT [hlp_Local1] ON;
INSERT INTO [hlp_Local1] ([LOCId], [LOCNimi], [LOCLuotu], [LOCLuoja], [LOCPaivitetty], [LOCPaivittaja]) VALUES ('1', '-', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_Local1] ([LOCId], [LOCNimi], [LOCLuotu], [LOCLuoja], [LOCPaivitetty], [LOCPaivittaja]) VALUES ('3', 'A002', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_Local1] ([LOCId], [LOCNimi], [LOCLuotu], [LOCLuoja], [LOCPaivitetty], [LOCPaivittaja]) VALUES ('4', 'A125', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_Local1] OFF;
GO

-- Table: hlp_Lupataho (5 rows)
SET IDENTITY_INSERT [hlp_Lupataho] ON;
INSERT INTO [hlp_Lupataho] ([LPTId], [LPTLupataho], [LPTLuoja], [LPTLuotu], [LPTPaivittaja], [LPTPaivitetty]) VALUES ('1', 'Kaupunki', 'admin', '2014-08-14 10:38:47.003', NULL, NULL);
INSERT INTO [hlp_Lupataho] ([LPTId], [LPTLupataho], [LPTLuoja], [LPTLuotu], [LPTPaivittaja], [LPTPaivitetty]) VALUES ('2', 'ELY', 'admin', '2014-08-14 10:38:47.010', NULL, NULL);
INSERT INTO [hlp_Lupataho] ([LPTId], [LPTLupataho], [LPTLuoja], [LPTLuotu], [LPTPaivittaja], [LPTPaivitetty]) VALUES ('3', 'Fingrid', 'admin', '2014-08-14 10:38:47.017', NULL, NULL);
INSERT INTO [hlp_Lupataho] ([LPTId], [LPTLupataho], [LPTLuoja], [LPTLuotu], [LPTPaivittaja], [LPTPaivitetty]) VALUES ('4', 'Tiekunta', 'admin', '2014-08-14 10:38:47.020', NULL, NULL);
INSERT INTO [hlp_Lupataho] ([LPTId], [LPTLupataho], [LPTLuoja], [LPTLuotu], [LPTPaivittaja], [LPTPaivitetty]) VALUES ('5', 'Ratahallinto', 'admin', '2015-03-03 11:05:58.390', 'admin', '2015-03-03 11:05:58.390');
SET IDENTITY_INSERT [hlp_Lupataho] OFF;
GO

-- Table: hlp_MaaraAlaTarkenne (1 rows)
SET IDENTITY_INSERT [hlp_MaaraAlaTarkenne] ON;
INSERT INTO [hlp_MaaraAlaTarkenne] ([MATId], [MATMaaraAlaTarkenne], [MATLuotu], [MATLuoja], [MATPaivitetty], [MATPaivittaja]) VALUES ('1', 'Erottamaton', '2013-12-30 14:51:18.920', 'admin', '2013-12-30 14:51:18.920', 'admin');
SET IDENTITY_INSERT [hlp_MaaraAlaTarkenne] OFF;
GO

-- Table: hlp_MaksunSuoritus (3 rows)
SET IDENTITY_INSERT [hlp_MaksunSuoritus] ON;
INSERT INTO [hlp_MaksunSuoritus] ([MSUId], [MSUMaksunSuoritus], [MSULuotu], [MSULuoja], [MSUPaivitetty], [MSUPaivittaja]) VALUES ('1', 'Asiakkaan lähettämä lasku (Bw IP)', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_MaksunSuoritus] ([MSUId], [MSUMaksunSuoritus], [MSULuotu], [MSULuoja], [MSUPaivitetty], [MSUPaivittaja]) VALUES ('2', 'Verkonhaltija suorittaa korvauksen', '2014-01-02 11:47:14.467', 'admin', '2014-01-02 11:47:14.467', 'admin');
INSERT INTO [hlp_MaksunSuoritus] ([MSUId], [MSUMaksunSuoritus], [MSULuotu], [MSULuoja], [MSUPaivitetty], [MSUPaivittaja]) VALUES ('3', 'Asiakkaan läh tosite perusteena', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_MaksunSuoritus] OFF;
GO

-- Table: hlp_Metsatyyppi (4 rows)
SET IDENTITY_INSERT [hlp_Metsatyyppi] ON;
INSERT INTO [hlp_Metsatyyppi] ([MTYId], [MTYMetsatyyppi], [MTYLuotu], [MTYLuoja], [MTYPaivitetty], [MTYPaivittaja]) VALUES ('1', 'Kuiva kangas', '2014-01-02 09:39:03.750', 'admin', '2014-01-02 09:39:03.750', 'admin');
INSERT INTO [hlp_Metsatyyppi] ([MTYId], [MTYMetsatyyppi], [MTYLuotu], [MTYLuoja], [MTYPaivitetty], [MTYPaivittaja]) VALUES ('2', 'Kuivahko kangas', '2014-01-02 09:39:03.750', 'admin', '2014-01-02 09:39:03.750', 'admin');
INSERT INTO [hlp_Metsatyyppi] ([MTYId], [MTYMetsatyyppi], [MTYLuotu], [MTYLuoja], [MTYPaivitetty], [MTYPaivittaja]) VALUES ('3', 'Lehtomainen', '2014-01-02 09:39:03.750', 'admin', '2014-01-02 09:39:03.750', 'admin');
INSERT INTO [hlp_Metsatyyppi] ([MTYId], [MTYMetsatyyppi], [MTYLuotu], [MTYLuoja], [MTYPaivitetty], [MTYPaivittaja]) VALUES ('4', 'Tuore kangas', '2014-01-02 09:39:03.750', 'admin', '2014-01-02 09:39:03.750', 'admin');
SET IDENTITY_INSERT [hlp_Metsatyyppi] OFF;
GO

-- Table: hlp_Purpose (3 rows)
SET IDENTITY_INSERT [hlp_Purpose] ON;
INSERT INTO [hlp_Purpose] ([PURId], [PURNimi], [PURLuotu], [PURLuoja], [PURPaivitetty], [PURPaivittaja]) VALUES ('1', '0', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_Purpose] ([PURId], [PURNimi], [PURLuotu], [PURLuoja], [PURPaivitetty], [PURPaivittaja]) VALUES ('3', '-', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_Purpose] ([PURId], [PURNimi], [PURLuotu], [PURLuoja], [PURPaivitetty], [PURPaivittaja]) VALUES ('4', '0FI', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_Purpose] OFF;
GO

-- Table: hlp_Puustolaji (3 rows)
SET IDENTITY_INSERT [hlp_Puustolaji] ON;
INSERT INTO [hlp_Puustolaji] ([PLAId], [PLAPuustolaji], [PLALuotu], [PLALuoja], [PLAPaivitetty], [PLAPaivittaja]) VALUES ('1', 'Koivu', '2014-01-02 09:39:49.890', 'admin', '2014-01-02 09:39:49.890', 'admin');
INSERT INTO [hlp_Puustolaji] ([PLAId], [PLAPuustolaji], [PLALuotu], [PLALuoja], [PLAPaivitetty], [PLAPaivittaja]) VALUES ('2', 'Kuusi', '2014-01-02 09:39:49.890', 'admin', '2014-01-02 09:39:49.890', 'admin');
INSERT INTO [hlp_Puustolaji] ([PLAId], [PLAPuustolaji], [PLALuotu], [PLALuoja], [PLAPaivitetty], [PLAPaivittaja]) VALUES ('3', 'Mänty', '2014-01-02 09:39:49.890', 'admin', '2014-01-02 09:39:49.890', 'admin');
SET IDENTITY_INSERT [hlp_Puustolaji] OFF;
GO

-- Table: hlp_PuustonOmistajuus (2 rows)
SET IDENTITY_INSERT [hlp_PuustonOmistajuus] ON;
INSERT INTO [hlp_PuustonOmistajuus] ([POMId], [POMPuustonOmistajuus], [POMLuotu], [POMLuoja], [POMPaivitetty], [POMPaivittaja], [POMPuustonOmistajuusSwe]) VALUES ('1', 'Maanomistajan', '2014-01-02 12:10:35.247', 'admin', '2014-01-02 12:10:35.247', 'admin', 'Markägaren');
INSERT INTO [hlp_PuustonOmistajuus] ([POMId], [POMPuustonOmistajuus], [POMLuotu], [POMLuoja], [POMPaivitetty], [POMPaivittaja], [POMPuustonOmistajuusSwe]) VALUES ('2', 'Johdonomistajan', '2014-01-02 12:10:53.960', 'admin', '2014-01-02 12:10:53.960', 'admin', 'Ledningsägaren');
SET IDENTITY_INSERT [hlp_PuustonOmistajuus] OFF;
GO

-- Table: hlp_PuustonPoisto (2 rows)
SET IDENTITY_INSERT [hlp_PuustonPoisto] ON;
INSERT INTO [hlp_PuustonPoisto] ([PPOId], [PPOPuustonPoisto], [PPOLuotu], [PPOLuoja], [PPOPaivitetty], [PPOPaivittaja], [PPOPuustonPoistoSwe]) VALUES ('1', 'Maanomistajan', '2014-01-02 12:16:03.137', 'admin', '2014-01-02 12:16:03.137', 'admin', NULL);
INSERT INTO [hlp_PuustonPoisto] ([PPOId], [PPOPuustonPoisto], [PPOLuotu], [PPOLuoja], [PPOPaivitetty], [PPOPaivittaja], [PPOPuustonPoistoSwe]) VALUES ('2', 'Johdonomistajan', '2014-01-02 12:16:11.510', 'admin', '2014-01-02 12:16:11.510', 'admin', NULL);
SET IDENTITY_INSERT [hlp_PuustonPoisto] OFF;
GO

-- Table: hlp_Regulation (3 rows)
SET IDENTITY_INSERT [hlp_Regulation] ON;
INSERT INTO [hlp_Regulation] ([REGId], [REGNimi], [REGLuotu], [REGLuoja], [REGPaivitetty], [REGPaivittaja]) VALUES ('1', '-', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_Regulation] ([REGId], [REGNimi], [REGLuotu], [REGLuoja], [REGPaivitetty], [REGPaivittaja]) VALUES ('3', '1 - reg.kulu kerta-, kk- ja vuosikorvauksissa', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
INSERT INTO [hlp_Regulation] ([REGId], [REGNimi], [REGLuotu], [REGLuoja], [REGPaivitetty], [REGPaivittaja]) VALUES ('4', '4 - Reg.n ulkopuolinen kustannus', '1753-01-01 00:00:00.000', 'Tuntematon', '1753-01-01 00:00:00.000', 'Tuntematon');
SET IDENTITY_INSERT [hlp_Regulation] OFF;
GO

-- Table: hlp_Saanto (4 rows)
SET IDENTITY_INSERT [hlp_Saanto] ON;
INSERT INTO [hlp_Saanto] ([SAAId], [SAASaanto], [SAALuotu], [SAALuoja], [SAAPaivitetty], [SAAPaivittaja]) VALUES ('3', 'Lainhuuto', '2013-12-30 15:12:20.343', 'admin', '2013-12-30 15:12:20.343', 'admin');
INSERT INTO [hlp_Saanto] ([SAAId], [SAASaanto], [SAALuotu], [SAALuoja], [SAAPaivitetty], [SAAPaivittaja]) VALUES ('4', 'Lainhuuto vireillä', '2013-12-30 15:12:29.963', 'admin', '2013-12-30 15:12:29.963', 'admin');
INSERT INTO [hlp_Saanto] ([SAAId], [SAASaanto], [SAALuotu], [SAALuoja], [SAAPaivitetty], [SAAPaivittaja]) VALUES ('5', 'Selvennyslainhuuto', '2013-12-30 15:12:42.060', 'admin', '2013-12-30 15:12:42.060', 'admin');
INSERT INTO [hlp_Saanto] ([SAAId], [SAASaanto], [SAALuotu], [SAALuoja], [SAAPaivitetty], [SAAPaivittaja]) VALUES ('6', 'Selvennyslainhuuto vireillä', '2013-12-30 15:12:59.133', 'admin', '2013-12-30 15:12:59.133', 'admin');
SET IDENTITY_INSERT [hlp_Saanto] OFF;
GO

-- Table: hlp_SiirtoOikeus (5 rows)
SET IDENTITY_INSERT [hlp_SiirtoOikeus] ON;
INSERT INTO [hlp_SiirtoOikeus] ([SOIId], [SOISiirtoOikeus], [SOILuotu], [SOILuoja], [SOIPaivitetty], [SOIPaivittaja]) VALUES ('1', 'Ei saa siirtää', '2013-12-30 17:44:18.603', 'admin', '2013-12-30 17:44:18.603', 'admin');
INSERT INTO [hlp_SiirtoOikeus] ([SOIId], [SOISiirtoOikeus], [SOILuotu], [SOILuoja], [SOIPaivitetty], [SOIPaivittaja]) VALUES ('2', 'Ei saa siirtää ilman kirjallista ilmoitusta', '2013-12-30 17:44:26.803', 'admin', '2013-12-30 17:44:26.803', 'admin');
INSERT INTO [hlp_SiirtoOikeus] ([SOIId], [SOISiirtoOikeus], [SOILuotu], [SOILuoja], [SOIPaivitetty], [SOIPaivittaja]) VALUES ('3', 'Ei saa siirtää ilman kirjallista sopimusta', '2013-12-30 17:44:35.390', 'admin', '2013-12-30 17:44:35.390', 'admin');
INSERT INTO [hlp_SiirtoOikeus] ([SOIId], [SOISiirtoOikeus], [SOILuotu], [SOILuoja], [SOIPaivitetty], [SOIPaivittaja]) VALUES ('4', 'Saa siirtää toiselle johdonomistajalle / verkonhaltijalle', '2013-12-30 17:44:46.833', 'admin', '2013-12-30 17:44:46.833', 'admin');
INSERT INTO [hlp_SiirtoOikeus] ([SOIId], [SOISiirtoOikeus], [SOILuotu], [SOILuoja], [SOIPaivitetty], [SOIPaivittaja]) VALUES ('5', 'Saa siirtää kolmannelle', '2013-12-30 17:44:55.630', 'admin', '2013-12-30 17:44:55.630', 'admin');
SET IDENTITY_INSERT [hlp_SiirtoOikeus] OFF;
GO

-- Table: hlp_SopimuksenAlaluokka (5 rows)
SET IDENTITY_INSERT [hlp_SopimuksenAlaluokka] ON;
INSERT INTO [hlp_SopimuksenAlaluokka] ([SALId], [SALSopimuksenAlaluokka], [SALLuotu], [SALLuoja], [SALPaivitetty], [SALPaivittaja]) VALUES ('1', 'Tyyppi 1', '2013-12-30 17:21:14.630', 'admin', '2013-12-30 17:21:14.630', 'admin');
INSERT INTO [hlp_SopimuksenAlaluokka] ([SALId], [SALSopimuksenAlaluokka], [SALLuotu], [SALLuoja], [SALPaivitetty], [SALPaivittaja]) VALUES ('2', 'Järvenpää Vaikea', '2013-12-30 17:21:24.553', 'admin', '2013-12-30 17:21:24.553', 'admin');
INSERT INTO [hlp_SopimuksenAlaluokka] ([SALId], [SALSopimuksenAlaluokka], [SALLuotu], [SALLuoja], [SALPaivitetty], [SALPaivittaja]) VALUES ('3', 'JAS 1973 -1976', '2013-12-30 17:21:33.177', 'admin', '2013-12-30 17:21:33.177', 'admin');
INSERT INTO [hlp_SopimuksenAlaluokka] ([SALId], [SALSopimuksenAlaluokka], [SALLuotu], [SALLuoja], [SALPaivitetty], [SALPaivittaja]) VALUES ('4', 'JAS 1977 -1984', '2013-12-30 17:21:42.117', 'admin', '2013-12-30 17:21:42.117', 'admin');
INSERT INTO [hlp_SopimuksenAlaluokka] ([SALId], [SALSopimuksenAlaluokka], [SALLuotu], [SALLuoja], [SALPaivitetty], [SALPaivittaja]) VALUES ('5', 'JAS Fortum 2010 -', '2013-12-30 17:21:50.693', 'admin', '2013-12-30 17:21:50.693', 'admin');
SET IDENTITY_INSERT [hlp_SopimuksenAlaluokka] OFF;
GO

-- Table: hlp_SopimuksenEhtoversio (2 rows)
SET IDENTITY_INSERT [hlp_SopimuksenEhtoversio] ON;
INSERT INTO [hlp_SopimuksenEhtoversio] ([SEHId], [SEHSopimuksenEhtoversio], [SEHLuotu], [SEHLuoja], [SEHPaivitetty], [SEHPaivittaja]) VALUES ('1', 'Käsin kirjoitettuja ehtoja', '2013-12-30 17:25:17.753', 'admin', '2013-12-30 17:25:17.753', 'admin');
INSERT INTO [hlp_SopimuksenEhtoversio] ([SEHId], [SEHSopimuksenEhtoversio], [SEHLuotu], [SEHLuoja], [SEHPaivitetty], [SEHPaivittaja]) VALUES ('2', 'Koneellisia lisäehtoja', '2013-12-30 17:25:27.690', 'admin', '2013-12-30 17:25:27.690', 'admin');
SET IDENTITY_INSERT [hlp_SopimuksenEhtoversio] OFF;
GO

-- Table: hlp_SopimuksenKesto (4 rows)
SET IDENTITY_INSERT [hlp_SopimuksenKesto] ON;
INSERT INTO [hlp_SopimuksenKesto] ([SKEId], [SKESopimuksenKesto], [SKELuoja], [SKELuotu], [SKEPaivittaja], [SKEPaivitetty]) VALUES ('1', '10V', 'admin', '2013-12-31 09:01:52.907', 'admin', '2013-12-31 09:01:52.907');
INSERT INTO [hlp_SopimuksenKesto] ([SKEId], [SKESopimuksenKesto], [SKELuoja], [SKELuotu], [SKEPaivittaja], [SKEPaivitetty]) VALUES ('2', '30v', 'admin', '2013-12-31 09:01:58.550', 'admin', '2013-12-31 09:01:58.550');
INSERT INTO [hlp_SopimuksenKesto] ([SKEId], [SKESopimuksenKesto], [SKELuoja], [SKELuotu], [SKEPaivittaja], [SKEPaivitetty]) VALUES ('3', '50v', 'admin', '2013-12-31 09:02:04.950', 'admin', '2013-12-31 09:02:04.950');
INSERT INTO [hlp_SopimuksenKesto] ([SKEId], [SKESopimuksenKesto], [SKELuoja], [SKELuotu], [SKEPaivittaja], [SKEPaivitetty]) VALUES ('4', 'Pysyvä', 'admin', '2013-12-31 09:02:11.280', 'admin', '2013-12-31 09:02:11.280');
SET IDENTITY_INSERT [hlp_SopimuksenKesto] OFF;
GO

-- Table: hlp_SopimusFormaatti (1 rows)
SET IDENTITY_INSERT [hlp_SopimusFormaatti] ON;
INSERT INTO [hlp_SopimusFormaatti] ([SFOId], [SFOSopimusFormaatti], [SFOLuotu], [SFOLuoja], [SFOPaivitetty], [SFOPaivittaja]) VALUES ('1', 'Paperi', '2013-12-27 18:37:11.020', 'admin', '2013-12-27 18:37:11.020', 'admin');
SET IDENTITY_INSERT [hlp_SopimusFormaatti] OFF;
GO

-- Table: hlp_Vuokratyyppi (3 rows)
SET IDENTITY_INSERT [hlp_Vuokratyyppi] ON;
INSERT INTO [hlp_Vuokratyyppi] ([VTId], [VTNimi], [VTLuotu], [VTLuoja], [VTPaivitetty], [VTPaivittaja]) VALUES ('1', 'Maavuokra', '2020-11-12 10:11:23.437', 'admin', '2020-11-12 12:14:47.743', 'admin');
INSERT INTO [hlp_Vuokratyyppi] ([VTId], [VTNimi], [VTLuotu], [VTLuoja], [VTPaivitetty], [VTPaivittaja]) VALUES ('2', 'Kiinteistövuokra', '2020-11-12 10:11:23.437', 'admin', NULL, NULL);
INSERT INTO [hlp_Vuokratyyppi] ([VTId], [VTNimi], [VTLuotu], [VTLuoja], [VTPaivitetty], [VTPaivittaja]) VALUES ('4', 'Laitevuokra', '2020-12-08 17:42:56.463', 'admin', NULL, NULL);
SET IDENTITY_INSERT [hlp_Vuokratyyppi] OFF;
GO

-- Table: hlp_Yksikko (8 rows)
SET IDENTITY_INSERT [hlp_Yksikko] ON;
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('3', 'ha', '.0001', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/ha', '3');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('4', 'kpl', '1.0000', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/kpl', '2');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('5', 'm', '1.0000', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/m', '2');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('6', 'm2', '1.0000', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/m2/kk', '3');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('7', 'mmo', '1.0000', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/mmo', '2');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('8', 'Pylväs', '1.0000', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/Pylväs', '2');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('9', 'sopimus', '1.0000', '2014-01-02 09:41:25.420', 'admin', 'admin', '2014-01-02 09:41:25.420', '€/sopimus', '2');
INSERT INTO [hlp_Yksikko] ([YKSId], [YKSKorvausyksikko], [YKSKerroin], [YKSLuotu], [YKSLuoja], [YKSPaivittaja], [YKSPaivitetty], [_Korvausyksikko], [YKSKorvausyksikonTyyppiId]) VALUES ('10', '%', '1.0000', '2014-02-27 13:20:38.353', 'admin', 'admin', '2014-02-27 13:20:38.353', NULL, '1');
SET IDENTITY_INSERT [hlp_Yksikko] OFF;
GO

-- Table: hlps_KorvauslaskemaStatus (6 rows)
SET IDENTITY_INSERT [hlps_KorvauslaskemaStatus] ON;
INSERT INTO [hlps_KorvauslaskemaStatus] ([KSTId], [KSTKorvauslaskelmaStatus], [KSTLuotu], [KSTLuoja], [KSTPaivittaja], [KSTPaivitetty]) VALUES ('1', 'Hyväksymättä', '2013-12-26 11:37:25.880', 'admin', 'admin', '2013-12-26 11:37:25.880');
INSERT INTO [hlps_KorvauslaskemaStatus] ([KSTId], [KSTKorvauslaskelmaStatus], [KSTLuotu], [KSTLuoja], [KSTPaivittaja], [KSTPaivitetty]) VALUES ('2', 'Hyväksytty', '2013-12-26 11:37:38.947', 'admin', 'admin', '2013-12-26 11:37:38.947');
INSERT INTO [hlps_KorvauslaskemaStatus] ([KSTId], [KSTKorvauslaskelmaStatus], [KSTLuotu], [KSTLuoja], [KSTPaivittaja], [KSTPaivitetty]) VALUES ('3', 'Kieltäytynyt korvauksesta', '2014-01-02 12:06:19.950', 'admin', 'admin', '2014-01-02 12:06:19.950');
INSERT INTO [hlps_KorvauslaskemaStatus] ([KSTId], [KSTKorvauslaskelmaStatus], [KSTLuotu], [KSTLuoja], [KSTPaivittaja], [KSTPaivitetty]) VALUES ('4', 'Maksettu', '2014-01-02 12:06:51.873', 'admin', 'admin', '2014-01-02 12:06:51.873');
INSERT INTO [hlps_KorvauslaskemaStatus] ([KSTId], [KSTKorvauslaskelmaStatus], [KSTLuotu], [KSTLuoja], [KSTPaivittaja], [KSTPaivitetty]) VALUES ('5', 'Numerotta', '2019-04-23 13:44:14.820', 'admin', 'admin', '2019-04-23 13:44:14.820');
INSERT INTO [hlps_KorvauslaskemaStatus] ([KSTId], [KSTKorvauslaskelmaStatus], [KSTLuotu], [KSTLuoja], [KSTPaivittaja], [KSTPaivitetty]) VALUES ('6', 'Projekti peruttu', '2020-12-01 15:09:35.750', 'admin', NULL, '2020-12-01 15:09:35.750');
SET IDENTITY_INSERT [hlps_KorvauslaskemaStatus] OFF;
GO

-- Table: hlps_Korvaustyyppi (4 rows)
SET IDENTITY_INSERT [hlps_Korvaustyyppi] ON;
INSERT INTO [hlps_Korvaustyyppi] ([KTYId], [KTYKorvaustyyppi], [KTYLuotu], [KTYLuoja], [KTYPaivitetty], [KTYPaivittaja]) VALUES ('1', 'Kertakorvaus', '2013-12-26 11:31:21.230', 'admin', '2013-12-26 11:31:21.230', 'admin');
INSERT INTO [hlps_Korvaustyyppi] ([KTYId], [KTYKorvaustyyppi], [KTYLuotu], [KTYLuoja], [KTYPaivitetty], [KTYPaivittaja]) VALUES ('2', 'Vuosimaksu', '2013-12-26 11:31:33.507', 'admin', '2013-12-26 11:31:33.507', 'admin');
INSERT INTO [hlps_Korvaustyyppi] ([KTYId], [KTYKorvaustyyppi], [KTYLuotu], [KTYLuoja], [KTYPaivitetty], [KTYPaivittaja]) VALUES ('3', 'Ei korvausta', '2013-12-26 11:31:46.337', 'admin', '2013-12-26 11:31:46.337', 'admin');
INSERT INTO [hlps_Korvaustyyppi] ([KTYId], [KTYKorvaustyyppi], [KTYLuotu], [KTYLuoja], [KTYPaivitetty], [KTYPaivittaja]) VALUES ('4', 'Kuukausivuokra', '2014-04-17 16:25:13.570', 'admin', '2014-04-17 16:25:13.570', 'admin');
SET IDENTITY_INSERT [hlps_Korvaustyyppi] OFF;
GO

-- Table: hlps_KorvausyksikonTyyppi (4 rows)
SET IDENTITY_INSERT [hlps_KorvausyksikonTyyppi] ON;
INSERT INTO [hlps_KorvausyksikonTyyppi] ([KYTId], [KYTKorvausyksikonTyyppi], [KYTLuotu], [KYTLuoja], [KYTPaivittaja], [KYTPaivitetty]) VALUES ('1', 'Prosentti', '2014-02-27 11:27:17.683', 'admin', 'admin', '2014-02-27 11:27:17.683');
INSERT INTO [hlps_KorvausyksikonTyyppi] ([KYTId], [KYTKorvausyksikonTyyppi], [KYTLuotu], [KYTLuoja], [KYTPaivittaja], [KYTPaivitetty]) VALUES ('2', 'Määrä', '2000-01-01 00:00:00.000', 'admin', 'admin', '2000-01-01 00:00:00.000');
INSERT INTO [hlps_KorvausyksikonTyyppi] ([KYTId], [KYTKorvausyksikonTyyppi], [KYTLuotu], [KYTLuoja], [KYTPaivittaja], [KYTPaivitetty]) VALUES ('3', 'Pinta-ala', '2000-01-01 00:00:00.000', 'admin', 'admin', '2000-01-01 00:00:00.000');
INSERT INTO [hlps_KorvausyksikonTyyppi] ([KYTId], [KYTKorvausyksikonTyyppi], [KYTLuotu], [KYTLuoja], [KYTPaivittaja], [KYTPaivitetty]) VALUES ('4', 'Erityiskorvaus', '2000-01-01 00:00:00.000', 'admin', 'admin', '2000-01-01 00:00:00.000');
SET IDENTITY_INSERT [hlps_KorvausyksikonTyyppi] OFF;
GO

-- Table: hlps_Kuukausi (12 rows)
SET IDENTITY_INSERT [hlps_Kuukausi] ON;
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('1', 'Tammikuu', '2014-01-02 10:18:01.923', 'admin', '2014-01-02 10:18:01.923', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('2', 'Helmikuu', '2014-01-02 10:18:07.290', 'admin', '2014-01-02 10:18:07.290', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('3', 'Maaliskuu', '2014-01-02 10:18:12.627', 'admin', '2014-01-02 10:18:12.627', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('4', 'Huhtikuu', '2014-01-02 10:18:18.020', 'admin', '2014-01-02 10:18:18.020', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('5', 'Toukokuu', '2014-01-02 10:18:23.750', 'admin', '2014-01-02 10:18:23.750', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('6', 'Kesäkuu', '2014-01-02 10:18:29.737', 'admin', '2014-01-02 10:18:29.737', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('7', 'Heinäkuu', '2014-01-02 10:18:34.827', 'admin', '2014-01-02 10:18:34.827', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('8', 'Elokuu', '2014-01-02 10:18:40.797', 'admin', '2014-01-02 10:18:40.797', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('9', 'Syyskuu', '2014-01-02 10:18:46.010', 'admin', '2014-01-02 10:18:46.010', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('10', 'Lokakuu', '2014-01-02 10:18:51.623', 'admin', '2014-01-02 10:18:51.623', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('11', 'Marraskuu', '2014-01-02 10:18:58.280', 'admin', '2014-01-02 10:18:58.280', 'admin');
INSERT INTO [hlps_Kuukausi] ([KUUId], [KUUKuukausi], [KUULuotu], [KUULuoja], [KUUPaivitetty], [KUUPaivittaja]) VALUES ('12', 'Joulukuu', '2014-01-02 10:19:17.213', 'admin', '2014-01-02 10:19:17.213', 'admin');
SET IDENTITY_INSERT [hlps_Kuukausi] OFF;
GO

-- Table: hlps_MaksuStatus (2 rows)
INSERT INTO [hlps_MaksuStatus] ([MSAId], [MSAMaksuStatus], [MSALuotu], [MSALuoja], [MSAPaivitetty], [MSAPaivittaja]) VALUES ('1', 'Maksetaan', '2013-12-26 12:08:35.277', 'admin', '2013-12-26 12:08:35.277', 'admin');
INSERT INTO [hlps_MaksuStatus] ([MSAId], [MSAMaksuStatus], [MSALuotu], [MSALuoja], [MSAPaivitetty], [MSAPaivittaja]) VALUES ('2', 'Maksettu', '2013-12-26 12:08:46.873', 'admin', '2013-12-26 12:08:46.873', 'admin');
GO

-- Table: hlps_OrganisaationTyyppi (4 rows)
SET IDENTITY_INSERT [hlps_OrganisaationTyyppi] ON;
INSERT INTO [hlps_OrganisaationTyyppi] ([ORTId], [ORTTyyppi], [ORTLuotu], [ORTLuoja], [ORTPaivitetty], [ORTPaivittaja]) VALUES ('1', 'Yritys', '2013-12-23 15:42:15.760', 'admin', '2013-12-23 15:42:15.760', 'admin');
INSERT INTO [hlps_OrganisaationTyyppi] ([ORTId], [ORTTyyppi], [ORTLuotu], [ORTLuoja], [ORTPaivitetty], [ORTPaivittaja]) VALUES ('2', 'Juridinen yhtiö', '2013-12-23 15:42:15.760', 'admin', '2013-12-23 15:42:15.760', 'admin');
INSERT INTO [hlps_OrganisaationTyyppi] ([ORTId], [ORTTyyppi], [ORTLuotu], [ORTLuoja], [ORTPaivitetty], [ORTPaivittaja]) VALUES ('3', 'Vastuuyksikkö', '2013-12-23 15:42:15.760', 'admin', '2013-12-23 15:42:15.760', 'admin');
INSERT INTO [hlps_OrganisaationTyyppi] ([ORTId], [ORTTyyppi], [ORTLuotu], [ORTLuoja], [ORTPaivitetty], [ORTPaivittaja]) VALUES ('8', 'Yhtiö', '2014-01-28 16:55:58.533', 'admin', '2014-01-28 16:55:58.533', 'admin');
SET IDENTITY_INSERT [hlps_OrganisaationTyyppi] OFF;
GO

-- Table: hlps_SopimuksenTila (5 rows)
SET IDENTITY_INSERT [hlps_SopimuksenTila] ON;
INSERT INTO [hlps_SopimuksenTila] ([STIId], [STISopimuksenTila], [STILuotu], [STILuoja], [STIPaivitetty], [STIPaivittaja]) VALUES ('2', 'Lakkautettu', '2013-12-30 10:43:06.507', 'admin', '2013-12-30 10:43:06.507', 'admin');
INSERT INTO [hlps_SopimuksenTila] ([STIId], [STISopimuksenTila], [STILuotu], [STILuoja], [STIPaivitetty], [STIPaivittaja]) VALUES ('3', 'Voimassa', '2013-12-30 10:43:14.993', 'admin', '2013-12-30 10:43:14.993', 'admin');
INSERT INTO [hlps_SopimuksenTila] ([STIId], [STISopimuksenTila], [STILuotu], [STILuoja], [STIPaivitetty], [STIPaivittaja]) VALUES ('4', 'Kesken', '2014-01-27 17:51:43.860', 'admin', '2014-01-27 17:51:43.860', 'admin');
INSERT INTO [hlps_SopimuksenTila] ([STIId], [STISopimuksenTila], [STILuotu], [STILuoja], [STIPaivitetty], [STIPaivittaja]) VALUES ('5', 'Ei tiedossa', '2014-01-27 17:51:52.187', 'admin', '2014-01-27 17:51:52.187', 'admin');
INSERT INTO [hlps_SopimuksenTila] ([STIId], [STISopimuksenTila], [STILuotu], [STILuoja], [STIPaivitetty], [STIPaivittaja]) VALUES ('8', 'Poistettu tarpeettomana', '2015-03-06 16:45:37.413', 'admin', '2015-03-06 16:45:37.413', 'admin');
SET IDENTITY_INSERT [hlps_SopimuksenTila] OFF;
GO

-- Table: hlps_Sopimusluokka (3 rows)
SET IDENTITY_INSERT [hlps_Sopimusluokka] ON;
INSERT INTO [hlps_Sopimusluokka] ([SLUId], [SLUSopimusLuokka], [SLULuotu], [SLULuoja], [SLUPaivitetty], [SLUPaivittaja]) VALUES ('1', 'Raamisopimus', '2014-01-02 09:18:28.643', 'admin', '2014-01-02 09:18:28.643', 'admin');
INSERT INTO [hlps_Sopimusluokka] ([SLUId], [SLUSopimusLuokka], [SLULuotu], [SLULuoja], [SLUPaivitetty], [SLUPaivittaja]) VALUES ('2', 'Lunastussopimus', '2014-01-02 09:18:36.523', 'admin', '2014-01-02 09:18:36.523', 'admin');
INSERT INTO [hlps_Sopimusluokka] ([SLUId], [SLUSopimusLuokka], [SLULuotu], [SLULuoja], [SLUPaivitetty], [SLUPaivittaja]) VALUES ('3', 'Lunastustoimitus', '2014-01-02 09:18:44.020', 'admin', '2014-01-02 09:18:44.020', 'admin');
SET IDENTITY_INSERT [hlps_Sopimusluokka] OFF;
GO

-- Table: hlps_TahoTyyppi (2 rows)
SET IDENTITY_INSERT [hlps_TahoTyyppi] ON;
INSERT INTO [hlps_TahoTyyppi] ([TATId], [TATTahoTyyppi], [TATLuotu], [TATLuoja], [TATPaivittaja], [TATPaivitetty]) VALUES ('1', 'Henkilo', '2013-12-23 15:55:37.927', 'admin', 'admin', '2013-12-23 15:55:37.927');
INSERT INTO [hlps_TahoTyyppi] ([TATId], [TATTahoTyyppi], [TATLuotu], [TATLuoja], [TATPaivittaja], [TATPaivitetty]) VALUES ('2', 'Organisaatio', '2013-12-23 15:56:13.403', 'admin', 'admin', '2013-12-23 15:56:13.403');
SET IDENTITY_INSERT [hlps_TahoTyyppi] OFF;
GO

-- Table: hlps_Tiedostolahde (2 rows)
SET IDENTITY_INSERT [hlps_Tiedostolahde] ON;
INSERT INTO [hlps_Tiedostolahde] ([TLAId], [TLATiedostoLahde], [TLALuotu], [TLALuoja], [TLAPaivittaja], [TLAPaivitetty]) VALUES ('1', 'Sopimusrekisteri', '2013-12-30 11:02:00.777', 'admin', 'admin', '2013-12-30 11:02:00.777');
INSERT INTO [hlps_Tiedostolahde] ([TLAId], [TLATiedostoLahde], [TLALuotu], [TLALuoja], [TLAPaivittaja], [TLAPaivitetty]) VALUES ('2', 'SharePoint sopimusarkisto', '2013-12-30 11:02:17.220', 'admin', 'admin', '2013-12-30 11:02:17.220');
SET IDENTITY_INSERT [hlps_Tiedostolahde] OFF;
GO

-- Table: hlps_YlasopimuksenTyyppi (5 rows)
SET IDENTITY_INSERT [hlps_YlasopimuksenTyyppi] ON;
INSERT INTO [hlps_YlasopimuksenTyyppi] ([YSTId], [YSTYlasopimuksenTyyppi], [YSTLuoja], [YSTLuotu], [YSTPaivittaja], [YSTPaivitetty]) VALUES ('1', 'Raamisopimus', 'admin', '2014-05-07 15:48:43.800', 'admin', '2014-05-07 15:48:43.800');
INSERT INTO [hlps_YlasopimuksenTyyppi] ([YSTId], [YSTYlasopimuksenTyyppi], [YSTLuoja], [YSTLuotu], [YSTPaivittaja], [YSTPaivitetty]) VALUES ('2', 'Lunastuslupa', 'admin', '2014-05-07 15:48:43.803', 'admin', '2014-05-07 15:48:43.803');
INSERT INTO [hlps_YlasopimuksenTyyppi] ([YSTId], [YSTYlasopimuksenTyyppi], [YSTLuoja], [YSTLuotu], [YSTPaivittaja], [YSTPaivitetty]) VALUES ('3', 'Lunastustoimitus', 'admin', '2014-05-07 15:48:43.803', 'admin', '2014-05-07 15:48:43.803');
INSERT INTO [hlps_YlasopimuksenTyyppi] ([YSTId], [YSTYlasopimuksenTyyppi], [YSTLuoja], [YSTLuotu], [YSTPaivittaja], [YSTPaivitetty]) VALUES ('4', 'Yhteistoimintasopimus, kunta', 'admin', '2022-04-12 16:46:42.133', NULL, '2022-04-12 16:46:42.133');
INSERT INTO [hlps_YlasopimuksenTyyppi] ([YSTId], [YSTYlasopimuksenTyyppi], [YSTLuoja], [YSTLuotu], [YSTPaivittaja], [YSTPaivitetty]) VALUES ('5', 'Yhteiskäyttöpuitesopimus', 'admin', '2022-04-12 16:46:42.133', NULL, '2022-04-12 16:46:42.133');
SET IDENTITY_INSERT [hlps_YlasopimuksenTyyppi] OFF;
GO

