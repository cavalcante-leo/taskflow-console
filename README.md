# taskflow-console-net

Gerenciador de tarefas em linha de comando, desenvolvido em C# com .NET 10.

## Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- Git

Para conferir a versão instalada:

```bash
dotnet --version
```

## Como compilar

Na raiz da solução:

```bash
dotnet restore
dotnet build
```

## Como executar a aplicação

```bash
dotnet run --project taskflow-console-net
```

O menu interativo é exibido com as opções:

| Opção | Ação              |
|-------|-------------------|
| 1     | Adicionar tarefa  |
| 2     | Listar tarefas    |
| 3     | Concluir tarefa   |
| 0     | Sair              |

## Como executar os testes unitários

```bash
dotnet test
```

Para ver o nome de cada teste executado:

```bash
dotnet test --logger "console;verbosity=normal"
```

## Estrutura

- `TaskItem.cs`: entidade da tarefa (id, título e status de conclusão)
- `TaskManager.cs`: regras de negócio para adicionar, buscar e concluir tarefas
- `Program.cs`: menu interativo do console
- `TaskManagerTests.cs`: testes unitários com xUnit