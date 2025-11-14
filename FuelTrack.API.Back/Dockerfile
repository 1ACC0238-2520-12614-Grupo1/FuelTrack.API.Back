# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el csproj y restauramos dependencias
COPY ["FuelTrack.API.Back/FuelTrack.API.Back.csproj", "FuelTrack.API.Back/"]
RUN dotnet restore "FuelTrack.API.Back/FuelTrack.API.Back.csproj"

# Copiamos el resto del código y publicamos
COPY . .
WORKDIR "/src/FuelTrack.API.Back"
RUN dotnet publish "FuelTrack.API.Back.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa de runtime (imagen ligera solo con ASP.NET Core)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Puerto interno de la app (Render detecta el puerto automáticamente)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FuelTrack.API.Back.dll"]
