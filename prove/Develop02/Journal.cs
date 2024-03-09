using System;

public class Journal
{
    public List<Entry> _entries; // Setting the custom variable for the list of entries
    
    public Journal(){ 
        _entries = new List<Entry>(); // Creates a new list of entries called  "_entries" and sets it to an empty list
    }

    public void AddEntry(Entry newEntry){ 
        _entries.Add(newEntry); // Adds and Stores entries in the List _entries
    }

    public void DisplayAll(){ // Display the list _entries
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName){
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
    }
    
    public void LoadFromFile(string fileName){
        _entries.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string date = parts[0];
                string prompt = parts[1];
                string entryText = parts[2];
                _entries.Add(new Entry(date, prompt, entryText));
            }
        }
    }
}