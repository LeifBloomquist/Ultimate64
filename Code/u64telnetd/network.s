
LISTEN_PORT=64000

network_init
  
  ; 1. Detect and identify Ultimate 64
  jsr identify  ; TODO, check for success
  jsr showdata
  
  ; 2. Open listen socket
  
  ; TESTING - connect to an IP instead
         #POKEWORD $fd, server_address

         lda #tcpconn
         #ldxy LISTEN_PORT
         jsr connect
         sta socket
         lda #<msgconn
         sta $fb
         lda #>msgconn
         sta $fc
         clc
         jsr show
         jsr showstat
         ldy #0       ;error code?
         lda ($fb),y
         cmp #"0"
         bne bail
         iny
         lda ($fb),y
         cmp #"0"
         beq connok
bail     jmp network_init_x

connok
  
  
  ;jsr connect
  
  ; Check success
  
printip  
  ; 3. Get IP address and display with port
  #PRINTSTRING listen_text
  jsr getip
  jsr showip
  
  #PRINTSTRING port_text
  #PRINTWORD LISTEN_PORT
  
  #PRINTSTRING cr
  
network_init_x
  rts
  
  
; -----------------------------------------------
; Poll network - called from IRQ
; -----------------------------------------------

network_poll

  ; TESTING - send data
  
  lda #1
         sta buffer ;length
         lda #65
         sta buffer+1
         #POKEWORD $fd, buffer

         lda socket
         jsr sockwr
		 
         #POKEWORD $fb, msgsckwr
         
         clc
         ;jsr show
         ;jsr showstat
  


  ; 1. Poll for data
  ; 2. Check for disconnect
  rts

; -----------------------------------------------
; Subroutines
; -----------------------------------------------

showdata
    #PRINTSTRING data
    #PRINTSTRING cr
    rts

showip
	ldy #3

getbin	
    lda data,y
	sta binip,y
	dey
	bpl getbin
    jsr bindot
	
	ldy #$00
showip2  
	lda ipaddr,y
    beq ipshown
    jsr $ffd2
    iny
    bne showip2
ipshown
	rts
	
; -----------------------------------------------
; Strings
; -----------------------------------------------

listen_text
    .null "listening on "
	
port_text
	.null " port "
	
; -----------------------------------------------
; Includes
; -----------------------------------------------

  .include "u6502lib.s"
  
  
  
  
  
  
  ;--------------------------------------

msgident .text "identify: "
         .byte 0
msggetip .text "getip: "
         .byte 0
msgconn  .text "tcpconn: "
         .byte 0
msgsckwr .text "sockwr: "
         .byte 0
msgsckrd .byte $0d
         .text "sockrd: "
         .byte 0
msgsckcl .text "sockcls: "
         .byte 0
server_address
		 .null "192.168.7.51"
socket   .byte 0


;--------------------------------------
; showstat (show status area)
;--------------------------------------
showstat lda stataddr
         sta $fb
         lda stataddr+1
         sta $fc
         sec     ;print CR
         jmp show
;--------------------------------------
; show string at ($fb)
; pass: carry set to print CR
;--------------------------------------
show
         .block
         php
         ldy #0
show1    lda ($fb),y
         beq show2
         jsr $ffd2
         iny
         bne show1
         inc $fc
         bne show1
show2    plp
         bcc shown
         lda #$0d
         jsr $ffd2
shown    rts
         .bend
