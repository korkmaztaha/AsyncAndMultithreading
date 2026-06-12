
#region new Task
//klasik şekilde instance oluşturma yönetemi. Bu şekilde task üretilmiş ama henüz başlatılmamış olur. Start() metodu ile başlatılabilir.
//Task task = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});
//task.Start();
#endregion
#region Task.Run
//bu kullanım ile method threadpool üzerinden alınmış ve başlatılmış bir thread üzerinde çalışan task nesnesi elde edilir. En yaygın kullanımdır.
//Task task = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});
#endregion
#region Task.Factory.StartNew
// Task.Factory.StartNew(), Task.Run()'a göre daha esnektir. TaskCreationOptions, TaskScheduler gibi gelişmiş ayarlar sunar. Child task attachment senaryolarını destekler. Her ikisi de CancellationToken alabilir.
//Task task = Task.Factory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});
#endregion

//Metotlar
Task task = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
        Console.WriteLine(i);
});
#region Start
//taskı başlatmak için kullanılır. Ancak Task.Run() veya Task.Factory.StartNew() gibi yöntemlerle oluşturulan task'lar zaten başlatılmıştır, bu yüzden Start() metodunu kullanmak genellikle gerekli değildir ve hatta hataya yol açabilir (örneğin, bir task'ı iki kez başlatmaya çalışmak InvalidOperationException'a neden olur).
//task.Start();
#endregion
#region Wait
//taskın tamamlanmasını beklemek için kullanılır. 
//task.Wait();
//Console.WriteLine("merhaba");
#endregion
#region ContinueWith
//bir task tamamlandıktan sonra başka bir işlemi gerçekleştirmek için kullanılır. event mantığı vardır.
//task.ContinueWith((_task) =>
//{
//    Console.WriteLine("İşlem tamamlandı");
//});
#endregion
#region WaitAll
//verilen tüm taskların tamamlanmasını bekler.
//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + "task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + "task3");
//});
//Task.WaitAll(task, task2, task3);
//Console.WriteLine("merhaba");
#endregion
#region WhenAll
//belirtilen tüm taskların tamamlanmasını bekler ve tamamlandıklarında bir Task nesnesi döner.
//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + "task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + "task3");
//});
//Task.WhenAll(task, task2, task3);
//Console.WriteLine("merhaba");
#endregion
#region WaitAny
//verilen tasklardan herhangi birinin tamamlanmasını bekler ve tamamlanan ilk taskın indeksini döner.
//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + "task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + "task3");
//});
//Task.WaitAny(task, task2, task3);
//Console.WriteLine("merhaba");
#endregion
#region WhenAny
//belirtilen tasklardan herhangi birinin tamamlanmasını bekler ve tamamlanan ilk taskı döner. Task.WaitAny()'a göre daha esnektir, çünkü tamamlanan taskın sonucunu almak gibi ek özellikler sunar.
//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 100; i++)
//        Console.WriteLine(i + "task2");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 300; i++)
//        Console.WriteLine(i + "task3");
//});
//Task.WhenAny(task, task2, task3);
//Console.WriteLine("merhaba");
#endregion
#region Delay
//belirtilen süre kadar gecikme sağlar.
//Task task1 = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        Task.Delay(1000);
//        Console.WriteLine(i);
//    }
//});
#endregion
#region FromCancelled
//iptal edilmiş bir task oluşturmak için kullanılır. Genellikle bir CancellationToken ile birlikte kullanılır ve iptal durumunu belirtmek için kullanılır.
//Task task2 = Task.Run(() =>
//{
//    return Task.FromCanceled(new());
//});
#endregion
#region FromException
//hata ile oluşturulmuş bir task oluşturmak için kullanılır. Genellikle bir istisna ile birlikte kullanılır ve hata durumunu belirtmek için kullanılır.
//Task task1 = Task.FromException(new("Hata alındı!"));
#endregion
#region FromResult
//belirtilen sonucu içeren tamamlanmış bir task oluşturmak için kullanılır. Genellikle senkron bir sonucu asenkron bir şekilde döndürmek istediğinizde kullanılır.
//Task<int> task1 = Task.Run<int>(() => 35);
//var result = task1.Result;

//Task<int> task1 = Task.FromResult(35);
#endregion
#region GetAwaiter
//asenkron bir işlemin sonucunu almak için kullanılır. 
//Task<int> task1 = Task.Run(() => 3);
//var result = task1.Result;

//var result2 = task1
//    .GetAwaiter()
//    .GetResult();
#endregion
//Propertyler
#region CompletedTask
//tamamlanmış bir task döner. Genellikle, tamamlanmış bir task'ı temsil etmek veya bir metot tarafından tamamlanmış bir task döndürmek istediğinizde kullanılır. Bu, özellikle asenkron bir metot içinde belirli koşullar altında hemen tamamlanmış bir task döndürmek istediğiniz durumlarda yararlıdır.
//Task X()
//{
//    //......
//    //return Task.Run(() => { });
//    //return new Task(() => { });
//    return Task.CompletedTask;
//}
#endregion
#region CurrentId
//şu anda yürütülmekte olan taskın id'sini döner. Eğer şu anda yürütülmekte olan bir task yoksa null döner. Bu, özellikle bir task içinde çalışırken o taskın kimliğini almak istediğiniz durumlarda yararlıdır.
//Task task1 = Task.Run(() =>
//{
//    Console.WriteLine($"Task1 Current Id : {Task.CurrentId}");
//});
//Task task2 = Task.Run(() =>
//{
//    Console.WriteLine($"Task2 Current Id : {Task.CurrentId}");
//});
//Task task3 = Task.Run(() =>
//{
//    Console.WriteLine($"Task3 Current Id : {Task.CurrentId}");
//});
//Task task4 = Task.Run(() =>
//{
//    Console.WriteLine($"Task4 Current Id : {Task.CurrentId}");
//});
#endregion
#region AsyncState
//task ile ilişkili durumu temsil eder.  örnekte 10 state temsil eder
//var task1 = Task.Factory.StartNew((i) =>
//{
//    var _i = (int)i;
//    for (int j = 0; j < _i; j++)
//        Console.WriteLine("Merhaba");
//}, 10);
//var state = task1.AsyncState;
#endregion
#region Status
//taskın mevcut durumunu temsil eder. TaskStatus enum'unda tanımlanan değerlerden birini alır. Bu, özellikle bir taskın durumunu izlemek veya belirli durumlara göre işlem yapmak istediğiniz durumlarda yararlıdır.
//Task task2 = Task.Run(async () =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        await Task.Delay(1000);
//        Console.WriteLine(i);
//    }
//});

//TaskStatus? status = null;
//while (true)
//{
//    if (status != task2.Status)
//    {
//        Console.WriteLine(task2.Status);
//        status = task2.Status;
//    }
//}
#endregion

Console.Read();