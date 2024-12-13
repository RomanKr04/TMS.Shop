using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Занятие_1._4.Models;

namespace Занятие_1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balance = 500;
            bool flag = false;
            var products = new List<Product>()
            {
                new Product("Сыр", 100, 3),
                new Product("Хлеб", 30, 2),
                new Product("Яблоки", 50, 4)
            };

            Console.WriteLine("Добро пожаловать в магазин!");
            while (!flag)
            {
                if(balance<=0)
                {
                    Console.WriteLine("Вы истратили все монеты, Спасибо за покупку!");
                    break;
                }
                Console.WriteLine($"\nВаш баланс: {balance} монет.");
                Console.WriteLine("Меню выбора: \n 1. Посмотреть наличие товара\n 2. Приобрести товар\n 3. Выход из программы");
                int choseNum = Convert.ToInt32(Console.ReadLine());

                switch (choseNum)
                {
                    case 1: 
                        Console.WriteLine("Товары в наличии:");
                        for (int i = 0; i < products.Count; i++)
                        {
                            var product = products[i];
                            Console.WriteLine($"{i + 1}. Наименование: {product.Name}, Цена: {product.Price}, Количество: {product.Quantity}");
                        }
                        break;

                    case 2: 
                        Console.WriteLine("Выберите товар по номеру:");
                        for (int i = 0; i < products.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {products[i].Name}");
                        }

                        int choseNum2 = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (choseNum2 >= 0 && choseNum2 < products.Count)
                        {
                            var selectedProduct = products[choseNum2];
                            if (balance >= selectedProduct.Price && selectedProduct.Quantity > 0)
                            {
                                balance -= selectedProduct.Price;
                                selectedProduct.Quantity--;
                                Console.WriteLine($"Вы купили {selectedProduct.Name}. Остаток баланса: {balance} монет.");
                            }
                            else if (selectedProduct.Quantity == 0)
                            {
                                Console.WriteLine("Этот товар закончился.");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно средств для покупки.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор.");
                        }
                        break;

                    case 3: 
                        flag = true;
                        Console.WriteLine("Спасибо за визит! До свидания!");
                        Console.WriteLine($"Ваш остаток {balance} монет");
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}