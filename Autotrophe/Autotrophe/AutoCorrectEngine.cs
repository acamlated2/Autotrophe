using Autotrophe.Core;
using WindowsInput;
using WindowsInput.Native;

namespace Autotrophe;

public class AutoCorrectEngine
{
    private readonly TypedBuffer _typedBuffer = new TypedBuffer();
    private readonly IInputSimulator _sim = new InputSimulator();
    
    public event Action<string>? KeyPressed;
    public event Action<string>? WordCompleted;
    public event Action<List<(string, int, long)>>? SuggestionsFound;

    public AutoCorrectEngine()
    {
        _typedBuffer.WordCompleted += TypedBuffer_WordCompleted;
    }

    public void ProcessKey(Keys key)
    {
        KeyPressed?.Invoke(key.ToString());
        _typedBuffer.ProcessKey(key);
    }
    
    private void TypedBuffer_WordCompleted(object sender, string completedWord)
    {
        WordCompleted?.Invoke(completedWord);
        
        string input = completedWord.ToLower();

        if (DictionaryManager.Instance.GlobalTrie.Search(input))
            return;

        var candidates = DictionaryManager.Instance.GlobalTrie.SearchSimilar(input, 2);
        if (candidates.Count == 0)
            return;

        var sorted = candidates.OrderBy(c => c.Distance)
            .ThenByDescending(c => c.Frequency)
            .ToList();

        string suggestion = sorted[0].Item1;
        
        SuggestionsFound?.Invoke(sorted);

        // Ctrl+Backspace to remove wrong word
        _sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.BACK);

        // Small delay before typing suggestion
        Thread.Sleep(50);

        _sim.Keyboard.TextEntry(suggestion);
    }
}