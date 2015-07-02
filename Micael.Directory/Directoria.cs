using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micael.Directoria
{
   public static class Diretoria
    {

        public static void GetAllFoldersAndSubFolders(List<string> lstFolders, string path)
        {
            lstFolders.Add(path);
            string[] files = Directory.GetDirectories(path);
            foreach (string pathFolders in files)
            {
                GetAllFoldersAndSubFolders(lstFolders, pathFolders);
            }
        }
        public static void GetFilesFromListPaths(List<string> lstPaths, List<string> lstFilesPath)
        {
            GetFilesFromListPaths(lstPaths, lstFilesPath, "", false);
        }
        public static void GetFilesFromListPaths(List<string> lstPaths, List<string> lstFilesPath, string NameFile,bool ContainsNameFile)
        {
            if (ContainsNameFile)
                NameFile = "*" + NameFile + "*";
            foreach (string path in lstPaths)
            {
                string[] result = Directory.GetFiles(path, NameFile);
                foreach (string pathFile in result)
                {
                    lstFilesPath.Add(pathFile);
                }
            }
        }
    }
}
