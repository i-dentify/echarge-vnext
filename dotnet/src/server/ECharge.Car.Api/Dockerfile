FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/src/server/ECharge.Car.Api
RUN dotnet restore
RUN dotnet build --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECharge.Car.Api.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECharge.Car.Api.dll"]
