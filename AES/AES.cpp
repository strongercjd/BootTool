// AES.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <iostream>
#include "AESDLL.h"
using namespace std;
int main()
{
	int num = 0;
	unsigned char data[16] = { 0X00,0X11,0X22,0X33,0X44,0X55,0X66,0X77,0X88,0X99,0XAA,0XBB,0XCC,0XDD,0XEE,0XFF };
	cout << "�����ǣ�" << endl;
	for (num = 0; num < 16;num++) {
		cout << hex << (int)data[num] << ' ';
	}
	AesEncInit();
	AesEncrypt(data);
	cout << endl << "����֮�������ǣ�" << endl;
	for (num = 0; num < 16; num++) {
		cout << hex << (int)data[num] << ' ';
	}
	AesDecrypt(data);
	cout << endl << "����֮�������ǣ�" << endl;
	for (num = 0; num < 16; num++) {
		cout << hex << (int)data[num] << ' ';
	}
	while (1);

    return 0;
}

