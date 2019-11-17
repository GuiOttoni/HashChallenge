FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 50051/tcp
EXPOSE 50051/udp

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ServiceOneServer/ServiceOneServer.csproj", "ServiceOneServer/"]
COPY ["ServiceOneLib/ServiceOneLib.csproj", "ServiceOneLib/"]
COPY ["SOne/SOne.csproj", "SOne/"]
RUN dotnet restore "ServiceOneServer/ServiceOneServer.csproj"
COPY . .
WORKDIR "/src/ServiceOneServer"
RUN dotnet build "ServiceOneServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceOneServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceOneServer.dll"]