# Razor Pages Application

This is a Razor Pages application that connects to a Minimal API for data retrieval and manipulation. It utilizes the default Azure Razor Pages template.

## Description

The Razor Pages application serves as a user interface for interacting with the data provided by the Minimal API. It allows users to perform CRUD (Create, Read, Update, Delete) operations on the data stored in the connected database.

## Minimal API Connection

The Razor Pages application connects to the Minimal API using Basic authentication. The username and password for the Basic authentication are configured as environment variables in the Azure App Service where the application is deployed.

## Environment Variables

The following environment variables are defined in the Azure App Service for configuring Basic authorization to connect to the Minimal API:

- `API_USERNAME`: Username for Basic authentication
- `API_PASSWORD`: Password for Basic authentication
- `API_URL`: The URL of the deployed Minimal API

## Usage

Users can access the Razor Pages application through its URL and perform CRUD operations on the connected data via the user interface.

## License

This project is licensed under the [MIT License](LICENSE).
