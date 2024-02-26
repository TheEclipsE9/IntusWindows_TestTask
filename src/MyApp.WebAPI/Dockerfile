#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MyApp.WebAPI/MyApp.WebAPI.csproj", "src/MyApp.WebAPI/"]
COPY ["src/MyApp.Application.Services/MyApp.Application.Services.csproj", "src/MyApp.Application.Services/"]
COPY ["src/MyApp.Domain.Contracts/MyApp.Domain.Contracts.csproj", "src/MyApp.Domain.Contracts/"]
COPY ["src/MyApp.Domain.Entities/MyApp.Domain.Entities.csproj", "src/MyApp.Domain.Entities/"]
COPY ["src/MyApp.Infrastructure.Data/MyApp.Infrastructure.Data.csproj", "src/MyApp.Infrastructure.Data/"]
RUN dotnet restore "src/MyApp.WebAPI/MyApp.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/MyApp.WebAPI"
RUN dotnet build "MyApp.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApp.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApp.WebAPI.dll"]