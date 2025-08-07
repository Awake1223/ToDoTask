namespace ToDoTask.Contracts
{
    public record ToDoTaskRequest(
        string Name,
        string Descriptions,
        bool IsComplited,
        DateTime DateCreated);
}
