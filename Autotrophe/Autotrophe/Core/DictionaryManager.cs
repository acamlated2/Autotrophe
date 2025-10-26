namespace Autotrophe.Core;

public class DictionaryManager
{
    private static DictionaryManager? _instance;
    public static DictionaryManager Instance => _instance ??= new DictionaryManager();
    
    public Trie GlobalTrie { get; private set; } = new();
    
    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath)) return;
        
        string extension = Path.GetExtension(filePath).ToLowerInvariant();

        if (extension == ".txt") // plain text
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var word = line.Trim().ToLowerInvariant();
                if (!string.IsNullOrWhiteSpace(word))
                    GlobalTrie.Insert(word, 1);
            }
        }
        else if (extension == ".csv") // comma-separated values
        {
            // Use Skip(1) to ignore the header row (e.g. "ngram,freq,cumshare")
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Split the line by the comma
                var parts = line.Split(',');

                // The word ("ngram") is the first part (index 0)
                if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[0]) && long.TryParse(parts[1], out long frequency))
                {
                    var word = parts[0].Trim().ToLowerInvariant();
                    if (!string.IsNullOrWhiteSpace(word))
                        GlobalTrie.Insert(word, frequency);
                }
            }
        }
    }
}