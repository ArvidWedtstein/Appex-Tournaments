FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tournament.csproj", "tournament/"]
RUN dotnet restore "tournament/tournament.csproj"
COPY . .
WORKDIR "/src/tournament"
RUN dotnet build "tournament.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tournament.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tournament.dll"]