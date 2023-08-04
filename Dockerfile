#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/presentation/App.Webapi/App.Webapi.csproj", "src/presentation/App.Webapi/"]
COPY ["src/core/App.Application/App.Application.csproj", "src/core/App.Application/"]
COPY ["src/infrastructure/App.Data/App.Data.csproj", "src/infrastructure/App.Data/"]
COPY ["src/core/App.Domain/App.Domain.csproj", "src/core/App.Domain/"]
COPY ["src/infrastructure/App.Identity/App.Identity.csproj", "src/infrastructure/App.Identity/"]
RUN dotnet restore "src/presentation/App.Webapi/App.Webapi.csproj"
COPY . .
WORKDIR "/src/src/presentation/App.Webapi"
RUN dotnet build "App.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "App.Webapi.dll","--server.urls", "http://+:5000"]