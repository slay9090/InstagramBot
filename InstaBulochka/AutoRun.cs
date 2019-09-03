using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstaBulochka
{
    class AutoRun
    {

        public void appAutoRunOn()
        {
            string link = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)
             + Path.DirectorySeparatorChar + Application.ProductName + ".lnk";
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut(link) as IWshShortcut;
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            //shortcut...
            shortcut.Save();


        }

        

 

        public void appAutoRunOff() {
            //удаляем 
            
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)
             + Path.DirectorySeparatorChar + Application.ProductName + ".lnk");

        }
    }
}
