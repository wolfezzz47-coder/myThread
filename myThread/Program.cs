using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Hello, World!");
//windows показує логічні процесори
int countCPU = Environment.ProcessorCount;
// Отримуємо кількість логічних ядер — корисно для розуміння,
// скільки потоків реально виконуватимуться паралельно.
Console.WriteLine($"Кількість логічних процессорів: {countCPU}");

//мультизадачнисть
Console.WriteLine("ID potoku " + Thread.CurrentThread.ManagedThreadId);
// Кожен потік має унікальний ManagedThreadId у межах процесу.
// Головний (основний) потік завжди існує при запуску програми —
// з нього починається виконання Main/top-level statements.
Thread newThread = new Thread(Animals);
newThread.Start();
// new Thread(Animals) — створює новий об'єкт потоку,
// але не запускає його. Як параметр передається
// делегат ThreadStart (метод без параметрів і без повернення).
// Start() — запускає потік. Після цього ОС планує його на
// виконання паралельно з основним.
string[] eats = { "Pizza", "Salat", "Hot-dog", "burger"};
foreach (string eat in eats)
{
    Console.WriteLine(eat);
    Thread.Sleep(500);
}
// Це виконується в основному потоці паралельно з Animals().
// Thread.Sleep(500) зупиняє поточний потік на 500 мс,
// звільняючи процесор іншим потокам.
void Animals()
{
    string[] animals = { "котик", "їжачок", "опосум", "білочка" };
    foreach (string animal in animals)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(animal);
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(500);
    }
}
// Виконується у вторинному потоці. Зверніть увагу: виведення
// із двох потоків у консоль перемішується — це і є візуальна
// демонстрація паралелізму. Порядок рядків недетермінований —
// його визначає планувальник ОС.