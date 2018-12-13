FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["JupyterSharpParser.Web/JupyterSharpParser.Web.csproj", "JupyterSharpParser.Web/"]
RUN dotnet restore "JupyterSharpParser.Web/JupyterSharpParser.Web.csproj"
COPY . .
WORKDIR "/src/JupyterSharpParser.Web"
RUN dotnet build "JupyterSharpParser.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JupyterSharpParser.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JupyterSharpParser.Web.dll"]