CREATE TABLE IF NOT EXISTS jogos (
codigo INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
descicaojogo TEXT, 
qtdnumeros TEXT, 
dataregistro TEXT DEFAULT (datetime('now')) NOT NULL);