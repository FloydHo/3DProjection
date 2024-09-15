# 3DProjection

<div id="header" align="center">
  <img src="https://media.giphy.com/media/M9gbBd9nbDrOTu1Mqx/giphy.gif" width="100"/>
</div>

Übertragene Notizen die ursprünglich Handschriftlich gemacht wurden sind (Skizzen fehlen deshalb):


Wie speicher ich die Koordinaten am besten?
Würfel = 6 Flächen a 4 Koordinaten
Struct oder Arrays?

Alles als float da ganze reelle Zahlen ,je nachdem was ich in der Zukunft noch vorhabe, ungenau sind.

//Ich habe mich am Ende für Structs entschieden, da ich es bequemer fand direkt '.x' nehmen zu können anstatt .[0] ect.
//Ausserdem wollte ich auch mit Structs arbeiten.

Wie?

ProjektionsMatrix: Eine Matrix die einen Punkt im 3D-Raum auf einen Punkt im 2D-Raum projiziert.

--     --      3D       2D
| 1 0 0 |      x        x
| 0 1 0 |  X   y    =   y
| 0 0 1 |      z        0
--     --

Matrix Vector Multiplikation => eigene Methode

| a11 * x + a12 * y + a13 * z | 
| a21 * x + a22 * y + a23 * z |
| a31 * x + a32 * y + a33 * z |

C# hat von Haus aus eine Matrix Struct die jedoch 4x4 ist , deshalb muss a44 (M44 in C#) auf 1 gesetzt werden.

Rotationsmatrixe habe ich von Wikipedia übernommen (https://en.wikipedia.org/wiki/Rotation_matrix)

Diese müssen vor der Projektion mit den Koordinatien des Objektes verrechnet werden. 

Rotation Theta(θ) wird über einen Timer inkrementiert, damit eine bewegte Rotation gezeichnet werden kann.
