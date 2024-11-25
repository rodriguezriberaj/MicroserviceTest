FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY Client.Service.sln ./
COPY Client.Application/Client.Application.csproj ./Client.Application/
COPY Client.Api/Client.Api.csproj ./Client.Api/
COPY Client.Domain/Client.Domain.csproj ./Client.Domain/
COPY Client.Infrastructure/Client.Infrastructure.csproj ./Infrastructure/
RUN dotnet restore Client.Api/Client.Api.csproj

COPY . .
RUN dotnet publish Client.Api/Client.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Client.Api.dll"]
