# CleanArchitectureTemplate

[![CI - Build, Format, Test](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/build.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/build.yml) [![Generate documentation](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/documentation.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/documentation.yml) [![Generate and Publish Code Coverage](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/codecoverage.yml/badge.svg)](https://github.com/domoar/CleanArchitectureTemplate/actions/workflows/codecoverage.yml)

## ToC

 1. [Api](#api)
 2. [Docker](#dockerfile-and-dockercompose-for-the-project)
 3. [Testing](#testing)
 4. [Usage](#usage)
 5. [Architecture](#architecture)
 6. [CI/CD](#continuous-integration-und-continuous-deployment-cicd)
 7. [Tools](#tools)
 8. [Git Hooks](#git-hooks)

## Api

To debug or run the api locally use

```bash
dotnet watch run --launch-profile "https"
```

## DockerFile and DockerCompose for the project

There is a Dockerfile and a docker-compose.yml in the root directory. The DockerFile can be build with:

```bash
docker build .
```

The compose file starts three services:

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

### Code Coverage

Code Coverage is generated from unittests and integrationtests and merged into a report via GitHub Actions using the[ReportGenerator](https://github.com/danielpalme/ReportGenerator) tool.

[View Full Coverage Report](https://domoar.github.io/CleanArchitectureTemplate/coverage/index.html)

### Postman

The testsuite contains a postman collection that can be used via the postman application or its vscode extension. In `.extras/postman`.

### Testsuite client

The testsuite also contains a .http file with environments pre configured. In `.extras/client` you can either use the vscode extension [Rest-Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) or the built in feature from VS2022.

## Usage

You can either use the github template and refactor or if you want the the full parametric experience?

Consider the '.template.config/template.json' file.

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

CI/CD is handled with Github Actions see the workflows in **`.github/workflows`**.

## Tools

Using the .editorconfig file all projects can be formatted using

```bash
dotnet format .\__Northwind__.sln --verbosity diagnostic
```

## Git Hooks

This repo ships with a pre-commit hook in **`.githooks/pre-commit`**. Enable it once per clone by running

```bash
git config core.hooksPath .githooks
```

after cloning.
[Git Hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks)

The pre-commit checks for formatting/ linting and also if the solution compiles and can be build without errors.
