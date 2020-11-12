---
name: Xamarin.Forms - AzureSignalR
description: This sample is a real-time chat application demonstrating the integration of Azure SignalR Service with Azure Functions and Xamarin.Forms.
page_type: sample
languages:
- csharp
products:
- xamarin
- azure
urlFragment: webservices-azuresignalr
---
# AzureSignalR

This sample is a real-time chat application demonstrating the integration of Azure SignalR Service with Azure Functions and Xamarin.Forms.

## Setting up Azure SignalR Service and Azure Functions

In order to run this sample application an Azure SignalR Service instance and an Azure Functions App must be created. These, high level steps must be performed:

1. Create an Azure SignalR Service, ensure that the **ServiceMode** is set to **serverless**.
1. Create an Azure Functions App.
1. Update the **Constants.cs** file with the Azure Functions App URL.
1. Deploy the two functions found in the **ChatServer** project to the Azure Functions App instance.

Once these steps have been performed, run any of the platform applications, click the Connect button and test sending messages once connected.

