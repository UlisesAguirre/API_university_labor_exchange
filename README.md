# Bolsa de trabajo universitaria
### Descripción del proyecto:
El proyecto consiste en un sistema en el que los estudiantes de la universidad tecnológica nacional puedan presentar sus solicitudes para pasantías y empleos que estén relacionados directamente con sus áreas de estudio y habilidades. 
A su vez, ofrece a las empresas la posibilidad de ingresar sus ofertas laborales y seleccionar de entre los aspirantes quienes se han postulado para el cargo. 

### Link deploy:

https://amazing-axolotl-5d86cd.netlify.app/

![QR-Deploy](deploy-qr.png)

### Tecnologías utilizadas:
El proyecto está desarrollado en .NET, utilizando entity framework para una interacción simplificada con la base de datos SQL SERVER.
.
### Dependencias y paquetes utilizados:
- **Microsoft.Entity Framework Core:** ORM para interactuar con la base de datos.
- **Microsoft.EntityFrameworkCore.SqlServer:** Para interactuar con la base de datos específica (SQL Server).
- **Microsoft.EntityFrameworkCore.Tools:** Para administrar las migraciones de datos. 
- **Microsoft.AspNetCore.Authentication.JwtBearer & Microsoft.IdentityModel.Tokens:** Para el manejos de tokens JWT.
- **Automapper:** Para facilitar el mapeo de un modelo a otro.

### Instalacion y ejecucion:

- ##### Clonar el repositorio:
```
    git clone https://github.com/UlisesAguirre/API_university_labor_exchange.git
```
- ##### Configurar la base de datos.
    Asegurarse de tener SQL Server instalado y ajustar la cadena de conexión en el archivo appsettings.json

- ##### Aplicar la migración para crear la base de datos:
```
    database-update
```
- ##### Iniciar la aplicación.

    La aplicación se ejecutará en http://localhost:7049.

### Detalles adicionales:
- Implementa autenticación y almacenamiento mediante tokens JWT.
- Control de acceso en cada endpoint en función del tipo de usuario.
- Utiliza el patrón de diseño Observer para el envío de notificaciones.

### Users data:
to test the different screens the users are the following

Admin: `admin@gmail.com`
password: `Admin123`

Student: `student1@gmail.com`
password: `Student123`

Company: `company1@gmail.com`
password: `Company123`