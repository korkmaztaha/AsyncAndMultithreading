//her bir thread'in kendine ait bir veriye sahip olması gerektiği durumlarda Thread Local Storage (TLS) kullanılır. TLS, her bir thread'in kendi verisini saklamasına olanak tanır ve bu veriye diğer thread'ler tarafından erişilemez. 
#region ThreadStatic Attribute

//internal class Program
//{
//    [ThreadStatic]
//    ilgili verini her bir thread için ayrı ayrı saklamak istediğimizde kullanılır, her thread'in kendine ait bir kopyası olur, bu kopyalar birbirinden bağımsızdır, bir thread'in yaptığı değişiklik diğer thread'leri etkilemez
//    static int x = 0;
//ThreadStatic kullanılacağı değişkenin static olması gerekir
//    private static void Main(string[] args)
//    {
//        Thread thread1 = new(() =>
//        {
//            while (x < 10)
//                Console.WriteLine($"Thread1 {++x}");
//        });

//        Thread thread2 = new(() =>
//        {
//            while (x < 10)
//                Console.WriteLine($"Thread2 {++x}");
//        });

//        Thread thread3 = new(() =>
//        {
//            while (x < 10)
//                Console.WriteLine($"Thread3 {++x}");
//        });

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();
//    }
//}



#endregion
#region ThreadLocal<T> Class'ı
//static olmayan fieldlar için de kullanılır
//ThreadLocal<int> x = new(() => 0);
//Thread thread1 = new(() =>
//{
//    while (x.Value < 10)
//        Console.WriteLine($"Thread1 {++x.Value}");
//});

//Thread thread2 = new(() =>
//{
//    while (x.Value < 10)
//        Console.WriteLine($"Thread2 {++x.Value}");
//});

//Thread thread3 = new(() =>
//{
//    while (x.Value < 10)
//        Console.WriteLine($"Thread3 {++x.Value}");
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion
#region GetData & SetData

class Program
{
    // her bir thread için x slotu oluşturduk
    static LocalDataStoreSlot localDataStoreSlot = Thread.GetNamedDataSlot("x");
    static int X
    {
        get
        {//ilgili thread'in x slotundaki veriyi alır, eğer veri yoksa null döner, null ise 0 döner, null değilse verinin değerini döner
            var data = (int?)Thread.GetData(localDataStoreSlot);
            return data is null ? 0 : data.Value;
        }
        set => Thread.SetData(localDataStoreSlot, value);
    }

    static void Main(string[] args)
    {
        Thread thread1 = new(() =>
        {
            while (X < 10)
                Console.WriteLine($"Thread1 {++X}");
        });

        Thread thread2 = new(() =>
        {
            while (X < 10)
                Console.WriteLine($"Thread2 {++X}");
        });

        Thread thread3 = new(() =>
        {
            while (X < 10)
                Console.WriteLine($"Thread3 {++X}");
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
}


#endregion