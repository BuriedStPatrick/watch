FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Watch.Cli/Watch.Cli.csproj", "Watch.Cli/"]
RUN dotnet restore "Watch.Cli/Watch.Cli.csproj"
COPY . .
WORKDIR "/src/Watch.Cli"
RUN dotnet build "Watch.Cli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Watch.Cli.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watch.Cli.dll"]
