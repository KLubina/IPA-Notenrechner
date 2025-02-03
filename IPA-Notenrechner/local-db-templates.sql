CREATE TABLE Templates (
    TemplateID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    LastModified DATETIME DEFAULT GETDATE(),
    -- Serialisierte Listen als TEXT
    KompetenzPunkte TEXT,
    DokumentationPunkte TEXT,
    PraesentationPunkte TEXT
);