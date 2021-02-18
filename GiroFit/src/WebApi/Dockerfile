#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["src/CrossCutting.IoC/CrossCutting.IoC.csproj", "src/CrossCutting.IoC/"]
COPY ["src/Domain.Core/Domain.Core.csproj", "src/Domain.Core/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/ApplicationService/ApplicationService.csproj", "src/ApplicationService/"]
COPY ["src/Data.PostgreSQL/Data.PostgreSQL.csproj", "src/Data.PostgreSQL/"]
COPY ["src/CrossCutting.Bus/CrossCutting.Bus.csproj", "src/CrossCutting.Bus/"]
RUN dotnet restore "src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]