# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . .

# Restore & Publish the server project
RUN dotnet restore ./HomeAssistantUi.csproj
RUN dotnet publish ./HomeAssistantUi.csproj -c Release -o /app/out

# Stage 2: Runtime (not actually used in the final image but kept for clarity)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Stage 3: Nginx with generated SSL certificate
FROM nginx:1.23.0-alpine
WORKDIR /app
EXPOSE 8040 8042

# Install openssl and generate self-signed certificate
RUN apk add --no-cache openssl \
    && mkdir -p /etc/ssl/private \
    && openssl req -x509 -newkey rsa:4096 -nodes \
        -keyout /etc/ssl/private/nginx.key \
        -out /etc/ssl/certs/nginx.crt \
        -days 365 \
        -subj "/CN=localhost"

COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/out/wwwroot /usr/share/nginx/html