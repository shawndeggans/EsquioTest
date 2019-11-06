FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EsqFeatureToggle.API/EsqFeatureToggle.API.csproj", "EsqFeatureToggle.API/"]
RUN dotnet restore "EsqFeatureToggle.API/EsqFeatureToggle.API.csproj"
COPY . .
WORKDIR "/src/EsqFeatureToggle.API"
RUN dotnet build "EsqFeatureToggle.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EsqFeatureToggle.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EsqFeatureToggle.API.dll"]