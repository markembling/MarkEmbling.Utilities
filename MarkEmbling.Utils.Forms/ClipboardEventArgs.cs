using System.ComponentModel;

namespace MarkEmbling.Utils.Forms {
    public class ClipboardEventArgs : CancelEventArgs {
        public string Text { get; private set; }

        public ClipboardEventArgs(string text) {
            Text = text;
        }
    }
}
