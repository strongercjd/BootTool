using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PCTool
{
    class AESDLL
    {
        /// <summary>
        /// AES加密初始化
        /// </summary>
        [DllImport("AESDLL.dll")]
        public static extern void AesEncInit();
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="buffer"></param>
        [DllImport("AESDLL.dll")]
        public static extern void AesEncrypt(ref byte buffer);
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="buffer"></param>
        [DllImport("AESDLL.dll")]
        public static extern void AesDecrypt(ref byte buffer);
        /// <summary>
        /// 设置解密Key
        /// </summary>
        /// <param name="KeyBuffer"></param>
        [DllImport("AESDLL.dll")]
        public static extern void SetKey(ref byte KeyBuffer);
    }
}
