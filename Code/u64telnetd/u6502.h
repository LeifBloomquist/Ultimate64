;-------------------------------------
; U6502.H (ULTIMATE LIB INCLUDE FILE)
;-------------------------------------
CTRL_REG = $DF1C ;WRITE
STA_REG  = $DF1C ;READ
CMD_DREG = $DF1D ;WRITE
ID_REG   = $DF1D ;READ
RSP_DREG = $DF1E ;READ
STA_DREG = $DF1F ;READ

DAT_QSIZ = 896
STA_QSIZ = 256

TGT_DOS1 = 1
TGT_DOS2 = 2
TGT_NET  = 3
TGT_CTRL = 4

;STA_REG (READ)
DAT_AVL  = $80
STA_AVL  = $40
STA_BITS = $30
IDLE     = $00
CMD_BUSY = $10
DAT_LAST = $20
DAT_MORE = $30
ERR      = $08
ABRT_PND = $04
DATA_ACC = $02
BUSY_CMD = $01

;CTRL_REG (WRITE)
CLR_ERR  = $08
ABRT     = $04
ACC_DATA = $02
PUSH_CMD = $01

;ÄÏÓ COMMANDS
IDENT    = $01
FOPEN    = $02
FCLOSE   = $03
FREAD    = $04
FWRITE   = $05
FSEEK    = $06
FINFO    = $07
FSTAT    = $08
FDEL     = $09
FREN     = $0A
FCOPY    = $0B
FCD      = $11
FGETPATH = $12
OPENDIR  = $13
READDIR  = $14
CPYUPATH = $15
MKDIR    = $16
CPYHPATH = $17
LOADREU  = $21
SAVEREU  = $22
MNTDSK   = $23
UMNTDSK  = $24
SWAPDSK  = $25
GETTIME  = $26
SETTIME  = $27
EN_DSKA  = $30
DIS_DSKA = $31
EN_DSKB  = $32
DIS_DSKB = $33
DRVA_PWR = $34
DRVB_PWR = $35
ECHO     = $F0

;NETWORK COMMANDS
GETIFCNT = $02
GETIPADR = $05
TCPCONN  = $07
UDPCONN  = $08
SCKCLOSE = $09
SCKREAD  = $10
SCKWRITE = $11
TCPLSTRT = $12
TCPLSTOP = $13
GETLSTAT = $14
GETLSCK  = $15
NOTLISN  = $00
LISENING = $01
CONNECTD = $02
BINDERR  = $03
PORTUSED = $04

;-------------------------------------
; ÐRINT A MESSAGE. ÐASS LO/HI BYTES OF
; MESSAGE ADDRESS AS PARAMETERS.
;-------------------------------------
SHOWMSG  .MACRO
         PHA
         TYA
         PHA
         LDA #\1
         STA $FD
         LDA #\2
         STA $FE
         LDY #0
SHOW     LDA ($FD),Y
         BEQ SHOWN
         JSR $FFD2
         INY
         BNE SHOW
SHOWN    PLA
         TAY
         PLA
         .ENDM
;-------------------------------------

