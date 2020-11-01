# TemplateRepositoryUnitOfWork

Este es un template creaado con la tecnologías Asp.net web API .net core 3.1 y estructurado con los patrones Repository y Unit of Work. Obviando el GeneryRepository.
Este template consta de las siguientes configuraciones:

* NSwagger
* ILogger configuración de logs.
* AutoMapper
* Entre Otras 

## Tabla de métodos que retornan códigos de estado HTTP 

| Métodos         | code          | Descripción                                                   |  Métodos HTTP         |
| --------------- |:-------------:|:-------------------------------------------------------------:|:---------------------:|
| Ok()            | 200           |  Respuesta estándar para solicitudes HTTP exitosas.           | PUT, POST, GET        |
| Created()       | 201           |  La solicitud éxitosa y se ha creado un nuevo recurso         | POST                   |   
| NoContent()     | 204           |  La petición se ha completado con éxito pero su respuesta no tiene ningún contenido                                                     | En los métodos de su preferencia  |
| BadRequest()    | 400           |  Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.                                                             | En los métodos de su preferencia |
| Unauthorized()  | 401           |  Es necesario autenticar para obtener la respuesta solicitada                                                   | |
| Forbid()        | 403           |  El cliente no posee los permisos necesarios para cierto contenido                                                          |  |
| NotFound()      | 404           |  El servidor no pudo encontrar el contenido solicitado         | PUT, POST, GET        |

## Resume para los método de la APIs RESTful HTTP

<table>

<thead>

<tr>

<th>**HTTP Method**</th>

<th>CRUD</th>

<th>Entire Collection (e.g. /users)</th>

<th>Specific Item (e.g. /users/123)</th>

</tr>

</thead>

<tbody>

<tr>

<td>POST</td>

<td>Create</td>

<td>201 (Created), ‘Location’ header with link to /users/{id} containing new ID.</td>

<td>Avoid using POST on single resource</td>

</tr>

<tr>

<td>GET</td>

<td>Read</td>

<td>200 (OK), list of users. Use pagination, sorting and filtering to navigate big lists.</td>

<td>200 (OK), single user. 404 (Not Found), if ID not found or invalid.</td>

</tr>

<tr>

<td>PUT</td>

<td>Update/Replace</td>

<td>405 (Method not allowed), unless you want to update every resource in the entire collection of resource.</td>

<td>200 (OK) or 204 (No Content). Use 404 (Not Found), if ID not found or invalid.</td>

</tr>

<tr>

<td>PATCH</td>

<td>Partial Update/Modify</td>

<td>405 (Method not allowed), unless you want to modify the collection itself.</td>

<td>200 (OK) or 204 (No Content). Use 404 (Not Found), if ID not found or invalid.</td>

</tr>

<tr>

<td>DELETE</td>

<td>Delete</td>

<td>405 (Method not allowed), unless you want to delete the whole collection — use with caution.</td>

<td>200 (OK). 404 (Not Found), if ID not found or invalid.</td>

</tr>

</tbody>

</table>
<span>Tabla extraido de la página<a href="https://restfulapi.net/http-methods/#put"> Rest API Tutorial</a></span>

