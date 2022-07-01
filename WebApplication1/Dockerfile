FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5243
EXPOSE 7243

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
RUN dotnet restore "WebApplication1/WebApplication1.csproj"
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet dev-certs https
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS="https://*:7243;http://*:5243"
COPY --from=publish /app/publish .

# dotnet dev-certs only available in SDK
COPY --from=build /root/.dotnet/corefx/cryptography /root/.dotnet/corefx/cryptography

ENTRYPOINT ["dotnet", "WebApplication1.dll"]
