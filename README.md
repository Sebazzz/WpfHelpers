WpfHelpers
===========================

Useful utility functions and extensions for Windows Phone and WPF

Documentation is a big TODO but to help you on your way:

Naming Convention
---------------------------
The folders and namespaces are very much like the .NET namespaces. For example, there is a Windows/Data folder. I
n code, the classes in those folders are in the WpfHelpers.Windows.Data namespace. You can expect the same type of objects as one would expect in the System.Windows.Data namespace.

Projects
---------------------------
WpfHelpers.Base: Contains most utility classes. All classes in this library are also safe to use by background agents.

WpfHelpers: Contains non-backgroundworker safe classes (Windows Phone only).


Highlights (Windows Phone)
---------------------------

Classes to check out:
- UserInterfaceThreadDispatcher and DelegateExtensions: Helper interface for dispatching asynchronous updates back to the UI
- SettingsBase: Base class for general application settings
- ListBoxEx: Extended version of the Windows Phone listbox that supports an empty view (shown when there are no items in the list), command binding for MVVM.
- GlobalApplication: Base class for you application definition (App.xaml) that provides you with debugging tools and prevents boilerplate code.

Style files to check out:
- TransitionStyles.xaml: Avoid that biolerplate clutter of Silverlight Toolkit transitions and apply one of the style to your page.
- ListBoxStyles.xaml/ListBoxEmptyStretchTemplate: Fixes a bug in the standard Windows Phone listbox, where items are not horizontally stretched to its container.


Wiki pages
----------------------------
Check out the [wiki pages](https://github.com/Sebazzz/SDammann.WindowsPhone.Utils/wiki).