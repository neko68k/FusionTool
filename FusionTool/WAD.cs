using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FusionTool
{
    class WAD
    {
        Stream wad;

        public WAD(Stream stream)
        {
            wad = stream;
        }
        public void Close()
        {
            wad.Close();
        }

        public byte[] GetFileFromOfs(long ofs, UInt32 size)
        {
            byte[] buf = new byte[size];
            wad.Seek(ofs, SeekOrigin.Begin);
            wad.Read(buf, 0, (int)size);
            return buf;
        }

    }
}
