;--------------------------------------
; u6502lib.s (Ultimate 64 library)
;--------------------------------------
      
         .include "u6502.h"
debug    = 0
;--------------------------------------
; jump table
;--------------------------------------
identify jmp j_ident
getip    jmp j_getip
connect  jmp j_conn
listen   jmp j_listen
sockwr   jmp j_sockwr
sockrd   jmp j_sockrd
sockcls  jmp j_sockcl
readdata jmp j_rddat
readstat jmp j_rdsta
accept   jmp j_accept
sendcmd  jmp j_sndcmd
showsr   jmp j_shwsr
dataddr  .byte <data,>data
stataddr .byte <status,>status

;--------------------------------------
; identify Ultimate device
; return: data, status populated
;--------------------------------------
j_ident
         .block
         ldx #<cmdid
         ldy #>cmdid
         jsr sendcmd
         jsr readdata
         jsr readstat
         jsr accept
         rts
         .bend

;--------------------------------------
; getip (get Ultimate's IP address)
; return: data, binary IP (4 bytes)
;--------------------------------------
j_getip
         .block
         ldx #<cmdgetip
         ldy #>cmdgetip
         jsr sendcmd
         jsr readdata
         jsr readstat
         jsr accept
         rts
         .bend

;--------------------------------------
; connect (connect to host)
; pass: $fd address of hostname
;       .A tcpconn/udpconn
;       .X/.Y port number
; return: socket no. in .A
;--------------------------------------
j_conn
         .block
         sta conntype
         stx connport
         sty connport+1
         ldy #0
cnthost  lda ($fd),y
         beq hostdone
         sta hostname,y
         iny
         bne cnthost
hostdone iny  ;target
         iny  ;conntype
         iny  ;port
         iny
         sty cmdconn ;no. bytes in cmd
         ldx #<cmdconn
         ldy #>cmdconn
         jsr sendcmd
         jsr readdata
         jsr readstat
         jsr accept
         lda data ;socket no.
         rts
         .bend

;--------------------------------------
; listen (listen for connection - TCP only)
; pass: .X/.Y port number
; return: socket no. in .A
;--------------------------------------
j_listen
         .block
         stx listport
         sty listport+1

         ldx #<cmdlist
         ldy #>cmdlist
         jsr sendcmd
         jsr readdata
         jsr readstat
         jsr accept
         ;lda data ;socket no.
         rts
         .bend


;--------------------------------------
; sockwr (write to open socket)
; pass: .A socket
;       $fd address of data buffer
;       (first byte is number of bytes,
;       max. 254)
;--------------------------------------
j_sockwr
         .block
         sta cmdsckwr+3 ;socket
         ldx #<cmdsckwr
         ldy #>cmdsckwr
         jsr sendcmd
         jsr readdata
         jsr readstat
         jsr accept
         rts
         .bend

;--------------------------------------
; sockrd (read from open socket)
; pass:   .A socket
;         .X/.Y length of data to read
;         carry set: wait for data
; return: data, bytes read
;         (first two bytes are length)
;--------------------------------------
j_sockrd
         .block
         php
         sta cmdsckrd+3
         stx cmdsckrd+4
         sty cmdsckrd+5
         ldx #<cmdsckrd
         ldy #>cmdsckrd
         jsr sendcmd
         plp
         jsr readdata
         jsr readstat
         jsr accept
         rts
         .bend

;--------------------------------------
; sockcls (close socket)
; pass: .A socket
;--------------------------------------
j_sockcl
         .block
         sta cmdsckcl+3
         ldx #<cmdsckcl
         ldy #>cmdsckcl
         jsr sendcmd
         jsr readdata
         jsr readstat
         jsr accept
         rts
         .bend

;--------------------------------------
; readdata (populates data buffer)
; pass: carry set to wait for data
; return: count, no. bytes read
;--------------------------------------
j_rddat
         .block
         lda #0
         sta count
         sta count+1
         ldx #<data
         ldy #>data
         stx $fb
         sty $fc
         ldy #0
         bcc readsr
wait     lda sta_reg
         and #dat_avl
         beq wait
readsr   lda sta_reg
         and #dat_avl
         beq srdone
         .if debug
         #showmsg <dbgrdat1,>dbgrdat1
         .endif
         lda rsp_dreg
         sta ($fb),y
         iny
         bne readsr
         inc $fc
         inc count+1
         bne readsr
srdone   lda #0
         sta ($fb),y
         sty count
         rts
         .bend

;--------------------------------------
; readstat (populates status buffer)
; pass: carry clear to wait for status
; return: count, no. bytes read
;--------------------------------------
j_rdsta
         .block
         lda #0
         sta count
         sta count+1
         ldx #<status
         ldy #>status
         stx $fb
         sty $fc
         ldy #0
         bcc readst
wait     lda sta_reg
         and #sta_avl
         beq wait
readst   lda sta_reg
         and #sta_avl
         beq stdone
         .if debug
         #showmsg <dbgrsta1,>dbgrsta1
         .endif
         lda sta_dreg
         sta ($fb),y
         iny
         bne readst
         inc $fc
         inc count+1
         bne readst
stdone   lda #0
         sta ($fb),y
         sty count
         rts
         .bend

;--------------------------------------
; accept (signal acceptance of data)
;--------------------------------------
j_accept
         .block
         lda ctrl_reg
         ora #acc_data
         sta ctrl_reg
readsr   lda sta_reg
         and #data_acc
         beq readsr
         rts
         .bend

;--------------------------------------
; sendcmd (send command to Ultimate)
;--------------------------------------
; pass: .X/.Y address of command
;       (first byte is number of bytes)
; if writing to socket:
;       $fd address of data buffer
;       (first byte is number of bytes,
;       max. 254)
; return: carry clear on success,
;         set otherwise
;--------------------------------------
j_sndcmd
         .block
readsr
         .if debug
         jsr showsr
         .endif
         lda sta_reg
         and #sta_bits
         bne readsr
         stx $fb
         sty $fc
         ldy #0
         lda ($fb),y
         tax ;number of bytes to send
wrcmd    iny
         lda ($fb),y
         sta cmd_dreg
         dex
         bne wrcmd
         ldy #2
         lda ($fb),y ;command
         cmp #sckwrite
         bne cmddone
         ldy #0
         lda ($fd),y ;no. bytes to send
         tax
         iny
snddata  lda ($fd),y ;write socket data
         sta cmd_dreg
         dex
         beq cmddone
         iny
         bne snddata
cmddone  lda #push_cmd
         sta ctrl_reg
         lda sta_reg ;error check
         and #err
         beq snddone
         lda #clr_err
         ora ctrl_reg
         sta ctrl_reg
         sec
         rts
snddone  lda sta_reg
         and #dat_last
         beq snddone
         lda sta_reg
         and #cmd_busy
         bne snddone
         clc
         rts
         .bend

;--------------------------------------
; showsr (show status register)
;        .A,.X,.Y preserved
;--------------------------------------
j_shwsr
         .block
         pha
         txa
         pha
         tya
         pha
         lda sta_reg
         ldx #1
         ldy #0
andstats pha
         and stats,y
         beq clear
         lda #"1"
         .byte $2c
clear    lda #"0"
         sta statmsg2,x
nextbit  inx
         inx
         inx
         inx
         iny
         cpx #9 ;state
         bne ckdone
         iny    ;one extra
         bne nextbit ;bypass for now
ckdone   cpy #8
         beq dostate
         pla
         clv
         bvc andstats
dostate  pla
         and #sta_bits
         lsr a
         lsr a
         lsr a
         lsr a
         tay   ;in case it's zero
         beq fill
         tax   ;no. times to mult. by 3
         tay
by3      dey
         iny
         iny
         iny
         dex
         bne by3
fill     ldx #8  ;state
mvstate  lda states,y
         sta statmsg2,x
         inx
         iny
         cpx #11
         bne mvstate

         ldy #0
msg1     lda statmsg1,y
         beq done1
         jsr $ffd2
         iny
         bne msg1
done1    ldy #0
msg2     lda statmsg2,y
         beq done2
         jsr $ffd2
         iny
         bne msg2
done2    pla
         tay
         pla
         tax
         pla
         rts
         .bend

;--------------------------------------
; Convert binary IP to dotted quad.
; (internal use only)
; pass: binary IP at binip
; return: dotted quad at ipaddr
;--------------------------------------
bindot
         .block
         ldx #0
         ldy #0
l10      lda binip,x
         jsr byte2asc
         txa
         pha
         ldx #0
l20      lda ascnum,x
         beq l30
         sta ipaddr,y
         inx
         iny
         bne l20
l30      pla
         tax
         inx
         cpx #4
         beq l40
         lda #"."
         sta ipaddr,y
         iny
         bne l10
l40      lda #0
         sta ipaddr,y
         rts
         .bend
;--------------------------------------
; Binary byte to decimal string.
; (internal use only)
; pass: byte in .A
; return: decimal string at ascnum
;         (.Y preserved)
;--------------------------------------
byte2asc
         .block
         sta hold
         tya
         pha
         ldy #0
         sty accum
         lda #100
         sta const
l10      lda hold
l20      cmp const
         bcc l30
         sec
         sbc const
         sta hold
         inc accum
         bne l20
l30      lda accum
         bne l35
         cpy #0 ;no leading zeros
         beq l37
l35      ora #$30
         sta ascnum,y
         iny
         lda #0
         sta accum
l37      lda const
         cmp #10
         beq l40 ;to one's place
         lda #10
         sta const
         bne l10 ;to ten's place
l40      lda hold
         ora #$30
         sta ascnum,y
         iny
         lda #0
         sta ascnum,y
         pla
         tay
         rts
         .bend

;--------------------------------------

cmdid    .byte $02,tgt_dos1,ident
cmdgetip .byte $03,tgt_net,getipadr,0

cmdconn  .byte 0,tgt_net
conntype .byte 0 ;TCP or UDP
connport .word 0
hostname .repeat 128,$00 ;*= *+128

cmdlist  .byte 4,tgt_net 
listtype .byte tcplstrt ;TCP only right now
listport .word 0

cmdsckwr .byte 3,tgt_net,sckwrite,0
cmdsckrd .byte 5,tgt_net,sckread,0,0,0
cmdsckcl .byte 3,tgt_net,sckclose,0

count    .word 0
stats    .byte dat_avl,sta_avl,0,0,err
         .byte abrt_pnd,data_acc
         .byte busy_cmd
states   .text "idlcbylstmor"
statmsg1 .text "dav sav sta err abt "
         .text "acc bsy"
         .byte $0d,0
statmsg2 .text "                    "
         .text "       "
         .byte $0d,0
dbgrdat1 .text "readdata: "
         .text "data available"
         .byte $0d,0
dbgrsta1 .text "readstat: "
         .text "status available"
         .byte $0d,0
data     .repeat dat_qsiz*2,0  ; *= *+(dat_qsiz*2)
status   .repeat sta_qsiz,0    ; *= *+sta_qsiz
hold     .byte 0
accum    .byte 0
const    .byte 0
binip    .byte 0,0,0,0
ascnum   .byte 0,0,0,0
ipaddr   .repeat 16,0
