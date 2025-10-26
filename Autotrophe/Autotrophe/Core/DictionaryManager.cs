namespace Autotrophe.Core;

public class DictionaryManager
{
    private static DictionaryManager? _instance;
    public static DictionaryManager Instance => _instance ??= new DictionaryManager();
    
    public Trie GlobalTrie { get; private set; } = new();
    
    private static readonly Dictionary<string, long> CommonApostropheWords = new()
    {
        // --- High-Frequency Contractions (Core) ---
        {"i'm", 6808191815},
        {"you're", 6808191815},
        {"he's", 6808191815},
        {"she's", 6808191815},
        {"it's", 6808191815},
        {"we're", 6808191815},
        {"they're", 6808191815},

        {"don't", 6808191815},
        {"can't", 6808191815},
        {"won't", 6808191815},
        {"isn't", 6808191815},
        {"aren't", 6808191815},
        {"wasn't", 6808191815},
        {"weren't", 6808191815},
        {"haven't", 6808191815},
        {"hasn't", 6808191815},
        {"hadn't", 6808191815},

        {"i'll", 6808191815},
        {"you'll", 6808191815},
        {"he'll", 6808191815},
        {"she'll", 6808191815},
        {"we'll", 6808191815},
        {"they'll", 6808191815},

        {"i've", 6808191815},
        {"you've", 6808191815},
        {"we've", 6808191815},
        {"they've", 6808191815},

        {"i'd", 6808191815},
        {"you'd", 6808191815},
        {"he'd", 6808191815},
        {"she'd", 6808191815},
        {"we'd", 6808191815},
        {"they'd", 6808191815},

        // --- Question & Location Contractions (Noun + 'is / has) ---
        {"what's", 6808191815}, 
        {"that's", 6808191815}, 
        {"where's", 6808191815},
        {"who's", 6808191815}, 
        {"how's", 6808191815}, 
        {"there's", 6808191815},
        {"when's", 6808191815}, 
        {"why's", 6808191815}, 
        {"here's", 6808191815}, 

        // --- Negative Contractions (Modals) ---
        {"couldn't", 6808191815},
        {"shouldn't", 6808191815},
        {"wouldn't", 6808191815},
        {"mustn't", 6808191815},
        {"mightn't", 6808191815},
        {"daren't", 6808191815}, 

        // --- Other Common Contractions ---
        {"let's", 6808191815}, 
        {"ain't", 6808191815}, 
        {"d'ye", 6808191815}, 
        {"o'clock", 6808191815},
        {"ma'am", 6808191815}, 

        // --- Informal/Slang/Dialect Contractions ---
        {"y'all", 6808191815}, 
        {"gimme", 6808191815}, 
        {"gotta", 6808191815}, 
        {"wanna", 6808191815}, 
        {"c'mon", 6808191815}, 
        {"'cause", 6808191815},
        {"'em", 6808191815}, 
        {"rock 'n' roll", 6808191815},

        // --- Archaic/Poetic Contractions ---
        {"ne'er", 6808191815},
        {"e'er", 6808191815}, 
        {"o'er", 6808191815}, 
        {"'tis", 6808191815}, 
        {"'twas", 6808191815},

        // --- High-Frequency Singular Possessives (Noun's) ---
        {"world's", 6808191815},
        {"God's", 6808191815},
        {"man's", 6808191815},
        {"woman's", 6808191815},
        {"day's", 6808191815},
        {"year's", 6808191815},
        {"life's", 6808191815},
        {"time's", 6808191815},
        {"city's", 6808191815},
        {"country's", 6808191815},
        {"house's", 6808191815},
        {"friend's", 6808191815},
        {"father's", 6808191815},
        {"mother's", 6808191815},
        {"brother's", 6808191815},
        {"sister's", 6808191815},
        {"king's", 6808191815},
        {"queen's", 6808191815},
        {"president's", 6808191815},
        {"company's", 6808191815},
        {"government's", 6808191815},
        {"team's", 6808191815},
        {"book's", 6808191815},
        {"car's", 6808191815},
        {"today's", 6808191815},
        {"someone's", 6808191815},
        {"nobody's", 6808191815},
        {"everybody's", 6808191815},
        {"anyone's", 6808191815},
        {"something's", 6808191815},
        {"nothing's", 6808191815},

        // --- Irregular Plural Possessives (Word's) ---
        {"people's", 6808191815},
        {"children's", 6808191815},
        {"men's", 6808191815},
        {"women's", 6808191815},
    };
    
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
                {
                    if (CommonApostropheWords.TryGetValue(word, out long freq))
                    {
                        GlobalTrie.Insert(word, freq);
                    }
                    else
                    {
                        GlobalTrie.Insert(word, 1); // default frequency
                    }
                }
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
                    {
                        if (CommonApostropheWords.TryGetValue(word, out long freq))
                            frequency = freq;
                        
                        GlobalTrie.Insert(word, frequency);
                    }
                }
            }
        }
    }
}