using ResetWindows.Properties;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ResetWindows
{
    public partial class ResetForm : Form
    {
        private readonly NotifyIcon _NotifyIcon;
        private readonly ContextMenuStrip _ContextMenuStrip;
        private bool _AllowShow = false;

        public IHostApplicationLifetime? Lifetime { get; set; }

        public ResetForm()
        {
            InitializeComponent();
            components = new Container();
            _NotifyIcon = new(components)
            {
                Icon = Resources.dollar,
                Visible = true
            };
            _NotifyIcon.DoubleClick += NotifyIconClick;
            _ContextMenuStrip = new ContextMenuStrip();
            _ContextMenuStrip.Items.Add(new ToolStripMenuItem("Reset &all windows", null, ResetAllWindowsClick));
            _ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _ContextMenuStrip.Items.Add(new ToolStripMenuItem("&Close", null, CloseClick));
            _ContextMenuStrip.Items.Add(new ToolStripMenuItem("E&xit", null, ExitClick));
            _NotifyIcon.ContextMenuStrip = _ContextMenuStrip;
            ContextMenuStrip = _ContextMenuStrip;
        }

        private void NotifyIconClick(object? sender, EventArgs e)
        {
            _AllowShow = true;
            Visible = !Visible;
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(_AllowShow ? value : _AllowShow);
        }

        private void ResetAllWindowsClick(object? sender, EventArgs e)
        {
            NativeMethods.GetDesktopWindowHandlesAndTitles(out List<IntPtr>? handles, out List<string>? titles);
            List<string> ignoreTheseWindows = new() { "Program Manager", "MainWindow", "Snipping Tool", "Task Manager", "Task Manager Properties", "Settings" };
            for (int i = 0; i < titles?.Count; i++)
                if (!ignoreTheseWindows.Contains(titles[i]))
                {
                    Rectangle wrect = new();
                    Rectangle xrect = new();

                    _ = NativeMethods.GetWindowRect(handles![i], ref wrect);
                    _ = NativeMethods.DwmGetWindowAttribute(handles![i], 9, ref xrect, Marshal.SizeOf(typeof(Rectangle)));

                    Point wtl = new(wrect.Left, wrect.Top);
                    Point wbr = new(wrect.Right, wrect.Bottom);

                    Point xtl = new(xrect.Left, xrect.Top);
                    Point xbr = new(xrect.Right, xrect.Bottom);

                    _ = NativeMethods.PhysicalToLogicalPointForPerMonitorDPI(handles![i], ref xtl);
                    _ = NativeMethods.PhysicalToLogicalPointForPerMonitorDPI(handles![i], ref xbr);
                    Rectangle required_rect = new(0, 0, wrect.Width, wrect.Height);
                    Rectangle adjusted_rect = new(
   required_rect.X - (xtl.X - wtl.X),
   required_rect.Y - (xtl.Y - wtl.Y),
   required_rect.Width + (xtl.X - wtl.X) + (wbr.X - xbr.X),
   required_rect.Height + (xtl.Y - wtl.Y) + (wbr.Y - xbr.Y));
                    _ = NativeMethods.MoveWindow(handles![i], adjusted_rect.X, adjusted_rect.Y, adjusted_rect.Width, adjusted_rect.Height, true);
                }
        }

        private void CloseClick(object? sender, EventArgs e)
        {
            _AllowShow = Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        private void ExitClick(object? sender, EventArgs e)
        {
            Lifetime?.StopApplication();
            Application.Exit();
        }
    }
}
