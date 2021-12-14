# Overview

This repository demonstrates hosting options for containers in Azure

## Description

Currently supported in this repository:

- [Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/)
- [Azure App Service for Containers](https://docs.microsoft.com/en-us/azure/app-service/quickstart-custom-container?tabs=dotnet&pivots=container-linux)
- [Azure Kubernetes Service](https://docs.microsoft.com/en-us/azure/aks/)

## Workflow

The current workflow file will build and push a container to a [Azure Container Registry](https://docs.microsoft.com/en-us/azure/container-registry/) and then deploy to the currently supported services.