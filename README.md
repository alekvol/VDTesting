# VDTesting
*Тестовое приложения для работы с Kafka и Docker*

ASP.net приложении "ProducerService - отправляет JSON в брокер

Консольное приложение "ConsumerApp" - получает из брокера сообщение в формате JSON
## Запуск приложения
Запустите приложение через docker-compose файл 

Создайте топик в Kafka (в контейнере с кафкой) с именем `registrations` с помощью команды :
```
kafka-topics.sh --create --topic registrations --bootstrap-server localhost:9092
```
***Enjoy!!!*** :+1:
