#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIgateways/OcelotAPIGateway/OcelotAPIGateway.csproj", "APIgateways/OcelotAPIGateway/"]
RUN dotnet restore "APIgateways/OcelotAPIGateway/OcelotAPIGateway.csproj"
COPY . .
WORKDIR "/src/APIgateways/OcelotAPIGateway"
RUN dotnet build "OcelotAPIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotAPIGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotAPIGateway.dll"]

FROM quay.io/keycloak/keycloak:18.0.1
#Adding custom ENTRYPOINT
ENTRYPOINT ["/opt/keycloak/bin/kc.sh", "start --proxy=edge" , "--auto-build", "--db=postgres"]