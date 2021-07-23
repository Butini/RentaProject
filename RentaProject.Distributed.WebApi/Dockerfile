#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RentaProject.Distributed.WebApi/RentaProject.Distributed.WebApi.csproj", "RentaProject.Distributed.WebApi/"]
RUN dotnet restore "RentaProject.Distributed.WebApi/RentaProject.Distributed.WebApi.csproj"
COPY . .
WORKDIR "/src/RentaProject.Distributed.WebApi"
RUN dotnet build "RentaProject.Distributed.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentaProject.Distributed.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentaProject.Distributed.WebApi.dll"]