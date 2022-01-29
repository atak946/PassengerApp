FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
EXPOSE 80
COPY Gozen.Application/*.csproj Gozen.Application/
COPY Gozen.Domain/*.csproj Gozen.Domain/
COPY Gozen.Infrastructure/*.csproj Gozen.Infrastructure/
COPY Gozen.Infrastructure.IoC/*.csproj Gozen.Infrastructure.IoC/
COPY Gozen.API/*.csproj Gozen.API/
RUN dotnet restore  Gozen.API/*.csproj
COPY . .
RUN dotnet publish Gozen.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Gozen.API.dll" ]