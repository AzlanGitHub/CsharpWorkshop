CREATE TABLE LehrerFach (
    LehFaID   INTEGER PRIMARY KEY AUTOINCREMENT
                      NOT NULL,
    LehrerID  INTEGER REFERENCES Lehrer (LehrerID) 
                      NOT NULL,
    FachID    INTEGER REFERENCES Fach (FachID) 
                      NOT NULL,
    KlasseID  INTEGER REFERENCES Klasse (KlasseID) 
                      NOT NULL,
    Bemerkung TEXT,
    Schuljahr TEXT,
    Von       TEXT,
    Bis       TEXT
);


CREATE TABLE Anwesenheit (
    AnwesenheitID INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId     INTEGER REFERENCES Student (StudentID),
    KursID        INTEGER REFERENCES Kurs (KursID),
    Datum         TEXT,
    Status        TEXT,
    Beemerkung    TEXT
);


CREATE TABLE Fach (
    FachID       INTEGER       PRIMARY KEY AUTOINCREMENT,
    Titel        VARCHAR (100),
    Beschreibung TEXT (0),
    Credits      INT           DEFAULT (0) 
);


CREATE TABLE Klasse (
    KlasseID        INTEGER PRIMARY KEY AUTOINCREMENT
                            NOT NULL,
    Bezeichnung     TEXT    NOT NULL,
    Kuerzel         TEXT    NOT NULL,
    Jahrgangsstufe  INTEGER NOT NULL,
    Schuljahr       TEXT    NOT NULL,
    KlassenlehrerID INTEGER REFERENCES Lehrer (LehrerID) 
);

CREATE TABLE Kurs (
    KursID    INTEGER PRIMARY KEY AUTOINCREMENT,
    LehrerID  INTEGER REFERENCES Lehrer (LehrerID),
    FachID    INTEGER REFERENCES Fach (FachID),
    KlasseID  INTEGER REFERENCES Klasse (KlasseID),
    Schuljahr TEXT,
    Bemerkung TEXT
);

CREATE TABLE Lehrer (
    LehrerID     INTEGER PRIMARY KEY AUTOINCREMENT
                         NOT NULL,
    Vorname      TEXT    NOT NULL,
    Nachname     TEXT    NOT NULL,
    Geburtsdatum TEXT    NOT NULL,
    EMail        TEXT
);


CREATE TABLE LehrerFach (
    LehFaID   INTEGER PRIMARY KEY AUTOINCREMENT
                      NOT NULL,
    LehrerID  INTEGER REFERENCES Lehrer (LehrerID) 
                      NOT NULL,
    FachID    INTEGER REFERENCES Fach (FachID) 
                      NOT NULL,
    KlasseID  INTEGER REFERENCES Klasse (KlasseID) 
                      NOT NULL,
    Bemerkung TEXT,
    Schuljahr TEXT,
    Von       TEXT,
    Bis       TEXT
);


CREATE TABLE Noten (
    NotenID   INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentID INTEGER REFERENCES Student (StudentID),
    KursID    INTEGER REFERENCES Kurs (KursID),
    Note      TEXT,
    Datum     TEXT,
    Art       TEXT
);


CREATE TABLE Raum (
    RaumID      INTEGER PRIMARY KEY AUTOINCREMENT,
    RaumNr      TEXT,
    Kapazitaet  INTEGER,
    Gebaeude    TEXT,
    Ausstattung TEXT,
    ErstelltAm  TEXT,
    Status      TEXT    DEFAULT aktiv
);


CREATE TABLE Slot (
    SlotID  INTEGER PRIMARY KEY AUTOINCREMENT,
    SlotNr  INTEGER,
    VonZeit TEXT    NOT NULL,
    BisZeit TEXT    NOT NULL
);


CREATE TABLE Student (
    StudentID    INTEGER PRIMARY KEY AUTOINCREMENT
                         NOT NULL,
    Vorname      TEXT    NOT NULL,
    Nachname     TEXT    NOT NULL,
    Geburtsdatum TEXT    NOT NULL,
    Strasse      TEXT    NOT NULL,
    Stadt        TEXT    NOT NULL,
    KlasseID     INTEGER REFERENCES Klasse (KlasseID) 
);


CREATE TABLE StudentFach (
    StudentFachID INTEGER PRIMARY KEY AUTOINCREMENT
                          NOT NULL,
    StudentID     INTEGER REFERENCES Student (StudentID) 
                          NOT NULL,
    FachID        INTEGER REFERENCES Fach (FachID) 
                          NOT NULL,
    LehrerID      INTEGER NOT NULL
                          REFERENCES Lehrer (LehrerID),
    Semester      TEXT,
    Note          REAL
);


CREATE TABLE Stundenplan (
    StundenplanID INTEGER PRIMARY KEY AUTOINCREMENT
                          NOT NULL,
    KursID        INTEGER REFERENCES Kurs (KursID) 
                          NOT NULL,
    RaumID        INTEGER REFERENCES Raum (RaumID) 
                          NOT NULL,
    SlotID        INTEGER REFERENCES Slot (SlotID) 
                          NOT NULL,
    Wochentag     INTEGER,
    Status        TEXT,
    DatumGueltig  TEXT
);

CREATE TABLE Benutzer (
    BenutzerID INTEGER PRIMARY KEY AUTOINCREMENT,
    Benutzername TEXT NOT NULL UNIQUE,
    PasswortHash TEXT NOT NULL,
    Rolle        TEXT NOT NULL
);

