# dotnetcore_basic_crud

docker image

https://hub.docker.com/_/microsoft-mssql-server

> docker pull mcr.microsoft.com/mssql/server


> docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest


Connection String 
> "server=localhost;database=MvcDemoDb;User Id=sa;Password=Niamulhasan@123;Trusted_connection=false;MultipleActiveResultSets=true"
