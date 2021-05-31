#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GFN.PrivateWebApi/GFN.PrivateWebApi.csproj", "GFN.PrivateWebApi/"]
RUN dotnet restore "GFN.PrivateWebApi/GFN.PrivateWebApi.csproj"
COPY . .
WORKDIR "/src/GFN.PrivateWebApi"
RUN dotnet build "GFN.PrivateWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GFN.PrivateWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GFN.PrivateWebApi.dll"]