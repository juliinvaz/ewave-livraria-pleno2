FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./

RUN dotnet restore
RUN dotnet publish ./Livraria.API/Livraria.API.csproj -c Release -o ./Livraria.API/build --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime

WORKDIR /app

COPY --from=build-env /app/Livraria.API/build ./

ENTRYPOINT ["dotnet", "Livraria.API.dll"]