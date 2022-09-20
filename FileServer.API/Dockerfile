FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["source/FileServer.API/FileServer.API.csproj", "source/FileServer.API/"]
COPY ["source/ModelLibrary/ModelLibrary.csproj", "source/ModelLibrary/"]
RUN dotnet restore "source/FileServer.API/FileServer.API.csproj"
COPY . .
WORKDIR "/src/source/FileServer.API"
RUN dotnet build "FileServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileServer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileServer.API.dll"]