FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY "/Exercises/Exercises.csproj" "./Exercises/Exercises.csproj"
COPY "/Common/Common.csproj" "./Common/Common.csproj"

WORKDIR /src
COPY . .
RUN dotnet restore "/src/Exercises/Exercises.csproj"

WORKDIR "/src/Exercises"
RUN dotnet build "Exercises.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Exercises.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

EXPOSE 8080

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exercises.dll"]