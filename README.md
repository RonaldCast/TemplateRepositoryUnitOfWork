# TemplateRepositoryUnitOfWork

Este es un template creaado con la tecnologías Asp.net web API .net core 3.1 y estructurado con los patrones Repository y Unit of Work. Obviando el GeneryRepository.
Este template consta de las siguientes configuraciones:

* NSwagger
* ILogger configuración de logs.
* UnitTest
* AutoMapper
* Entre Otras 

## Tabla de métodos que retornan códigos de estado http  

| Métodos         | code          | Descripción                                                   |  Métodos HTTP         |
| --------------- |:-------------:|:-------------------------------------------------------------:|:---------------------:|
| Ok()            | 200           |  Respuesta estándar para solicitudes HTTP exitosas.           | PUT, POST, GET        |
| Created()       | 201           |  La solicitud éxitosa y se ha creado un nuevo recurso         | PUT                   |   
| NoContent()     | 204           |  La petición se ha completado con éxito pero su respuesta no tiene ningún contenido                                                     | En los métodos de su preferencia  |
| BadRequest()    | 400           |  Esta respuesta significa que el servidor no pudo interpretar la solicitud dada una sintaxis inválida.                                                             | En los métodos de su preferencia |
| Unauthorized()  | 401           |  Es necesario autenticar para obtener la respuesta solicitada                                                   | |
| Forbid()        | 403           |  El cliente no posee los permisos necesarios para cierto contenido                                                          |  |
| NotFound()      | 404           |  El servidor no pudo encontrar el contenido solicitado         | PUT, POST, GET        |

