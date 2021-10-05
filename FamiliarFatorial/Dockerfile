#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FamiliarFatorial/FamiliarFatorial.Console.csproj", "FamiliarFatorial/"]
COPY ["FamiliarFatorial.Domain/FamiliarFatorial.Domain.csproj", "FamiliarFatorial.Domain/"]
COPY ["FamiliaFatorial.Shared/FamiliaFatorial.Shared.csproj", "FamiliaFatorial.Shared/"]
RUN dotnet restore "FamiliarFatorial/FamiliarFatorial.Console.csproj"
COPY . .
WORKDIR "/src/FamiliarFatorial"
RUN dotnet build "FamiliarFatorial.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamiliarFatorial.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamiliarFatorial.Console.dll"]