#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OT.ProjectEaton.MeasurementUnit.Emulator/OT.ProjectEaton.MeasurementUnit.Emulator.csproj", "src/OT.ProjectEaton.MeasurementUnit.Emulator/"]
COPY ["src/OT.ProjectEaton.Common/OT.ProjectEaton.Common.csproj", "src/OT.ProjectEaton.Common/"]
RUN dotnet restore "src/OT.ProjectEaton.MeasurementUnit.Emulator/OT.ProjectEaton.MeasurementUnit.Emulator.csproj"
COPY . .
WORKDIR "/src/src/OT.ProjectEaton.MeasurementUnit.Emulator"
RUN dotnet build "OT.ProjectEaton.MeasurementUnit.Emulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OT.ProjectEaton.MeasurementUnit.Emulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OT.ProjectEaton.MeasurementUnit.Emulator.dll"]