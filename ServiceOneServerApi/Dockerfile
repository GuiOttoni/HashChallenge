FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ServiceOneServerApi/ServiceOneServerApi.csproj", "ServiceOneServerApi/"]
RUN dotnet restore "ServiceOneServerApi/ServiceOneServerApi.csproj"
COPY . .
WORKDIR "/src/ServiceOneServerApi"
RUN dotnet build "ServiceOneServerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceOneServerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceOneServerApi.dll"]