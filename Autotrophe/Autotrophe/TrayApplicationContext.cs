using System;
using System.Drawing;
using System.Windows.Forms;
using Autotrophe;

public class TrayApplicationContext : ApplicationContext
{
    private readonly NotifyIcon _tray;
    private MainForm? _settingsForm;
        
    private readonly AutoCorrectEngine _engine;
    private readonly KeyboardHook _hook;

    public TrayApplicationContext()
    {
        _engine = new AutoCorrectEngine();
        _hook = new KeyboardHook();
        _hook.KeyDown += OnKeyDown;
        _hook.Start();
            
        // Create the tray icon
        _tray = new NotifyIcon
        {
            Icon = new Icon("Icons/Autotrophe.ico"),
            Text = "Autotrophe",
            Visible = true,
            ContextMenuStrip = new ContextMenuStrip()
        };

        // Create right-click menu items
        var openItem = new ToolStripMenuItem("Settings", null, OpenSettings);
        var exitItem = new ToolStripMenuItem("Exit", null, Exit);

        _tray.ContextMenuStrip.Items.Add(openItem);
        _tray.ContextMenuStrip.Items.Add(new ToolStripSeparator());
        _tray.ContextMenuStrip.Items.Add(exitItem);

        // Double-click to open Settings
        _tray.DoubleClick += OpenSettings;
    }

    private void OpenSettings(object? sender, EventArgs e)
    {
        if (_settingsForm == null || _settingsForm.IsDisposed)
        {
            _settingsForm = new MainForm(_engine);
            _settingsForm.FormClosed += (_, _) => _settingsForm = null;
            _settingsForm.Show();
        }
        else
        {
            _settingsForm.BringToFront();
        }
    }

    private void Exit(object? sender, EventArgs e)
    {
        _tray.Visible = false;
        _tray.Dispose();
        Application.Exit();
    }
        
    private void OnKeyDown(object? sender, Keys key)
    {
        _engine.ProcessKey(key);
    }
}