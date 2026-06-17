//geleneksel koleksiyonlar tek threaded çalışır ve thread-safe değildir.  System.Collections.Concurrent namespace'i, thread-safe koleksiyonlar sağlar. Bu koleksiyonlar, çoklu thread'ler tarafından güvenli bir şekilde kullanılabilir ve performans açısından optimize edilmiştir.
using System.Collections.Concurrent;
using System.Linq;
#region ConcurrentBag<T>
//ConcurrentBag<int> numbers = new();

//Task producer1 = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Add(i);
//        await Console.Out.WriteLineAsync($"P1 : {i}");
//        await Task.Delay(500);
//    }
//});

//Task producer2 = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Add(i);
//        await Console.Out.WriteLineAsync($"P2 : {i}");
//        await Task.Delay(500);
//    }
//});


//Task consumer = Task.Run(async () =>
//{
//    while (true)
//    {
//        //koleksiyondan öğe almak için TryTake() metodu kullanılır. Bu metod, koleksiyondan bir öge almayı dener ve başarılı olursa true döner, aksi takdirde false döner.
//        if (numbers.TryTake(out int result))
//        {
//            await Console.Out.WriteLineAsync($"C : {result}");
//        }
//        else
//            await Task.Delay(500);
//    }
//});

//await Task.WhenAny(producer1,producer2, consumer);
#endregion
#region BlockingCollection<T>
//BlockingCollection<int> numbers = new();

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Add(i);
//        Console.WriteLine($"P : {i}");
//        await Task.Delay(500);
//    }
//Consumera haber vermek için CompleteAdding() metodu çağrılır. Bu metod, koleksiyona daha fazla öğe eklenmeyeceğini belirtir.
//    numbers.CompleteAdding();
//});

//Task consumer = Task.Run(() =>
//{
//    try
//    {
//        while (true)
//        {
//            int result = numbers.Take();
//            Console.WriteLine($"C : {result}");
//        }
//    }
//    catch (Exception ex)
//    {

//    }
//});

//await Task.WhenAny(producer, consumer);
//Console.Read();
#endregion
#region ConcurrentStack<T>
//ConcurrentStack<int> numbers = new();

//Task producer1 = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Push(i);
//        Console.WriteLine($"P1 : {i}");
//        await Task.Delay(100);
//    }
//});
//Task producer2 = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Push(i);
//        Console.WriteLine($"P2 : {i}");
//        await Task.Delay(200);
//    }
//});

//Task consumer = Task.Run(async () =>
//{
//    await Task.Delay(3000);
//    while (true)
//    {
//        if (numbers.TryPop(out int result))
//        {
//            Console.WriteLine($"C : {result}");
//            await Task.Delay(100);
//        }
//    }
//});

//await Task.WhenAny(producer1,producer2, consumer);

//Console.Read();
#endregion
#region ConcurrentQueue<T>
//ConcurrentQueue<int> numbers = new();

//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        numbers.Enqueue(i);
//        Console.WriteLine($"P : {i}");
//        await Task.Delay(100);
//    }
//});

//Task consumer = Task.Run(async () =>
//{
//    await Task.Delay(3000);
//    while (true)
//    {
//        if (numbers.TryDequeue(out int result))
//        {
//            Console.WriteLine($"C : {result}");
//            await Task.Delay(100);
//        }
//    }
//});

//await Task.WhenAny(producer, consumer);

//Console.Read();
#endregion
#region ConcurrentDictionary<TKey, TValue>
//ConcurrentDictionary<int, int> numbers = new();
//Task producer = Task.Run(async () =>
//{
//    for (int i = 0; i < 5; i++)
//    {
//        numbers[i] = i * 5;
//        Console.WriteLine($"P : '{i}' key'ine karşılık '{i * 5}' değeri verilmiş.");
//        await Task.Delay(100);
//    }
//});

//Task consumer = Task.Run(async () =>
//{
//    await Task.Delay(1000);
//    for (int i = 0; i < 5; i++)
//    {
//        Console.WriteLine($"C : '{i}' key'ine karşılık '{numbers[i]}' değeri okunmuştur.");
//        await Task.Delay(300);
//    }
//});

//await Task.WhenAny(producer, consumer);
//Console.Read();
#endregion