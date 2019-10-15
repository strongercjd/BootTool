#pragma once
#include "stdafx.h"

#define AESDLL_EXPORTS

#ifdef AESDLL_EXPORTS
#define AESDLL_API __declspec(dllexport)
#else
#define AESDLL_API __declspec(dllimport)
#endif

/**************************初始化函数**************************/
extern "C" AESDLL_API void AesEncInit(void);

/**************************加密函数**************************/
extern "C" AESDLL_API void AesEncrypt(unsigned char * date);

/**************************解密函数**************************/
extern "C" AESDLL_API void AesDecrypt(unsigned char *date);

/**************************设置秘钥函数**************************/
extern "C" AESDLL_API void SetKey(unsigned char *KeyBuffer);


