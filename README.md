MarkEmbling.Utils
=================

Miscellaneous bits and pieces (.NET) which don't fit anywhere else but need somewhere to live.

### MarkEmbling.Utils

Extension methods, helpers and other common bits with no special requirements. A lot of this is stuff I might otherwise find myself copying into many projects - and nobody wants that mess - so they're packaged up here for easy re-use.

[Available](https://www.nuget.org/packages/MarkEmbling.Utils/) on NuGet.

### MarkEmbling.Utils.Forms

Custom controls and any other Windows Forms specifics which again don't really belong anywhere else.

[Available](https://www.nuget.org/packages/MarkEmbling.Utils.Forms/) on NuGet.

 - `ClipboardAwareTextBox`
    - Inherits from `TextBox` and exposes events for clipboard events (cut/copy/paste).
 - `NativeStyleTreeView`
    - Extends `TreeView` and adds a property to toggle between the standard .NET TreeView appearance and the 'native' Explorer style appearance (updated expend/contract buttons and selection style)
 - `DragDropTreeView`
    - Extends the above `NativeStyleTreeView` control and adds the ability to re-order nodes via drag and drop. Remember to change the `AllowDrop` property to true to enable this.
 - `Gauge`
    - Gauge control based upon [AGauge](http://www.codeproject.com/Articles/448721/AGauge-WinForms-Gauge-Control). Currently buggy when using 3D-style needles and there are more features to be implemented, but is usable.

### MarkEmbling.Utils.Tests

[xUnit](https://xunit.github.io/) tests for the `MarkEmbling.Utils` project.

### MarkEmbling.Utils.Forms.Examples

A little Windows Forms app which demos some of the controls from `MarkEmbling.Utils.Forms`. Not very comprehensive.
