//signsllig. bir threadin bir işi yapıp diğer threadlere o işin yapıldığını ve işlemlerin devam etmesi gerektiğini bildirmek için kullanılan bir senkronizasyon mekanizmasıdır.
#region AutoResetEvent

//AutoResetEvent(false) başlangıçta non-signaled durumdadır. WaitOne() çağıran thread'ler bloke edilir. Set() çağrıldığında bekleyen thread'lerden yalnızca biri serbest bırakılır ve event otomatik olarak tekrar non-signaled duruma döner. Bu nedenle AutoResetEvent, thread'ler arasında tek tek sinyal iletmek ve sırayla ilerleme sağlamak için kullanılı. Turinke mantığı vardır. Set() çağrıldığında sıradaki bekleyen thread serbest bırakılır ve diğerleri beklemeye devam eder. Bu yapı, thread'lerin belirli bir sırayla çalışmasını sağlamak için kullanışlıdır. her geçişte işlem sıfırlanır.

//örnekte threadlerin her zaman 1,2,3 şeklinde çalışmasını garanti altına alıyoruz.
//AutoResetEvent autoResetEvent = new(false);
//Thread thread1 = new(() =>
//{
//    Console.WriteLine("Thread1");
//    autoResetEvent.Set();//diğer threadlerin çalışması için sinyal gönderilir.
//});
//Thread thread2 = new(() =>
//{
//    autoResetEvent.WaitOne();//thread1'in sinyalini bekler. Sinyal geldiğinde thread2 çalışır.
//    Console.WriteLine("Thread2");
//    autoResetEvent.Set();
//});
//Thread thread3 = new(() =>
//{
//    autoResetEvent.WaitOne();
//    Console.WriteLine("Thread3");
//    autoResetEvent.Set();
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion
#region ManualResetEventSlim
//sinyal verildiğinde sinyali alan tüm threadler işlem yapabilir hale gelir. burada ilk  Thread1 çalışır ancak 2 ve 3ün sırasın garanti edilemez
//ManualResetEventSlim manualResetEventSlim = new(false);
//Thread thread1 = new(() =>
//{
//    Console.WriteLine("Thread1");
//    manualResetEventSlim.Set();
//});
//Thread thread2 = new(() =>
//{
//    for (int i = 0; i < 5; i++)
//    {
//        manualResetEventSlim.Wait();
//        Console.WriteLine("Thread2");
//        manualResetEventSlim.Reset();
//    }
//});
//Thread thread3 = new(() =>
//{
//    manualResetEventSlim.Wait();
//    for (int i = 0; i < 5; i++)
//    {
//        manualResetEventSlim.Wait();
//        Console.WriteLine("Thread3");
//        manualResetEventSlim.Reset();
//    }
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion
#region EventWaitHandle
//iki ypıyı bir arada kullanmamaıza olanak sağlar. EventWaitHandle, AutoResetEvent ve ManualResetEvent'un birleşimi gibi çalışır. EventWaitHandle, AutoResetEvent gibi tek tek sinyal iletmek veya ManualResetEvent gibi tüm thread'leri serbest bırakmak için kullanılabilir.
//EventWaitHandle eventWaitHandle = new(false, EventResetMode.AutoReset);
//EventWaitHandle eventWaitHandle = new(false, EventResetMode.ManualReset);
//Thread thread1 = new(() =>
//{
//    Console.WriteLine("Thread1");
//    eventWaitHandle.Set();
//});
//Thread thread2 = new(() =>
//{
//    eventWaitHandle.WaitOne();
//    Console.WriteLine("Thread2");
//});
//Thread thread3 = new(() =>
//{
//    eventWaitHandle.WaitOne();
//    Console.WriteLine("Thread3");
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion
#region CountdownEvent
// 3 adet threadin işlemini tamamlamasını bekliyoruz. CountdownEvent, belirli bir sayıda sinyal bekleyen bir senkronizasyon mekanizmasıdır. CountdownEvent, başlangıçta belirli bir sayıda sinyal bekler ve her sinyal geldiğinde sayacı azaltır. Sayaç sıfıra ulaştığında, CountdownEvent sinyali verir ve bekleyen thread'ler serbest bırakılır. Bu yapı, belirli bir sayıda işlemin tamamlanmasını beklemek için kullanışlıdır.
//CountdownEvent countdownEvent = new(3);

//Thread thread1 = new(() =>
//{
//    Console.WriteLine("Thread1");
//    Thread.Sleep(1000);
//    countdownEvent.Signal();
//});
//Thread thread2 = new(() =>
//{
//    Console.WriteLine("Thread2");
//    Thread.Sleep(5500);
//    countdownEvent.Signal();
//});
//Thread thread3 = new(() =>
//{
//    Console.WriteLine("Thread3");
//    Thread.Sleep(800);
//    countdownEvent.Signal();
//});
//Thread thread4 = new(() =>
//{
//    countdownEvent.Wait();
//    Console.WriteLine("Thread4");
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
//thread4.Start();

//countdownEvent.Wait();
//Console.WriteLine("İşlem devam ediyor...");
#endregion