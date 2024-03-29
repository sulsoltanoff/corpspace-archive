﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Corpspace.sln" "Corpspace.sln"

COPY "ApiGateways/Corpspace.Bff.Mobile/aggregator/Corpspace.Mobile.HttpAggregator.csproj" "ApiGateways/Corpspace.Bff.Mobile/aggregator/Corpspace.Mobile.HttpAggregator.csproj"
COPY "ApiGateways/Corpspace.Bff.Web/aggregator/Corpspace.Web.HttpAggregator.csproj" "ApiGateways/Corpspace.Bff.Web/aggregator/Corpspace.Web.HttpAggregator.csproj"
COPY "BuildingBlocks/Commons/Corpspace.Commons/Corpspace.Commons.csproj" "BuildingBlocks/Commons/Corpspace.Commons/Corpspace.Commons.csproj"
COPY "BuildingBlocks/Commons/WebHost.Customization/WebHost.Customization.csproj" "BuildingBlocks/Commons/WebHost.Customization/WebHost.Customization.csproj"
COPY "BuildingBlocks/Devspaces.Support/Devspaces.Support.csproj" "BuildingBlocks/Devspaces.Support/Devspaces.Support.csproj"
COPY "BuildingBlocks/EventBus/EventBus.Tests/EventBus.Tests.csproj" "BuildingBlocks/EventBus/EventBus.Tests/EventBus.Tests.csproj"
COPY "BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj" "BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj"
COPY "BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj" "BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj"
COPY "BuildingBlocks/EventBus/EventBus/EventBus.csproj" "BuildingBlocks/EventBus/EventBus/EventBus.csproj"
COPY "BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj" "BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj"
COPY "Services/ChatSpace/ChatSpace.API/ChatSpace.API.csproj" "Services/ChatSpace/ChatSpace.API/ChatSpace.API.csproj"
COPY "Services/ChatSpace/ChatSpace.Application/ChatSpace.Application.csproj" "Services/ChatSpace/ChatSpace.Application/ChatSpace.Application.csproj"
COPY "Services/ChatSpace/ChatSpace.Domain/ChatSpace.Domain.csproj" "Services/ChatSpace/ChatSpace.Domain/ChatSpace.Domain.csproj"
COPY "Services/ChatSpace/ChatSpace.Infrastructure/ChatSpace.Infrastructure.csproj" "Services/ChatSpace/ChatSpace.Infrastructure/ChatSpace.Infrastructure.csproj"
COPY "Services/Identity/Identity.API/Identity.API.csproj" "Services/Identity/Identity.API/Identity.API.csproj"
COPY "Services/Payment/Payment.API/Payment.API.csproj" "Services/Payment/Payment.API/Payment.API.csproj"
COPY "Services/Webhooks/Webhooks.API/Webhooks.API.csproj" "Services/Webhooks/Webhooks.API/Webhooks.API.csproj"
COPY "Tests/Services/Application.FunctionalTests/Application.FunctionalTests.csproj" "Tests/Services/Application.FunctionalTests/Application.FunctionalTests.csproj"
COPY "Web/WebAngular/WebAngular.csproj" "Web/WebAngular/WebAngular.csproj"
COPY "Web/WebStatus/WebStatus.csproj" "Web/WebStatus/WebStatus.csproj"
COPY "Web/WebhookClient/WebhookClient.csproj" "Web/WebhookClient/WebhookClient.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "Corpspace.sln"

COPY . .
WORKDIR "/src/Services/ChatSpace/ChatSpace.API"
RUN dotnet build "ChatSpace.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatSpace.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatSpace.API.dll"]
