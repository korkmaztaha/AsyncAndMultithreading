// Non-blocking (lock’suz) atomik okuma/yazma ile paylaşılan değişken üzerinde sürekli artış/azalış yapılır.
// Avantajı: kilit (lock) olmadığı için yüksek performans ve bekleme olmadan çalışma sağlar.
// Dezavantajı: senkronizasyon garantisi yoktur; race condition ve tutarsız/öngörülemez sonuçlar üretir.


using System.Runtime.Intrinsics.X86;

internal class Program
{
    private static void Main(string[] args)
    {
        Run();
    }
    static int i;
    private static void Run()
    {
        Thread thread1 = new(() =>
        {
            while (true)
                // volatile: değişkenin her thread tarafından en güncel haliyle (cache yerine main memory’den) okunmasını sağlar. Bu sayede thread’ler arasında tutarsız veri okuma sorununu önler.
                Volatile.Write(ref i, Volatile.Read(ref i) + 1);
            //belekten okumanın garantisi alındı ve direkt belleğe yazıldı
        });
        Thread thread2 = new(() =>
        {
            while (true)
                Console.WriteLine(Volatile.Read(ref i));
        });
        Thread thread3 = new(() =>
        {
            while (true)
                Volatile.Write(ref i, Volatile.Read(ref i) - 1);
        });
        thread1.Start();
        thread2.Start();
        thread3.Start();


    }
}
//volatile keyword, bir değişkenin tüm thread’ler tarafından her zaman en güncel haliyle okunmasını sağlar ve bu özelliği değişkenin kendisine uygular. Volatile class (Volatile.Read/Write) ise aynı görünürlük garantisini verir ama bunu değişken seviyesinde değil, yapılan okuma/yazma işlemi seviyesinde uygular. Yani volatile keyword değişkenin tüm erişimlerini etkilerken, Volatile class sadece seçilen işlemlerde bu davranışı sağlar. İkisi de thread-safe yapmaz, sadece cache ve görünürlük problemlerini çözer.

//internal class Program
//{
//    static volatile int i;

//    private static void Main(string[] args)
//    {
//        Thread thread1 = new(() =>
//        {
//            while (true)
//                i++; // NOT: thread-safe değil
//        });

//        Thread thread2 = new(() =>
//        {
//            while (true)
//                Console.WriteLine(i);
//        });

//        Thread thread3 = new(() =>
//        {
//            while (true)
//                i--; // NOT: thread-safe değil
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//    }
//}