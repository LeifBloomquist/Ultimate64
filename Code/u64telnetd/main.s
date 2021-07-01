
  .include "macros.s"

  * = $C000

  #PRINTSTRING start_text

  jsr network_init
  jsr irq_init
  rts
    
; -----------------------------------------------
; Strings
; -----------------------------------------------

start_text
    .byte 13
    .text "ultimate 64 telnet daemon"
cr
    .byte 13,0

crcr
  .byte 13,13,0

; -----------------------------------------------
; Includes
; -----------------------------------------------

  .include "irq.s"
  .include "network.s"
