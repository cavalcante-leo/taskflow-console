using TaskFlow.Console;

var manager = new TaskManager();
var running = true;

while (running)
{
    ShowMenu();
    var option = Console.ReadLine()?.Trim();

    Console.WriteLine();

    switch (option)
    {
        case "1":
            AddTask(manager);
            break;
        case "2":
            ListTasks(manager);
            break;
        case "3":
            CompleteTask(manager);
            break;
        case "0":
            running = false;
            Console.WriteLine("Até logo!");
            break;
        default:
            Console.WriteLine("Opção inválida. Escolha uma das opções do menu.");
            break;
    }

    if (running)
    {
        Console.WriteLine();
        Console.Write("Pressione ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }
}

static void ShowMenu()
{
    Console.WriteLine("==============================");
    Console.WriteLine("        TASKFLOW CONSOLE      ");
    Console.WriteLine("==============================");
    Console.WriteLine("1 - Adicionar tarefa");
    Console.WriteLine("2 - Listar tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("------------------------------");
    Console.Write("Escolha uma opção: ");
}

static void AddTask(TaskManager manager)
{
    Console.Write("Título da tarefa: ");
    var title = Console.ReadLine();

    try
    {
        var task = manager.AddTask(title ?? string.Empty);
        Console.WriteLine($"Tarefa adicionada com sucesso! (Id: {task.Id})");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}

static void ListTasks(TaskManager manager)
{
    if (manager.Tasks.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa cadastrada.");
        return;
    }

    var index = 1;
    foreach (var task in manager.Tasks)
    {
        var status = task.IsCompleted ? "[x]" : "[ ]";
        Console.WriteLine($"{index} {status} {task.Title}");
        Console.WriteLine($"    Id: {task.Id}");
        index++;
    }
}

static void CompleteTask(TaskManager manager)
{
    if (manager.Tasks.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa cadastrada.");
        return;
    }

    ListTasks(manager);
    Console.WriteLine();
    Console.Write("Número da tarefa a concluir: ");

    if (!int.TryParse(Console.ReadLine(), out var number)
        || number < 1
        || number > manager.Tasks.Count)
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    var selected = manager.Tasks.ElementAt(number - 1);

    if (manager.CompleteTask(selected.Id))
    {
        Console.WriteLine("Tarefa concluída com sucesso!");
    }
    else
    {
        Console.WriteLine("Tarefa não encontrada.");
    }
}