using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FusionTool
{
    class WAC
    {
        public struct FOLDER
        {
            public UInt32 numFiles;
            public UInt32 numFolders;
            public UInt32 filenameOfs;
            public UInt32 fileTOCOfs;
            public UInt32 folderTOCOfs;

            // not in the file. used internally by program.
            public UInt32 thisOffset;
        }
        public struct FILE
        {
            public UInt32 filenameOfs;
            public UInt32 size;					// actual size of file in bytes
            public UInt32 sizeInBlocks;			// loading optimization. multiply by 2048 (DVD block size)
            public UInt32 offset;

            // not in the file. used internally by program.
            public UInt32 thisOffset;
            String fileName;
        }

        private Stream inStream;

        public WAC(Stream stream)
        {
            inStream = stream;
        }

        public void Close()
        {

        }

        public FOLDER GetRoot();
        // get an array of folder children from the passed folder or from root if folder == null
        public FOLDER[] GetFolders(FOLDER folder);
        public String GetName(FOLDER folder) { return (GetNameFromOfs(folder.filenameOfs)); }
        public String GetName(FILE file) { return (GetNameFromOfs(file.filenameOfs)); }

        public FILE GetFile(String name);
        // get an array of file children from the passed folder
        public FILE[] GetFiles(FOLDER folder);      

        public void ReplaceFile(String name, byte[] data);


        private String GetNameFromOfs(UInt32 ofs)
        {
            StringBuilder builder = new StringBuilder();
            Int32 c = 0;
            c = inStream.ReadByte();
            while (c != 0)
            {
                builder.Append(c);
                c = inStream.ReadByte();
            }

            return(builder.ToString());
        }

    }
}
