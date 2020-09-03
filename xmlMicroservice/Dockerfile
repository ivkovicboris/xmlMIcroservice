FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["xmlMicroservice/xmlMicroservice.csproj", "xmlMicroservice/"]
COPY ["xmlMicroservice.BLL/xmlMicroservice.BLL.csproj", "xmlMicroservice.BLL/"]
COPY ["xmlMicroservice.DAL/xmlMicroservice.DAL.csproj", "xmlMicroservice.DAL/"]
RUN dotnet restore "xmlMicroservice/xmlMicroservice.csproj"
COPY . .
WORKDIR "/src/xmlMicroservice"
RUN dotnet build "xmlMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "xmlMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "xmlMicroservice.dll"]
