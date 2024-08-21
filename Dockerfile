#va a construir el proyecto**\
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app 

#va a copiar todo lo que esta en el proyecto del appwebCafe2.csproj, toda la extensiones**\
COPY *.csproj ./ 
RUN dotnet restore
#luego va a publicar en correr proyecto publish**\aca hemos agregado el nombre para q funcione porque me salia error en render
COPY . ./
RUN dotnet publish appwebCafe2.csproj -c Release -o out

#configuracion**\
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

#CAMBIAR AQUI EL NOMBRE DEL APLICATIVO esta en carpeta bin appwebCafe2.dll
#nombre de tu app busca en bin\Release**\netcore5.0\plantitas.exe
ENV APP_NET_CORE appwebCafe2.dll 

CMD ASPNETCORE_URLS=http://*:$PORT dotnet $APP_NET_CORE