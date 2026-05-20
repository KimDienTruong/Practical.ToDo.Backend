FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["backend.csproj", "."]
RUN dotnet restore

COPY . .
WORKDIR /src
RUN dotnet build "backend.csproj" -c Release -o /App/build

FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /App/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /App/publish .
ENTRYPOINT ["dotnet", "backend.dll"]

