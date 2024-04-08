using System;
using System.Collections.Generic;

class Program
{
    // Liste erstellen und Startwerte hinzufügen
    static List<(int id, string beschreibung)> ListeAufgaben = new List<(int, string)>(){
        (1, "Aufstehen"),
        (2, "Zähne putzen"),
        (3, "Duschen"),
        (4, "Frühstücken")
    };

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            //Hauptmenü erstellen
            Console.Clear();
            Console.WriteLine("Hauptmenü:");
            Console.WriteLine("1___Aufgabe hinzufügen");
            Console.WriteLine("2___Alle Aufgaben anzeigen");
            Console.WriteLine("3___Aufgabe bearbeiten");
            Console.WriteLine("4___Aufgabe löschen");
            Console.WriteLine("5___Programmende");

            Console.Write("Wählen Sie eine Option: ");
            string Auswahl = Console.ReadLine();

            // Verweis auf die Funktionen je nach Auswahl
            switch (Auswahl)
            {
                case "1":
                    AufgabeHinzufuegen();
                    break;
                case "2":
                    AlleAufgabenAnzeigen();
                    break;
                case "3":
                    AufgabeBearbeiten();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Bitte nur gültige Menüpunkte auswählen");
                    Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AufgabeHinzufuegen()
    {
        // Hinzufügen einer Aufgabe
        Console.Clear();
        Console.Write("Geben Sie die Beschreibung der Aufgabe ein: ");
        string Beschreibung = Console.ReadLine();

        int ID = ListeAufgaben.Count > 0 ? ListeAufgaben[ListeAufgaben.Count - 1].id + 1 : 1;
        ListeAufgaben.Add((ID, Beschreibung));

        Console.WriteLine("Aufgabe erfolgreich hinzugefügt");
        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadLine();
    }

    static void AlleAufgabenAnzeigen()
    {
        // Ausgabe aller Aufgaben am Bildschirm
        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben:");

        foreach (var Aufgabe in ListeAufgaben)
        {
            Console.WriteLine($"ID: {Aufgabe.id}, Beschreibung: {Aufgabe.beschreibung}");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadLine();
    }

    static void AufgabeBearbeiten()
    {
        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben:");

        foreach (var Aufgabe in ListeAufgaben)
        {
            Console.WriteLine($"ID: {Aufgabe.id}, Beschreibung: {Aufgabe.beschreibung}");
        }

        // Abfrage ID für Bearbeitung Aufgabe
        Console.Write("Geben Sie die ID der zu bearbeitenden Aufgabe ein: ");
        int IDBearbeiten = int.Parse(Console.ReadLine());

        // Suchen der ID in der Liste
        var AufgabeBearbeiten = ListeAufgaben.Find(Aufgabe => Aufgabe.id == IDBearbeiten);

        if (AufgabeBearbeiten.Equals(default((int, string))))
        {
            Console.WriteLine("Aufgabe nicht gefunden");
        }
        else
        {
            // Wenn ID gefunden, dann neue Beschreibung eingeben
            Console.WriteLine($"Aktuelle Beschreibung: {AufgabeBearbeiten.beschreibung}");
            Console.Write("Geben Sie die neue Beschreibung ein: ");
            string NeueBeschreibung = Console.ReadLine();

            ListeAufgaben[ListeAufgaben.IndexOf(AufgabeBearbeiten)] = (IDBearbeiten, NeueBeschreibung);
            Console.WriteLine("Aufgabe erfolgreich aktualisiert");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadLine();
    }

    static void DeleteTask()
    {
        // Alle Aufgaben am Bildschirm ausgeben
        Console.Clear();
        Console.WriteLine("Alle Aufgaben:");
        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben:");

        foreach (var Aufgabe in ListeAufgaben)
        {
            Console.WriteLine($"ID: {Aufgabe.id}, Beschreibung: {Aufgabe.beschreibung}");
        }

        // Abfrage ID für Löschen der Aufgabe
        Console.Write("Geben Sie die ID der zu löschenden Aufgabe ein: ");
        int IDLoeschen = int.Parse(Console.ReadLine());

        // Aufgabe-ID in Liste suchen
        var AufgabeLoeschen =ListeAufgaben.Find(Aufgabe => Aufgabe.id == IDLoeschen);

        if (AufgabeLoeschen.Equals(default((int, string))))
        {
            Console.WriteLine("Aufgabe nicht gefunden");
        }
        else
        {
            // Wenn Aufgabe gefunden --> löschen
            ListeAufgaben.Remove(AufgabeLoeschen);
            Console.WriteLine("Aufgabe erfolgreich gelöscht");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadLine();
    }
}
