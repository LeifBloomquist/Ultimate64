# Ultimate64
Experiments and doodads for the Ultimate 64, especially the network interface.

### Ultimate 64 Remote Commander GUI

Remote control your Ultimate 64 over the network!

![Screenshot](https://raw.githubusercontent.com/LeifBloomquist/Ultimate64/master/Screenshots/U64Remote1.png)

### Ultimate 64 Remote Commander CLI

Prefer a command line?  Great for scripting remote development!

```
Usage: u64remote.exe <ip> <command> <parameters>

Command is one of:
   reset
   type <text>
   poke <startaddress> <byte 1> <byte 2> <byte n>
   load <filename>  (start address in file)
   run  <filename>  (loads and runs)
   jump <filename>  (loads and jumps to start address)
```
