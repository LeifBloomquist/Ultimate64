  * = $C000

  jsr network_init
  jsr irq_init
  rts
 
  .include "macros.s"
  .include "irq.s"
  .include "network.s"
  
 