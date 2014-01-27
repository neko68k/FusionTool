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
        private struct FOLDER
        {
            UInt32 numFiles;
            UInt32 numFolders;
            UInt32 filenameOfs;
            UInt32 fileTOCOfs;
            UInt32 folderTOCOfs;

        }
        private struct FILE
        {
            UInt32 filenameRelOfs;
            UInt32 size;					// actual size of file in bytes
            UInt32 sizeInBlocks;			// loading optimization. multiply by 2048 (DVD block size)
            UInt32 offset;
        }

        private Stream inStream;

        public WAC(Stream stream)
        {
            inStream = stream;
        }

        public void Close()
        {

        }

        public FOLDER GetFolder(String name);
        public FOLDER[] GetFolders(FOLDER folder);  // get an array of folder children from the passed folder or from root if folder == null

        public FILE GetFile(String name);        
        public FILE[] GetFiles(FOLDER folder);      // get an array of file children from the passed folder

        public void ReplaceFile(String name, byte[] data);

    }
}
