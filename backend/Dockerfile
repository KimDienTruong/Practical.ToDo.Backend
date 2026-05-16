FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App
COPY . ./
RUN dotnet restore 
RUN dotnet publish -o out


FROM mcr.microsoft.com/dotnet/aspnet:9.0@sha256:b4bea3a52a0a77317fa93c5bbdb076623f81e3e2f201078d89914da71318b5d8
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "backend.dll"]

EXPOSE 8080
EXPOSE 8081
