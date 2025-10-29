using System.Text;
using Autotrophe.Core;
using Microsoft.Win32;
using WindowsInput;
using WindowsInput.Native;

namespace Autotrophe;

public partial class MainForm : Form
{
    private bool _wordCompleted = false;
    private readonly AutoCorrectEngine _engine;
    
    private const string _appName = "Autotrophe";
    
    public MainForm(AutoCorrectEngine engine)
    {
        InitializeComponent();
        _engine = engine;
        
        _engine.KeyPressed += EngineKeyPressed;
        _engine.WordCompleted += EngineWordCompleted;
        _engine.SuggestionsFound += EngineSuggestionsFound;
    }
    
    private void MainForm_Load(object sender, EventArgs e)
    {
        this.Icon = new Icon("Icons/Autotrophe.ico");
        
        checkBox1.Checked = IsStartupEnabled();
    }
    
    private void EngineKeyPressed(string key)
    {
        if (_wordCompleted)
            label2.Text = "";
        
        _wordCompleted = false;
        
        label2.Text += key + " ";
    }
    
    private void EngineWordCompleted(string word)
    {
        // Update label on UI thread
        if (InvokeRequired)
        {
            Invoke(new Action(() => label4.Text = word));
        }
        else
        {
            label4.Text = word;
        }
    }

    private void EngineSuggestionsFound(List<(string Word, int Distance, long Frequency)> suggestions)
    {
        richTextBox1.Clear();
        
        if (suggestions.Count == 0)
            return;
        
        foreach (var (word, dist, frequency) in suggestions)
        {
            richTextBox1.AppendText($"{word} (distance {dist}) (frequency {frequency})");
        }
        
        (string suggestedWord, int wordDistance, long wordFrequency) = suggestions[0];
        
        label6.Text = suggestedWord;
    }

    private void SetStartup(bool enable)
    {
        string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
        {
            if (enable)
            {
                key.SetValue(_appName, Application.ExecutablePath);
            }
            else
            {
                {
                    key.DeleteValue(_appName, false);
                }
            }
        }
    }

    private bool IsStartupEnabled()
    {
        string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
        {
            return key?.GetValue(_appName) != null;
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        SetStartup(checkBox1.Checked);
    }
}