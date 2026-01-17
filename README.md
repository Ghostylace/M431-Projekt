# Dokumentation Arbeitsschritte von jeder Person

## Cyril
Ich habe zuerst das GitHub-Repository erstellt und danach direkt das Frontend- und Backend-Projekt aufgesetzt. Zudem habe ich ein Shared-Projekt erstellt, damit wir unsere DTOs an einem Ort ablegen können. Danach habe ich vorgeschlagen, die Datenbank über Supabase aufzusetzen, damit nicht jeder die Datenbank lokal installieren muss und wir einfacher gemeinsam daran arbeiten können. Ausserdem habe ich den Support für Prorektor und Lehrer erstellt und den bestehenden Support? (Was meinst du mit support @ghostylace? --> bitte erklären) von anderen entsprechend angepasst. Danach habe ich den JWT Token Generator hinzugefügt und die nötigen Daten in die appsettings-Datei eingetragen. Dabei musste ich sogar zwei separate Token Generatoren erstellen, weil der Login-Controller je nach Anmeldetyp unterschiedliche Rückgaben liefert. Nebenbei habe ich auch immer wieder Bugfixes gemacht, damit das Projekt überhaupt sauber starten konnte. Bei den meisten Models musste ich ausserdem die Properties an die Datenbank anpassen, damit alles korrekt zusammenpasst und funktioniert.


## Nelio
Ich habe zuerst die Datenbank in MySQL erstellt. Nach einer Besprechung haben wir entschieden, auf PostgreSQL zu wechseln und die DB über Supabase zu hosten, weil wir Supabase gerade im ÜK nutzen und es einfacher zum Gebrauchen ist. Danach habe ich die Verbindung zwischen Backend und Datenbank gemacht, damit wir Daten speichern und auslesen können.
Auch habe ich Codecks überarbeitet, erledigte Pakete abgeschlossen und bei angepasst. Anschliessend haben wir einen kleinen Projektplan erstellt, damit klar ist, was wir machen müssen und wer was in den nächsten zwei Wochen machen sollte. Später haben wir gemerkt, dass wir keine einheitlichen Coding Guidelines haben, deshalb haben wir Regeln festgelegt und die Dateien passend umbenannt (z.B Deutsch --> Englisch). Zusätzlich haben wir Branches erstellt, damit wir uns nicht gegenseitig reinpushen und der Main-Branch stabil bleibt. Zum Schluss habe ich die DB nochmal überarbeitet, weil noch deutsche Begriffe drin waren, und ich habe das Backend weiter ausgebaut, damit mehr Funktionen möglich sind.


## Nevio
Meine Aufgabe war es, das Mockup zu erstellen. Ich hatte die Idee, das Mockup wie mit Blazor zu machen: mit einer Seitennavigation. Ich machte eine Ansicht für die Lehrpersonen und eine für die Prorektoren. Die Lehrer sollten sich mit der 2FA anmelden können und Noten hinzufügen können. Der Prorektor kann diese Noten besichtigen und annehmen oder ablehnen. Es dauerte eine Weile, aber es kam auch gut heraus. Nun bin ich für die Dokumentation zuständig und helfe im Frontend mit. Nachdem die eigentliche Planung beendet war, gingen wir rüber ins Realisieren. Das heisst, jeder machte die arbeit, die im zugewiesen worden wurde. Ich arbeitete also an der Projektdokumentation und schaute, dass diese bis am Abgabedatum beendet war. Ich machte die Dokumentation alleine mit der Hilfe vom Template und schrieb alles selber.


## Emanuel
Ich habe im Codedecks meine Arbeiten erstellt. Ich habe die Nutzwerkanalyse für unser Team erstellt mit Nelio.
Ich habe bereits das normale HTML für das Register und Login erstellt, damit ich es nur noch mit der Datenbank verbinden muss.
Ich hab dann noch alle restlichen Pages welche wir für das Projekt brauchen erstellt und dazu das normal HTML mit Bootstrap erstellt. Dann hab ich mit einem GET von den Lehrern der GIBZ einen Durchbruch erstellt das wir wussten das es funktioniert mit der DB zu verbinden. Es gab oft das Szenario, dass etwas im Backend oder Frontend noch nicht voll umgesetzt wurde und man dann dadurch nichts testen konnte, ob es auf der WebApp funktionierte. 


Codecks Link: `https://slowkob.codecks.io`
