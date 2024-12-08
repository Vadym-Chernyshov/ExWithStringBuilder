using System.Text;

namespace ExWithStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool isRunningProgram = true;
            int countOfEvents = 0;
            //список подій
            StringBuilder events = new StringBuilder();
            //створюємо основне меню програми
            StringBuilder menu = new StringBuilder();
            menu.Append("Оберіть потрібну функцію:\n");
            menu.Append("1. Показати всі мої події\n");
            menu.Append("2. Створити подію\n");
            menu.Append("3. Вийти з програми");


            while (isRunningProgram)
            {                
                Console.WriteLine(menu);
                string inputNumberOfOperation = Console.ReadLine();

                if (int.TryParse(inputNumberOfOperation, out int operation) &&
                    (operation == 1 || operation == 2 || operation == 3))
                {
                    switch (operation)
                    {
                        case (int)ProgramFunction.DisplayEvents: //виводимо події
                            if (countOfEvents != 0)
                            {
                                Console.WriteLine(events);
                                Console.WriteLine();                                
                            }
                            else //коли немає жодний події
                            {
                                Console.WriteLine("Жодної події не створено");
                                Console.WriteLine();                                
                            }
                            break;
                        case (int)ProgramFunction.CreateEvent:
                            Console.WriteLine("Прохання ввести дату події у форматі YYYY-MM-DD");
                            Console.WriteLine();
                            string inputDate = Console.ReadLine();
                            if (DateTime.TryParse(inputDate, out DateTime parsedDate) && parsedDate <= DateTime.Now)
                            {
                                events.Append($"Подія номер {++countOfEvents}\n");
                                events.Append($"Дата {parsedDate.ToString("yyyy-MM-dd")}\n");

                                Console.WriteLine("Тепер опишіть подію");
                                //вважаємо що користувач обов'язково щось введе
                                string description = Console.ReadLine();

                                events.Append($"Опис події: {description}");
                            }
                            else
                            {
                                Console.WriteLine("Упс...Неправильний формат або дата\nСпробуйте знову");
                                Console.WriteLine();
                            }
                            break;
                        case (int)ProgramFunction.EndProgram:
                            isRunningProgram = false; //виходимо з програми
                            break;
                        default:
                            Console.WriteLine("Упс...щось пішло не так");
                            break;
                    }
                }
                else //некоректний вибір операції
                {
                    Console.WriteLine("Некоректний вибір операції\nСпробуйте знову");
                    Console.WriteLine();                    
                }
            }
        }
    }
    enum ProgramFunction
    {
        DisplayEvents = 1,
        CreateEvent,
        EndProgram
    }
}
