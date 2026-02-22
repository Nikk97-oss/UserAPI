# UserAPI - .NET 8 CLI Data Processor

**UserAPI**

è un'applicazione console interattiva sviluppata in **C# 12 / .NET 8**. Il progetto funge da intermediario (Proxy) tra l'utente e l'API pubblica [JSONPlaceholder](https://jsonplaceholder.typicode.com/), aggiungendo funzionalità avanzate di filtraggio e analisi statistica.

## Funzionalità
Il cuore del progetto è il `UserService`, che implementa una logica di business basata su **LINQ**:
* **Filtraggio Avanzato**: Ricerca per ID, Città, Suite, Azienda e Dominio Email.
* **Geofencing**: Filtro utenti basato su coordinate geografiche (`Lat` / `Lng`).
* **Statistiche**: Calcolo della distribuzione degli utenti per città (Aggregation).
* **Reporting**: Esportazione asincrona di un sommario dati su file `.txt`.
* **CLI Interattiva**: Menu a scelta multipla per navigare tra le funzioni.

##  Stack Tecnologico
* **Linguaggio**: C#
* **Framework**: .NET 8.0
* **Librerie**: `System.Net.Http.Json` per la gestione automatica dei dati JSON.

## Struttura del Progetto
* `User.cs`, `Address.cs`, `Geo.cs`, `Company.cs`: Modelli di dati nidificati.
* `UserService.cs`: Service layer per la manipolazione dei dati.
* `Program.cs`: Entry point dell'applicazione e gestione del menu utente.

## Come iniziare
1.  Assicurati di avere installato l'**SDK di .NET 8**.
2.  Clona il progetto: `git clone https://github.com/Nikk97-oss/UserAPI.git`
3.  Esegui l'applicazione: `dotnet run`

---
*Progetto realizzato per approfondire le nuove funzionalità di C# 12 e la gestione asincrona delle API HTTP.*
