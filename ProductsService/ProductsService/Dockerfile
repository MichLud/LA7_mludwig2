FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5210

ENV ASPNETCORE_URLS=http://+:5210

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ProductsService/ProductsService/ProductsService.csproj", "ProductsService/ProductsService/"]
RUN dotnet restore "ProductsService/ProductsService/ProductsService.csproj"
COPY . .
WORKDIR "/src/ProductsService/ProductsService"
RUN dotnet build "ProductsService.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ProductsService.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsService.dll"]
