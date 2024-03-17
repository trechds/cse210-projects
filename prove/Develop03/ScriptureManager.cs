using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureManager
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private string _text;

    public void EnterNewScripture()
    {
        Console.WriteLine("Enter the book:");
        _book = Console.ReadLine();

        Console.WriteLine("Enter the chapter:");
        _chapter = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the first verse:");
        _startVerse = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the last verse (or press Enter to skip):");
        string _lastVerseInput = Console.ReadLine();

        if (string.IsNullOrEmpty(_lastVerseInput))
        {
            // If the input is empty, we set _endVerse to 0
            _endVerse = 0;
        }
        else if (!int.TryParse(_lastVerseInput, out _endVerse) || _endVerse < 0)
        {
            // If the input is not a valid number or is negative, we show an error message
            Console.WriteLine("Invalid input. Last verse must be a non-negative number or press Enter to skip.");
            return;
        }

        Console.WriteLine("Enter the text of the scripture:");
        _text = Console.ReadLine();

        // Save the scripture to a text file
        using (StreamWriter sw = File.AppendText("Scriptures.txt"))
        {
            if (_endVerse == 0)
            {
                // If _endVerse is 0, we write the line without the - endVerse
                sw.WriteLine($"{_book} {_chapter}:{_startVerse} - {_text}");
            }
            else
            {
                // Otherwise, we write the line in the normal format
                sw.WriteLine($"{_book} {_chapter}:{_startVerse}-{_endVerse} - {_text}");
            }
        }

        Console.WriteLine("Scripture saved successfully!");
    }

    public void SelectScriptureToMemorize()
    {
        Console.WriteLine("Please choose the scripture to memorize:");

        List<string> references = new List<string>();
        using (StreamReader sr = new StreamReader("Scriptures.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(" - ");
                references.Add(parts[0]);
            }
        }

        for (int i = 0; i < references.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {references[i]}");
        }

        int selection = Convert.ToInt32(Console.ReadLine());

        if (selection >= 1 && selection <= references.Count)
        {
            string selectedReference = references[selection - 1];

            string selectedScripture = "";
            using (StreamReader sr = new StreamReader("Scriptures.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(" - ");
                    if (parts[0] == selectedReference)
                    {
                        selectedScripture = line;
                        break;
                    }
                }
            }

            string[] selectedParts = selectedScripture.Split(" - ");
            string _reference = selectedParts[0];
            string _text = selectedParts[1];

            Console.WriteLine(_reference);
            Console.WriteLine(_text);

            // Create an instance of Reference and Scripture
            Reference referenceObj = Reference.Parse(_reference);
            Scripture scriptureObj = new Scripture(referenceObj, _text);

            // Pass the instance of Scripture to MemorizeScripture
            MemorizeScripture(scriptureObj);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void RandomScriptureToMemorize()
    {
        List<string> scriptures = LoadScripturesFromFile();

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available. Please add scriptures first.");
            return;
        }

        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        string selectedScripture = scriptures[randomIndex];

        // Split the record into reference and text
        string[] parts = selectedScripture.Split(" - ");
        string referenceText = parts[0];
        string _scriptureText = parts[1];

        // Create instances of Reference and Scripture
        Reference reference = Reference.Parse(referenceText);
        Scripture scripture = new Scripture(reference, _scriptureText);

        MemorizeScripture(scripture);
    }

    private List<string> LoadScripturesFromFile()
    {
        List<string> scriptures = new List<string>();
        if (File.Exists("Scriptures.txt"))
        {
            using (StreamReader reader = new StreamReader("Scriptures.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    scriptures.Add(line);
                }
            }
        }
        return scriptures;
    }

    private void MemorizeScripture(Scripture scripture)
    {
        Console.WriteLine("Press enter to hide 2 random words or type 'quit' to finish the program.");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(2);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to hide 2 more words or type 'quit' to finish the program.");
        }
    }
}
