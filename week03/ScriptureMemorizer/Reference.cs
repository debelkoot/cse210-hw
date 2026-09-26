namespace ScriptureMemorizer;

class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (startVerse == endVerse)
            return $"{book} {chapter}:{startVerse}";

        return $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}
