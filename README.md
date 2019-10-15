# BootTool

使用vs2017打开，BootTool解决方案共3个项目

- AES，C++控制台项目，调用AESDLL项目生成的动态库
- AESDLL，DLL动态库项目，生成动态库
- PCTool，C#项目，调用AESDLL项目生成的动态库，用于加密升级固件的PC上位机软件，读取bin文件，使用AES加密，产生加密后的bin文件，后缀名为REL



解决方案的启动项目是PCTool



运行PCTool项目

- 需要重新编译一下AESDLL项目
- 重新编译PCTool项目
- 快捷键：Ctrl+F5



运行AES的控制台项目

- 重新编译一下AESDLL项目
- 将BootTool\PCTool\bin\Debug文件夹中的AESDLL.dll和AESDLL.lib拷贝进入BootTool\AES文件夹
- 将BootTool\PCTool\bin\Debug文件夹中的AESDLL.dll拷贝进入BootTool\AES\exe
- 重新编译AES的控制台项目
- 将AES设置为启动项目
- 快捷键：Ctrl+F5



