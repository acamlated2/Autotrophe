namespace Autotrophe.Core;

using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new();
    public long Frequency { get; set; } = 0;
}

public class Trie
{
    private readonly TrieNode root = new();

    public void Insert(string word, long frequency)
    {
        var node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode();
            node = node.Children[c];
        }

        if (frequency > node.Frequency)
        {
            node.Frequency = frequency;   
        }
    }

    public bool Search(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (!node.Children.TryGetValue(c, out node))
                return false;
        }
        return node.Frequency > 0;
    }

    public long GetFrequency(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            if (!node.Children.TryGetValue(c, out node))
                return 0;
        }
        return node.Frequency;
    }

    // For prefix search (autocomplete)
    public bool StartsWith(string prefix)
    {
        var node = root;
        foreach (char c in prefix)
        {
            if (!node.Children.TryGetValue(c, out node))
                return false;
        }
        return true;
    }

    public List<(string Word, int Distance, long Frequency)> SearchSimilar(string input, int maxDistance)
    {
        var results = new List<(string, int, long)>();
        
        // initialise first row: [0, 1, 2, 3, ... len(input)]
        var currentRow = new int[input.Length + 1];
        for (int i = 0; i <= input.Length; i++)
            currentRow[i] = i;

        foreach (var kvp in root.Children)
        {
            SearchRecursive(kvp.Key, kvp.Value, kvp.Key.ToString(), input, currentRow, results, maxDistance);
        }
        
        return results;
    }

    private void SearchRecursive(char letter, TrieNode node, string prefix, string word, int[] previousRow,
        List<(string, int, long)> results, int maxDistance)
    {
        int columns = word.Length + 1;
        int[] currentRow = new int[columns];
        currentRow[0] = previousRow[0] + 1;
        
        // Fill in the rest of the row
        for (int column = 1; column < columns; column++)
        {
            int insertCost = currentRow[column - 1] + 1;
            int deleteCost = previousRow[column] + 1;
            int replaceCost = previousRow[column - 1] + (word[column - 1] == letter ? 0 : 1);
            currentRow[column] = Math.Min(Math.Min(insertCost, deleteCost), replaceCost);
        }

        // If at the end of a word in trie and within distance -> add it
        if (node.Frequency > 0 && currentRow[^1] <= maxDistance)
            results.Add((prefix, currentRow[^1], node.Frequency));

        // If any value in currentRow ≤ maxDistance -> keep exploring
        if (Min(currentRow) <= maxDistance)
        {
            foreach (var kvp in node.Children)
            {
                SearchRecursive(kvp.Key, kvp.Value, prefix + kvp.Key, word, currentRow, results, maxDistance);
            }
        }
    }
    
    private int Min(int[] arr)
    {
        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] < min)
                min = arr[i];
        return min;
    }
}