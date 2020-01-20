#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SampleBlog.WebAPI/SampleBlog.WebAPI.csproj", "SampleBlog.WebAPI/"]
COPY ["SampleBlog.Application/SampleBlog.Application.csproj", "SampleBlog.Application/"]
COPY ["SampleBlog.Persistence/SampleBlog.Persistence.csproj", "SampleBlog.Persistence/"]
COPY ["SampleBlog.Domain/SampleBlog.Domain.csproj", "SampleBlog.Domain/"]
RUN dotnet restore "SampleBlog.WebAPI/SampleBlog.WebAPI.csproj"
COPY . .
WORKDIR "/src/SampleBlog.WebAPI"
RUN dotnet build "SampleBlog.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleBlog.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleBlog.WebAPI.dll"]