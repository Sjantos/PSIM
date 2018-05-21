FROM microsoft/dotnet:2.1.300-preview2-sdk AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/dotnet:2.1.300-preview2-sdk AS build
WORKDIR /src
COPY StudBaza.sln ./
COPY StudBaza.WebApi/StudBaza.WebApi.csproj StudBaza.WebApi/
COPY StudBaza.Application/StudBaza.Application.csproj StudBaza.Application/
COPY StudBaza.Core/StudBaza.Core.csproj StudBaza.Core/
COPY StudBaza.Data/StudBaza.Data.csproj StudBaza.Data/
COPY . .
RUN dotnet restore -nowarn:msb3202,nu1503 ./StudBaza.sln
WORKDIR /src/StudBaza.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ["dotnet", "StudBaza.WebApi.dll"]
