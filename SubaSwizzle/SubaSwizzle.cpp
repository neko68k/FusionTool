// SubaSwizzle.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "SubaSwizzle.h"


// This is an example of an exported variable
SUBASWIZZLE_API int nSubaSwizzle=0;

// This is an example of an exported function.
SUBASWIZZLE_API int fnSubaSwizzle(void)
{
	return 42;
}

// This is the constructor of a class that has been exported.
// see SubaSwizzle.h for the class definition
CSubaSwizzle::CSubaSwizzle()
{
	return;
}
