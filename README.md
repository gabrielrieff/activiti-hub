# Descrição Geral do Serviço

O serviço de notificações escuta eventos de mudança de status de tarefas via RabbitMQ e envia notificações em tempo real aos usuários conectados via SignalR.

## 🏗 Arquitetura do Projeto

| **Camada**      | **Pasta**      | **Responsabilidade**                                                                                                                                                                                                                       |
| --------------- | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **API**         | `Apli/`        | - Controllers (ex: Webhooks, endpoints REST) <br> - Configurações iniciais (`Program.cs`) <br> - Hubs SignalR                                                                                                                              |
| **Application** | `Application/` | - Casos de uso (UseCases) <br> - Lógica de orquestração de negócio <br> - Interfaces de entrada                                                                                                                                            |
| **Repository**  | `Repository/`  | - Interfaces e abstrações (ex: `INotificationRepository`, `INotificationDispatcherRepository`) <br>                                                                                                                                        |
| **Services**    | `Services/`    | - Implementações das abstrações da camada de `Domain` <br> - Acesso ao MongoDB (ex: `MongoNotificationRepository`) <br> - Integração com RabbitMQ (ex: `RabbitMqMessageConsumer`) <br> - Serviço SignalR (`SignalRNotificationDispatcher`) |
| **Hubs**        | `Hubs/`        | - Implementações do SignalR <br> - Abortura de Eventos                                                                                                                                                                                     |
| **Models**      | `Models/`      | - Entidades e modelos de comunicação                                                                                                                                                                                                       |

## 🔁 Integração e Comunicação

| **Componente**            | **Tecnologia**    | **Responsabilidade**                                             |
| ------------------------- | ----------------- | ---------------------------------------------------------------- |
| **MongoDB**               | MongoDB           | Armazenamento das notificações persistentes                      |
| **SignalR**               | SignalR (.NET)    | Comunicação em tempo real com o frontend                         |
| **RabbitMQ**              | RabbitMQ (Docker) | Receber eventos de outras aplicações via filas                   |
| **Frontend (React + TS)** | SignalR JS Client | Conectar ao Hub e escutar/em disparar eventos (ex: `MarkAsRead`) |

---

## ⚙️ Fluxo de Notificação

1. 🛠 **Backend Principal**  
   → Publica evento `task-status-updated` no RabbitMQ.

2. 📥 **RabbitMqMessageConsumer**  
   → Consome evento da fila, deserializa e executa envio.

3. 📤 **SignalRNotificationDispatcher**  
   → Envia notificação em tempo real ao frontend conectado.

4. 🖥 **Frontend (React)**  
   → Escuta evento via SignalR e exibe notificação.

5. ✅ **Marcar como lida**  
   → Frontend dispara `MarkAsReadNotification` via SignalR, que atualiza o MongoDB.

---

## 📌 Tecnologias Utilizadas

- .NET 8
- SignalR
- RabbitMQ
- MongoDB

## Configurações do Serviço

> 📁 appsettings

       "Mongo": {
        "ConnectionString": "SuaConnectionString",
        "Database": "SeuDataBase"
       },
       "RabbitMQ": {
        "ConnectionString": "SuaConnectionString"
       }
