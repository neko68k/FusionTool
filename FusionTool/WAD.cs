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
