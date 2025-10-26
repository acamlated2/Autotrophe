using System;
using System.Drawing;
using System.Windows.Forms;
using Autotrophe;

namespace Autotrophe
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _tray;
        private MainForm? _settingsForm;

        public TrayApplicationContext()
        {
            // Create the tray icon
            _tray = new NotifyIcon
            {
                Icon = SystemIcons.Application, // default app icon
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
                _settingsForm = new MainForm();
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
    }
}