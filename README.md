# CleanArchitectureTemplate

[![CI - Build, Format, Test](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/build.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/build.yml) [![Generate documentation](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/docu.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/docu.yml)

## ToC

 1. [Api](#api)
 2. [Docker](#dockerfile-and-dockercompose-for-the-project)
 3. [Testing](#testing)
 4. [Usage](#usage)
 5. [Architecture](#architecture)
 6. [CI/CD](#continuous-integration-und-continuous-deployment-cicd)
 7. [Tools](#tools)

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

##### Additonal compose files for different purposes (.dcproj)

- `docker-compose.yml` + `docker-compose.override.yml` – default local-dev stack (override is loaded automatically).
- `docker-compose.dev.yml` – adds optional developer tooling (e.g. ).
- `docker-compose.prod.yml` – production-only tweaks (harder restart policies, resource limits, etc.).

```bash
# development 
docker compose -f docker-compose.yml -f docker-compose.prod.yml up -d

# production
docker compose -f docker-compose.yml -f docker-compose.dev.yml up -d
```

to run the developement stack.

[Docker merge strategies](https://docs.docker.com/compose/how-tos/multiple-compose-files/merge/)

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

## Architecture

## Continuous Integration und Continuous Deployment (CI/CD)

`.github/workflows`

## Tools

Using the .editorconfig file all projects can be formatted using

```bash
cd dotnet format .\__Northwind__.sln --verbosity diagnostic
```
