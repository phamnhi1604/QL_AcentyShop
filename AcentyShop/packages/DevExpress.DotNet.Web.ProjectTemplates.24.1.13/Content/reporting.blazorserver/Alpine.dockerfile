#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#if(framework == "net6.0")
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
#elseif(framework == "net7.0")
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
#elseif(framework == "net8.0")
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
#endif

#Install dependencies
RUN apk update && apk upgrade
RUN apk add icu-libs icu-data-full fontconfig

#Install fonts
RUN apk add ttf-dejavu && \
    apk add msttcorefonts-installer && \
    apk add ttf-dejavu && \
    update-ms-fonts && \
    fc-cache -f

WORKDIR /app
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
EXPOSE 443


#if(framework == "net6.0")
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
#elseif(framework == "net7.0")
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
#elseif(framework == "net8.0")
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
#endif
WORKDIR /src
RUN --mount=type=secret,id=dxnuget dotnet nuget add source $(cat /run/secrets/dxnuget) -n devexpress-nuget
COPY ["DevExpressProjectTemplate.csproj", "DevExpressProjectTemplate/"]
RUN dotnet restore "DevExpressProjectTemplate/DevExpressProjectTemplate.csproj"
COPY ["./", "DevExpressProjectTemplate/"]
WORKDIR "/src/DevExpressProjectTemplate"
RUN dotnet build "DevExpressProjectTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevExpressProjectTemplate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevExpressProjectTemplate.dll"]
