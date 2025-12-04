-- PostgreSQL Schema Script (ohne Beispieldaten)

-- 1. Tabelle für die Prorektor:innen
CREATE TABLE IF NOT EXISTS PROREKTORAT (
    ProrektorID SERIAL PRIMARY KEY,
    Vorname VARCHAR(50) NOT NULL,
    Nachname VARCHAR(50) NOT NULL,
    E_Mail VARCHAR(100) NOT NULL UNIQUE
);

-- 2. Tabelle für die Lehrpersonen
CREATE TABLE IF NOT EXISTS LEHRPERSON (
    LehrpersonID SERIAL PRIMARY KEY,
    Vorname VARCHAR(50) NOT NULL,
    Nachname VARCHAR(50) NOT NULL,
    E_Mail VARCHAR(100) NOT NULL UNIQUE
);

-- 3. Tabelle für die Lernenden
CREATE TABLE IF NOT EXISTS LERNENDER (
    LernenderID SERIAL PRIMARY KEY,
    Vorname VARCHAR(50) NOT NULL,
    Nachname VARCHAR(50) NOT NULL,
    Klasse VARCHAR(10)
);

-- 4. Tabelle für die Module
CREATE TABLE IF NOT EXISTS MODUL (
    ModulID SERIAL PRIMARY KEY,
    Modulname VARCHAR(100) NOT NULL UNIQUE,
    Semester INT
);

-- ENUM-Typ für Status
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'status_enum') THEN
        CREATE TYPE status_enum AS ENUM (
            'EINGEREICHT',
            'GEPRUEFT_JA',
            'GEPRUEFT_NEIN',
            'ANS_SEKRETARIAT_UEBERMITTELT'
        );
    END IF;
END$$;

-- Zentrale Antrags-Tabelle
CREATE TABLE IF NOT EXISTS NOTENANPASSUNG_ANTRAG (
    AntragID SERIAL PRIMARY KEY,

    LehrpersonID INT NOT NULL REFERENCES LEHRPERSON(LehrpersonID),
    ProrektorID INT NOT NULL REFERENCES PROREKTORAT(ProrektorID), 
    LernenderID INT NOT NULL REFERENCES LERNENDER(LernenderID),
    ModulID INT NOT NULL REFERENCES MODUL(ModulID),

    AlteNote NUMERIC(3,2), 
    NeueNote NUMERIC(3,2) NOT NULL,

    Antragsdatum TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Bemerkungen TEXT,

    Status status_enum NOT NULL DEFAULT 'EINGEREICHT',
    Pruefungsdatum TIMESTAMP NULL,
    Ablehnungsgrund TEXT
);
