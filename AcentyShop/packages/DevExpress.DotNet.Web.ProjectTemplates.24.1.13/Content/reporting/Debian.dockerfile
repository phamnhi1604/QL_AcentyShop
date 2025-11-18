#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#if(framework == "net6.0")
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
#elseif(framework == "net7.0")
FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
#elseif(framework == "net8.0")
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS base
#endif

#Install dependencies
RUN apt-get update
RUN apt-get install -y libc6 libicu-dev libfontconfig1

WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80

FROM node:20 as build-frontend
WORKDIR /modules
COPY ["package.json", "./"]
RUN npm install

#if(framework == "net6.0")
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
#elseif(framework == "net7.0")
FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
#elseif(framework == "net8.0")
FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
#endif
WORKDIR /src
RUN --mount=type=secret,id=dxnuget dotnet nuget add source $(cat /run/secrets/dxnuget) -n devexpress-nuget
COPY ["DevExpressProjectTemplate.csproj", "DevExpressProjectTemplate/"]
RUN dotnet restore "DevExpressProjectTemplate/DevExpressProjectTemplate.csproj"
COPY ["./", "DevExpressProjectTemplate/"]
WORKDIR "/src/DevExpressProjectTemplate"
COPY --from=build-frontend ./modules .
RUN dotnet build "DevExpressProjectTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevExpressProjectTemplate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevExpressProjectTemplate.dll"]
