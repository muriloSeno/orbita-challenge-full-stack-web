#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GroupA.API/GroupA.API.csproj", "GroupA.API/"]
RUN dotnet restore "GroupA.API/GroupA.API.csproj"
COPY . .
WORKDIR "/src/GroupA.API"
RUN dotnet build "GroupA.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupA.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupA.API.dll"]