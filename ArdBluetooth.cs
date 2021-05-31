#include <SoftwareSerial.h>// import the serial library

#include <LiquidCrystal.h>//import the LCD library


SoftwareSerial testserial(10, 11); // RX, TX

LiquidCrystal lcd(13, 12, 5, 4, 3, 2);// Pins used for RS,E,D4,D5,D6,D7

int BTData; // the data received from the app store here

int a=0,b=0,c=0,d=0,e=0; //used for key press or not 

int ONE=6;    //Digital pin 6 is used to ON relay 1

int TWO=7;    //Digital pin 7 is used to ON relay 2

int THREE=8;   //Digital pin 8 is used to ON relay 3

int FOUR=9;  //Digital pin 9 is used to ON relay 4

void setup() {

  // Setup code to initialize all the user and predefined functions

  testserial.begin(9600); //Software serial initialization

  lcd.begin(16,2);//LCD 16x2 initialization

  pinMode(ONE, OUTPUT);// Set pim 6 as OUTPUT

  pinMode(TWO, OUTPUT);// Set pim 7 as OUTPUT

  pinMode(THREE, OUTPUT); // Set pim 8 as OUTPUT

  pinMode(FOUR, OUTPUT); // Set pim 9 as OUTPUT

  lcd.setCursor(0,0); //Initially set the cursor position of LCD to 1st Columb 1st row.

  lcd.print("Home Automation");//After initialising print data

  lcd.setCursor(0,1); //Initially set the cursor position of LCD to 1st Columb 2nd row.

   lcd.print("               ");  //print blank to clear all the data on LCD

   delay(3000);

   lcd.setCursor(0,0);

   lcd.print(" BlueTooth Home ");

   lcd.setCursor(0,1);

   lcd.print("   Automation   ");  

   delay(3000);

   lcd.setCursor(0,0);

   lcd.print("D1:OFF    D2:OFF"); //Initially dispaly all are OFF 

   lcd.setCursor(0,1);

   lcd.print("D3:OFF    D4:OFF");//Initially dispaly all are OFF 

}



void loop() {

  

   if (testserial.available())  // wait for the data to be available at the receiver buffer.

       {

        BTData=testserial.read(); // Read the data and store it in the variable.

       //testserial.write(BTData); // Displaying in the serial monitor.

       if(BTData=='1' && a==0){   // Checking the received number if found with the given condition

       a=1;                       // "a" variable used to checked if button is pressed or not.

       digitalWrite(ONE,1);       //if pressed send HIGH value to the pin number 6

       lcd.setCursor(3,0);        

       lcd.print("ON ");          //Display ON in the location 1st ROW and 3rd COLOUMB

       }

      else if (BTData=='1' && a==1)

          {

          a=0;

          digitalWrite(ONE,0);

          lcd.setCursor(3,0);

          lcd.print("OFF");

          }

      else if (BTData=='2' && b==0)

            {

            b=1;

            digitalWrite(TWO,1);

            lcd.setCursor(13,0);

            lcd.print("ON ");

            }

      else if (BTData=='2' && b==1)

          {

          b=0;

          digitalWrite(TWO,0);

           lcd.setCursor(13,0);

            lcd.print("OFF ");

          }

      else if(BTData=='3' && c==0){   

       c=1;

       digitalWrite(THREE,1);

       lcd.setCursor(3,1);

       lcd.print("ON ");

       }

      else if (BTData=='3' && c==1)

          {

          c=0;

          digitalWrite(THREE,0);

           lcd.setCursor(3,1);

       lcd.print("OFF ");

          }

      else if (BTData=='4' && d==0)

            {

            d=1;

            digitalWrite(FOUR,1);

             lcd.setCursor(13,1);

            lcd.print("ON ");

            }

      else if (BTData=='4' && d==1)

          {// if number 0 pressed ....

          d=0;

          digitalWrite(FOUR,0);

           lcd.setCursor(13,1);

            lcd.print("OFF ");

          }