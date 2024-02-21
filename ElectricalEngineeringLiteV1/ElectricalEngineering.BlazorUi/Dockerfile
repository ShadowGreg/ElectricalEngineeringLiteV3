FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ElectricalEngineering.BlazorUi/ElectricalEngineering.BlazorUi.csproj", "ElectricalEngineering.BlazorUi/"]
COPY ["ElectricalEngineering.Data/ElectricalEngineering.Data.csproj", "ElectricalEngineering.Data/"]
COPY ["ElectricalEngineering.Domain/ElectricalEngineering.Domain.csproj", "ElectricalEngineering.Domain/"]
COPY ["ElectricalEngineering.DomainServices/ElectricalEngineering.DomainServices.csproj", "ElectricalEngineering.DomainServices/"]
RUN dotnet restore "ElectricalEngineering.BlazorUi/ElectricalEngineering.BlazorUi.csproj"
COPY . .
WORKDIR "/src/ElectricalEngineering.BlazorUi"
RUN dotnet build "ElectricalEngineering.BlazorUi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ElectricalEngineering.BlazorUi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectricalEngineering.BlazorUi.dll"]
