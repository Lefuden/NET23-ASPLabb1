# Labb 1 – Entity Framework
## Om uppgiften

I denna labb kommer du att bygga en databas genom tekniken Entity Framework. Uppgiften utgår från det fiktiga caset att ett företag vill ha ett system för att deras personal ska kunna söka ledighet.

## Vad du ska göra

### Tekniska krav

Följande är de tekniska kraven som vi ställer på labbens genomförande

- [X]  Databasen skall skapas genom att använda EF (Code First)
- [X]  Fyll i lite data i alla tabeller genom koden

### Krav på datastrukturen

Följande är krav på den datastruktur du skapar i programmet.

- [X]  Företaget vill att all personal ska registreras i en databas
- [X]  Personalen ska ha en historik över sin ledighet med alla som har sökt ledighet tidigare
- [X]  Registreringen av ledighet ska ha olika ledighetstyper, t.ex. semester, vård av barn m.m

### Funktionella krav

Följande saker ska gå att göra en Console-applikationen eller i en MVC App när den körs.

- [X]  En anställd ska kunna skapa en ledighetsansökan genom att fylla i start- och slutdatum samt ledighetstyp. Tiden då denna ansökan registreras ska också sparas men fylls inte i av användaren.
- [X]  Bygg funktionalitet så det går att hämta en specifik person med namn samt om hen sökt ledighet
- [X]  Administratören vill kunna hämta alla ansökningar som skapats en viss månad och kunna se hur många dagar varje person har sökt ledighet och vilka datum ansökan har skapats.
