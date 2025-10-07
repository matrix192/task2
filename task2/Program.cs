using System.Diagnostics;

Console.WriteLine("Программа начала работу");

string filename1 = "Файл 1";
string filename2 = "Файл 2";
string filename3 = "Файл 3";

static string ProcessData(string dataName)
{
    Thread.Sleep(3000);
    string syncResult = $"Обработка файла '{dataName}' завершилась синхронно за 3 секунды";

    return syncResult;
}


async Task ProcessDataAsync(string dataName)
{

    await Task.Delay(3000);
    Console.WriteLine($"Обработка файла '{dataName}' завершилась ассинхронно за 3 секунды");

}

Stopwatch asyncStopwatch = Stopwatch.StartNew();
Task task1 = ProcessDataAsync(filename1);
Task task2 = ProcessDataAsync(filename2);
Task task3 = ProcessDataAsync(filename3);
await Task.WhenAll(task1, task2, task3);
asyncStopwatch.Stop();
Console.WriteLine($"Ассинхронная обработка завершилась за {asyncStopwatch.Elapsed.TotalSeconds} секунд.");

Stopwatch syncStopwatch = Stopwatch.StartNew();
Console.WriteLine(ProcessData(filename1));
Console.WriteLine(ProcessData(filename2));
Console.WriteLine(ProcessData(filename3));
syncStopwatch.Stop();
Console.WriteLine($"Синхронная обработка завершилась за {syncStopwatch.Elapsed.TotalSeconds} секунд.");

Console.WriteLine($"Разница в выполнении между синхронным и ассинхронным " +
    $"методами составила {syncStopwatch.Elapsed.TotalSeconds - asyncStopwatch.Elapsed.TotalSeconds} секунд.");

Console.ReadKey();

