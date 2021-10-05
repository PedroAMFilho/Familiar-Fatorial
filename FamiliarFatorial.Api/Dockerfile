#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FamiliarFatorial.Api/FamiliarFatorial.Api.csproj", "FamiliarFatorial.Api/"]
COPY ["FamiliarFatorial.Domain/FamiliarFatorial.Domain.csproj", "FamiliarFatorial.Domain/"]
COPY ["FamiliaFatorial.Shared/FamiliaFatorial.Shared.csproj", "FamiliaFatorial.Shared/"]
RUN dotnet restore "FamiliarFatorial.Api/FamiliarFatorial.Api.csproj"
COPY . .
WORKDIR "/src/FamiliarFatorial.Api"
RUN dotnet build "FamiliarFatorial.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamiliarFatorial.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamiliarFatorial.Api.dll"]