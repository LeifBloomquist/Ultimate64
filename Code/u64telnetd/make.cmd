@cls
@set exename=u64telnetd.prg
del %exename%
tmpx -i main.s -o %exename%

@echo off

choice /c yn /n /m "Run on Ultimate64 Yes, No?"
if %ERRORLEVEL% == 2 exit /b

..\..\Executable\u64remote.exe 192.168.7.64 load %exename%
..\..\Executable\u64remote.exe 192.168.7.64 reset
..\..\Executable\u64remote.exe 192.168.7.64 type sys49152