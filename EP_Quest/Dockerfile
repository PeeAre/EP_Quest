#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EP_Quest.csproj", "EP_Quest/"]
RUN dotnet restore "./EP_Quest/EP_Quest.csproj"
COPY [".", "EP_Quest/"]
WORKDIR "/src/EP_Quest"
RUN dotnet build "./EP_Quest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EP_Quest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./certificate.pfx ./
ENTRYPOINT ["dotnet", "EP_Quest.dll"]