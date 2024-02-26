FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ElectricalEngineering.BlazorUI.MUD/ElectricalEngineering.BlazorUI.MUD.csproj", "ElectricalEngineering.BlazorUI.MUD/"]
RUN dotnet restore "ElectricalEngineering.BlazorUI.MUD/ElectricalEngineering.BlazorUI.MUD.csproj"
COPY . .
WORKDIR "/src/ElectricalEngineering.BlazorUI.MUD"
RUN dotnet build "ElectricalEngineering.BlazorUI.MUD.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ElectricalEngineering.BlazorUI.MUD.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectricalEngineering.BlazorUI.MUD.dll"]
