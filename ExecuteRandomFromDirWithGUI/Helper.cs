using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExecuteRandomFromDirWithGUI
{
    class Helper
    {
        public static string[] GetAllSafeFiles(string path, IProgress<int> progress, string searchPattern = "*.*")
        {
            List<string> allFiles = new List<string>();
            string[] root = Directory.GetFiles(path, searchPattern);
            allFiles.AddRange(root);

            string[] folders = Directory.GetDirectories(path);
            for (var i = 0; i < folders.Length; i++)
            {
                var perComplete = (i * 100) / folders.Length;
                progress.Report(perComplete);

                try
                {
                    if (!IsIgnorable(folders[i]))
                    {
                        allFiles.AddRange(Directory.GetFiles(folders[i], searchPattern, SearchOption.AllDirectories));
                    }
                }
                catch { }
            }

            return allFiles.ToArray();
        }

        private static bool IsIgnorable(string dir)
        {
            if (dir.EndsWith("System Volume Information")) return true;
            if (dir.Contains("$RECYCLE.BIN")) return true;
            return false;
        }

    }
}
