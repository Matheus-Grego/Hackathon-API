FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReWind.API/ReWind.API.csproj", "ReWind.API/"]
COPY ["ReWind.Application/ReWind.Application.csproj", "ReWind.Application/"]
COPY ["Rewind.Core/Rewind.Core.csproj", "Rewind.Core/"]
COPY ["ReWind.Infrastructure/ReWind.Infrastructure.csproj", "ReWind.Infrastructure/"]
RUN dotnet restore "ReWind.API/ReWind.API.csproj"
COPY . .
WORKDIR "/src/ReWind.API"
RUN dotnet build "./ReWind.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ReWind.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReWind.API.dll"]
