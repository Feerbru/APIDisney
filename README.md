CHALLENGE BACKEND - C# .NET<br>
(API) 🚀<br>
Objetivo<br>
Desarrollar una API para explorar el mundo de Disney, la cual permitirá conocer y modificar los<br>
personajes que lo componen y entender en qué películas estos participaron. Por otro lado, deberá<br>
exponer la información para que cualquier frontend pueda consumirla.<br>
👉Utilizar .NET Core.<br>
👉No es necesario armar el Frontend.<br>
👉Las rutas deberán seguir el patrón REST.<br>
👉Utilizar DataAnnotations para el manejo de Autenticación.<br>
👉Implementar el modelo CodeFirst para el modelado de datos.<br>
⚠️¡No es indispensable hacer todo!<br>
Mientras más completes, mayor puntaje obtendrás, pero puedes enviar la app hasta el estadío que la<br>
tengas en base a tu conocimiento actual. Recuerda que el objetivo del challenge es entender tu nivel<br>
de conocimiento actual.<br>
Requerimientos técnicos<br>
¡Pueden parecer muchos! Sin embargo, no te preocupes. No es necesario que completes todos. Por<br>
supuesto, mientras más completes, mayor puntaje obtendrás.<br><br>

1. Modelado de Base de Datos<br>
● Personaje: deberá tener,<br>
○ Imagen.<br>
○ Nombre.<br>
○ Edad.<br>
○ Peso.<br>
○ Historia.<br>
○ Películas o series asociadas.<br><br>

● Película o Serie: deberá tener,<br>
○ Imagen.<br>
○ Título.<br>
○ Fecha de creación.<br>
○ Calificación (del 1 al 5).<br>
○ Personajes asociados.<br><br>

● Género: deberá tener,<br>
○ Nombre.<br>
○ Imagen.<br>
○ Películas o series asociadas.<br><br>

2. Autenticación de Usuarios<br>
Para realizar peticiones a los endpoints subsiguientes el usuario deberá contar con un token que<br>
obtendrá al autenticarse. Para ello, deberán desarrollarse los endpoints de registro y login, que<br>
permitan obtener el token.<br>
Los endpoints encargados de la autenticación deberán ser:<br>
● /auth/login<br>
● /auth/register<br><br>

3. Listado de Personajes<br>
El listado deberá mostrar:<br>
● Imagen.<br>
● Nombre.<br>
El endpoint deberá ser:<br>
● /characters<br><br>
4. Creación, Edición y Eliminación de Personajes (CRUD)<br>
Deberán existir las operaciones básicas de creación, edición y eliminación de personajes.<br><br>
5. Detalle de Personaje<br>
En el detalle deberán listarse todos los atributos del personaje, como así también sus películas o series<br>
relacionadas.<br><br>
6. Búsqueda de Personajes<br>
Deberá permitir buscar por nombre, y filtrar por edad, peso o películas/series en las que participó.<br>
Para especificar el término de búsqueda o filtros se deberán enviar como parámetros de query:<br>
● GET /characters?name=nombre<br>
● GET /characters?age=edad<br>
● GET /characters?movies=idMovie<br><br>
7. Listado de Películas<br>
Deberá mostrar solamente los campos imagen, título y fecha de creación.<br>
El endpoint deberá ser:<br>
● GET /movies<br><br>
8. Detalle de Película / Serie con sus personajes<br>
Devolverá todos los campos de la película o serie junto a los personajes asociados a la misma<br><br>
9. Creación, Edición y Eliminación de Película / Serie (CRUD)<br>
Deberán existir las operaciones básicas de creación, edición y eliminación de películas o series.<br><br>
10. Búsqueda de Películas o Series<br>
Deberá permitir buscar por título, y filtrar por género. Además, permitir ordenar los resultados por fecha<br>
de creación de forma ascendiente o descendiente.<br>
El término de búsqueda, filtro u ordenación se deberán especificar como parámetros de query:<br>
● /movies?name=nombre<br>
● /movies?genre=idGenero<br>
● /movies?order=ASC | DESC<br><br>
11. Envío de emails<br>
Al registrarse en el sitio, el usuario deberá recibir un email de bienvenida. Es recomendable, la<br>
utilización de algún servicio de terceros como SendGrid.<br>
Tests<br>
De forma opcional, se podrán agregar tests de los diferentes endpoints de la APP, verificando<br>
posibles escenarios de error:<br>
- Campos faltantes o con un formato inválido en BODY de las peticiones<br>
- Acceso a recursos inexistentes en endpoints de detalle<br>
Los tests pueden realizarse utilizando UnitTesting.<br>
