using System.Text;

namespace Autotrophe;

public class TypedBuffer
{
    private StringBuilder _currentWord = new StringBuilder();
    public event EventHandler<string>? WordCompleted;

    public void ProcessKey(Keys key)
    {
        // Letter keys
        if (key >= Keys.A && key <= Keys.Z)
        {
            bool shift = Control.ModifierKeys.HasFlag(Keys.Shift);
            char c = (char)key;
            _currentWord.Append(shift ? char.ToUpper(c) : char.ToLower(c));
        }
        // Digit keys
        else if (key >= Keys.D0 && key <= Keys.D9)
        {
            _currentWord.Append((char)('0' + (key - Keys.D0)));
        }
        // Word boundary
        else if (key == Keys.Space || key == Keys.Enter || key == Keys.Tab)
        {
            TriggerWord();
        }
        // Basic punctuation
        else if (IsPunctuation(key))
        {
            TriggerWord();
        }
        else if (key == Keys.Back)
        {
            if (_currentWord.Length > 0)
                _currentWord.Length--;
        }
    }

    private void TriggerWord()
    {
        if (_currentWord.Length > 0)
        {
            WordCompleted?.Invoke(this, _currentWord.ToString());
            _currentWord.Clear();
        }
    }

    private bool IsPunctuation(Keys key)
    {
        return key == Keys.OemPeriod ||
               key == Keys.Oemcomma ||
               key == Keys.OemQuestion ||
               key == Keys.OemSemicolon ||
               key == Keys.OemQuotes ||
               key == Keys.OemMinus;
    }
}