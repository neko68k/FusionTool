using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FusionTool
{
    

    unsafe class MUN
    {

        [DllImport(@"SubaSwizzle.dll", EntryPoint="writeTexPSMCT32")]        
        public static extern void writeTexPSMCT32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMCT32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void writeTexPSMCT16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMCT16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void writeTexPSMCT16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMCT16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);

        // Z Buffer modes
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMZ32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void writeTexPSMZ32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMZ16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void writeTexPSMZ16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMZ16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void writeTexPSMZ16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        // Texture modes
        public static extern void writeTexPSMT8(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMT8(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void writeTexPSMT4(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);
        [DllImport(@"SubaSwizzle.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void readTexPSMT4(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void* data);


        UInt32 width;
        UInt32 height;


        public MUN()
        {
            byte[] test = {0};
            
            fixed(void *t = test){
            writeTexPSMT4(0, 0, 0, 0, 128, 128, t);
            }
        }

        
    }
}
