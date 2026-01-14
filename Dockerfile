# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Sikalaty/Sikalaty.csproj", "Sikalaty/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Interfaces/Interfaces.csproj", "Interfaces/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Sikalaty.Presentation/Sikalaty.Presentation.csproj", "Sikalaty.Presentation/"]
COPY ["Services.Interfaces/Services.Interfaces.csproj", "Services.Interfaces/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "Sikalaty/Sikalaty.csproj"
COPY . .
WORKDIR "/src/Sikalaty"
RUN dotnet build "Sikalaty.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Sikalaty.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY ["Shared/Email/EmailContent.html", "/app/Shared/Email/EmailContent.html"]
COPY --from=publish /app/publish .

# Install NGINX
RUN apt-get update && apt-get install -y --no-install-recommends \
    wget \
    ca-certificates \
    nginx \
    curl && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Copy NGINX configuration
RUN rm -rf /etc/nginx/conf.d/*
COPY nginx.conf /etc/nginx/conf.d/nginx.conf

# Set environment variables
ENV ASPNETCORE_URLS=http://+:5000

# Expose ports
EXPOSE 5000

# Start NGINX and your application
CMD ["sh", "-c", "nginx && dotnet Sikalaty.dll"]
