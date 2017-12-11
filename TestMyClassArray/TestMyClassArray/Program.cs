using System;
using KLogger;
using Array = KVector.Array.Array;

namespace TestMyClassArray
{
    class Program
    {
        static void Main()
        {
            Logger log = new Logger("Main");
            log.Log("Запущенно програму", LoggerLevel.Debug);

            Random rand = new Random();
            try
            {
                Array firstArray = new Array(2, 8);
                Array secondArray = new Array(2, 8);

                for (int i = 0; i < firstArray.Count; i++)
                {
                    firstArray.Add(rand.Next(0, 100));
                    secondArray.Add(rand.Next(0, 100));
                }

                log.Log("Створено два вектора A i B. " +
                        $"Перший векртор(A): {firstArray.ToString()} Довжина={firstArray.Count} Крок={firstArray.Step};" +
                        $"Другий векртор(B): {secondArray.ToString()} Довжина={secondArray.Count} Крок={secondArray.Step};"
                    , LoggerLevel.Info);
               Console.WriteLine(
                   $"Перший векртор(A):\n {firstArray.ToString()} Довжина={firstArray.Count} Крок={firstArray.Step};" +
                   $"\nДругий векртор(B):\n {secondArray.ToString()} Довжина={secondArray.Count} Крок={secondArray.Step};");
                try
                {
                    log.Log("Поелементне додавання​ ​векторів A i B", LoggerLevel.Debug);
                    var resultVector = firstArray + secondArray;
                    Console.WriteLine($"Сума векторiв(A+B):\n {resultVector.ToString()}");
                    log.Log($"Сума векторiв(A+B): {resultVector.ToString()}", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Вектори не вдалось додати!", LoggerLevel.Error);
                }
                try
                {
                    log.Log("Віднімається від  вектора A  вектор B", LoggerLevel.Debug);
                    var resultVector = firstArray - secondArray;
                    Console.WriteLine($"Рiзниця векторiв(A-B):\n {resultVector.ToString()}");
                    log.Log($"Рiзниця векторiв(A-B): {resultVector.ToString()};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Вектори не вдалось відняти!", LoggerLevel.Error);
                }
                try
                {
                    int h = 2;
                    log.Log($"Mноження​ всiх​ елементiв​ масиву​ на​ ​{h}", LoggerLevel.Debug);
                    var resultVector = firstArray * h;
                    Console.WriteLine($"Mноження всix елементiв масиву нa {h}:\n {resultVector}");
                    log.Log($"Добуток вектора(A*{h}): {resultVector};", LoggerLevel.Info);
                }
                catch (Exception)
                {
                    log.Log("Не вдалось помножити вектор на скаляр!", LoggerLevel.Error);
                }
                Console.WriteLine(
                    $"Порiвняння векторiв (А==B)={firstArray.Equals(secondArray)} (А==A)={firstArray.Equals(firstArray)}.");
                int b = 15;
                try
                {
                    Console.WriteLine($"A[{b - 1}]={firstArray.GetValue(b - 1)}");
                }
                catch (Exception)
                {
                    log.Log($"A[{ b - 1}]iндекс вийшов за межі!", LoggerLevel.Error);
                    Console.WriteLine($"A[{b-1}]iндекс вийшов за межі!");
                }
                try
                {
                    Console.WriteLine($"A[{b}]={firstArray.GetValue(b)}");
                }
                catch (Exception)
                {
                    log.Log($"A[{b}] iндекс вийшов за межi", LoggerLevel.Error);
                    Console.WriteLine($"A[{b}] iндекс вийшов за межi");
                }
            }
            catch (Exception ex)
            {
                log.Log($"Винекла помилка в роботі програми({ex.Message})", LoggerLevel.Fatal);
            }



            Console.ReadKey();
        }
    }
}
