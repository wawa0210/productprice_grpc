FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Client/ Client/
COPY ProductPriceBase/ ProductPriceBase/
RUN dotnet restore Client/Client.csproj
COPY . .
WORKDIR /src/Client
RUN dotnet build Client.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Client.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Client.dll"]
