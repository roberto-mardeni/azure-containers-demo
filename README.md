# Overview

This repository demonstrates hosting options for containers in Azure

## Description

Currently supported in this repository:

- [Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/)
- [Azure App Service for Containers](https://docs.microsoft.com/en-us/azure/app-service/quickstart-custom-container?tabs=dotnet&pivots=container-linux)
- [Azure Kubernetes Service](https://docs.microsoft.com/en-us/azure/aks/)
- [Azure Container Apps](https://docs.microsoft.com/en-us/azure/container-apps/)
- [Azure Spring Apps (Enterprise)](https://docs.microsoft.com/en-us/azure/spring-cloud/)

## Workflow

The current workflow file will build and push a container to a [Azure Container Registry](https://docs.microsoft.com/en-us/azure/container-registry/) and then deploy to the currently supported services.

To demonstrate the flexibility in configuration, ah HTML HEX value is passed as a parameter to each of the services deployment to be set as the HTML body background color.
