@cls
@set exename=u64telnetd.prg
del %exename%
tmpx -i main.s -o %exename%
..\..\Executable\u64remote.exe 192.168.7.64 load %exename%