CREATE DATABASE DbViolazioni

CREATE TABLE Anagrafica (

    id_Anagrafica INT IDENTITY(1,1) PRIMARY KEY REFERENCES Anagrafica(id_Anagrafica),
	
    Cognome VARCHAR(50) not null,
    NomeUtente VARCHAR(50) not null,
	Indirizzo VARCHAR(50) not null,
	Città VARCHAR(50) not null,
	Cod_fisc VARCHAR(16) not null UNIQUE,
);


CREATE TABLE Violazioni (

    Id_violazione INT IDENTITY(1,1)  PRIMARY KEY REFERENCES Violazioni(id_violazione),
	TipoViolazione VARCHAR (50) not null,
	Contestabilità BIT not null,
);

CREATE TABLE Verbali (

    id_verbali INT IDENTITY(1,1) PRIMARY KEY REFERENCES Verbali(id_verbali),
	id_violazione INT,
	id_anagrafica INT,

	Descrizione VARCHAR(250) not null,
    Dataviolazione DATE not null UNIQUE,
    IndirizzoViolazione VARCHAR(50) not null,
	NominativoAgente VARCHAR(50) not null,
	DataTrascrizioneVerbale DATE not null UNIQUE,
	Importo DECIMAL (9,2) not null,
	DecurtamentoPunti INT CHECK(DecurtamentoPunti >= 0 AND DecurtamentoPunti <= 20),

	CONSTRAINT FK_Anagrafica FOREIGN KEY(id_Anagrafica) REFERENCES Anagrafica(id_Anagrafica),
	CONSTRAINT FK_Violazione FOREIGN KEY(id_violazione) REFERENCES Violazioni(id_Violazione),
);


