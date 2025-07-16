# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . .

# Restore & Publish the server project
RUN dotnet restore ./HomeAssistantUi.csproj
RUN dotnet publish ./HomeAssistantUi.csproj -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

FROM nginx:1.23.0-alpine
WORKDIR /app
EXPOSE 8040
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/out/wwwroot /usr/share/nginx/html