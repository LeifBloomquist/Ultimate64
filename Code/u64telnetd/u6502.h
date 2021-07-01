;-------------------------------------
; u6502.h (ultimate lib include file)
;-------------------------------------
ctrl_reg = $df1c ;write
sta_reg  = $df1c ;read
cmd_dreg = $df1d ;write
id_reg   = $df1d ;read
rsp_dreg = $df1e ;read
sta_dreg = $df1f ;read

dat_qsiz = 896
sta_qsiz = 256

tgt_dos1 = 1
tgt_dos2 = 2
tgt_net  = 3
tgt_ctrl = 4

;sta_reg (read)
dat_avl  = $80
sta_avl  = $40
sta_bits = $30
idle     = $00
cmd_busy = $10
dat_last = $20
dat_more = $30
err      = $08
abrt_pnd = $04
data_acc = $02
busy_cmd = $01

;ctrl_reg (write)
clr_err  = $08
abrt     = $04
acc_data = $02
push_cmd = $01

;DOS commands
ident    = $01
fopen    = $02
fclose   = $03
fread    = $04
fwrite   = $05
fseek    = $06
finfo    = $07
fstat    = $08
fdel     = $09
fren     = $0a
fcopy    = $0b
fcd      = $11
fgetpath = $12
opendir  = $13
readdir  = $14
cpyupath = $15
mkdir    = $16
cpyhpath = $17
loadreu  = $21
savereu  = $22
mntdsk   = $23
umntdsk  = $24
swapdsk  = $25
gettime  = $26
settime  = $27
en_dska  = $30
dis_dska = $31
en_dskb  = $32
dis_dskb = $33
drva_pwr = $34
drvb_pwr = $35
echo     = $f0

;network commands
getifcnt = $02
getipadr = $05
tcpconn  = $07
udpconn  = $08
sckclose = $09
sckread  = $10
sckwrite = $11
tcplstrt = $12
tcplstop = $13
getlstat = $14
getlsck  = $15
notlisn  = $00
lisening = $01
connectd = $02
binderr  = $03
portused = $04

;-------------------------------------
; Print a message. Pass lo/hi bytes of
; message address as parameters.
;-------------------------------------
showmsg  .macro
         pha
         tya
         pha
         lda #\1
         sta $fd
         lda #\2
         sta $fe
         ldy #0
show     lda ($fd),y
         beq shown
         jsr $ffd2
         iny
         bne show
shown    pla
         tay
         pla
         .endm
;-------------------------------------

