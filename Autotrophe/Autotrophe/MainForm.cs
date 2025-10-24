using System.Text;
using SysAutoCorrect;

namespace Autotrophe;

public partial class MainForm : Form
{
    private bool _enabled = false;
    
    private KeyboardHook? _hook;
    private StringBuilder _log = new();
    
    private TypedBuffer _typedBuffer = new TypedBuffer();
    
    public MainForm()
    {
        InitializeComponent();
        
        _typedBuffer.WordCompleted += TypedBuffer_WordCompleted;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _enabled = !_enabled;
        button1.Text = _enabled ? "Disable Autocorrect" : "Enable Autocorrect";
        MessageBox.Show("Autocorrect is now " + (_enabled ? "enabled" : "disabled"));

        if (_enabled)
        {
            _hook = new KeyboardHook();
            _hook.KeyDown += OnKeyDown;
            _hook.Start();
        }
        else
        {
            _hook?.Stop();
            _hook = null;
        }
    }

    private void OnKeyDown(object? sender, Keys key)
    {
        textBox1.AppendText(key + " ");
        
        _typedBuffer.ProcessKey(key);
    }

    private void TypedBuffer_WordCompleted(object sender, string word)
    {
        textBox2.AppendText(word + " ");
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        
    }
}