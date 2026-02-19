
### Core - Кущенко Данило
---
#### Як перевітири List через enumerator:  
*2 пункт меню* - метод `ShowEvents()`

    var enumerator = schedule.GetEnumerator();  
    while (enumerator.MoveNext())  
    {  
        Console.WriteLine(enumerator.Current);  
    }
---
#### Sort default:
*4 пункт меню* - метод `Sort()`

За допомогою інтерфейсу `IComparable` використовувується метод `Array.Sort(array)`. При цьому сортуванні спочатку відображаються найбільш близькі задачі за часом;

---
#### Alternative sort:
*5 пункт меню* - метод `DecreasingSort()`

За допомгою інтерфейсу `IComparer` додається спосіб сортування(клас `DecreasingTimeComparer`) до `Array.Sort(array, Comparer)`. При цьому сортуванні спочатку відображаються найбільш віддалені задачі за часом;

---
#### Stats: 

*7 пункт меню* - метод `GetReport()`

Метод повертає кількість доданих задач;

### QA - Лозінський Микита
---
#### Як запустити тести:
У консолі написати команду *dotnet test*
