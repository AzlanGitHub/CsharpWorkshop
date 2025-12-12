## 🚀 Startanleitung für die Schulverwaltung (WPF/MVVM)
Diese Anwendung wurde mit C\#, WPF, Entity Framework Core und dem MVVM-Muster entwickelt. 
Sie verwendet eine SQLite-Datenbank.
### 📋 Voraussetzungen
Stellen Sie sicher, dass folgende Software auf Ihrem System installiert ist:
1.  **Visual Studio 2022** (oder höher, da Visual Studio 2026 zum Zeitpunkt der Erstellung noch nicht verfügbar ist, aber die Schritte dieselben bleiben).
      * Stellen Sie sicher, dass die Workloads **".NET-Desktopentwicklung"** installiert sind.
2.  **.NET SDK 8.0** (oder höher, falls Sie .NET 9/10 verwenden).
3.  **SQLite DB Browser** (Optional, um die Datenbankdatei zu prüfen).

### 🛠️ Setup-Anweisungen
Folgen Sie diesen Schritten, um das Projekt zu klarten und zu starten.
#### 1\. Repository klonen
Öffnen Sie die Kommandozeile (oder Git Bash) und klonen Sie das Repository:
```bash
git clone https://github.com/AzlanGitHub/CsharpWorkshop.git
cd Schulmanager```
#### 2\. Visual Studio öffnen
1.  Öffnen Sie Visual Studio.
2.  Wählen Sie **"Projektmappe oder Projekt öffnen"** und navigieren Sie zum geklonten Ordner.
3.  Wählen Sie die Datei `Schulverwaltung.sln` (Solution File).

#### 3\. Datenbank-Setup (SQLite)
Die Anwendung verwendet die Datei `Schule.db`. 
Diese muss im Ausgabeverzeichnis vorhanden sein, damit Entity Framework Core darauf zugreifen kann.

1.  Suchen Sie die Datei `Schule.db` im Hauptverzeichnis des Projekts.
2.  Klicken Sie im **Projektmappen-Explorer** mit der rechten Maustaste auf die Datei `Schule.db` und wählen Sie **"Eigenschaften"**.
3.  Stellen Sie sicher, dass die Einstellung für **"In Ausgabeverzeichnis kopieren"** auf **"Kopieren, wenn neuer"** oder **"Immer kopieren"** gesetzt ist.

> **ℹ️ Hinweis zur Datenbank:**
> Der Connection String in `Models/SchuleContext.cs` ist auf `Data Source=Schule.db` gesetzt, was bedeutet, dass die DB im selben Ordner wie die ausführbare `.exe` Datei gesucht wird.

#### 4\. NuGet-Pakete wiederherstellen

Visual Studio sollte dies automatisch tun, aber falls nicht, können Sie die Pakete manuell wiederherstellen:

1.  Gehen Sie in Visual Studio zu **"Tools"** -\> **"NuGet-Paket-Manager"** -\> **"Paket-Manager-Konsole"**.

2.  Führen Sie folgenden Befehl aus:
    ```powershell
    Update-Package -Reinstall
    # Oder einfach:
    dotnet restore 
    ```
#### 5\. Anwendung starten
1.  Stellen Sie sicher, dass **`Schulverwaltung`** als Startprojekt ausgewählt ist.
2.  Drücken Sie **F5** oder klicken Sie auf den **"Start"**-Button (grüner Pfeil), um die Anwendung im Debug-Modus zu kompilieren und auszuführen.
Die WPF-Oberfläche mit dem DataGrid zur Studentenverwaltung sollte nun erscheinen und die Daten aus der `Schule.db` anzeigen.

### 📚 MVVM-Struktur
Die Anwendung folgt strikt dem MVVM-Muster.
| Ordner | Beschreibung | Verwendete Technologie |
| :--- | :--- | :--- |
| **Views** | Enthält die XAML-Dateien (z.B. `MainWindow.xaml`) zur Definition der Benutzeroberfläche. | WPF, XAML |
| **ViewModels** | Enthält die Logik-Klassen (z.B. `StudentViewModel.cs`). Diese exponieren Daten und `ICommand`s für die Views. | C\#, CommunityToolkit.Mvvm |
| **Models** | Enthält die automatisch generierten Entitäten (z.B. `Student.cs`) und den Datenbank-Kontext (`SchuleContext.cs`). | Entity Framework Core, C\# |