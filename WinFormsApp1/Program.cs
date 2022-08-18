using System;
using System.Windows.Forms;
using WK.Libraries.SharpClipboardNS;


namespace WinFormsApp1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GenerateBatchCommand());
            //var clipboard = new SharpClipboard();

            //// Attach your code to the ClipboardChanged event to listen to cuts/copies.
            //clipboard.ClipboardChanged += ClipboardChanged;



            //static void ClipboardChanged(Object sender, SharpClipboard.ClipboardChangedEventArgs e)
            //{
            //    // Is the content copied of text type?
            //    if (e.ContentType == SharpClipboard.ContentTypes.Text)
            //    {
            //        // Get the cut/copied text.
            //        //  Debug.WriteLine(e.Content.ToString());
            //        string text = e.Content.ToString();
            //        MessageBox.Show($"si text eeee =  {text}");
            //    }

            //}

        }
    }
}
