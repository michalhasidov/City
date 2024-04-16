using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCity
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Hello helloForm = new Hello();
            //Edit editForm = new Edit();
            //helloForm.ValueSelected += (sender, selectedValue) =>
            //{
            //    editForm.UpdateTextBox(selectedValue);
            //    editForm.Show();
            //};
            Application.Run(new Hello());
             //editForm = new Edit();

        }
    }
}
