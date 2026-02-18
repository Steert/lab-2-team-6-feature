namespace task;
using System.Text;

class Menu
{
    private ScheduleManager manager = new ScheduleManager();

    public void Start()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        while (true)
        {
            Console.WriteLine("-----Головне меню-----");
            Console.WriteLine("1) Додати подію");
            Console.WriteLine("2) Показати список");
            Console.WriteLine("3) Перевірити конфлікти");
            Console.WriteLine("4) Сортувати список");
            Console.WriteLine("5) Видалити подію");
            Console.WriteLine("0) Вихід");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddEventFromConsole();
                    break;
                case "2":
                    manager.ShowEvents();
                    break;
                case "3":
                    manager.ShowConflicts();
                    break;
                case "4":
                    manager.Sort();
                    break;
                case "5":
                    manager.DeleteEventFromConsole();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Помилка.");
                    break;
            }
        }
    }
}