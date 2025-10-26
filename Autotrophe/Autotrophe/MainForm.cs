using System.Text;
using Autotrophe.Core;
using SysAutoCorrect;

namespace Autotrophe;

public partial class MainForm : Form
{
    private bool _enabled = false;
    
    private KeyboardHook? _hook;
    
    private readonly TypedBuffer _typedBuffer = new TypedBuffer();
    
    private static MainForm? _instance;
    public static MainForm Instance => _instance ??= new MainForm();
    
    public MainForm()
    {
        InitializeComponent();
        
        _typedBuffer.WordCompleted += TypedBuffer_WordCompleted;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // _enabled = !_enabled;
        // button1.Text = _enabled ? "Disable Autocorrect" : "Enable Autocorrect";
        // MessageBox.Show("Autocorrect is now " + (_enabled ? "enabled" : "disabled"));
        //
        // if (_enabled)
        // {
        //     _hook = new KeyboardHook();
        //     _hook.KeyDown += OnKeyDown;
        //     _hook.Start();
        // }
        // else
        // {
        //     _hook?.Stop();
        //     _hook = null;
        // }
    }

    private void OnKeyDown(object? sender, Keys key)
    {
        textBox1.AppendText(key + " ");
        
        _typedBuffer.ProcessKey(key);
    }

    private void TypedBuffer_WordCompleted(object sender, string completedWord)
    {
        textBox2.Clear();
        textBox2.AppendText(completedWord);
        
        string input = completedWord.ToLower();

        if (DictionaryManager.Instance.GlobalTrie.Search(input)) return;
        
        var candidates = DictionaryManager.Instance.GlobalTrie.SearchSimilar(input, 2);

        List<(string, int, long)> sortedCandidates =
            candidates.OrderBy(c => c.Distance).ThenByDescending(c => c.Frequency).ToList();
        
        foreach (var (word, dist, frequency) in sortedCandidates)
        {
            AppendLog($"{word} (distance {dist}) (frequency {frequency})");
        }

        (string suggestedWord, int wordDistance, long wordFrequency) = sortedCandidates[0];
        
        textBox4.Clear();
        textBox4.AppendText(suggestedWord);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        _hook = new KeyboardHook();
        _hook.KeyDown += OnKeyDown;
        _hook.Start();
    }

    public void AppendLog(string text)
    {
        textBox3.AppendText(text + " ");
    }
}