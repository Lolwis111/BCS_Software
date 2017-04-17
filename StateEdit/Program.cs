using System;
using System.Windows.Forms;

namespace StateEdit
{
    [Obsolete("The state system got dropped. Simply enter name and points into BCS Software.")]
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
