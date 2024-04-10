using System;
using System.Collections.Generic;
using System.IO;

public class Document
{
    private string _filename;
    private List<List<string>> _contents = new List<List<string>>();
    private List<List<string>> _transcript = new List<List<string>>();

    // Constructor to initialize the Document with a specified filename
    public Document(string filename)
    {
        _filename = filename;
    }

    // Get the contents of the document
    public List<List<string>> GetContents()
    {
        return _contents;
    }

    // Set the transcript of the document
    public void SetTranscript(List<List<string>> transcript)
    {
        _transcript = transcript;
    }

    // Save the transcript to the file
    public void SaveFile()
    {
        // Ensure that the StreamWriter is properly instantiated within the using statement
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (List<string> item in _transcript)
            {
                // Join the item contents with a delimiter and write to the file
                string oneLine = string.Join(" -> ", item);
                outputFile.WriteLine(oneLine);
            }
        }
    }

    // Read the contents of the file and populate the document's contents
    public void ReadFile()
    {
        string[] lines = File.ReadAllLines(_filename);
        foreach (string line in lines)
        {
            // Split the line into parts using a specific delimiter
            string[] parts = line.Split(new[] { " -> " }, StringSplitOptions.None);

            List<string> itemContents = new List<string>();
            foreach (string part in parts)
            {
                if (part == " -> ")
                {
                    // Handle empty lines
                    itemContents.Add("");
                }
                else if (!string.IsNullOrEmpty(part))
                {
                    // Add non-empty parts to the item contents
                    itemContents.Add(part);
                }
            }
            _contents.Add(itemContents);
        }
    }
}