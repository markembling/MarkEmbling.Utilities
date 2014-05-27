using System.Runtime.InteropServices;
using System.Text;

namespace MarkEmbling.Utils.Interop {
    public static class PathUtils {
        [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
        private static extern bool PathCompactPathEx([Out] StringBuilder pszOut, string szPath, int cchMax, int dwFlags);

        /// <summary>
        /// Compacts a path to the specified number of characters in length
        /// 
        /// Example:
        ///     C:\really\long\path\to\a\file.txt -> C:\really\...\file.txt
        /// </summary>
        /// <param name="path">Full path to compact</param>
        /// <param name="length">Maximum number of characters</param>
        /// <returns>Compacted path string</returns>
        public static string Compact(string path, int length) {
            var b = new StringBuilder(length);
            PathCompactPathEx(b, path, length, 0);
            return b.ToString();
        }
    }
}