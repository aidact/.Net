using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Far
{
    class Program
    {
        //public Directory cur;
        static int areaHeights = 0;
        static List<string> area1 = new List<string>();
        static List<string> area2 = new List<string>();

        #region drawing
        static void Draw(string text, ConsoleColor fore, bool nl) {
            Console.ForegroundColor = fore;
            Console.Write(text);
            if (nl) Console.WriteLine();
        }
        static void Draw(string text, ConsoleColor fore, ConsoleColor back, bool nl) {
            Console.BackgroundColor = back;
            Draw(text, fore, nl);

        }
        #endregion 


        static void DrawLAT()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            FileSystemInfo[] items = dir.GetFileSystemInfos();
            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(40, i);
                Console.WriteLine(items[i].LastAccessTime);
            }
        }

        public static string Rename(FileSystemInfo[] cur, int index)
        {
            string ext = Path.GetExtension(cur[index].FullName);
            FileInfo fi = cur[index] as FileInfo;
            MyClear(3, 23);
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter file's new name: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 24);

            string s = Console.ReadLine();
            string w = cur[index].FullName.Remove(cur[index].FullName.Length - cur[index].Name.Length);
            string newFileName = s+ext;

            if (cur[index].GetType() == typeof(FileInfo))
            {
                string r = Path.Combine(fi.DirectoryName, newFileName);
                File.Move(cur[index].FullName, r);
            }
            else
            {
                string r = Path.Combine(w, newFileName);
                Directory.Move(cur[index].FullName, r);
            }

            return newFileName;
        }

        static void createFile(FileSystemInfo[] dir, int dirIndex, int index)
        {
            MyClear(3, 23);
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter file's name: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 24);
            string filename = Console.ReadLine();
            string path = dir[dirIndex].FullName + "\\" + filename;
            File.Create(path);
            reloadDir(dir[dirIndex], index);
        }

        static void deleteFile(FileSystemInfo[] dir, int dirIndex, int index, string path)
        {
            File.Delete(path);
            reloadDir(dir[dirIndex], index);
        }

        static void reloadDir(FileSystemInfo dir, int index)
        {
            MyClear(10, 2);
            MyClear(4, 23);
            FileSystemInfo[] newDir = (dir as DirectoryInfo).GetFileSystemInfos();
            Show(newDir, index);
        }

        private static void MyClear()
        {
            for (int i = 2; i <= Console.WindowHeight - 9; ++i)
            {
                Console.SetCursorPosition(2, i);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(new String(' ', Console.WindowWidth - 3));
            }
        }
        private static void MyClear(int cnt, int y)
        {
            for (int i = y; i <= Console.WindowHeight - cnt; ++i)
            {
                Console.SetCursorPosition(2, i);
                Console.WriteLine(new String(' ', Console.WindowWidth - 3));
            }
        }

        static void Show(FileSystemInfo[] cur, int index)
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            int ind = 0;
                foreach (FileSystemInfo fsi in cur)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    if (ind++ == index) Console.BackgroundColor = ConsoleColor.Red;
                    String disp = fsi.Name.Length < 20 ? fsi.Name : fsi.Name.Substring(0, 20);
                    if (fsi is DirectoryInfo)
                    {
                        Draw("[+]", ConsoleColor.Green, false);
                        Draw(disp, ConsoleColor.Cyan, true);
                    }
                    else
                    {
                        Draw(disp, ConsoleColor.White, true);
                    }
                }
            //}
        }

        /*private static void drawScreen()
        {
            Console.Clear();

            // Draw the area divider
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, areaHeights);
                Console.Write('=');
            }

            int currentLine = areaHeights - 1;

            for (int i = 0; i < area1.Count; i++)
            {
                Console.SetCursorPosition(0, currentLine - (i + 1));
                Console.WriteLine(area1[i]);

            }

            currentLine = (areaHeights * 2);
            for (int i = 0; i < area2.Count; i++)
            {
                Console.SetCursorPosition(0, currentLine - (i + 1));
                Console.WriteLine(area2[i]);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("> ");

        }

        private static void AddLineToBuffer(ref List<string> areaBuffer, string line)
        {
            areaBuffer.Insert(0, line);

            if (areaBuffer.Count == areaHeights)
            {
                areaBuffer.RemoveAt(areaHeights - 1);
            }
        }*/

        static void ShowInfo(DirectoryInfo directory, int cursor)
        {
            int index = 0;
            foreach (FileSystemInfo fInfo in directory.GetFileSystemInfos())
            {
                if (index == cursor)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                index++;
                if (fInfo.GetType() == typeof(FileInfo)){
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write("- ");
                }
                /*else
                    Console.Write("[+] ");*/
                Console.WriteLine(fInfo.Name);
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.SetWindowSize(60, 30);
            Console.CursorVisible = false;
            Stack<FileSystemInfo[]> parent = new Stack<FileSystemInfo[]>();
            Stack<int> indexhist = new Stack<int>();
            string[] drives = Environment.GetLogicalDrives();
            FileSystemInfo[] cur = new FileSystemInfo[drives.Length];
            for (int i = 0; i < cur.Length; i++)
                cur[i] = new DirectoryInfo(drives[i]);

            int index = 0;
            Show(cur, index);

            ConsoleKeyInfo pressed = Console.ReadKey(true);
            while (pressed.Key != ConsoleKey.Escape)
            {
                switch (pressed.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (cur.Length > index + 1)
                            index++;
                        else index = 0;
                        break;

                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        else index = cur.Length - 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (parent.Count > 0)
                        {
                            index = indexhist.Pop();
                            cur = parent.Pop();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (cur[index] is DirectoryInfo)
                        {
                            try
                            {
                                DirectoryInfo dir = cur[index] as DirectoryInfo;
                                indexhist.Push(index);
                                parent.Push(cur);
                                index = 0;
                                if (dir.GetFileSystemInfos().Length > 30)
                                {
                                    
                                }
                                cur = dir.GetFileSystemInfos();

                            }
                            catch (Exception e)
                            {
                            }
                        }
                        else {
                            if (Path.GetExtension(cur[index].FullName) == ".jpg" || Path.GetExtension(cur[index].FullName) == ".png" || Path.GetExtension(cur[index].FullName) == ".jpeg")
                            {
                                Console.Clear();
                                Bitmap bmpSrc = new Bitmap(cur[index].FullName, true);    
                                OpenImage.ConsoleWriteImage(bmpSrc);
                                Console.ReadKey();
                            }
                            else
                            {
                                StreamReader sr = new StreamReader(cur[index].FullName);
                                string s = sr.ReadToEnd();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Clear();
                                Console.WriteLine(s);
                                Console.ReadKey();
                            }
                        }
                        break;
                    case ConsoleKey.F2:
                        createFile(parent.Peek(), indexhist.Peek(), index);
                        break;
                    case ConsoleKey.F3:
                        deleteFile(parent.Peek(), indexhist.Peek(), index, cur[index].FullName);
                        cur = (parent.First()[indexhist.First()] as DirectoryInfo).GetFileSystemInfos();
                        break;
                    case ConsoleKey.F5:
                        Rename(cur, index);
                        break;
                    case ConsoleKey.Escape:
                        break;

                }
                Show(cur, index);
                DrawLAT();
                MakeBeauty();
                pressed = Console.ReadKey(true);
            }
        }

        public static void MakeBeauty()
        {
            Console.SetCursorPosition(30, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Write('|');
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.WriteLine('|');
            }
        }

        private static void DrawPanel()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            // Console.Clear();
            MyClear(10, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            int i, j;
            Console.SetCursorPosition(1, 1);
            for (i = 0; i < width; ++i) Console.Write("-");
            Console.WriteLine();
            for (j = 0; j < height - 10; ++j)
            {
                Console.Write("|");
                for (i = 0; i < width - 2; ++i)
                {
                    Console.Write(" ");
                }

                Console.Write("|");
                Console.WriteLine();
            }

            for (i = 0; i < width; ++i) Console.Write("-");
            Console.WriteLine();
            for (j = 0; j < 5; ++j)
            {
                Console.Write("|");
                for (i = 0; i < width - 2; ++i)
                {
                    Console.Write(" ");
                }

                Console.Write("|");
                Console.WriteLine();
            }
            for (i = 0; i < width; ++i) Console.Write("-");
            Console.WriteLine();
            for (j = 0; j < 1; ++j)
            {
                Console.Write("|");
                for (i = 0; i < width - 2; ++i)
                {
                    Console.Write(" ");
                }

                Console.Write("|");
                Console.WriteLine();
            }
            //enlarge window in order to prevent it from being scrolled
            Console.WindowHeight += 1;

            for (i = 0; i < width; ++i) Console.Write("-");
            //restore window's original size
            Console.WindowHeight -= 1;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 29);
            Console.Write("1=Help");
            Console.SetCursorPosition(11, 29);
            Console.Write("2=Mk dir");
            Console.SetCursorPosition(22, 29);
            Console.Write("3=Mk fl");
            Console.SetCursorPosition(33, 29);
            Console.Write("4=Del/Rem");
        }

    }
}
