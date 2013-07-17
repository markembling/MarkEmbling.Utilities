using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkEmbling.Utils.Forms {
    public class ClipboardEventArgs : CancelEventArgs {
        public string Text { get; private set; }

        public ClipboardEventArgs(string text) {
            Text = text;
        }
    }
}
