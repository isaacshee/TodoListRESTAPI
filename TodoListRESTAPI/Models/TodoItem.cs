namespace TodoListRESTAPI.Models
{
    //Isaac - TodoItem entity, to describe one singular item in the todolist
    public class TodoItem
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Status { get; set; }

    }
}
