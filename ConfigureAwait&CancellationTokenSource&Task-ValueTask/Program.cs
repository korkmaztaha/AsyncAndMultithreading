#region ConfigureAwait
//asenkron bir methodu çağıran thread ile çalıştıran thread farklı olabilir. ConfigureAwait(false) kullanarak, asenkron methodun tamamlanmasının ardından devam eden kodun, çağıran thread yerine farklı bir thread üzerinde çalışmasını sağlayabiliriz. Bu, özellikle UI uygulamalarında performansı artırabilir ve deadlock riskini azaltabilir.
//async Task<string> ReadFileAsync(string path)
//{
//    StreamReader streamReader = new(path);
//    var content = await streamReader.ReadToEndAsync()
//        .ConfigureAwait(false);

// bu kod artık herhangi bir thread üzerinde çalışabilir, çağıran thread'e geri dönmeyecektir.  
//    Console.WriteLine("End.");
//    return content;
//}

//var content = await ReadFileAsync("C:\\Users\\korkm\\Downloads\\test.html");
//Console.WriteLine(content);
#endregion
#region CancellationToken & CancellationTokenSource 
//cancellationToken, asenkron işlemlerin iptal edilmesini sağlamak için kullanılan bir yapıdır. CancellationTokenSource ise bu token'ı oluşturmak ve yönetmek için kullanılan bir sınıftır. CancellationTokenSource, iptal isteği gönderildiğinde, ilgili CancellationToken'ı iptal eder ve bu token'ı kullanan asenkron işlemler de iptal edilir.
//async Task DoWorkAsync(CancellationToken cancellationToken)
//{
//    for (int i = 0; i < 10; i++)
//    {
//        // Her döngüde iptal isteği kontrol edilir. Eğer iptal edilmişse, bir OperationCanceledException fırlatılır. 
//        cancellationToken.ThrowIfCancellationRequested();
//        await Console.Out.WriteLineAsync($"{i}");
//        await Task.Delay(1000);
//    }
//    Console.WriteLine("Work completed...");
//}

//CancellationTokenSource cancellationTokenSource = new();

//Task.Run(async () =>
//{
//    await Task.Delay(3000);
//    await cancellationTokenSource.CancelAsync();
//});

//try
//{
//    await DoWorkAsync(cancellationTokenSource.Token);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion
#region Task & ValueTask
//perfomans ve kullanım açısından Task ve ValueTask arasındaki farklar vardır. Task, referans tipidir ve heap üzerinde oluşturulur, bu nedenle bellek yönetimi açısından daha maliyetlidir. ValueTask ise değer tipidir ve stack üzerinde oluşturulabilir, bu nedenle daha az bellek kullanır ve performans açısından daha iyidir. Ancak, ValueTask yalnızca belirli durumlarda kullanılmalıdır; örneğin, bir methodun çoğu zaman senkron olarak tamamlanması bekleniyorsa veya methodun geri dönüş değeri yoksa (void) ValueTask tercih edilebilir. Aksi takdirde, Task kullanmak daha güvenli ve okunabilir bir yaklaşımdır.  
async Task X()
{

}
async ValueTask Y()
{

}

await X();
await Y();
#endregion