FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ServiceOneServerApi/ServiceOneServerApi.csproj", "ServiceOneServerApi/"]
COPY ["ServiceOneLib/ServiceOneLib.csproj", "ServiceOneLib/"]
RUN dotnet restore "ServiceOneServerApi/ServiceOneServerApi.csproj"
RUN dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p teste
COPY . .
WORKDIR "/src/ServiceOneServerApi"
RUN dotnet build "ServiceOneServerApi.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "ServiceOneServerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceOneServerApi.dll"]
