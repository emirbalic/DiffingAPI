# DiffingAPI

Diffing API Task

> Using only http.

1 API Documentation
===================

1.1 Structures
--------------

### Item

* `id`
* `left`
* `right`


### Diff

* `Offset`
* `Length`

### DiffResponse
* `DiffResultType`
* `Diffs []`


1.2 Endpoints
--------------

###  [GET] - List ITEMS

#### Example:
```
http://localhost:5000/v1/diff
```
Control endpoint will return overview of all items.


###  [GET] - Single ITEM (ID)

#### Example:
```
http://localhost:5000/v1/diff/6
```
Endpoint returning item after comparing (left / right) values. If not both values present returns 404.
Various usecases follow specification as written in the assignement.


###  [PUT] - ITEM UPDATE (or functioning as [POST])

#### Example:
```
http://localhost:5000/v1/diff/1/left
```
Endpoint adds value to items either left or right value field. If value exists it overwrites it. Required structure follows specification as written in the assignement.

1.3 Project Structure
----------------------

### Visual Studio 
* `API`
* `API.IntegrationTesting`
* `API.Tests`


1.4 Clients
-----------

### Postman 
* `Attached collection `


### Swagger 
* `Endpoints enabled on http://localhost:5000/swagger/index.html`


1.5 Data
---------

### Sqlite database
* `Present in the root of the API project`

### Seed data
* `Configurable inside the Data/Seed.cs`
* `If not already been updated, it populates DB upon start`
