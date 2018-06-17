FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ConsoleDemo/ ConsoleDemo/
RUN dotnet restore ConsoleDemo/ConsoleDemo.csproj
COPY . .
WORKDIR /src/ConsoleDemo
RUN dotnet build ConsoleDemo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ConsoleDemo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConsoleDemo.dll"]
