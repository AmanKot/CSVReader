FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 1237
EXPOSE 44327

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["FileReader/FileReader.csproj", "FileReader/"]
RUN dotnet restore "FileReader/FileReader.csproj"
COPY . .
COPY ["FileReader/Corpus.csv", "FileReader/Corpus.csv"]
WORKDIR "/src/FileReader"
RUN dotnet build "FileReader.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FileReader.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FileReader.dll"]