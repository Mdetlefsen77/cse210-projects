using System;
using System.Collections.Generic;

public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string content)
    {
        _text = content;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public string GetDisplayText()
    {
        if (IsHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
