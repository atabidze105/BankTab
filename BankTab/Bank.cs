using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTab
{
    public class Bank
    {
        private int? _nom;//Номер счета пользователя
        private string _name;//ФИО пользователя
        private float _sum = 0;//Сумма на счету
        private float _transaction; //Поле для пополнения счет
        private int _option;
        private int _nomTransaction;

        private void accountOpening(int nom, string name, float sum) //Открытие счета
        {
            _nom = nom;
            _name = name;
            _sum = sum;
            Console.WriteLine("Счет открыт успешно.");
        }

        private void displayInfo() //Вывод информации
        {
            Console.WriteLine($"Номер счета: {_nom}.\nИмя клиента: {_name}.\nСумма денег на счету: {_sum}.");
        }

        private void replenishment(float sum)//Пополнение счета
        {
            _sum += sum; //Пополнение счета
            Console.WriteLine($"Пополнение завершено успешно. Текущая сумма на счету: {_sum}.");
        }

        private void withdrawal(float sum)//Снятие средств со счета
        {
            if (sum <= _sum)//Если снимаемая сумма не превышает счет, то она снимается
            {
                _sum -= sum;//Снятие средств со счета
                Console.WriteLine($"Снятие завершено успешно. Текущая сумма на счету: {_sum}.");
            }
            else
            {
                Console.WriteLine("Невозможно снять со счета сумму большую, чем сам счет.");
            }
        }

        private void nullification() //Обнуление счета
        {
            if (_sum > 0) //Если счет больше и не равен нулю, то происходит обнуление
            {
                _sum = 0;
                Console.WriteLine("Счет успешно обнулен.");
            }
            else
            {
                Console.WriteLine("Невозможно обнулить счет.");
            }
        }

        private void transaction(Bank bank) //Перевод средств с одного счета на другой
        {
            if (bank != null)//Проверка на наличие объекта-адресата
            {
                Console.WriteLine($"Введите сумму, которую хотите перевести со счета {_nom} на счет {bank._nom}:");
                _transaction = bank._transaction = float.Parse(Console.ReadLine());
                if (_transaction <= _sum)//Если снимаемая сумма не превышает счет, то она снимается
                {
                    _sum -= _transaction;//Снятие средств со счета отправителя
                    bank._sum += bank._transaction; //Пополнение счета адресата
                    Console.WriteLine("Транзакция успешно завершена.");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете отправителя.");
                }
            }
            else
            {
                Console.WriteLine("Адресат задан некорректно.");
            }
        }

        private Bank searchingByID(Bank[] accs, int nom) //Поиск объекта для проведения операции транзакции
        {
            foreach (Bank bank in accs) //Перебор объектов в массиве
            {
                if (bank._nom == nom) //Проверка элемента массива на соответствие искомому номеру
                {
                    return bank; //Возврат искомого элемента массива
                }
            }
            return null;    //Если объект не был найден, вернется пустое значение
        }

        public void callCenter(Bank[] banks) //Метод для обращения к другим методам
        {
            if (_nom == null) //Если поле номера счета пустое, то объекту присваиваются значения
            {
                Console.WriteLine("\nНеобходимо открыть счет чтобы продолжить.\nВведите номер счета:");
                int accNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите ФИО:");
                string accName = Console.ReadLine();
                if (accName == "")
                {
                    Console.WriteLine("ФИО введено некорректно.\n");
                    return;
                }
                Console.WriteLine("Введите сумму денег на счету:");
                float accMoney = float.Parse(Console.ReadLine());
                accountOpening(accNumber, accName, accMoney);
            }
            if (_nom != null)
            {
                Console.WriteLine($"\nДобро пожаловать в личный кабинет, {_name}!\nКакой услугой Вы бы хотели воспользоваться?\n\n");
                string continuation = ""; //Пока строка пуста, выполняется следующий цикл
                do
                {
                    Console.WriteLine(" Чтобы узнать информацию о счете, выберите \"1\".\n Чтобы пополнить счет, выберите \"2\".\n Чтобы снять сумму со счета, выберите \"3\".\n Чтобы обнулить счет, выберите \"4\".\n Чтобы перевести деньги на другой счет, выберите \"5\".\n");
                    _option = Convert.ToInt32(Console.ReadLine());

                    switch (_option)//Выбор операции
                    {
                        case 1: //Вывод информации
                            Console.WriteLine("\n");
                            displayInfo();
                            break;
                        case 2: //Пополнение
                            Console.WriteLine("\nВведите сумму, на которую хотите пополнить счет:"); ;
                            replenishment(float.Parse(Console.ReadLine()));
                            break;
                        case 3:  //Снятие средств
                            Console.WriteLine("\nВведите сумму, которую хотите снять со счета:");
                            withdrawal(float.Parse(Console.ReadLine()));
                            break;
                        case 4://Обнуление
                            Console.WriteLine("\n");
                            nullification();
                            break;
                        case 5: //Перевод
                            Console.WriteLine("\n");
                            Console.WriteLine("Введите номер счета, на который хотите совершить перевод:");
                            _nomTransaction = Convert.ToInt32(Console.ReadLine());
                            if (_nomTransaction != _nom)
                            {
                                transaction(searchingByID(banks, _nomTransaction));
                            }
                            else
                            {
                                Console.WriteLine("Невозможно перевести средства на свой же счет.");
                            }
                            break;
                        default:
                            Console.WriteLine("\nВведено некорректное значение.");
                            break;
                    }
                    Console.WriteLine("\nЧтобы продолжить нажмите \"Enter\".");
                    continuation = Console.ReadLine();
                } while (continuation == "");
            }
            //else
            //{
            //    Console.WriteLine("Аккаунт создан некорректно.");
            //}
        }
    }

}
