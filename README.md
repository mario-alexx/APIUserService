# API Rest Usuarios con .Net Core 5 :zap:

- Desarrollando una API CRUD de clientes con **Onion Architecture**.

- Implementando **JWT** para la Autenticación y Autorización de Permisos y Roles.

- Para la gestión de la Base de datos se uso el **ORM EF** con SQL Server y para el **caching se uso Redis** optimizando las consulta contra la base de datos.

- Design patterns: Repository, MediatR, CQRS, Dependency Inyection.

-  Paginado en la operación de lectura

- Otros: FluentValidation,  AutoMapper, ArdailsSpecification.
## Account

#### Autenticar Usuario

```
Post 	/api/Account/authenticate

{
  "email": "user@mail.com",
  "password": "123Pa$$word%"
}

200  "Message": "Usuario Autenticado [nombreUsuario]"
400  "Message": "No hay una cuenta registrada con el email:[email]",
400  "Message": "Las credenciales del usuario no son validas. user@mail.com"
}
```

#### Registrar usuario

```
Post 	/api/Account/register

{
  "nombre": "string",
  "apellido": "string",
  "email": "string",
  "userName": "string",
  "password": "string",
  "confirmPassword": "string"
}

200  "Message": "Usuario Autenticado [nombreUsuario]"
400  "Message": "Se han producido uno o más errores de validación",
400  "Message": "El email user@mail.com ya fue registrado previamente.",
}
```

### Customer
#### Leer cliente 
```
Get 	/api/v{version}/Customer
Parameters:
	nombre: string,
	apellido: string,
	pageNumber: int,
	pageSize: int,
	version*: int

Responses:
{
  "pageNumber": 1,
  "pageSize": 10,
  "succeded": true,
  "message": null,
  "errors": null,
  "data": [
    {
      "nombre": "string",
      "apellido": "string",
      "fechaNacimiento": "YYYY-MM-DD",
      "telefono": "string",
      "email": "string",
      "direccion": "string",
      "edad": int
    }
  ]
}

200  Success
500  Message: "No connection is available to service this operation"
}
```

#### Obtener Cliente por Id 
```
Get 	/api/v{version}/Customer/{id}

Parameters: id*, version*

Responses:
{
	version* : int
  "nombre": "string",
  "apellido": "string",
  "fechaNacimiento": "2024-03-01",
  "telefono": "string",
  "email": "string",
  "direccion": "string"
}

200 "Success": true
401 "Message": "Usted no esta autorizado"
404 "Message": "Registro no encontrado con el id 1"
```

#### Crear Cliente 
```
Post 	/api/v{version}/Customer
{
	version* : int
  "nombre": "string",
  "apellido": "string",
  "fechaNacimiento": "2024-03-01",
  "telefono": "string",
  "email": "string",
  "direccion": "string"
}

200 "succeded": true,
400 "Message": "Se han producido uno o más errores de validación"
401 "Message": "Usted no esta autorizado"

```

#### Actualizar Cliente 
```
Put 	/api/v{version}/Customer/{id}

Parameter: id*, version*

{
  "nombre": "string",
  "apellido": "string",
  "fechaNacimiento": "2024-03-01",
  "telefono": "string",
  "email": "string",
  "direccion": "string"
}

200 "Succeded": true
401 "Message": "Usted no esta autorizado"
```

#### Eliminar Cliente 
```
Delete 	/api/v{version}/Customer/{id}

Parameter: id*, version*

200 "Succeded": true
401 "Message": "Usted no esta autorizado"
403 "Message": "Usted no tiene permisos sobre este recurso"
```
---- 
### Image

![](https://github.com/mario-alexx/APIUserService/blob/master/apipng.jpg)


