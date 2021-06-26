; -------------------------------------------------------------------------
; IRQ Code

RASTER_LINE=49

; -------------------------------------------------------------------------
; IRQ Initialization

irq_init
  sei                           ; disable interrupts

  lda #$7f                      ; turn off the cia interrupts
  sta $dc0d

  lda $d01a                     ; enable raster irq
  ora #$01
  sta $d01a

  lda $d011                     ; clear high bit of raster line
  and #$7f
  sta $d011

  lda #RASTER_LINE              ; line number to go off at
  sta $d012                     ; low byte of raster line

  ; get address of target routine
  ; put into interrupt vector
  #ldax irqtop
  #stax $0314

  cli                           ; re-enable interrupts
  rts                           ; return to caller

; -------------------------------------------------------------------------
; Main IRQ Code

irqtop 
  ; IRQ code starts here
  inc $d020
  jsr network_poll
  dec $d020
  
  asl $d019   ; acknowledge the interrupt by clearing the VIC's interrupt flag
 
  
  ; Exit this interrupt. 
  jmp $ea31          ; Exit to ROM.  Alternately, use below if we don't need ROM routines. 
  ;pla                 ; we exit interrupt entirely.
  ;tay                           
  ;pla                           
  ;tax                          
  ;pla      
  ;rti
    
; EOF!