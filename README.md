## Задача
Требуется спроектировать модуль расчета доставки для интернет магазина. 
Модуль должен предоставлять возможность получить информацию о доставке двумя способами:

- одной конкретной службой
- всеми доступными службами

## Исходные данные
Используются 2 службы доставки:

#### Птичка
Принимает на вход следующие параметры:
- адрес отправителя 
- адрес получателя
- список элементов (для каждого вес, ШхГхВ)

Возвращает:
- стоимость доставки
- количество дней начиная с сегодняшнего

Или ошибку, если произвести расчет не удалось
        
#### Черепашка
Имеет базовую стоимость (например 150 рублей).
Принимает на вход следующие параметры:
- адрес отправителя 
- адрес получателя
- список элементов (для каждого вес, ШхГхВ, кол-во)
         
Возвращает:
- коэффициент стоимости (конечная цена доставки рассчитывается как произведение базовой стоимости на коэффициент)
- дата доставки

