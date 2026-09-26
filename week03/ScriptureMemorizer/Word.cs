namespace ScriptureMemorizer;

class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenWord = "";
            foreach (char character in _text)
            {
                if (char.IsLetter(character))
                {
                    hiddenWord += "_";
                }
                else
                {
                    hiddenWord += character;
                }
            }
            return hiddenWord;
        }
        return _text;
    }
}
