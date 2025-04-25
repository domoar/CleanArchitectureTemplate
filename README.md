# CleanArchitectureTemplate

[![CI - Build, Format, Test](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/build.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/build.yml) [![Generate documentation](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/docu.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/docu.yml)


## ToC

 1. [Api](#api)
 2. [Docker](#dockerfile-and-dockercompose-for-the-project)
 3. [Testing](#testing)
 4. [Usage](#usage)

## Api

To debug or run the api locally use 

```bash
dotnet watch run --launch-profile "https"
```

## DockerFile and DockerCompose for the project

There is a Dockerfile and a docker-compose.yml in the root directory.
The compose file starts five services:

- api – ASP.NET Core application.
- seq – Centralised structured log server.
- jaeger – Distributed tracing system.

Start / Shutdown these services with

```bash
docker compose up -d 
docker compose down
```

### Seq for Logging

Seq captures and can query structures logs.

#### How to setup Seq

### Jaeger for Tracing

Jaeger displays distributed traces.

#### How to setup Jaeger

## Testing

All Tests can be run by chaning the working directory of the unit or integration tests and then using the command:

```bash
cd tests/IntegrationTests
dotnet test --logger "console;verbosity=detailed"
```

or

```bash
cd tests/UnitTests
dotnet test --logger "console;verbosity=detailed"
```

Applying the `[Trait]` attribute at the **class** level allows, that every test method in that class can be run seperatly.

Example to run individual test parts:

```bash
dotnet test --filter "category=application"
```

## Usage

You can either use the github template and refactor or if you want the the full parametric experience?

Use

```bash
git clone https://github.com/domoar/CleanArchitectureTemplate.git
cd CleanArchitectureTemplate
```

to clone the repository then customize with 

```bash
dotnet new cleanarch --name MyApp --SolutionName "MyApp"
```

This repo will be redone once github templates allows variable names in templates. [Discussion](https://github.com/orgs/community/discussions/5336)
