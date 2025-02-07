# IPA-Notenrechner

Windows Forms Anwendung zur Berechnung und Verwaltung von IPA-Noten.

## Features

- Notenberechnung mit konfigurierten Gewichtungen (50%, 20%, 30%)
- Vorlagen als .txt-Datei speichern
- Bearbeiten bestehender Vorlagen
- Automatische Berechnung der Teilnoten und Endnote

## Installation

1. .exe-File aus https://github.com/KLubina/IPA-Notenrechner/blob/main/IPA-Notenrechner/IPA-Notenrechner/bin/Debug/IPA-Notenrechner.exe herunterladen
2. .exe-File ausführen

## Ordnerstruktur

Die Anwendung erstellt automatisch folgende Ordner:

![Automatisch generierte Ordner](Pictures-for-README.md/automatic-generated-folders.png)

## Hauptfenster

Das Hauptfenster zeigt die berechnete Endnote und Teilnoten an:

![Hauptfenster](Pictures-for-README.md/main_form.png)

## Vorlagen erstellen

Neue Bewertungsvorlagen können über ein Formular erstellt werden:

![Vorlage erstellen](Pictures-for-README.md/CreateTemplate_Form.png)

## Vorlagen bearbeiten

Bestehende Vorlagen können bearbeitet werden:

![Vorlage bearbeiten](Pictures-for-README.md/EditTemplate_Form.png)

## Technische Details

- .NET Framework 4.8
- Windows Forms
- Speicherung der Informationen als .txt Dateien
- SQL Server für optionale DB-Anbindung (nur für den Ersteller (also KLubina) nutzbar)
