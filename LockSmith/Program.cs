using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LockSmith
{

      


    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {

            string filePath = "";


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormListLocks frmLocks = new FormListLocks();

            if (args.Length > 0)
            {
                filePath = args[0];
                filePath = filePath.Replace("\"", "");

                if (System.IO.File.Exists(filePath))
                {
                    frmLocks.strFilePath = filePath;
                }
            }


            Application.Run(frmLocks);


        }

        


    }
}
