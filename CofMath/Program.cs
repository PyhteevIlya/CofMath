using CofMath.Models;
using System.Diagnostics;
//using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace CofMath
{
    class Program
    {

        static void Main(string[] args)
        {
            //Хранилище
            int groundCoffee = 10;
            int water = 10;
            int milk = 20;
            int sugar = 20;
            int cup = 3;
            int price = 0;
            bool successPrice = false;
            int choicePay = 0;
            int handing = 1000;

            //Дополнительно
            int addMilk = 0;
            bool successMilk = false;
            int addSugar = 0;
            bool successSugar = false;
            int sum = 0;

            //Выбор кофе
            int choice;
            bool success = false;


            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                while (groundCoffee >= 1 && water >= 1 && milk >= 3 && sugar >= 3 && cup >= 1 && handing >= 200)
                {
                    price = 0;
                    Console.WriteLine("Добро пожаловать, \nВыберите номер кофе который Вы хотите: \n1)Американо 15 рублей \n2)Экспрессо 30 рублей \n3)Латте 25 рублей \n4)Каппучино 20 рублей");
                    for (; ; )
                    {
                        success = int.TryParse(Console.ReadLine(), out choice);
                        if (success = true && choice > 0 && choice <= 4)
                        { break; }
                        else { Console.WriteLine("Вы ввели неверный символ"); };
                    };


                    Console.WriteLine("Введите количество сахара которое хотите добавить (от 0 до 3), введите 0 если не хотите добавлять");

                    for (; ; )
                    {
                        successSugar = int.TryParse(Console.ReadLine(), out addSugar);
                        if (successSugar = true && addSugar >= 0 && addSugar <= 3)
                        { break; }
                        else { Console.WriteLine("Вы ввели неверный символ"); };
                    };

                    Console.WriteLine("Введите количество молока которое хотите добавить (от 0 до 2), введите 0 если не хотите добавлять");

                    for (; ; )
                    {
                        successMilk = int.TryParse(Console.ReadLine(), out addMilk);
                        if (successMilk = true && addMilk >= 0 && addMilk <= 2)
                        { break; }
                        else { Console.WriteLine("Вы ввели неверный символ"); };
                    };

                    if (choice == 1)
                    {
                        cup = cup - 1;
                        groundCoffee = groundCoffee - 1;
                        water = water - 2;
                        sugar = sugar - addSugar;
                        milk = milk - 0 - addMilk;

                        price = 15;

                        Payment(ref price, ref handing);

                        var americano = new Coffee(1, 2, 0 + addMilk, price);
                        var americanoStorage = new Storage(cup, groundCoffee, water, sugar, milk, handing);
                        
                        db.Coffee.Add(americano);
                        db.Storage.Add(americanoStorage);
                        db.SaveChanges();

                        Console.WriteLine("ok");
                    }
                    if (choice == 2)
                    {
                        cup = cup - 1;
                        groundCoffee = groundCoffee - 1;
                        water = water - 1;
                        sugar = sugar - addSugar;
                        milk = milk - 0 - addMilk;

                        price = 30;

                        Payment(ref price, ref handing);

                        var espresso = new Coffee(1, 1, 0 + addMilk, price);
                        var espressoStorage = new Storage(cup, groundCoffee, water, sugar, milk, handing);

                        db.Coffee.Add(espresso);
                        db.Storage.Add(espressoStorage);
                        db.SaveChanges();

                        Console.WriteLine("ok");
                    }
                    if (choice == 3)
                    {
                        cup = cup - 1;
                        groundCoffee = groundCoffee - 1;
                        water = water - 1;
                        sugar = sugar - addSugar;
                        milk = milk - 2 - addMilk;

                        price = 25;

                        Payment(ref price, ref handing);

                        var latte = new Coffee(1, 1, 2 + addMilk, price);
                        var latteStorage = new Storage(cup, groundCoffee, water, sugar, milk, handing);

                        db.Coffee.Add(latte);
                        db.Storage.Add(latteStorage);
                        db.SaveChanges();

                        Console.WriteLine("ok");
                    }
                    if (choice == 4)
                    {
                        cup = cup - 1;
                        groundCoffee = groundCoffee - 1;
                        water = water - 1;
                        sugar = sugar - addSugar;
                        milk = milk - 1 - addMilk;

                        price = 20;

                        Payment(ref price, ref handing);

                        var cappuccino = new Coffee(1, 1, 1 + addMilk, price);
                        var cappuccinoStorage = new Storage(cup, groundCoffee, water, sugar, milk, handing);

                        db.Coffee.Add(cappuccino);
                        db.Storage.Add(cappuccinoStorage);
                        db.SaveChanges();

                        Console.WriteLine("ok");
                    }

                }
                Console.WriteLine("Требуется пополнить запасы!!!!!");

            }
            int Payment(ref int price, ref int handing)
            {
                Console.WriteLine($"К оплате {price}");
                Console.WriteLine("Выберите способ оплаты: \n1)Наличные \n2)Оплата картой");

                for (; ; )
                {
                    successPrice = int.TryParse(Console.ReadLine(), out choicePay);
                    if (successPrice = true && choicePay > 0 && choicePay <= 2)
                    { break; }
                    else { Console.WriteLine("Вы ввели неверный символ"); };
                };
                if (choicePay == 1)
                {


                    Console.WriteLine("Введите сумму( В качестве оплаты принимаются монеты 1, 2, 5, 10 рублей. А также бумажные \r\nкупюры номиналом в 10, 50, 100, 200 рублей.)");

                    do
                    {
                        sum = sum + Convert.ToInt32(Console.ReadLine());
                        if (sum < price)
                        {
                            int lacking = price- sum;
                            Console.WriteLine($"Вам не хватает {lacking}");
                        }
                    }
                    while (sum < price) ;;
                    handing = handing + price - sum;
                    int handingClient = sum - price;
                    Console.WriteLine($"Ваша сдача {handingClient} \n Спасибо за покупку!!");
                }
                else { Console.WriteLine("Спасибо за покупку!!"); }

                return handing;
            }

        }
    }
}