FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LivrosAPI/LivrosAPI.csproj", "LivrosAPI/"]
RUN dotnet restore "LivrosAPI/LivrosAPI.csproj"
COPY . .
WORKDIR "/src/LivrosAPI"
RUN dotnet build "LivrosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LivrosAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LivrosAPI.dll"]
