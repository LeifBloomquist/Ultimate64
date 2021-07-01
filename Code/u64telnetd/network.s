
LISTEN_PORT = 64000

network_init
  
  ; 1. Detect and identify Ultimate 64
  jsr identify  ; TODO, check for success
  jsr showdata
  
  ; 2. Open listen socket
  
  ; 3. Get IP address and display with port
  #PRINTSTRING listen_text
  jsr getip
  jsr showip
  
  #PRINTSTRING port_text
    
  rts
  
network_poll

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