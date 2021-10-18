FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "link.sln" "link.sln"

COPY "src/BuildingBlocks/EventBus/CommandBus/CommandBus.csproj" "src/BuildingBlocks/EventBus/CommandBus/CommandBus.csproj"
COPY "src/BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj" "src/BuildingBlocks/EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj"
COPY "src/BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj" "src/BuildingBlocks/EventBus/EventBusServiceBus/EventBusServiceBus.csproj"
COPY "src/BuildingBlocks/EventBus/EventBus/EventBus.csproj" "src/BuildingBlocks/EventBus/EventBus/EventBus.csproj"
COPY "src/BuildingBlocks/EventBus/EventBus.Tests/EventBus.Tests.csproj" "src/BuildingBlocks/EventBus/EventBus.Tests/EventBus.Tests.csproj"
COPY "src/BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj" "src/BuildingBlocks/EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj"
COPY "src/Services/Account/Account.API/Account.API.csproj" "src/Services/Account/Account.API/Account.API.csproj"
COPY "src/Services/Account/Account.FunctionalTests/Account.FunctionalTests.csproj" "src/Services/Account/Account.FunctionalTests/Account.FunctionalTests.csproj"
COPY "src/Services/Account/Account.UnitTests/Account.UnitTests.csproj" "src/Services/Account/Account.UnitTests/Account.UnitTests.csproj"
COPY "src/Services/Chat/Chat.API/Chat.API.csproj" "src/Services/Chat/Chat.API/Chat.API.csproj"
COPY "src/Services/Contact/Contact.SignalrHub/Contact.SignalrHub.csproj" "src/Services/Contact/Contact.SignalrHub/Contact.SignalrHub.csproj"
COPY "src/Services/Contact/Contact.API/Contact.API.csproj" "src/Services/Contact/Contact.API/Contact.API.csproj"
COPY "src/Services/Contact/Contact.FunctionalTests/Contact.FunctionalTests.csproj" "src/Services/Contact/Contact.FunctionalTests/Contact.FunctionalTests.csproj"
COPY "src/Services/Contact/Contact.UnitTests/Contact.UnitTests.csproj" "src/Services/Contact/Contact.UnitTests/Contact.UnitTests.csproj"
COPY "src/Services/Download/Download.API/Download.API.csproj" "src/Services/Download/Download.API/Download.API.csproj"
COPY "src/Services/File/File.API/File.API.csproj" "src/Services/File/File.API/File.API.csproj"
COPY "src/Services/File/File.Domain/File.Domain.csproj" "src/Services/File/File.Domain/File.Domain.csproj"
COPY "src/Services/File/File.Infrastructure/File.Infrastructure.csproj" "src/Services/File/File.Infrastructure/File.Infrastructure.csproj"
COPY "src/Services/Identity/Identity.Administration/Identity.Administration.csproj" "src/Services/Identity/Identity.Administration/Identity.Administration.csproj"
COPY "src/Services/Identity/Identity.API/Identity.API.csproj" "src/Services/Identity/Identity.API/Identity.API.csproj"
COPY "src/Services/Message/Message.API/Message.API.csproj" "src/Services/Message/Message.API/Message.API.csproj"
COPY "src/Services/Upload/Upload.API/Upload.API.csproj" "src/Services/Upload/Upload.API/Upload.API.csproj"
COPY "src/Web/WebMVC/WebMVC.csproj" "src/Web/WebMVC/WebMVC.csproj"


COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "link.sln"

COPY . .
WORKDIR /src/src/Services/Chat/Chat.API
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chat.API.dll"]