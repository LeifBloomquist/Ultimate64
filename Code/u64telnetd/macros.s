ldax   .macro    ;start macro def
       lda #<\1  ; low byte
	   ldx #>\1  ; high byte
       .endm     ;end macro def
	  
stax   .macro    ;start macro def
       sta  \1   ; low byte
	   stx  \1+1 ; high byte
       .endm     ;end macro def
	   
	  
	  
; ==============================================================
; Macro to print a string
; ==============================================================

PRINTSTRING .macro
  ldy #>\1
  lda #<\1
  jsr $ab1e ; STROUT 	
.endm