using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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

        // simple replacement, no rebuild of the WAD
        public void ReplaceFile(byte[] buf, long ofs, UInt32 size, UInt32 blocks)
        {
            wad.Seek(ofs, SeekOrigin.Begin);
            byte[] blockBuf = new byte[blocks * 2048];
            buf.CopyTo(blockBuf, 0);
            wad.Write(blockBuf, 0, (int)blocks * 2048);


        }

        public byte[] GetFileFromOfs(long ofs, UInt32 size)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            byte[] buf = new byte[size];
            wad.Seek(ofs, SeekOrigin.Begin);
            wad.Read(buf, 0, (int)size);
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
            return buf;
        }

    }
}
