#region SpinLock
//bir thread'in kritik bir bölgeye erişimini sağlamak için kullanılan bir senkronizasyon mekanizmasıdır. SpinLock, bir thread'in kilidi almayı denediği ancak kilidin başka bir thread tarafından tutulduğu durumlarda, thread'in beklemek yerine sürekli olarak kilidi almaya çalıştığı bir yapıdır. Bu nedenle, SpinLock genellikle kısa süreli kilitler için tercih edilir, çünkü uzun süreli kilitlerde CPU kaynaklarını tüketebilir ve performans sorunlarına yol açabilir.
//int value = 0;
//SpinLock spinLock = new();
//Thread thread1 = new(() =>
//{
//    bool lockTaken = false;
//    try
//    {
//        spinLock.Enter(ref lockTaken);
//        if (lockTaken)
//            for (int i = 0; i < 999; i++)
//                Console.WriteLine($"Thread1 : {++value}");
//    }
//    finally
//    {
//        spinLock.Exit();
//    }
//});
//Thread thread2 = new(() =>
//{
//    bool lockTaken = false;
//    try
//    {
//        spinLock.Enter(ref lockTaken);
//        if (lockTaken)
//            for (int i = 0; i < 999; i++)
//                Console.WriteLine($"Thread2 : {++value}");
//    }
//    finally
//    {
//        spinLock.Exit();
//    }
//});

//thread1.Start();
//thread2.Start();
#endregion
#region SpinWait
//spinlock gibi bir senkronizasyon mekanizmasıdır, ancak SpinWait, bir thread'in belirli bir koşulun gerçekleşmesini beklerken CPU kaynaklarını tüketmeden beklemesini sağlar. SpinWait, bir thread'in belirli bir koşulun gerçekleşmesini beklerken, belirli bir süre boyunca aktif olarak beklemesini sağlar. Bu süre boyunca, thread CPU kaynaklarını tüketmez ve diğer thread'lerin çalışmasına izin verir. SpinWait, genellikle kısa süreli beklemeler için tercih edilir, çünkü uzun süreli beklemelerde performans sorunlarına yol açabilir.
bool waitMod = false, condition = false;
Thread thread1 = new(() =>
{
    while (true)
    {
        if (waitMod)
        {
            continue;
        }

        if (!condition)
        {
            continue;
        }

        Console.WriteLine("Thread1 işleniyor...");
    }
});

Thread thread2 = new(() =>
{
    while (true)
    {
        SpinWait.SpinUntil(() =>
        {
            Thread.MemoryBarrier();
            return waitMod || condition;
        });

        Console.WriteLine("Thread2 işleniyor...");
    }
});

thread1.Start();
thread2.Start();
#endregion