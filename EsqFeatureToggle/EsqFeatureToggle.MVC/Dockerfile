FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EsqFeatureToggle.MVC/EsqFeatureToggle.MVC.csproj", "EsqFeatureToggle.MVC/"]
RUN dotnet restore "EsqFeatureToggle.MVC/EsqFeatureToggle.MVC.csproj"
COPY . .
WORKDIR "/src/EsqFeatureToggle.MVC"
RUN dotnet build "EsqFeatureToggle.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EsqFeatureToggle.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EsqFeatureToggle.MVC.dll"]