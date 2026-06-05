#region Interlocked Sınıfı
//özellikle değişken üzerinde atomik işlemler yapmamızı sağlayan bir sınıftır. Bu sınıfın sağladığı metotlar sayesinde, çoklu thread'ler arasında değişkenlere erişim sırasında oluşabilecek race condition'ları önleyebiliriz.
//int i = 0;
////değer ekleme
////Interlocked.Add(ref i, 10);

////değer değiştirme ve eski değeri alma
//var prevalue = Interlocked.Exchange(ref i, 5);
//Console.WriteLine(i);
//Console.WriteLine(prevalue);

////belirli bir koşulda değer değiştirme. Değişken değeri 5 ise, 15 yap. Değilse değiştirme. Mantığı ise değişken başka bir thread tarafından aynı zamanda değişiklik yapılmayacak
//Interlocked.CompareExchange(ref i, 15, 5);
//Console.WriteLine(i);

//Thread thread1 = new(() =>
//{
//    while (true)
//        //i++;
//        Interlocked.Increment(ref i);

//});
//Thread thread2 = new(() =>
//{
//    while (true)
//        Console.WriteLine(i);
//});
//Thread thread3 = new(() =>
//{
//    while (true)
//        //i--;
//        Interlocked.Decrement(ref i);
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion
#region MemoryBarrier Metodu
//MemoryBarrier önceki tüm okuma/yazma işlemleri tamamlanmadan bariyerden sonraki işlemler başlamaz. Günümüzde pek tercih edilmeyen bir yöntemdir. Genellikle Interlocked sınıfının sağladığı metotlar kullanılır.
int i = 0;
Thread writeThread = new(() =>
{
    while (true)
    {
        Interlocked.Increment(ref i);
        Thread.MemoryBarrier();
        //değişikliğin diğer thread'ler tarafından görülmesini sağlamak için MemoryBarrier kullanıyoruz. Bu sayede, writeThread tarafından yapılan değişiklikler readThread tarafından görülebilir hale gelir.
    }
});
Thread readThread = new(() =>
{
    while (true)
    {
        Thread.MemoryBarrier();
        Console.WriteLine(i);
        //i değerini okurken de MemoryBarrier kullanarak en güncel değeri görmeyi sağlıyoruz. 
    }
});

writeThread.Start();
readThread.Start();
#endregion