using BankTab;
class Program
{
    static void Main()
    {
        void accountChoshing(Bank[] banks, int quantity) //Метод для выбора из массива объекта для применения метода
        {
            int nom = -1;
            Console.WriteLine("\nНеобходимо выбрать счет чтобы продолжить.");
            while (nom > banks.Length || nom < 0)
            {
                Console.WriteLine($"Введите один из доступных номеров:\n\nот 1 до {quantity}:\n");
                nom = Convert.ToInt32(Console.ReadLine()); //Выбор индекса элемента массива
                if (nom > 0)
                {
                    if (nom <= banks.Length)
                    {
                        banks[nom - 1].callCenter(banks);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Введите значение в заданом диапазоне.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. Введите значение в заданом диапазоне.\n");
                }
            }
        }
        
        Console.WriteLine("Чтобы начать работу, необходимо задать количество счетов.\nВведите количество аккаунтов, которое хотите создать:\n");
        int quantityOfAccounts = Convert.ToInt32(Console.ReadLine());
        Bank[] accounts = new Bank[quantityOfAccounts];
        for (int i = 0; i < accounts.Length; i++) //Цикл для создания элементов массива
        {
            accounts[i] = new Bank();
        }

        accountChoshing(accounts, quantityOfAccounts); //Первое обращение к методу        
        
        Console.WriteLine("\nЧтобы вернуться к выбору аккаунта, нажмите \"Enter\".\nЧтобы выйти напишите что-нибудь и нажмите \"Enter\".\n");
        string thisAccount = ""; //Переменная для поддержания работы следующего цикла
        thisAccount = Console.ReadLine();

        if (thisAccount == "")
        {
            do
            {
                accountChoshing(accounts, quantityOfAccounts);
                Console.WriteLine("\nЧтобы вернуться к выбору аккаунта, нажмите \"Enter\".\nЧтобы выйти напишите что-нибудь и нажмите \"Enter\".\n");
                thisAccount = Console.ReadLine();
            } while (thisAccount == ""); //Метод работает пока строка пуста
        }
    }
}