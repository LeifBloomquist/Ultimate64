ldax   .macro    ;start macro def
       lda #<\1  ; low byte
	   ldx #>\1  ; high byte
       .endm     ;end macro def
	  
stax   .macro    ;start macro def
       sta  \1   ; low byte
	   stx  \1+1 ; high byte
       .endm     ;end macro def

ldxy   .macro    ;start macro def
       ldx #<\1  ; low byte
	   ldy #>\1  ; high byte
       .endm     ;end macro def
	  
; ==============================================================
; Macro to print a string
; ==============================================================

PRINTSTRING .macro
  ldy #>\1
  lda #<\1
  jsr $ab1e ; STROUT 	
.endm

; ==============================================================
; Macro to print a word
; ==============================================================

PRINTWORD .macro
  lda #>\1
  ldx #<\1
  jsr $bdcd ; LINPRT 	
.endm

; ==============================================================
; Macro to poke a word
; ==============================================================

POKEWORD .macro
  lda #<\2
  sta \1
  lda #>\2
  sta \1+1
.endm