DB Context
=

Install
-
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

Validate
-
```
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

Configuration
-
Need create folder "Configuration" under --output-dir because the Scaffold search this folder

Database Server
-
```
sql5112.site4now.net
DB_9A9C29_chantin
db_9a9c29_chantin_admin
Ch@nt1n$2164
```
```
Data Source=SQL5044.site4now.net;Initial Catalog=DB_9A9C29_condominios;Persist Security Info=True;User ID=DB_9A9C29_condominios_admin;Password=Rodrigo00
```
Execute
-
CMD

DATABASE
```
dotnet ef dbcontext scaffold "Server=SQL5044.site4now.net;Database=DB_9A9C29_condominios;uid=DB_9A9C29_condominios_admin;pwd=Rodrigo00;persist security info=True;" Microsoft.EntityFrameworkCore.SqlServer -c ChantinCTX -n Chantin -o D:/Proyectos/Trinity.Chantin/app/dbContext/Entities --context-dir D:/Proyectos/Trinity.Chantin/app/dbContext/Persistence --startup-project D:/Proyectos/Trinity.Escafolding/ScaffoldingTool/ScaffoldingTool.csproj -d -f -v --no-build --no-pluralize
```
TABLES
```
dotnet ef dbcontext scaffold "Server=SQL5044.site4now.net;Database=DB_9A9C29_condominios;uid=DB_9A9C29_condominios_admin;pwd=Rodrigo00;persist security info=True;" Microsoft.EntityFrameworkCore.SqlServer -c ChantinCTX -n Chantin -o D:/Proyectos/Trinity.Chantin/app/dbContext/Entities --context-dir D:/Proyectos/Trinity.Chantin/app/dbContext/Persistence --startup-project D:/Proyectos/Trinity.Escafolding/ScaffoldingTool/ScaffoldingTool.csproj -t tbl_ClientSettings -d -f -v --no-build --no-pluralize
```