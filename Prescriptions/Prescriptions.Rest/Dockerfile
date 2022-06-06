#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Prescriptions.Rest/Prescriptions.Rest.csproj", "Prescriptions.Rest/"]
COPY ["Prescriptions.Model/Prescriptions.Model.csproj", "Prescriptions.Model/"]
COPY ["Prescriptions.Logic/Prescriptions.Logic.csproj", "Prescriptions.Logic/"]
COPY ["Prescriptions.Rest.Model/Prescriptions.Rest.Model.csproj", "Prescriptions.Rest.Model/"]
RUN dotnet restore "Prescriptions.Rest/Prescriptions.Rest.csproj"
COPY . .
WORKDIR "/src/Prescriptions.Rest"
RUN dotnet build "Prescriptions.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prescriptions.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prescriptions.Rest.dll"]