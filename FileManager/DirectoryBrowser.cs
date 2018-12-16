using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class DirectoryBrowser
    {
        public String CurrentPath = @"D:\";

        public DirectoryInfo[] dirList = new DirectoryInfo[0];

        public FileInfo[] fileList = new FileInfo[0];

        public DirectoryInfo currentDir;


        public void GetDirectoryInfo(String path)
        {
            CurrentPath = path;
            currentDir = new DirectoryInfo(path);

            DirectoryInfo di = new DirectoryInfo(path);

            try
            {
                dirList = di.GetDirectories();
            }
            catch
            {

            }


            try
            {
                fileList = di.GetFiles();
            }
            catch
            {

            }

        }
    }
}
