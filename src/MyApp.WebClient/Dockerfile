#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["src/MyApp.Domain.Contracts/MyApp.Domain.Contracts.csproj", "src/MyApp.Domain.Contracts/"]
COPY ["src/MyApp.Domain.Entities/MyApp.Domain.Entities.csproj", "src/MyApp.Domain.Entities/"]
COPY ["src/MyApp.WebClient/MyApp.WebClient.csproj", "src/MyApp.WebClient/"]
RUN dotnet restore "src/MyApp.WebClient/MyApp.WebClient.csproj"
COPY . .
RUN dotnet build "src/MyApp.WebClient/MyApp.WebClient.csproj" -c Release -o build

FROM nginx:alpine AS final
WORKDIR /app
EXPOSE 80
COPY src/MyApp.WebClient/nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/build/wwwroot /usr/share/nginx/html