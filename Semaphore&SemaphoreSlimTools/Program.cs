//kritik bölgelere belirli sayıda thread 'in erişmesine izin veren bir yapıdır. Semaphore, belirli bir sayıda thread'in aynı anda belirli bir kaynağa erişmesine izin verirken, SemaphoreSlim ise daha hafif bir sürümüdür ve genellikle tek işlemci ortamlarında kullanılır. Her iki yapı da thread'lerin birbirlerini engellemesini önlemek ve kaynakların verimli kullanımını sağlamak için kullanılır.
#region Semaphore
//List<int> numbers = new();
// Maksimum 4 thread'in aynı anda erişebileceği, başlangıçta 3 thread'in erişimine izin verilen bir Semaphore oluşturuyoruz.
//Semaphore semaphore = new(2, 3);
//Thread thread1 = new(() =>
//{
//    semaphore.WaitOne();
//    int i = 0;
//    while (i < 10)
//    {
//        Console.WriteLine($"Thread1 {++i}");
//        numbers.Add(i);
//        Thread.Sleep(1000);
//    }
//    semaphore.Release();
//});
//Thread thread2 = new(() =>
//{
//    semaphore.WaitOne();
//    int i = 10;
//    while (i < 20)
//    {
//        Console.WriteLine($"Thread2 {++i}");
//        numbers.Add(i);
//        Thread.Sleep(1500);
//    }
//    semaphore.Release();
//});
//Thread thread3 = new(() =>
//{
//    semaphore.WaitOne();
//    int i = 20;
//    while (i < 30)
//    {
//        Console.WriteLine($"Thread3 {++i}");
//        numbers.Add(i);
//        Thread.Sleep(2000);
//    }
//    semaphore.Release();
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion
#region SemaphoreSlim
List<int> numbers = new();
using SemaphoreSlim semaphoreSlim = new(1, 3);
Thread thread1 = new(() =>
{
    // En fazla 100 ms boyunca semaphore izni bekler. İzin alınırsa Wait true döner, alınamazsa false döner. Bu örnekte dönüş değeri kontrol edilmediği için thread her durumda çalışmaya devam eder.
    semaphoreSlim.Wait(100);
    int i = 0;
    while (i < 10)
    {
        Console.WriteLine($"Thread1 {++i}");
        numbers.Add(i);
        Thread.Sleep(100);
    }
    semaphoreSlim.Release();
});

//izin süresinin kontrol edilmesi, thread'in belirli bir süre boyunca kaynak erişimi için beklemesini sağlar. Eğer izin alınamazsa, thread alternatif bir işlem yapabilir veya hata mesajı verebilir. Bu, uygulamanın daha esnek ve kullanıcı dostu olmasını sağlar.
//if (semaphoreSlim.Wait(100))
//{
//    try
//    {
//        int i = 0;
//        while (i < 10)
//        {
//            Console.WriteLine($"Thread1 {++i}");
//            numbers.Add(i);
//            Thread.Sleep(100);
//        }
//    }
//    finally
//    {
//        semaphoreSlim.Release();
//    }
//}
//else
//{
//    Console.WriteLine("İzin alınamadı.");
//}
Thread thread2 = new(() =>
{

     semaphoreSlim.Wait(1000);
    int i = 10;
    while (i < 20)
    {
        Console.WriteLine($"Thread2 {++i}");
        numbers.Add(i);
        Thread.Sleep(100);
    }
    semaphoreSlim.Release();
});
Thread thread3 = new(() =>
{
    semaphoreSlim.Wait(5000);
    int i = 20;
    while (i < 30)
    {
        Console.WriteLine($"Thread3 {++i}");
        numbers.Add(i);
        Thread.Sleep(100);
    }
    semaphoreSlim.Release();
});
thread1.Start();
thread2.Start();
thread3.Start();

thread1.Join();
thread2.Join();
thread3.Join();

semaphoreSlim.Dispose();

//SemaphoreSlim veya Semaphore kullanırken using ifadesi veya manuel olarak Dispose çağrısı yapmak önemlidir.
//semaphoreSlim.Dispose();
#endregion