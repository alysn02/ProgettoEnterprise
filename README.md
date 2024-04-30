# ProgettoEnterprise
Progetto ai fini dello svolgimento dell'esame di Paradigmi Avanzati di Programmazione modulo Enterprise

Gruppo composto da: 
Dottori Edoardo, Luciani Giovanni, Santolini Alice


Sviluppo del Progetto numero 3: Realizzazione di una web api che permetta la gestione di una lista di distribuzione multi utenza.

L'applicazione deve avere un elenco di utenti con le seguenti proprietà :
- Email
- Nome 
- Cognome
- Password

Ogni utente puo' essere proprietario di una o più liste di distribuzione.
Ogni lista di distribuzione ha le seguenti proprietà :
- Nome della lista
- Proprietario
- una lista di Email Destinatarie


Le api che dovranno essere realizzate sono le seguenti :
 - Creazione di un utente (anonima senza autenticazione)
 - Autenticazione
 - Creazione di una lista di distribuzione
 - Aggiunta di un destinatario ad una lista di distribuzione
 - Eliminazione di un destinatario ad un lista di distribuzione
 - Inivio di una comunicazione ad una lista di distrizibuzione.
   Tramite questa chiamata dovrà partire una email a tutti i membri della lista di distribuzione

 - Dato un destinatario ottenere tutte le liste di distribuzione a lui associate
   La ricerca dovrà paginare i risultanti, in base ad un parametro passato nella chiamata

   # Creazione del db
   Per la creazione del database creare un utente con le seguenti caratteristiche:
   - User Id: distribuzioniUtenze
   - Password: distribuzioni

    Successivamente è possibile eseguire il dump del db presente nel repository in :

   Unicam.Paradigmi.Progetto.Models-->Cartella Database-->scriptFinale.sql

   # Avvio della soluzione
   Impostare Unicam.Paradigmi.Progetto.Web-Deployment come progetto di avvio per poter testare le api con swagger 
   
