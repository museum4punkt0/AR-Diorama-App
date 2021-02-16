# AR-Diorama-App

## Introduction

Die AR-App widmet sich dem Thema "Moderner Content in Museen durch AR". Die Grundidee ist es, bereits bestehende Ausstellungsstücke durch AR Elemente zu erweitern und so eine höhere Informationstiefe als auch Attraktivität für alle Altersklassen zu erhalten. Die hier vorliegende App beinhalltet als Beispiel für eine solche Digitalisierung nicht digitaler Ausstellungsstücke die Erweiterung eines Dioramas. <br> Durch die Betrachtung des Dioramas mithilfe der Kamera eines Mobilgerätes mit dieser App werden auf dem Display virtuelle Icons eingeblendet über jedem Bereich, welcher mit zusätzlichen interaktiven Inhalten ausgestattet ist. Die Figuren des Dioramas wurden als 3D Modelle nachgebildet und animiert. So beginnt beim Antippen eines Bereiches im Diorama, über welchem ein Informations-Icon schwebt, eine Animation und eine zusätzliche Informations-Box öffnet sich im unteren Bereich des Bildschirms. <br> Die Hologramme werden durch das AR-Bewegungs-Tracking wie tatsächlich vorhandene Elemente an einem bestimmten Ort im Diorama verankert und führen dort in einer kurzen Animation Abläufe und Bewegungen vor. Diese "Geister" der statischen Modelle ermöglichen einen tieferen Einblick und den Einbau spielerischer Elemente.<br>Um die Erkennung des Dioramas und die richtige Platzierung der virtuellen Erweiterungen zu gewährleisten, sind keine zusätzlichen Tracking-Punkte im inneren des Dioramas nötig. Durch das Scannen der Info-Tafel des Dioramas wird die relative Position des Betrachters erfasst und alle weiteren Bewegungen über andere das Tracking unterstützende Methoden fortgeführt um eine "Marker-Lose" Ar-Erfahrung zu ermöglichen.<br> Die zusätzlichen Info-Boxen, welche sich zu jeder Ar-Station öffnen, enthalten zusätzlich einen "mehr Informationen" Bereich, in welchem auf dem Gerät im Fullscreen Informationen angezeigt werden. So ist es möglich auf sperrige Info-Tafeln zu verzichten oder zu einzelnen Bereichen noch tiefer ins Detail zu informieren, ohne den Ausstellungsbereich durch eine 'Wall of Text' zu belasten.

## Förderhinweis

Diese AR-Anwendung ist entstanden im Verbundprojekt museum4punkt0 – Digitale Strategien für das Museum der Zukunft, Teilprojekt M3-3D-Visualisierung: Perspektiven in der musealen Vermittlung. Das Projekt museum4punkt0 wird gefördert durch die Beauftragte der Bundesregierung für Kultur und Medien aufgrund eines Beschlusses des Deutschen Bundestages. Weitere Informationen: www.museum4punkt0.de

## Technische Informationen / Installation

Das Projekt wurde mit der Unity-Engine erstellt, Version 2019.1.9f1 und die dafür kompatiblen Bibliotheken der AR-Foundation. Um alle Tracking Methoden der AR-Foundation gewährleisten zu können wird auf den Endgeräten eine iOS-Version ab 11.0 oder eine Andriod-Version ab 7.0 benötigt. <br> Das aktuelle Projekt ist auf ein Tracking-Bild eingestellt, welches im Deutschen Museum neben der Info-Tafel des richtigen Dioramas platziert werden muss. Außerhalb des deutschen Museums können mit dem richtigen Tracking-Bild zwar die Funktionen getestet werden, aber diese sind an die Örtlichen Modelle angepasst und erzeugen somit ohne das Original Diorama keine Illusion oder vollständige Präsentation.<br>

## Umgesetzte Ar-Elemente

Das aktuelle Diorama ist unterteilt in 4 Stationen:
- der Ton-Rüherer: Hier wird die Aufbereitung des Tons gezeigt indem eine der beiden mit Hacken ausgestatteten Figuren diese Tätigkeit in einer Animation vorführt. Zusätzlich werden 3 Hauptpunkte zur Gewinnung des Tons im Info-Bereich angezeigt. Unter Mehr-Infos können diese 3 Punkte ausformuliert als Fließtext gelesen werden.
- die Krugfrau: Beim Start dieser Station wird eine AR-Abbildung der Frau mit Tonkrug im Diorama erzeugt, welche nach 2 Schritten den Krug fallen lässt. Er zerspringt am Boden. Der Info-Bereich enthält 3 Hauptpunkte zum Wassereinsatz bei der Ton-Aufbereitung, zur Belastbarkeit der fertigen Gefäße und zur Weiternutzung zerbrochener Tonschalen, um den Ofen abzudecken.
- den Töpfer: Diese Station erzeugt ein Ebenbild des Mannes an der Töpferscheibe. Diese wird Historisch korrekt mit dessen Fuß angetrieben, was in der Animation gut zu sehen ist. Mit den Händen formt er eine Amphore. Der Info-Bereich enthält die 3 wichtigsten Geschirr-Arten der damaligen zeit.
- der Zeitreisende: Zusätzlich zu den Stationen, die sich auf Figuren im Diorama beziehen wird in der App ein Roboter auf dem Dach der Scheune platziert. Dieser ist permanent zu sehen und winkt dem Betrachter ab und an zu. Tippt man ihn an und startet seine Station erhält man Informationen über den Diorama-Bau.
<br>
Außerdem wird durch zufällig kreisende Krähen, die am Horizont oder quer über den Brennofen fliegen, das Diorama im allgemeinen belebt. Statische Figuren erhalten durch virtuell hinzugefügte bewegte Elemente an neuem Reiz.

## Credits

Auftraggeber: Deutsches Museum, München <br>
Umsetzung: elfgenpick gmbh & co. kg, Augsburg (www.elfgenpick.de)

## Lizenz

CreativeCommons BY-SA 4.0 (https://creativecommons.org/licenses/by-sa/4.0/)
