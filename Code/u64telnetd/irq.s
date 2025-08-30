; -------------------------------------------------------------------------
; IRQ Code

RASTER_LINE=50

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

  ; Save original vector
  lda $0314
  sta old_irq+1
  lda $0315
  sta old_irq+2

  ; get address of target routine
  ; put into interrupt vector
  #ldax irqtop
  #stax $0314

  ; Same for output vector  
  #ldax newout
  #stax $0326

  cli                           ; re-enable interrupts
  rts                           ; return to caller

; -------------------------------------------------------------------------
; Main IRQ Code
; -------------------------------------------------------------------------

irqtop 
  ; IRQ code starts here
  inc $d020
  jsr network_poll
  dec $d020
  
  asl $d019   ; acknowledge the interrupt by clearing the VIC's interrupt flag
   
  ; Exit this interrupt and jump to the original vector.
old_irq
  jmp $FFFF
    
; EOF!