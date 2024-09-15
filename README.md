# Notizen

Übertragene Notizen die ursprünglich Handschriftlich gemacht wurden sind (Skizzen fehlen deshalb):


Wie speicher ich die Koordinaten am besten?
Würfel = 6 Flächen a 4 Koordinaten
Struct oder Arrays?

Alles als float da ganze reelle Zahlen ,je nachdem was ich in der Zukunft noch vorhabe, ungenau sind.

//Ich habe mich am Ende für Structs entschieden, da ich es bequemer fand direkt '.x' 
  nehmen zu können anstatt .[0] ect.

//Ausserdem wollte ich auch mit Structs arbeiten.


Wie? Was brauche ich?

ProjektionsMatrix: Eine Matrix die einen Punkt im 3D-Raum auf einen Punkt im 2D-Raum projiziert.

<div>
  <pre>
    
| 1 0 0 |      |x|        |x|
| 0 1 0 |  *   |y|    =   |y|
| 0 0 0 |      |z|        |0|
  </pre>
</div>


Matrix Vector Multiplikation => eigene Methode
<div>
  <pre>
| a11 * x + a12 * y + a13 * z | 
| a21 * x + a22 * y + a23 * z | 
| a31 * x + a32 * y + a33 * z | 
  </pre>
</div>

C# hat von Haus aus eine Matrix Struct die jedoch 4x4 ist , deshalb muss a44 (M44 in C#) auf 1 gesetzt werden.

Rotationsmatrixe habe ich von Wikipedia übernommen (Bild von 'matlab.izmiran.ru')

<div id="wiki" align="center" style="background-color: #f0f0f0; display: inline-block;">
  <img src="http://matlab.izmiran.ru/help/techdoc/creating_plots/hg_objea.gif" />
</div>

Diese müssen vor der Projektion mit den Koordinatien des Objektes verrechnet werden. 

Rotation Theta(θ) wird über einen Timer inkrementiert, damit eine bewegte Rotation gezeichnet werden kann.


