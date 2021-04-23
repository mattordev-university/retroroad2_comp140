// Simple sketch for testing potentiometers. Change pin value to match your wiring.

int steeringPot = A0;
int buttonAPin = 2;
int buttonBPin = 3;
int buttonCPin = 4;
int buttonDPin = 5;


void setup() 
{
  Serial.begin(9600);
  // Ability button pinMode setup
  pinMode(buttonAPin, INPUT_PULLUP);
  pinMode(buttonBPin, INPUT_PULLUP);
  pinMode(buttonCPin, INPUT_PULLUP);
  pinMode(buttonDPin, INPUT_PULLUP);
}

void loop() 
{
  int steeringPotValue = analogRead(steeringPot);
  int steeringPot8bit = map (steeringPotValue, 0, 1023, 0, 255);
  
  //Serial.print(steeringPotValue);
  //Serial.print(" >>>>> ");
  //Serial.println(steeringPot8bit);
  delay(10);

  if (digitalRead(buttonAPin) == LOW)
  {
    // Do ability
    Serial.println("it works a");
  }
  if (digitalRead(buttonBPin) == LOW)
  {
    // Do ability
    Serial.println("it works b");
  }
  if (digitalRead(buttonCPin) == LOW)
  {
    // Do ability
    Serial.println("it works c");
  }
  if (digitalRead(buttonDPin) == LOW)
  {
    // Do ability
    Serial.println("it works d");
  }
    
}
