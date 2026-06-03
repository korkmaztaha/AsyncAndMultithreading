#region Spinning
//Kod bloklarını şartla bağlı şeklilde çalıştırarak Race Condition'ı engellemek için kullanılan bir tekniktir. Threadler sürekli olarak bir koşulu kontrol ederler ve koşul sağlandığında kod bloğunu çalıştırırlar. Bu yöntem, kısa süreli kilitlenmeler için uygun olabilir, ancak uzun süreli kilitlenmelerde CPU kaynaklarını gereksiz yere tüketebilir. Spinning tekniği, genellikle düşük gecikme süresi gerektiren durumlarda tercih edilir, ancak yüksek CPU kullanımı nedeniyle dikkatli kullanılmalıdır.
//bool threadCondition = true;
//Thread thread1 = new(() =>
//{
//    while (true)
//    {
//        if (!threadCondition)
//        {
//            for (int i = 1; i <= 10; i++)
//                Console.WriteLine($"Thread 1 {i}.");
//            threadCondition = false;
//            break;
//        }
//    }
//});
//Thread thread2 = new(() =>
//{
//    while (true)
//    {
//        if (threadCondition)
//        {
//            for (int i = 10; i > 0; i--)
//                Console.WriteLine($"Thread 2 {i}.");
//            threadCondition = false;
//            break;
//        }
//    }
//});

//thread1.Start();
//thread2.Start();
#endregion
#region Monitor.Enter ve Monitor.Exit 
//Locking mekanizması, birden fazla thread'in paylaşılan bir kaynağa eşzamanlı erişimini kontrol etmek için kullanılır. Monitor.Enter ve Monitor.Exit metodları belirli bir nesne üzerinde karşılıklı dışlama (mutual exclusion) sağlar. Bir thread Monitor.Enter ile bir nesnenin kilidini aldığında, aynı nesne üzerinde Monitor.Enter çağıran diğer thread'ler kilit serbest bırakılana kadar bekler. Monitor.Exit çağrıldığında kilit bırakılır ve bekleyen thread'lerden biri kilidi alarak çalışmaya devam edebilir.
//object locking = new();
//int i = 0;
//Thread thread1 = new(() =>
//{
//    try
//    {
//        Monitor.Enter(locking);
//        for (i = 0; i < 10; i++)
//            Console.WriteLine($"Thread 1 {i}");
//    }
//    finally
//    {   bir hata durumunda kilidin serbest bırakılmasını sağlamak için finally bloğu kullanılır. 
//        Monitor.Exit(locking);
//    }
//});
//Thread thread2 = new(() =>
//{
//    try
//    {
//        Monitor.Enter(locking);
//        for (i = 0; i < 10; i++)
//            Console.WriteLine($"Thread 2 {i}");
//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});
//thread1.Start();
//thread2.Start();

#region lockTaken
//lockTaken parametresi, Monitor.Enter metodunun kilidi başarıyla alıp almadığını belirlemek için kullanılır. Bu parametre, Monitor.Enter çağrısının sonucunu yansıtır ve kilidin başarıyla alındığını gösterir. Eğer lockTaken true ise, kilit alınmıştır ve kod bloğu güvenli bir şekilde çalıştırılabilir. Eğer lockTaken false ise, kilit alınamamıştır ve kod bloğu çalıştırılmamalıdır. Bu mekanizma, kilidin alınamaması durumunda oluşabilecek hataları önlemek için önemlidir.
//object locking = new();
//int i = 0;
//Thread thread1 = new(() =>
//{
//    try
//    {
//        bool lockTaken = false;
//        Monitor.Enter(locking, ref lockTaken);
//        if (lockTaken)
//            for (i = 0; i < 10; i++)
//                Console.WriteLine($"Thread 1 {i}");
//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});
//Thread thread2 = new(() =>
//{
//    try
//    {
//        bool lockTaken = false;
//        Monitor.Enter(locking, ref lockTaken);
//        if (lockTaken)
//            for (i = 0; i < 10; i++)
//                Console.WriteLine($"Thread 2 {i}");
//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});
//thread1.Start();
//thread2.Start();
#endregion
#endregion
#region Monitor.TryEnter
//Monitor.TryEnter, belirli bir nesne üzerinde kilidi almaya çalışır ve bu işlemin başarılı olup olmadığını döndürür. Bu yöntem, kilidin alınamaması durumunda beklemek yerine hemen geri dönerek programın akışını kontrol etmeye olanak tanır. TryEnter, özellikle kilidin kısa süreli olarak tutulduğu durumlarda veya kilidin alınamaması durumunda alternatif işlemler yapmak istediğinizde kullanışlıdır. Bu yöntem, kilidin alınamaması durumunda oluşabilecek blokajları önlemek için önemlidir.
//object locking = new();
//int i = 0;
//Thread thread1 = new(() =>
//{
//    var result = Monitor.TryEnter(locking, 100);
//    if (result)
//        try
//        {
//            for (i = 0; i < 10; i++)
//                Console.WriteLine($"Thread 1 {i}");
//        }
//        finally
//        {
//            Monitor.Exit(locking);
//        }
//});
//Thread thread2 = new(() =>
//{   50 milisaniye boyunca kilidi almaya çalışır, eğer kilit alınamazsa işlemi atlar ve devam eder. Bu, kilidin uzun süre tutulduğu durumlarda diğer thread'lerin beklemesini önler ve programın akışını daha verimli hale getirir.
//    var result = Monitor.TryEnter(locking, 50);
//    if (result)
//        try
//        {
//            for (i = 0; i < 10; i++)
//                Console.WriteLine($"Thread 2 {i}");
//        }
//        finally
//        {
//            Monitor.Exit(locking);
//        }
//});
//thread1.Start();
//thread2.Start();
#endregion
#region Mutex Sınıfı
//Mutex hem aynı process içindeki thread'ler hem de farklı process'ler arasında senkronizasyon sağlayabilir.
//Mutex mutex = new();
//Thread thread1 = new(() =>
//{
//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 1 {i}");
//    }
//    mutex.ReleaseMutex();
//});
//Thread thread2 = new(() =>
//{
//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 2 {i}");
//    }
//    mutex.ReleaseMutex();
//});
//thread1.Start();
//thread2.Start();

#region Mutex İle Single Instance Application
// bir programın aynı anda sadece bir örneğinin çalışmasını sağlamak için Mutex sınıfı kullanılabilir. Bu, özellikle uygulamanın kaynaklarını korumak veya kullanıcı deneyimini iyileştirmek için önemlidir. Aşağıdaki örnekte, programın adını içeren bir Mutex oluşturulur ve eğer aynı isimde bir Mutex zaten varsa, program ikinci kez çalıştırılmaya çalışıldığında mevcut Mutex'e bağlanır ve program sonlanır. Eğer Mutex oluşturulamazsa, program normal şekilde çalışmaya devam eder.
internal class Program
{
    static Mutex _mutex;
    static string _programName = "Project Name";
    private static void Main(string[] args)
    {
        Mutex.TryOpenExisting(_programName, out _mutex);
        if (_mutex == null)
        {
            _mutex = new(true, _programName);
            Console.WriteLine("Program running....");
            Console.Read();
        }
        else
        {
            _mutex.Close();
            return;
        }
    }
}

#endregion
#endregion
