FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Reviews.API/Reviews.API.csproj", "src/Reviews.API/"]
COPY ["src/Reviews.Infrastructure/Reviews.Infrastructure.csproj", "src/Reviews.Infrastructure/"]
COPY ["src/Reviews.Application/Reviews.Application.csproj", "src/Reviews.Application/"]
COPY ["src/Reviews.Domain/Reviews.Domain.csproj", "src/Reviews.Domain/"]
RUN dotnet restore "src/Reviews.API/Reviews.API.csproj"
COPY . .
WORKDIR "/src/src/Reviews.API"
RUN dotnet build "./Reviews.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Reviews.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reviews.API.dll"]
