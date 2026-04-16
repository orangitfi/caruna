
SET IDENTITY_INSERT hlps_KorvauslaskemaStatus ON
INSERT INTO hlps_KorvauslaskemaStatus (KSTId, KSTKorvauslaskelmaStatus, KSTLuotu, KSTLuoja)
VALUES (6, 'Projekti peruttu', GETDATE(), 'admin')
SET IDENTITY_INSERT hlps_KorvauslaskemaStatus OFF
GO