public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }
    public string GetDisplayText()
    {
        if (_endVerse == 0)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
    public static Reference Parse(string referenceText)
    {
        string[] parts = referenceText.Split(' ');
        string book = parts[0];
        string[] verses = parts[1].Split(':');
        int chapter = int.Parse(verses[0]);

        if (verses[1].Contains('-'))
        {
            string[] verseRange = verses[1].Split('-');
            int startVerse = int.Parse(verseRange[0]);
            int endVerse = int.Parse(verseRange[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            int verse = int.Parse(verses[1]);
            return new Reference(book, chapter, verse);
        }
    }
}