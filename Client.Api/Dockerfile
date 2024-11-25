FROM mcr.microsoft.com/dotnet/aspnet:9.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Debug


COPY ["Client.Api/Client.Api.csproj", "Client.Api/"]

COPY ["Client.Application/Client.Application.csproj", "./Client.Application/"]
COPY ["Client.Domain/Client.Domain.csproj", " ./Client.Api/"]
RUN dotnet restore "Client.Api/Client.Api.csproj"

COPY ["Client.Api/", "Client.Api/"]
WORKDIR "Client.Api"
RUN dotnet build "Client.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
RUN dotnet publish "Client.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.Api.dll"]