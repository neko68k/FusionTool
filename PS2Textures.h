#define DLLEXPORT __declspec(dllexport)
// Display buffer modes
extern "C"{
DLLEXPORT void writeTexPSMCT32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void readTexPSMCT32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

DLLEXPORT void writeTexPSMCT16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void readTexPSMCT16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

DLLEXPORT void writeTexPSMCT16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void readTexPSMCT16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

// Z Buffer modes
DLLEXPORT void readTexPSMZ32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void writeTexPSMZ32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

DLLEXPORT void readTexPSMZ16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void writeTexPSMZ16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

DLLEXPORT void readTexPSMZ16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void writeTexPSMZ16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

// Texture modes
DLLEXPORT void writeTexPSMT8(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void readTexPSMT8(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

DLLEXPORT void writeTexPSMT4(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
DLLEXPORT void readTexPSMT4(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

}


// Display buffer modes
/*extern "C"{
 void __stdcall writeTexPSMCT32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall readTexPSMCT32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

 void __stdcall writeTexPSMCT16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall readTexPSMCT16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

 void __stdcall  writeTexPSMCT16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall readTexPSMCT16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

// Z Buffer modes
 void __stdcall readTexPSMZ32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall writeTexPSMZ32(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

 void __stdcall readTexPSMZ16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall writeTexPSMZ16(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

 void __stdcall readTexPSMZ16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall writeTexPSMZ16S(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

// Texture modes
 void __stdcall writeTexPSMT8(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall readTexPSMT8(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

 void __stdcall writeTexPSMT4(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);
 void __stdcall readTexPSMT4(int dbp, int dbw, int dsax, int dsay, int rrw, int rrh, void *data);

}*/











