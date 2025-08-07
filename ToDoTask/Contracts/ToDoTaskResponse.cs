namespace ToDoTask.Contracts
{
    public record ToDoTaskResponse(
        Guid Id,
        string Name,
        string Descriptions,
        bool IsComplited,
         DateTime DateCreated );
}
