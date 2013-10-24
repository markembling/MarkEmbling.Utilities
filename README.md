MarkEmbling.Utils
=================

Various miscellaneous bits and pieces for re-use (.NET). This will most likely grow over time.

### MarkEmbling.Utils

Various extension methods and other commonly used reusable bits.

### MarkEmbling.Utils.Forms

Windows Forms specific stuff such as custom controls and so on.

 - `ClipboardAwareTextBox`
     - Inherits from `TextBox` and exposes events for clipboard events (cut/copy/paste).
 - `NativeStyleTreeView`
 	 - Extends `TreeView` and adds a property to toggle between the standard .NET TreeView appearance and the 'native' Explorer style appearance (updated expend/contract buttons and selection style)
 - `DragDropTreeView`
 	 - Extends the above `NativeStyleTreeView` control and adds the ability to re-order nodes via drag and drop. Remember to change the `AllowDrop` property to true to enable this.
	 
---

### MarkEmbling.Utils.Tests

NUnit-based tests for the above projects.

### MarkEmbling.Utils.Forms.Examples

A little Windows Forms app which demos some of the controls from `MarkEmbling.Utils.Forms`. Not very comprehensive.
