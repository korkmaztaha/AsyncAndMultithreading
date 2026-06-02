#region Thread Sınıfı
//class Program
//{
//    private static void Main(string[] args)
//    {
//        //Bilinçli şekilde Worker Thread oluşturma
//        Thread thread = new((o) =>
//        {
//            for (int i = 0; i < 999; i++)
//            {
//                Console.WriteLine($"Worker Thread {i}");
//            }
//        });

//        // oluşuturulan thread'i başlatma. Main thread ve worker thread birbirinden bağımsız olarak çalışır. 
//        thread.Start();
//        for (int i = 0; i < 999; i++)
//        {
//            Console.WriteLine($"Main Thread {i}");
//        }
//    }


//}
#endregion
#region Thread Id
//Takip edilebilirlik için kullanılılabilir. Bug fixing sırasında hangi thread'in hangi işlemi yaptığını görebilmek için kullanılır.
//class Program
//{
//    private static void Main(string[] args)
//    {
//        Console.WriteLine("Main Thread");
//        Console.WriteLine(Environment.CurrentManagedThreadId);
//        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//        Thread thread1 = new(() =>
//        {
//            Console.WriteLine("Worker 1 Thread");
//            Console.WriteLine(Environment.CurrentManagedThreadId);
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//        });

//        thread1.Start();
//        Thread thread2 = new(() =>
//        {
//            Console.WriteLine("Worker 2 Thread");
//            Console.WriteLine(Environment.CurrentManagedThreadId);
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//        });

//        thread2.Start();
//    }
//}
#endregion
#region IsBackground
// Bir thread'in arka plan (background) thread'i olup olmadığını belirler. Uzun süren threadleri main tharede bağlı olarak çalıştırmak istemeyebiliriz. Main thread bittiğinde arka plan thread'leri de otomatik olarak sonlanır. Eğer bir thread'in IsBackground özelliği true ise, o thread arka plan thread'i olarak kabul edilir ve main thread bittiğinde otomatik olarak sonlanır. Eğer IsBackground özelliği false ise, o thread ön plan (foreground) thread'i olarak kabul edilir ve main thread bittiğinde bile çalışmaya devam eder. bir worker thread main thread bağlı olarak çalıştırmak veya bağımsız olarak çalıştırmak istediğimiz senaryolar olabilir.

//int i = 10;
//Thread thread = new(() =>
//{
//    while (i >= 0)
//    {
//        i--;
//        Thread.Sleep(1000);
//    }
//    Console.WriteLine($"Worker Thread görevini tamamladı.");
//});
//thread.IsBackground = true;
//thread.Start();
//Console.WriteLine($"Main Thread görevini tamamladı.");
#endregion
#region Thread State
//int i = 10;
//Thread thread = new(() =>
//{
//    while (i >= 0)
//    {
//        i--;
//        Thread.Sleep(1000);
//    }
//    Console.WriteLine($"Worker Thread görevini tamamladı.");
//});

//thread.Start();

//ThreadState state = ThreadState.Running;
//while (true)
//{
//    if (thread.ThreadState == ThreadState.Stopped)
//        break;

//    if (state != thread.ThreadState)
//    {
//        state = thread.ThreadState;
//        Console.WriteLine(thread.ThreadState);
//    }
//}

//Console.WriteLine($"Main Thread görevini tamamladı.");
#endregion
#region Locking
//Race Condition'u engellemek için en temel tekniklerden biri. Aynı anda sadece tek bir threadın bir kod bloğuna erişmesini sağlar. Race condition olabilecek kod blokları aynı lock referans nesnesi içine alınarak kullanılır.Diğer threadler o anlık kilitlenir. thread1 işini bitirince diğer threadler sırayla  işlerini yapar. 
//object locking = new();
//Lock locking = new();
//int i = 1;

//Thread thread1 = new(() =>
//{
//    lock (locking)
//    {

//        while (i < 10)
//        {
//            i++;
//            Console.WriteLine($"Thread 1 : {i}");
//        }
//    }
//});
//Thread thread2 = new(() =>
//{
//    lock (locking)
//    {
//        while (i > 0)
//        {
//            i--;
//            Console.WriteLine($"Thread 2 : {i}");
//        }
//    }
//});
//thread1.Start();
//thread2.Start();
#endregion
#region Sleep
//developer tarafından thread'in belirli bir süre uyumasını sağlar. Thread'in o süre boyunca hiçbir işlem yapmamasını sağlar. Thread.Sleep() metodu, belirtilen süre boyunca thread'i askıya alır ve diğer thread'lerin çalışmasına izin verir. Bu, belirli bir süre beklemek veya belirli bir zaman diliminde işlemleri gerçekleştirmek için kullanılabilir. 
//Thread thread = new(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine(i);
//        Thread.Sleep(1000);
//    }
//});
//thread.Start();
#endregion
#region Join
//Join metodu, bir thread'in tamamlanmasını beklemek için kullanılır. Bir thread'in Join() metodunu çağırdığınızda, o thread'in tamamlanmasını bekler ve  ardından diğer thread'lerin çalışmasına izin verir. Bu, belirli bir thread'in tamamlanmasını beklemek veya belirli bir sırayla işlemleri gerçekleştirmek için kullanılabilir.
//Thread thread1 = new(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 1 {i}");
//    }
//});
//Thread thread2 = new(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 2 {i}");
//    }
//});

//thread1.Start();
//thread1.Join();
//thread2.Start();
#endregion
#region Thread İptal Etme
//Yöntem 1: Thread'in çalışmasını durdurmak için bir kontrol değişkeni kullanmak. Thread'in çalıştığı kod bloğunda bu kontrol değişkenini kontrol ederek, thread'in ne zaman durdurulacağını belirleyebilirsiniz. 

//bool stop = false;
//Thread thread = new(() =>
//{
//    while (true)
//    {
//        if (stop) break;
//        Console.WriteLine("lorem ipsum");
//    }
//    Console.WriteLine("Thread görevini tamamladı.");
//});


//Yöntem 2: CancellationToken kullanarak thread'i iptal etmek. CancellationToken, bir thread'in çalışmasını durdurmak için kullanılan bir yapıdır. Thread'in çalıştığı kod bloğunda CancellationToken'ı kontrol ederek, thread'in ne zaman durdurulacağını belirleyebilirsiniz.,

//Thread thread = new((cancellationToken) =>
//{
//    var cancel = (CancellationTokenSource)cancellationToken;
//    while (true)
//    {
//        if (cancel.IsCancellationRequested) break;
//        Console.WriteLine("lorem ipsum");
//    }
//    Console.WriteLine("Thread görevini tamamladı.");
//});
//CancellationTokenSource cancellationToken = new();
//thread.Start(cancellationToken);
//Thread.Sleep(5000);
//cancellationToken.Cancel();
#endregion
#region Interrupt
// Thread.Interrupt, bekleme durumundaki bir thread’i uyandırarak ThreadInterruptedException fırlatılmasına neden olur. Bu exception yakalanarak thread’in akışı kontrol edilebilir. Ancak bu yöntem yalnızca blocking durumlarda çalışır ve modern .NET uygulamalarında genellikle CancellationToken tercih edilir çünkü daha güvenli ve kontrol edilebilirdir.
//Thread thread = new(() =>
//{
//    try
//    {
//        Thread.Sleep(Timeout.Infinite);
//    }
//    catch (ThreadInterruptedException ex)
//    {

//    }
//});

//thread.Start();
//thread.Interrupt();
#endregion