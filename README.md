# Chantin
## Administrador de Residentes en Condominio
Ver. 2.0.0
## Características:
* Empresa Admnistradora (Razón Social, Domicilio, Datos Fiscales, Cuentas Bancarias)
* Condominios / Casas / Departamentos / Unidades Habitacionales / Residenciales
* Residentes (Contactos, Vehiculos, Mascotas, Tags de Acceso, Datos Fiscales)
* Estados de Cuenta por Condominio / Casa / Calle / Cerrada / Edificio
* Publicación de Documentos como Reglamentos / Asambleas / Comunicados / Otros
* Control de Acceso para Proveedores / Visitantes / Personal Doméstico / Otros
* Visitas Programadas
* Gestión de Ingresos / Egresos
* Emisión de Comprobantes de Pagos / Facturas / Gastos
* Conceptos de Pago (Cuotas de Mantenimiento, Cuotas Extraordinarias, Cuotas de Reservaciones, Limpieza, etc.)
* Mesa Directiva
* Alertas Vecinales
* Encuestas y Votaciones para Iniciativas / Evaluaciones / Otros
* Solicitudes de Atención  
* Logros Realizados / Historico de Actividades 
* Directorio de Residentes / Proveedores
* Comentarios o Sugerencias
* Reservaciones de Areas Comunes: Salones / Canchas / Areas Recreativas / Palapas / Otros
* Notificaciones de Reuniones / Asambleas / Otros (por Correo electrónico / WhattsApp / Notificaciones push)
* Chat Interno
* Autenticación con Usuarios o con proveedores: Google, Microsoft y Apple
* Multi Lenguage, inicialmente Español e Ingles
## Arquitectura
### Backend - API Services
* Clean Architecture
* Dot NET Core
* Api Minimal Services
* SQL Server
* Entity Framework
* Chat Service with Websockets
### Definicón de Carpetas 
```
├── Api
│ ├── Chantin.Api
│	│   ├── EndPoints
│	│   └── Services
│ ├── Chantin.Core
│	│   ├── Features
│	│   └── Interfaces
│ ├── Chantin.Domain
│	│   ├── Config
│	│   ├── Entities
│	│   ├── Enums
│	│   ├── Dto
│	│   └── Models
│ └── Chantin.Infrastructure
│	    ├── Persistence
|	 	  │   └── Configurations
│	    ├── Repositories
│	    └── Services
└── TSM.Shared.Tools
```
### Frontend - Backoffice
* Angular 22
* AdminLte 4
* Bootstrap
* FontAwesome
* Reactive Forms
* NgRx & Effects
* Exporting to Excel
* Print to PDF from HTML
* Ionic to publish in Android and iOS
* Chat Service with Websockets
### Definicón de Carpetas
``` 
├── app
│   ├── core
│	│   ├── guards
│	│   ├── interceptors
│	│   ├── services
│	│   ├── providers
│	│   └── store
│   ├── shared
│	│   ├── loader
│	│   ├── dialog
│	│	├── toaster
│	│   └── models
│	│	    ├── dtos
│	│       └── enums
│	└── features
│		    └── <feature>
│			    ├── pages
│			    └── store
└── assets
```
## Esquema de Opciones 
### Administración
```
Administración
├── Mis Datos
│   ├── Datos Generales
│   ├── Domicilio
│   └── Fiscales
├── Empleados (Terceros)
│   ├── Domicilio
│   ├── Departamentos
│   └── Puestos
├── Proveedores (Terceros)
│   ├── Datos Generales
│   ├── Domicilio
│   └── Ficales
├── Tesorería
│   ├── Cuentas Bancarias
│   ├── Estados de Cuenta
│   ├── Facturación
│   ├── Conceptos Egresos/Ingresos
│   ├── Egresos
│   └── Ingresos
├── Residentes
│   ├── Datos Generales
│   ├── Domicilio
│   ├── Fiscales
│   ├── Personal Doméstico
│   └── Otros (Tarjeta Acceso, Tarjeta Club, Corbatin, etc.)
├── Iniciativas
├── Licitaciones
├── Documentos
├── Encuestas y Evaluaciones
├── Notificaciones
├── Ventanilla de Atención
├── Chat
└── Parametros
```
### Asociación
```
├── Mis Datos
│   ├── Datos Generales
│   ├── Domicilio
│   └── Fiscales
├── Mesa Directiva
│   ├── Datos Generales
│   ├── Domicilio
│   └── Fiscales
├── Asambleas 
│   ├── Agenda
│   └── Acuerdos
├── Vigilancia
│   ├── Empresa
│   ├── Empleados (Terceros - Vigilantes)
│   ├── Agenda
│   └── Bitácora de Acceso
├── Tesorería
│   ├── Cuentas Bancarias
│   ├── Estados de Cuenta
│   ├── Conceptos Egresos/Ingresos
│   ├── Egresos
│   └── Ingresos
├── Eventos (Agenda)
├── Areas Comunes
│   ├── Costos
│   └── Agenda
├── Comunicados
│   ├── Avisos
│   ├── Logros
│   └── Emergentes
├── Iniciativas
├── Licitaciones
├── Documentos
├── Encuestas y Evaluaciones
├── Notificaciones
├── Ventanilla de Atención
└── Chat
```
### Residentes
```
├── Mis Datos
│   ├── Datos Generales
│   ├── Domicilio
│   ├── Fiscales
│   ├── Personal Doméstico
│   └── Otros (Tarjeta Acceso, Tarjeta Club, Corbatin, etc.)
├── Estado de Cuenta
│   ├── Cargos
│   ├── Abonos
│   └── Facturas
├── Visitantes
├── Agenda
├── Administración
│	├── Comunicados
│	├── Iniciativas
│	├── Licitaciones
│	├── Documentos
│	└── Encuestas y Evaluaciones
├── Asociación
│	├── Comunicados
│	├── Iniciativas
│	├── Licitaciones
│	├── Documentos
│	└── Encuestas y Evaluaciones
├── Notificaciones
├── Ventanilla de Atención
└── Chat
```
### Vigilancia
```
├── Mis Datos
│   ├── Datos Generales
├── Agenda
│    ├── Visitantes
│    ├── Personal Doméstico
│    ├── Proveedores
│    ├── Otros
└── Bitácora de Acceso
```

