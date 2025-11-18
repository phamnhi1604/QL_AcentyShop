#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM amazonlinux AS base
#if(framework == "net6.0")
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y aspnetcore-runtime-6.0
#elseif(framework == "net7.0")
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y aspnetcore-runtime-7.0
#elseif(framework == "net8.0")
RUN rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm
RUN yum install -y aspnetcore-runtime-8.0
#endif

#Install dependencies
RUN yum install -y glibc-devel libicu fontconfig

WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80


FROM amazonlinux AS build
#if(framework == "net6.0")
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-6.0
#elseif(framework == "net7.0")
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-7.0
#elseif(framework == "net8.0")
RUN rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm
RUN yum install -y dotnet-sdk-8.0
#endif
WORKDIR /src
RUN --mount=type=secret,id=dxnuget dotnet nuget add source $(cat /run/secrets/dxnuget) -n devexpress-nuget
COPY ["../DevExpressProjectTemplate.Server/DevExpressProjectTemplate.Server.csproj", "DevExpressProjectTemplate.Server/"]
COPY ["../DevExpressProjectTemplate.Client/DevExpressProjectTemplate.Client.csproj", "DevExpressProjectTemplate.Client/"]
COPY ["../DevExpressProjectTemplate.Shared/DevExpressProjectTemplate.Shared.csproj", "DevExpressProjectTemplate.Shared/"]
RUN dotnet restore "DevExpressProjectTemplate.Server/DevExpressProjectTemplate.Server.csproj"
COPY . .
WORKDIR "/src/DevExpressProjectTemplate.Server"
RUN dotnet build "DevExpressProjectTemplate.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevExpressProjectTemplate.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevExpressProjectTemplate.Server.dll"]
