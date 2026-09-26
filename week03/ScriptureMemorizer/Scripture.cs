using System;
using System.Collections.Generic;

namespace ScriptureMemorizer;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
 public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }
public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result;
    }
    public void HideRandomWords(int numberOfWords)
    {
        Random random = new Random();
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }
        int count = 0;
        while (count < numberOfWords && visibleWords.Count > 0)
        {
            int index = random.Next(visibleWords.Count);
            Word selectedWord = visibleWords[index];
            selectedWord.Hide();
            visibleWords.RemoveAt(index);
            count++;
        }
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
