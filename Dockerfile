# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5000

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Authentication/Authentication.csproj", "Authentication/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY ["Infrastructure/Email/EmailContent.html", "/app/Infrastructure/Email/EmailContent.html"]
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
CMD ["sh", "-c", "nginx && dotnet API.dll"]
