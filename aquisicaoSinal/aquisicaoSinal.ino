#include "Timer.h"

Timer t;

#define pot A0


//const byte dado;
bool flag = false;

const byte ST = 0x24;
const byte ET = 0x0A;
const byte C1 = 0x45;




void setup()
{
  Serial.begin(115200);    //configura comunicação serial com 9600 bps
  analogReadResolution(12);
  t.every(1, takeReading);      
}


void loop() 
{
  if(flag)
  {
     t.update();
  }

  if(Serial.available())
  {
    byte start = Serial.read();
    if(start == 'e')
    {
      flag = true;
    }
     if(start == 's')
    {
      flag = false;
    }
  }
}
void takeReading()
{
  uint16_t canal1 = analogRead(pot);

  //Padrão MSB First: O primeiro byte sempre corresponde ao byte mais significativo
  
  Serial.write(ST); //Start 
  Serial.write(C1); //identificador da informaçao
  Serial.write(canal1>>8); //MSB
  Serial.write(canal1&0xFF); //LSB
  Serial.write(ET); //End


}

