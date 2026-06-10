#region System.Threading.Timer

// 200 ms sonra bir kez çalışacak timer oluşturulur.
// state parametresi callback'e gönderilen veridir.
System.Threading.Timer timer = new(state =>
{
    Console.WriteLine(state);
},
"Tick!",               // Callback'e gönderilecek state
200,                   // İlk çalışma gecikmesi (ms)
Timeout.Infinite);     // Tekrar etme

Thread.Sleep(1000);    // Programın kapanmasını engeller

// Timer'ı hemen başlatıp her 1500 ms'de bir çalıştırır.
// timer.Change(0, 1500);

Console.Read();

#endregion

#region System.Timers.Timer

//// Event tabanlı timer oluşturulur.
//System.Timers.Timer timer = new();

//// Timer tetiklendiğinde çalışacak olay tanımlanır.
//timer.Elapsed += (sender, e) =>
//{
//    Console.WriteLine("lorem ipsum");
//};

//// Timer başlatılır.
//timer.Start();

//// Tetiklenme aralığı 500 ms olarak ayarlanır.
//timer.Interval = 500;

//// Timer durdurulur.
//timer.Stop();

//Thread.Sleep(1000);    // Programın hemen sonlanmasını engeller

//Console.Read();

#endregion