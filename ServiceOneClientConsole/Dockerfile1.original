FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ServiceOneClientConsole/ServiceOneClientConsole.csproj", "ServiceOneClientConsole/"]
RUN dotnet restore "ServiceOneClientConsole/ServiceOneClientConsole.csproj"
COPY . .
WORKDIR "/src/ServiceOneClientConsole"
RUN dotnet build "ServiceOneClientConsole.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "ServiceOneClientConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceOneClientConsole.dll"]