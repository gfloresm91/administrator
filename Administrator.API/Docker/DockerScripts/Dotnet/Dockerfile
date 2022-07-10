#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["../AdministratorApi/AdministratorApi.csproj", "AdministratorApi/"]
RUN dotnet restore "AdministratorApi/AdministratorApi.csproj"
COPY . .
WORKDIR "/src/AdministratorApi"
RUN dotnet build "AdministratorApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdministratorApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdministratorApi.dll"]