public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordsArray = text.Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordsArray)
        {
            _words.Add(new Word(wordText));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        int wordsHidden = 0;

        while (wordsHidden < numberToHide)
        {
            int index = rand.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHidden++;
            }
        }
    }
    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()}\n";

        foreach (var word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }
    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}