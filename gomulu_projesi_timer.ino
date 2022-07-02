#include <TimerKontrol.h>

const int trigPin = 12, echoPin = 13;
long uzaklik;
long sure;
int YesilLed = 4;
int KirmiziLed = 2;
int SariLed = 3;
int sayac=0;
int buzzer = 3;

TimerKontrol timerayar = TimerKontrol();

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(YesilLed, OUTPUT);
  pinMode(KirmiziLed, OUTPUT);
  pinMode(SariLed, OUTPUT);
  pinMode(buzzer, OUTPUT);
  Serial.begin(9600);
  timerayar.TimerAyarlamasi();
}

ISR(TIMER1_COMPA_vect)
{
  digitalWrite(trigPin, LOW);
  delayMicroseconds(5);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  sure = pulseIn(echoPin, HIGH);
  uzaklik = sure / 2 / 29.1;
  Serial.println(uzaklik);
  digitalWrite(buzzer, HIGH); 
  if (uzaklik > 30)
  {
    digitalWrite(buzzer, LOW);      // Stop sound...
    digitalWrite(KirmiziLed, LOW);
    digitalWrite(SariLed, LOW);
    digitalWrite(YesilLed, HIGH);
  }
  else if (uzaklik > 6 && uzaklik < 30)
  {
    digitalWrite(buzzer, LOW);      // Stop sound...
    digitalWrite(KirmiziLed, LOW);
    digitalWrite(YesilLed, LOW);
    digitalWrite(SariLed, HIGH);
  }
  else
  {
    digitalWrite(YesilLed, LOW);
    digitalWrite(SariLed, LOW);
    digitalWrite(KirmiziLed, HIGH);
    digitalWrite(buzzer, LOW);  ; // Send 1KHz sound signal...
  }
}

void loop() {

}
