FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/G7.Foss.Web.Host/G7.Foss.Web.Host.csproj", "src/G7.Foss.Web.Host/"]
COPY ["src/G7.Foss.Web.Core/G7.Foss.Web.Core.csproj", "src/G7.Foss.Web.Core/"]
COPY ["src/G7.Foss.Application/G7.Foss.Application.csproj", "src/G7.Foss.Application/"]
COPY ["src/G7.Foss.Core/G7.Foss.Core.csproj", "src/G7.Foss.Core/"]
COPY ["src/G7.Foss.EntityFrameworkCore/G7.Foss.EntityFrameworkCore.csproj", "src/G7.Foss.EntityFrameworkCore/"]
WORKDIR "/src/src/G7.Foss.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/G7.Foss.Web.Host", "src/G7.Foss.Web.Host"]
COPY ["src/G7.Foss.Web.Core", "src/G7.Foss.Web.Core"]
COPY ["src/G7.Foss.Application", "src/G7.Foss.Application"]
COPY ["src/G7.Foss.Core", "src/G7.Foss.Core"]
COPY ["src/G7.Foss.EntityFrameworkCore", "src/G7.Foss.EntityFrameworkCore"]
WORKDIR "/src/src/G7.Foss.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "G7.Foss.Web.Host.dll"]
