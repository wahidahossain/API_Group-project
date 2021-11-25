
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS aspwebsite
WORKDIR /App
COPY ./bin/Release/net5.0/publish/ /App/
EXPOSE 5000
ENTRYPOINT ["dotnet", "catalino.dll"]
