//threadleri kontrol etmeyi amaçlar, belirli bir t anında tüm threadlerin belirli bir noktaya gelmesini bekler, tüm threadler o noktaya gelene kadar bekler, tüm threadler o noktaya gelince devam eder
// 3 adet threadden aksiyon bekleneceği belirttik. ikinci parametre olarak bir callback fonksiyonu verdik, bu fonksiyon tüm threadler belirli bir noktaya geldiğinde çalışır, bu örnekte sadece "barrier reached" yazdırır
Barrier barrier = new(3, _ => Console.WriteLine("barrier reached"));

Thread thread1 = new(() =>
{
    for (int i = 0; i < 5; i++)
        Console.WriteLine($"Thread 1.1 - {i} ");

    // thread1, thread2 ve thread3'ün belirli bir noktaya gelmesini bekler, tüm threadler o noktaya gelene kadar bekler, tüm threadler o noktaya gelince devam eder
    barrier.SignalAndWait();

    for (int i = 0; i < 3; i++)
        Console.WriteLine($"Thread 1.2 - {i} ");
});

Thread thread2 = new(() =>
{
    for (int i = 0; i < 3; i++)
        Console.WriteLine($"Thread 2.1 - {i} ");

    barrier.SignalAndWait();

    for (int i = 0; i < 2; i++)
        Console.WriteLine($"Thread 2.2 - {i} ");
});

Thread thread3 = new(() =>
{
    for (int i = 0; i < 4; i++)
        Console.WriteLine($"Thread 3.1 - {i} ");

    barrier.SignalAndWait();

    for (int i = 0; i < 5; i++)
        Console.WriteLine($"Thread 3.2 - {i} ");
});
thread1.Start();
thread2.Start();
thread3.Start();