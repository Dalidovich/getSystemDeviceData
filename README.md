# PC Hardware Information Collector

Проект представляет собой консольное приложение на C#, которое собирает информацию о конфигурации оборудования компьютера с помощью WMI (Windows Management Instrumentation) и сохраняет её в текстовый файл.

## Функциональность

Приложение выполняет следующие команды PowerShell через WMI и сохраняет их вывод:

1. Информация о материнской плате (производитель и модель)
2. Данные о процессоре (название)
3. Сведения о видеокарте (название)
4. Информация о жестких дисках (модель, описание, размер)
5. Данные об оперативной памяти (партномер, объем, частота)

## Установка и запуск

1. Склонируйте репозиторий или скачайте исходный код
2. Скомпилируйте проект с помощью .NET SDK:
