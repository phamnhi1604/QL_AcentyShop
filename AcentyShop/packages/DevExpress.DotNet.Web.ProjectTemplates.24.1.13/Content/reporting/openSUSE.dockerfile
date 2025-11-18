#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM opensuse/leap AS base
RUN zypper -n install wget libicu && \
    wget https://packages.microsoft.com/keys/microsoft.asc
RUN rpm --import microsoft.asc

RUN wget https://packages.microsoft.com/config/opensuse/15/prod.repo && \
    mv prod.repo /etc/zypp/repos.d/microsoft-prod.repo && \
    chown root:root /etc/zypp/repos.d/microsoft-prod.repo

#if(framework == "net6.0")
RUN zypper -n install aspnetcore-runtime-6.0
#elseif(framework == "net7.0")
RUN zypper -n install aspnetcore-runtime-7.0
#elseif(framework == "net8.0")
RUN zypper -n install aspnetcore-runtime-8.0
#endif

#Install dependencies
RUN zypper -n install glibc-devel fontconfig

#Install fonts
RUN zypper -n install fetchmsttfonts

WORKDIR /app
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
EXPOSE 443

FROM node:20 as build-frontend
WORKDIR /modules
COPY ["package.json", "./"]
RUN npm install

FROM opensuse/leap AS build
RUN zypper -n install wget libicu && \
    wget https://packages.microsoft.com/keys/microsoft.asc
RUN rpm --import microsoft.asc

RUN wget https://packages.microsoft.com/config/opensuse/15/prod.repo && \
    mv prod.repo /etc/zypp/repos.d/microsoft-prod.repo && \
    chown root:root /etc/zypp/repos.d/microsoft-prod.repo

#if(framework == "net6.0")
RUN zypper -n install dotnet-sdk-6.0
#elseif(framework == "net7.0")
RUN zypper -n install dotnet-sdk-7.0
#elseif(framework == "net8.0")
RUN zypper -n install dotnet-sdk-8.0
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
