using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using personal_manage.Common.dto;

namespace personal_manage.Common.util
{
    /// <summary>
    /// 优泰工具
    /// </summary>
    public class UTHelper
    {

        public static UKResult FileEncryption(string sourcePath,string publicKey)
        {
            var startTime = DateTime.Now;
            UKResult resultEntityRetun;
            String resultRetunStr;
            UTCCrypt.UTCCrypt crypt = new UTCCrypt.UTCCrypt();

            string outFile = Path.Combine(Path.GetDirectoryName(sourcePath), Path.GetFileName(sourcePath)+".enc");
            resultRetunStr = crypt.EnvelopFile(sourcePath, outFile, publicKey, UTCCrypt.UTCCrypt.RC4);
            resultEntityRetun = JsonConvert.DeserializeObject<UKResult>(resultRetunStr);
            var endTime = DateTime.Now;
            Console.WriteLine($"耗时：{endTime.Subtract(startTime).TotalMilliseconds}毫秒");

            return resultEntityRetun;
        }



        /// <summary>
        ///  解密
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static UKResult FileDecryption(string sourcePath)
        {
            UKResult resultEntityRetun;
            string resultRetunStr;
            UTCCrypt.UTCCrypt crypt = new UTCCrypt.UTCCrypt();
            string pfxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cert\\pfx.pfx");
            string outFile = Path.Combine(Path.GetDirectoryName(sourcePath), @"decry\"+Path.GetFileName(sourcePath).Replace(".enc",""));

            FileInfo file = new FileInfo(outFile);
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            
            resultRetunStr = crypt.DecryptFileByPfx(pfxPath, "1234", sourcePath, outFile);

            resultEntityRetun = JsonConvert.DeserializeObject<UKResult>(resultRetunStr);
            resultEntityRetun.ExtraInfo = outFile;

            return resultEntityRetun;
        }




    }
}
