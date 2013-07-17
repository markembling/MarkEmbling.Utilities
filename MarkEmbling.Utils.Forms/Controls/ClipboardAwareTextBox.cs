using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkEmbling.Utils.Forms.Controls
{
    /*
     * Thanks to the following for pointers, advice and examples:
     * - http://stackoverflow.com/questions/3446233/hook-on-default-paste-event-of-winforms-textbox-control
     * - http://www.vcskicks.com/clipboard-textbox.php
     */

    /// <summary>
    /// Extended version of the standard TextBox control to expose
    /// clipboard-centric events.
    /// </summary>
    public class ClipboardAwareTextBox : TextBox {
        private const int WM_CUT = 0x0300;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;

        public delegate void ClipboardEventHandler(object sender, ClipboardEventArgs e);

        [Category("Clipboard")]
        public event ClipboardEventHandler CutText;

        [Category("Clipboard")]
        public event ClipboardEventHandler CopiedText;

        [Category("Clipboard")]
        public event ClipboardEventHandler PastedText;

        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case WM_CUT:
                    if (CutText != null) {
                        var args = new ClipboardEventArgs(SelectedText);
                        CutText(this, args);
                        if (! args.Cancel) base.WndProc(ref m);
                    }
                    break;
                case WM_COPY:
                    if (CopiedText != null) {
                        var args = new ClipboardEventArgs(SelectedText);
                        CopiedText(this, args);
                        if (! args.Cancel) base.WndProc(ref m);
                    }
                    break;
                case WM_PASTE:
                    if (PastedText != null) {
                        var args = new ClipboardEventArgs(Clipboard.GetText());
                        PastedText(this, args);
                        if (! args.Cancel) base.WndProc(ref m);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
