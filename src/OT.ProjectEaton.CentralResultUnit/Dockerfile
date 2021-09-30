#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OT.ProjectEaton.CentralResultUnit/OT.ProjectEaton.CentralResultUnit.csproj", "src/OT.ProjectEaton.CentralResultUnit/"]
COPY ["src/OT.ProjectEaton.Common/OT.ProjectEaton.Common.csproj", "src/OT.ProjectEaton.Common/"]
RUN dotnet restore "src/OT.ProjectEaton.CentralResultUnit/OT.ProjectEaton.CentralResultUnit.csproj"
COPY . .
WORKDIR "/src/src/OT.ProjectEaton.CentralResultUnit"
RUN dotnet build "OT.ProjectEaton.CentralResultUnit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OT.ProjectEaton.CentralResultUnit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OT.ProjectEaton.CentralResultUnit.dll"]