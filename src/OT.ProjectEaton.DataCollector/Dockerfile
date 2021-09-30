#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OT.ProjectEaton.DataCollector/OT.ProjectEaton.DataCollector.csproj", "src/OT.ProjectEaton.DataCollector/"]
COPY ["src/OT.ProjectEaton.Common/OT.ProjectEaton.Common.csproj", "src/OT.ProjectEaton.Common/"]
RUN dotnet restore "src/OT.ProjectEaton.DataCollector/OT.ProjectEaton.DataCollector.csproj"
COPY . .
WORKDIR "/src/src/OT.ProjectEaton.DataCollector"
RUN dotnet build "OT.ProjectEaton.DataCollector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OT.ProjectEaton.DataCollector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OT.ProjectEaton.DataCollector.dll"]