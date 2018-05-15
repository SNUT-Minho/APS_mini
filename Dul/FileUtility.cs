using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dul
{
    public class FileUtility
    {
        public static string GetFileNameWithNumbering(string strBaseDirTemp, string strFileNameTemp)
        {
            string strName = Path.GetFileNameWithoutExtension(strFileNameTemp); // 순수 파일명 : Test
            string strExt = Path.GetExtension(strFileNameTemp);
            bool blnExists = true;
            int i = 0;
            while (blnExists)
            {
                //Path.Combine(경로, 파일명) = 경로+파일명
                if (File.Exists(Path.Combine(strBaseDirTemp, strFileNameTemp)))
                {
                    strFileNameTemp = strName + "(" + ++i + ")" + strExt; // Test(3).txt
                }
                else
                {
                    blnExists = false;
                }
            }
            return strFileNameTemp;
        }
    }
}
