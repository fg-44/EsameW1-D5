
-- INSERT ANAGRAFICA

INSERT INTO Anagrafica (Cognome, NomeUtente, Indirizzo, Città , Cod_fisc)

VALUES ('Rossi','Giuseppe','Via Monte Pelegrino', 'Palermo', '123456789'),
       ('Bianchi','Maria', 'Via Castelbuono','Catania','213456789'),
	   ('Conte','Donato', 'Via Erice','Messina','313456789'),
	   ('Florio','Paolo', 'Via Giuseppe Garibaldi','Siracusa','413456783'),
	   ('Russo', 'Luigi','Via Regina Margherita','Palermo','513636784'),
	   ('Bruno','Anna', 'Via Teatro Massimo','Ragusa','613656784'),
	   ('Caruso','Luigi', 'Via Roma','Siracusa','723656784'),
	   ('Caputo','Luigi', 'Via Crociferi','Trapani','813654784'),
	   ('Palumbo','Luigi','Via Plebiscito','Agrigento','915656784'),
	   ('Mele','Luigi', 'Via Etnea','Palermo','013656784');

--INSERT VIOLAZIONI

INSERT INTO ViolazionI (TipoViolazione, Contestabilità)

VALUES ('A1', 1),
       ('A3', 0),
	   ('A2', 1),
	   ('A1', 0),
	   ('A2', 1),
	   ('A3', 1),
       ('A2', 0),
	   ('A3', 1),
	   ('A5', 0),
	   ('A5', 1);

 
-- INSERT VERBALE

INSERT INTO Verbali ( Descrizione, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti)

VALUES ( 'Sorpassava a sinistra in zona non consentita','2009-01-02', 'Via Roma, Palermo', 'Agente_Gigi', '2024-01-04', 124.99, 4),
       ( 'Superava il limite di velocita di 50 km/h', '2009-01-09', 'Via Margherita, Catania', 'Agente_Gigi', '2024-01-12', 239.00, 3),
	   ( 'Parcheggio in doppia fila', '2009-01-22', 'Via Fiore, Agrigento', 'Agente_DeLuca', '2024-01-24', 133.90, 1),
	   ( 'Non portava la cintura di sicurezza', '2009-02-01', 'Via Etnea,Catania', 'Agente_Guglielmo', '2024-02-03', 375.34, 2),
	   ( 'Non si fermava al semaforo rosso','2009-02-06', 'Via Giuseppe Garibaldi, Siracusa', 'Agente_Gigi', '2024-02-09', 120.35, 3),
	   ( 'Usava il cellulare alla guida','2009-02-10', 'Via Monte Pelegrino, Ragusa', 'Agente_Gigi', '2024-02-13', 400.30, 6),
       ( 'Andava contromano','2009-03-14', 'Via Plebiscito, Palermo', 'Agente_Guglielmo', '2024-02-16', 319.98, 4),
	   ( 'Non si fermava allo stop','2009-03-20', 'Via Erice, Palermo', 'Agente_Gigi', '2024-02-23', 250.80, 5),
	   ( 'Superava il limite di alcol nel sangue','2009-03-24', 'Via Crociferi, Trapani', 'Agente_DeLuca', '2024-02-26', 305.00, 7),
	   ( 'Passava con il semaforo rosso quando il pedone stava attraversando', '2009-04-25', 'Via Giulio Cesare, Siracusa', 'Agente_Guglielmo', '2024-02-29', 125.40, 3)