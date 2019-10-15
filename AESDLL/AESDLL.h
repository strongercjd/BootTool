#pragma once
#include "stdafx.h"

#define AESDLL_EXPORTS

#ifdef AESDLL_EXPORTS
#define AESDLL_API __declspec(dllexport)
#else
#define AESDLL_API __declspec(dllimport)
#endif

/**************************��ʼ������**************************/
extern "C" AESDLL_API void AesEncInit(void);

/**************************���ܺ���**************************/
extern "C" AESDLL_API void AesEncrypt(unsigned char * date);

/**************************���ܺ���**************************/
extern "C" AESDLL_API void AesDecrypt(unsigned char *date);

/**************************������Կ����**************************/
extern "C" AESDLL_API void SetKey(unsigned char *KeyBuffer);


