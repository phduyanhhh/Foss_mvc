FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/G7.Foss.Web.Mvc/G7.Foss.Web.Mvc.csproj", "src/G7.Foss.Web.Mvc/"]
COPY ["src/G7.Foss.Web.Core/G7.Foss.Web.Core.csproj", "src/G7.Foss.Web.Core/"]
COPY ["src/G7.Foss.Application/G7.Foss.Application.csproj", "src/G7.Foss.Application/"]
COPY ["src/G7.Foss.Core/G7.Foss.Core.csproj", "src/G7.Foss.Core/"]
COPY ["src/G7.Foss.EntityFrameworkCore/G7.Foss.EntityFrameworkCore.csproj", "src/G7.Foss.EntityFrameworkCore/"]
WORKDIR "/src/src/G7.Foss.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/G7.Foss.Web.Mvc", "src/G7.Foss.Web.Mvc"]
COPY ["src/G7.Foss.Web.Core", "src/G7.Foss.Web.Core"]
COPY ["src/G7.Foss.Application", "src/G7.Foss.Application"]
COPY ["src/G7.Foss.Core", "src/G7.Foss.Core"]
COPY ["src/G7.Foss.EntityFrameworkCore", "src/G7.Foss.EntityFrameworkCore"]
WORKDIR "/src/src/G7.Foss.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "G7.Foss.Web.Mvc.dll"]
