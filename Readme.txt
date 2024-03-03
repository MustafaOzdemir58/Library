Powershell commands for create rabbitmq instance

- Pulling rabbitmq image from docker:
docker pull rabbitmq:3.13.0-management

-Run rabbitmq image as container:
 docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3.13.0-management