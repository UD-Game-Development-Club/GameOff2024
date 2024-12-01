EXTERNAL callCallback()
VAR code = "26617116"
VAR input = ""
There is a keypad on this safe.
Maybe I should try entering a code...
-> choices
== choices ==
Current code: {input}
+ [Press Number 1]
        ~ input += "1"
        -> choices
+ [Press Number 2]
        ~ input += "2"
        -> choices
+ [Press Number 3]
        ~ input += "3"
        -> choices
+ [Press Number 4]
        ~ input += "4"
        -> choices
+ [Press Number 5]
        ~ input += "5"
        -> choices
+ [Press Number 6]
        ~ input += "6"
        -> choices  
+ [Press Number 7]
        ~ input += "7"
        -> choices
+ [Press Number 8]
        ~ input += "8"
        -> choices
+ [Press Number 9]
        ~ input += "9"
        -> choices
+ [Press Number 0]
        ~ input += "0"
        -> choices
+ [Press Confirm Code]
        -> confirmInput

== confirmInput ==
{ code == input:
    -> correctCode
- else:
    -> incorrectCode
}

== correctCode ==
The safe opens and a key fell out. I wonder if this unlocks that door on the second floor
~ callCallback()
-> END
== incorrectCode ==
Hmmm... seems like that was not the right passcode.
Maybe I can find some hints lying around...
-> END