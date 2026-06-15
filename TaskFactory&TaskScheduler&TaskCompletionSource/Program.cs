#region TaskFactory
#region StartNew
//yeni bir task oluşturmak için kullanılır. Task.Run()'a benzer şekilde çalışır ancak daha fazla esneklik sağlar. Task.Run() genellikle basit görevler için tercih edilirken, TaskFactory.StartNew() daha karmaşık senaryolar için uygundur.
//TaskFactory taskFactory = new();
//taskFactory.StartNew(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(i);
//});
#endregion
#region ContinueWhenAll

//belirtilen tüm tasklar tamamlandığımda yeni bir task başlatmak için kullanılır. yeni bir task oluştuğu için asenkron çalışır yani ana threadi engellemez. 
//Task task1 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 1 {i}");
//});
//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 2 {i}");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 3 {i}");
//});

//TaskFactory taskFactory = new();
//taskFactory.ContinueWhenAll(new[] { task1, task2, task3 }, (tasks) =>
//{
//    Console.WriteLine("....");
//});

//Console.WriteLine("merhaba");
#endregion
#region ContinueWhenAny
//belirtilen tasklardan herhangi biri tamamlandığında yeni bir task başlatmak için kullanılır.  
//Task task1 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 1 {i}");
//});
//Task task2 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 2 {i}");
//});
//Task task3 = Task.Run(() =>
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine($"Task 3 {i}");
//});

//TaskFactory taskFactory = new();
//taskFactory.ContinueWhenAny(new[] { task1, task2, task3 }, (tasks) =>
//{
//    Console.WriteLine("....");
//});
#endregion
#endregion
#region TaskScheduler
//TaskScheduler, görevlerin nasıl ve nerede çalıştırılacağını belirlemek için kullanılan bir sınıftır. Varsayılan olarak, görevler ThreadPool tarafından yönetilen bir iş parçacığı havuzunda çalıştırılır. Ancak, özel bir TaskScheduler oluşturarak görevlerin belirli bir iş parçacığında veya belirli bir sırayla çalışmasını sağlayabilirsiniz.
//Task.Factory.StartNew(() =>
//{
//    //...
//}, new(), TaskCreationOptions.None, new CustomTaskScheduler());
//ikincş parametrede TaskScheduler'den inherit edilen bir sınıf örneği verilir. Bu sınıf, görevlerin nasıl planlanacağını ve çalıştırılacağını belirler. 

//class CustomTaskScheduler : TaskScheduler
//{
//planlanmış tasklar ile ilgili liste döner
//    protected override IEnumerable<Task>? GetScheduledTasks()
//        => null;

//farklı bir threade task yönlendirildi
//    protected override void QueueTask(Task task)
//        => ThreadPool.QueueUserWorkItem(_ =>
//        {
//            TryExecuteTask(task);
//        });
//taskların çalışıp çalışmadığı ile ilgili bilgi döner
//    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
//        => true;
//}
#endregion
#region TaskCompletionSource
//bir taskın sonucunu manuel olarak kontrol etmek için kullanılan bir sınıftır. Bu sınıf, bir görevin sonucunu, hatasını veya iptal durumunu belirlemek için kullanılabilir.
Task<int> Operation(ResultType resultType)
{
    TaskCompletionSource<int> taskCompletionSource = new();
    switch (resultType)
    {
        case ResultType.Result:
            taskCompletionSource.SetResult(42);
            break;
        case ResultType.Exception:
            taskCompletionSource.SetException(new Exception("Hata alındı!"));
            break;
        case ResultType.Canceled:
            taskCompletionSource.SetCanceled();
            break;
    }
    return taskCompletionSource.Task;
}
var task = Operation(ResultType.Canceled);
Console.WriteLine();
enum ResultType
{
    Result,
    Exception,
    Canceled
}

#endregion