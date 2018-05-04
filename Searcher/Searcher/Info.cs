using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Searcher
{
    class Info
    {
        public string path;
        //public static Regex reg;
        public string exp;

        public Info(string s)
        {
            exp = s;
        }

        public bool matches(FileInfo s)
        {
            if (s.Name.Contains(exp))
                return true;
            else
                return false;
            //Match m = Regex.Match(s);
        }
        public void setExpression(string s)
        {

        }

        public static List<FileInfo> GetFileList(string fileSearchPattern, string rootFolderPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootFolderPath);

            List<DirectoryInfo> dirList = new List<DirectoryInfo>(
                rootDir.GetDirectories("*", SearchOption.AllDirectories));
            dirList.Add(rootDir);

            List<FileInfo> fileList = new List<FileInfo>();

            foreach (DirectoryInfo dir in dirList)
            {
                fileList.AddRange(
                    dir.GetFiles(fileSearchPattern, SearchOption.TopDirectoryOnly));
            }

            return fileList;
        }
    }
}
