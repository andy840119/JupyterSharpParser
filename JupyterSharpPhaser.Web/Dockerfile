FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["JupyterSharpPhaser.Web/JupyterSharpPhaser.Web.csproj", "JupyterSharpPhaser.Web/"]
RUN dotnet restore "JupyterSharpPhaser.Web/JupyterSharpPhaser.Web.csproj"
COPY . .
WORKDIR "/src/JupyterSharpPhaser.Web"
RUN dotnet build "JupyterSharpPhaser.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JupyterSharpPhaser.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JupyterSharpPhaser.Web.dll"]