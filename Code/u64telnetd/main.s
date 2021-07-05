
  .include "macros.s"

  * = $C000

  #PRINTSTRING start_text

  jsr network_init
  bcc exit   ; Error  
  jsr irq_init
  
exit
  rts
    
; -----------------------------------------------
; Strings
; -----------------------------------------------

start_text
    .byte 13
    .text "ultimate 64 telnet daemon"
cr
    .byte 13,0

; -----------------------------------------------
; Includes
; -----------------------------------------------

  .include "irq.s"
  .include "network.s"
