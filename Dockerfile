# Use the .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Copy the current directory contents to the container at /app
COPY . .

# Set the working directory in the container
WORKDIR /app

# Build the .NET application
RUN dotnet restore "app.csproj" && \
    dotnet build -c Release -o ./build

# Use the official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Change directory to the app
WORKDIR /app

# Copy the build app from the build stage
COPY --from=build /app/build .

# Specify the entry point for the container
ENTRYPOINT [ "dotnet", "app.dll" ]

