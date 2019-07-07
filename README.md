# WebApiAssignment #
This project is prepared to demonstrate the use of C# Web API.

## How to Run: ##
Clone the project and open with Visual Studio 2019 Community Edition (not tested in other versions but probably works).
Since the project requires https, please accept the SSL certificate warning if occurs.

## Short Description: ##
This project consists of C# Web API technology. Since the project is not complicated and does not use a database, I decided not to use traditional MVC pattern. However, I have prepared the folder structure, such as MVC, for enterprise-level architecture. 

The folder structure is below;
* Controllers: Handle request and flow control logic.
* Interfaces: As a best practice. (Used to contain only the declaration of the methods.)
* Models: Data structures
* Services: Business Logic
* Views: Front-end; HTML pages

### Frontend – Web Page ###

URI: `https://localhost:<port>/Views/index.html` <br>
All the function can be tested via this page.

## API Enpoints ##

### Customers ###
`GET 	/api/Customers`		Lists all customers.<br>
`GET 	/api/Customers/{id}`	Returns the customer with given CustomerID.

### Accounts ###
POST `/api/Accounts` <br>
It creates a new account object and if InitialCredit parameter value is greater than zero, it calls TransactionService via ITransactionService Interface object to create a new transaction object under the account.

<b>Example Post Data (Payload):</b>
```
{"CustomerID": 1,
 "InitialCredit": 444
}
```

### Transactions ###
POST `/api/Transactions` <br>
Creates a new transaction object under given account number with given TransferAmount value.

<b>Example Post Data (Payload):</b>
```
{"AccountNo": 1,
 "TransferAmount": 321
}
```