## Database info

DataBase Local 
------------------------------
Server: (LocalDB)\MSSQLLocalDB
Database: ChantinDB

📍 Ubicación y Comando Exacto
1. Abre tu terminal en la raíz del workspace (/workspace).
2. Ejecuta el siguiente comando (ajustado a la estructura de carpetas detectada):
```bash
dotnet ef migrations add InitialCreate --project src/Chantin.Infrastructure/Chantin.Infrastructure.csproj --startup-project src/Chantin.Api/Chantin.Api.csproj
```
3. Para aplicar la migración y crear la BD:
```bash
dotnet ef database update --project src/Chantin.Infrastructure/Chantin.Infrastructure.csproj --startup-project src/Chantin.Api/Chantin.Api.csproj
```
⚙️ Requisitos Previos (Verificación)
Antes de ejecutar los comandos, asegúrate de tener esto listo:
Connection String Correcta:
Verifica que en src/Chantin.Api/appsettings.json tengas la cadena de conexión correcta para tu SQL Server local:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ChantinDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
(Si usas SQL Authentication, cambia Trusted_Connection=True por User ID=tu_usuario;Password=tu_password).
Herramientas EF Core Instaladas:
Si el comando dotnet ef no es reconocido, instala la herramienta globalmente:
```bash
dotnet tool install --global dotnet-ef
```
Proyecto de Infraestructura Referenciado:
Asegúrate de que Chantin.Api tenga referencia a Chantin.Infrastructure. En src/Chantin.Api/Chantin.Api.csproj debería existir:
```xml
<ProjectReference Include="..\Chantin.Infrastructure\Chantin.Infrastructure.csproj" />
```
📂 ¿Dónde se guardan los archivos de migración?
Por defecto, EF Core creará una carpeta llamada Migrations dentro del proyecto especificado con el flag --project.
Ruta esperada: /workspace/src/Chantin.Infrastructure/Migrations/
Ahí verás archivos como 20231027_InitialCreate.cs, ...Designer.cs, y ApplicationDbContextModelSnapshot.cs.
Una vez ejecutado el database update, revisa tu SQL Server Management Studio (SSMS) o Azure Data Studio y deberías ver la base de datos ChantinDB creada con todas las tablas definidas en las Fases 1 y 2.
