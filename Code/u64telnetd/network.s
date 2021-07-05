
LISTEN_PORT=64000

bufptr = $c6  ; Characters in keyboard buffer

; -----------------------------------------------
; Initialize and check network.
; Returns carry set on success, clear on failure.
; -----------------------------------------------

network_init
    ; 1. Detect and identify Ultimate 64
    jsr identify  ; TODO, check for success
    jsr showdata

    ; TESTING - connect to an IP instead, since TCP Listen not yet implemented in U64 firmware...
    #POKEWORD $fd, server_address

    lda #tcpconn
    #ldxy LISTEN_PORT
    jsr connect
    sta socket
    jsr showstat
    ldy #0       ;error code?
    lda ($fb),y
    cmp #"0"
    bne bail
    iny
    lda ($fb),y
    cmp #"0"
    beq connok
bail     
    clc
    jmp network_init_x


connok
  
printip  
  ; 3. Get IP address and display with port
  #PRINTSTRING listen_text
  jsr getip
  jsr showip
  
  #PRINTSTRING port_text
  #PRINTWORD LISTEN_PORT  
  #PRINTSTRING cr
  sec
  
network_init_x
  rts
  
  
; -----------------------------------------------
; Poll network - called from IRQ
; -----------------------------------------------

network_poll

    lda send_in_progress
    bne network_poll_x

    ; 1. Check connection state

    ; 2. Poll for data
readit   
    lda socket
    ldx #1  ; For now, a single character at a time.  Can be up to 254
    ldy #0
    clc  ;sec        ;wait for data
    jsr sockrd         
         
    ; Check for 0 (connection closed)
    lda data
    bne still_connected
    lda data+1
    bne still_connected

    lda #$00
    sta connected
    
    lda #$02 ; !!!!
    sta $d021

still_connected
    
    ; -1 indicates no data
    lda data
    cmp #$ff
    beq network_poll_x

    ; For now, a single character at a time.
    ldy data+2 ; Received byte - Ready into Y for lookup table
    lda asc2pet,y
    
    ldx bufptr
    sta $0277,x
    inc bufptr
             
network_poll_x  
  rts


; -------------------------------------------------------------------------
; Output Code
; This is the new output routine that sends to network and screen.
; The vector at $0326 points here.
; -------------------------------------------------------------------------

newout
    sta asave
    txa  ;save x & y!!
    pha
    tya
    pha

    lda asave
    jsr $e716 ; chrout for screen
    
     ; TODO - check connection

    inc send_in_progress

    #POKEWORD $fd, buffer
    lda socket
    jsr sockwr

    dec send_in_progress    

    pla
    tay
    pla
    tax
    lda asave 

    rts 
       
buffer   
    .byte $01   ; Only 1 character at a time
asave
    .byte $00
  
temp_border
   .byte 0

send_in_progress
    .byte $00

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
; Flags and Variables
; -----------------------------------------------

connected
    .byte 0

server_address
    .null "192.168.7.51"
         
socket
   .byte 0

save_border
    .byte 0    

; -----------------------------------------------
; Includes
; -----------------------------------------------

  .include "u6502lib.s"
 
; -----------------------------------------------
; ASCII to PETSCII lookup table
; ----------------------------------------------- 
asc2pet
    .byte $00,$01,$02,$03,$04,$05,$06,$07,$14,$09,$0d,$0b,$0c,$0d,$0e,$0f
    .byte $10,$0b,$12,$13,$08,$15,$16,$17,$18,$19,$1a,$1b,$1c,$1d,$1e,$1f
    .byte $20,$21,$22,$23,$24,$25,$26,$27,$28,$29,$2a,$2b,$2c,$2d,$2e,$2f
    .byte $30,$31,$32,$33,$34,$35,$36,$37,$38,$39,$3a,$3b,$3c,$3d,$3e,$3f
    .byte $40,$c1,$c2,$c3,$c4,$c5,$c6,$c7,$c8,$c9,$ca,$cb,$cc,$cd,$ce,$cf
    .byte $d0,$d1,$d2,$d3,$d4,$d5,$d6,$d7,$d8,$d9,$da,$5b,$5c,$5d,$5e,$5f
    .byte $c0,$41,$42,$43,$44,$45,$46,$47,$48,$49,$4a,$4b,$4c,$4d,$4e,$4f
    .byte $50,$51,$52,$53,$54,$55,$56,$57,$58,$59,$5a,$db,$dc,$dd,$de,$14
    .byte $80,$81,$82,$83,$84,$85,$86,$87,$88,$89,$8a,$8b,$8c,$8d,$8e,$8f
    .byte $90,$91,$92,$0c,$94,$95,$96,$97,$98,$99,$9a,$9b,$9c,$9d,$9e,$9f
    .byte $a0,$a1,$a2,$a3,$a4,$a5,$a6,$a7,$a8,$a9,$aa,$ab,$ac,$ad,$ae,$af
    .byte $b0,$b1,$b2,$b3,$b4,$b5,$b6,$b7,$b8,$b9,$ba,$bb,$bc,$bd,$be,$bf
    .byte $c0,$c1,$c2,$c3,$c4,$c5,$c6,$c7,$c8,$c9,$ca,$cb,$cc,$cd,$ce,$cf
    .byte $d0,$d1,$d2,$d3,$d4,$d5,$d6,$d7,$d8,$d9,$da,$db,$dc,$dd,$de,$df
    .byte $e0,$e1,$e2,$e3,$e4,$e5,$e6,$e7,$e8,$e9,$ea,$eb,$ec,$ed,$ee,$ef
    .byte $f0,$f1,$f2,$f3,$f4,$f5,$f6,$f7,$f8,$f9,$fa,$fb,$fc,$fd,$fe,$ff

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
