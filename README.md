Microservicio Materia
Microservicio desarrollado en **.NET 8** para la gestión de materias.  
Incluye:
- API REST (CRUD de Materia)
- SQL Server en contenedor Docker
- Entity Framework Core
- Swagger para documentación
- Postman para pruebas
Requisitos previos
Asegúrate de tener instalado:
Docker Desktop  
https://www.docker.com/products/docker-desktop/
.NET SDK 8  
https://dotnet.microsoft.com/es-es/download/dotnet/8.0
Git  
https://git-scm.com/
Levantar todo con Docker Compose
Ejecutar:
docker compose up -d
Probar en Swagger
Abrir en navegador:
http://localhost:8080/swagger
Probar en Postman
Obtener todas las materias
GET
http://localhost:8080/api/Materia
Crear una materia
Body → JSON:
{
  "nombre": "Matemática I",
  "codigo": "MAT101",
  "creditos": 4,
  "prerequisito": "Ninguno",
  "area": "Ciencias",
  "nivel": 1,
  "activa": true
}
POST
http://localhost:8080/api/Materia
