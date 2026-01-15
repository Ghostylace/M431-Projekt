# Dokumentation Arbeitsschritte von jeder Person

## Cyril
Ich habe das GitHub-Repository erstellt. Danach habe ich das Frontend- und Backend-Projekt erstellt und ein Shared-Projekt für die DTO-Ablage. 
Ich schlug vor, die Datenbank auf Supabase aufzusetzen, damit nicht alle die Datenbank lokal installieren müssen.
Ich habe Support für Prorektor und Lehrer erstellt und den Support von anderen angepasst.
Ich habe den JWTToken Generator hinzugefügt und die nötigen Daten in die appsettings Datei eingefügt.
Ich musste zwei separate JWTToken Generatoren erstellen, weil der Anmelde Controller zwei verschiedene Anmeldetypen zurückgibt.
Ich habe oft auch Bug fixes gemacht, damit das Projekt auch starten konnte.
Bei den meisten Models musste ich die Properties auf die DB anpassen.
Ich werde noch den Support für alle Tabellen verbessern und Exception handling hinzufügen.

## Nelio
Zuerst habe ich die Datenbank in MySQL erstellt. Nach einer Besprechung haben wir uns jedoch darauf geeinigt, auf PostgreSQL zu wechseln und die Datenbank über Supabase zu hosten. Diese Entscheidung fiel, da wir Supabase gerade im Unterricht bearbeitet hatten und PostgreSQL eine einfachere SQL Sprache ist. Zudem können wir mit Supabase die gesamte Datenbank anpassen und einsehen. Anschliessend habe ich eingerichtet, dass das Backend auf die Datenbank zugreifen kann, sodass Daten gespeichert und abgerufen werden können. Zwischendurch habe ich kurz das CodeDeck überarbeitet, alle bereits erledigten Aufgaben abgeschlossen und bei Bedarf angepasst. Danach haben wir einen Projektplan erstellt, damit wir genau wissen, woran wir arbeiten müssen und wie das System aufgebaut ist. So ist die Koordination besser und wir haben ein klares Ziel vor Augen. Nach einiger Zeit haben wir festgestellt, dass es keine einheitlichen Coding Guidelines gab. Dateien wurden unterschiedlich benannt, weshalb wir gemeinsame Richtlinien festgelegt haben, um eine bessere Zusammenarbeit zu gewährleisten. Dazu haben wir noch Branches eingerichtet, damit wir uns nicht gegenseitig behindern oder versehentlich ein nicht funktionierendes Main-Branch haben. Anschliessend habe ich die Datenbank noch einmal überarbeitet, da dort noch einige deutsche Begriffe verwendet wurden. Danach habe ich das Backend weiterentwickelt, sodass weitere Funktionen umgesetzt werden konnten.

## Nevio
Meine Aufgabe war es, das Mockup zu erstellen. Ich hatte die Idee, das Mockup wie mit Blazor zu machen: mit einer Seitennavigation. Ich machte eine Ansicht für die Lehrpersonen und eine für die Prorektoren. Die Lehrer sollten sich mit der 2FA anmelden können und Noten hinzufügen können. Der Prorektor kann diese Noten besichtigen und annehmen oder ablehnen. Es dauerte eine Weile, aber es kam auch gut heraus. Nun bin ich für die Dokumentation zuständig und helfe im Frontend mit.


## Emanuel
Ich habe im Codedecks meine Arbeiten erstellt. Ich habe die Nutzwerkanalyse für unser Team erstellt mit Nelio.
Ich habe bereits das normale HTML für das Register und Login erstellt, damit ich es nur noch mit der Datenbank verbinden muss.
Ich hab dann noch alle restlichen Pages welche wir für das Projekt brauchen erstellt und dazu das normal HTML mit Bootstrap erstellt. Dann hab ich mit einem GET von den Lehrern der GIBZ einen Durchbruch erstellt das wir wussten das es funktioniert mit der DB zu verbinden
Über die Ferien und dann die erste Woche konnte ich nichts machen da die API immer probleme hatte oder nie fertig gemacht wurde. Es wurden immer nur verschiedene GET erstellt welche ich nicht weis was ich damit machen sollte.

Codecks Link: `https://slowkob.codecks.io`
