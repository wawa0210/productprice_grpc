FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Server/ Server/
COPY ProductPriceBase/ ProductPriceBase/
RUN dotnet restore Server/Server.csproj
COPY . .
WORKDIR /src/Server
RUN dotnet build Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Server.dll"]
