using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

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
            public long thisOffset;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
            public String fileName;
        }
        public struct FILE
        {
            public UInt32 filenameOfs;
            public UInt32 size;					// actual size of file in bytes
            public UInt32 sizeInBlocks;			// loading optimization. multiply by 2048 (DVD block size)
            public UInt32 offset;

            // not in the file. used internally by program.
            public long thisOffset;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
            public String fileName;
        }

        private Stream inStream;

        public WAC(Stream stream)
        {
            inStream = stream;
        }

        public void Close()
        {

        }

        public FOLDER GetRoot()
        {
            return GetFolder();
        }

        // get an array of folder children from the passed folder or from root if folder == null
        //public FOLDER[] GetFolders(FOLDER folder);
        public String GetName(FOLDER folder) { return (GetNameFromOfs(folder.filenameOfs)); }
        public String GetName(FILE file) { return (GetNameFromOfs(file.filenameOfs)); }

        //public FILE GetFile(String name);
        // get an array of file children from the passed folder
        //public FILE[] GetFiles(FOLDER folder);      

        //public void ReplaceFile(String name, byte[] data);

        private FOLDER GetFolderFromOfs(UInt32 ofs)
        {
            inStream.Seek(ofs, SeekOrigin.Begin);
            return (GetFolder());
        }

        private FILE GetFileFromOfs(UInt32 ofs)
        {
            inStream.Seek(ofs, SeekOrigin.Begin);
            return (GetFile());
        }

        private FOLDER GetFolder()
        {
            FOLDER folder = new FOLDER();
            byte[] marshalled;
            marshalled = MarshalFolder(folder);
            folder.thisOffset = inStream.Position;
            inStream.Read(marshalled, 0, 0x14);
            folder = UnMarshalFolder(marshalled);
            folder.fileName = GetNameFromOfs(folder.filenameOfs);
            
            return (folder);
        }

        private FILE GetFile()
        {
            FILE file = new FILE();
            byte[] marshalled;
            marshalled = MarshalFile(file);
            file.thisOffset = inStream.Position;
            inStream.Read(marshalled, 0, 0x10);
            file = UnMarshalFile(marshalled);
            file.fileName = GetNameFromOfs(file.filenameOfs);
            return (file);
        }

        private byte[] MarshalFolder(FOLDER str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        private FOLDER UnMarshalFolder(byte[] arr)
        {
            FOLDER str = new FOLDER();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (FOLDER)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        private byte[] MarshalFile(FILE str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        private FILE UnMarshalFile(byte[] arr)
        {
            FILE str = new FILE();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (FILE)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        private String GetNameFromOfs(UInt32 ofs)
        {
            List<byte> list = new List<byte>();
            Byte c = 0;
            c = (Byte)inStream.ReadByte();
            while (c != 0)
            {
                list.Add(c);
                c = (Byte)inStream.ReadByte();
            }

            return(Encoding.ASCII.GetString(list.ToArray()));
        }

    }
}
