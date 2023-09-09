FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Dabernasho.Api/Dabernasho.Api.csproj", "Dabernasho.Api/"]
RUN dotnet restore "Dabernasho.Api/Dabernasho.Api.csproj"
COPY . .
WORKDIR "/src/Dabernasho.Api"
RUN dotnet build "Dabernasho.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dabernasho.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dabernasho.Api.dll"]
