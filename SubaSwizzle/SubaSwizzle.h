// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the SUBASWIZZLE_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// SUBASWIZZLE_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef SUBASWIZZLE_EXPORTS
#define SUBASWIZZLE_API __declspec(dllexport)
#else
#define SUBASWIZZLE_API __declspec(dllimport)
#endif

// This class is exported from the SubaSwizzle.dll
class SUBASWIZZLE_API CSubaSwizzle {
public:
	CSubaSwizzle(void);
	// TODO: add your methods here.
};

extern SUBASWIZZLE_API int nSubaSwizzle;

SUBASWIZZLE_API int fnSubaSwizzle(void);
