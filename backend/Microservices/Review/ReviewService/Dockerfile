#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["backend/Microservices/Review/ReviewService/ReviewService.csproj", "backend/Microservices/Review/ReviewService/"]
COPY ["backend/Microservices/Review/MorvieReview.Application/MorvieReview.Application.csproj", "backend/Microservices/Review/MorvieReview.Application/"]
COPY ["backend/Microservices/Review/MorvieReview.Domain/MorvieReview.Domain.csproj", "backend/Microservices/Review/MorvieReview.Domain/"]
COPY ["backend/Microservices/Review/MorvieReview.Infrastructure/MorvieReview.Infrastructure.csproj", "backend/Microservices/Review/MorvieReview.Infrastructure/"]
RUN dotnet restore "backend/Microservices/Review/ReviewService/ReviewService.csproj"
COPY . .
WORKDIR "/src/backend/Microservices/Review/ReviewService"
RUN dotnet build "ReviewService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReviewService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReviewService.dll"]