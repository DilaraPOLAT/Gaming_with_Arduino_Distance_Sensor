#include "TimerKontrol.h"
#include "Arduino.h"


TimerKontrol::TimerKontrol()
{
    
}

void TimerKontrol::TimerAyarlamasi()
{
  cli();

  TCCR1A = 0;
  TCCR1B = 0;
  TCNT1 = 0;

  OCR1A = 15624; // (16.000.000 / (1*1024)) - 1 ---> burada 1 sn oluyor.

  TCCR1B |= (1 << WGM12);
  TCCR1B |= (1 << CS12) | (1 << CS10);
  TIMSK1 |= (1 << OCIE1A);

  sei();
}