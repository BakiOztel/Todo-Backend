namespace App.Domain.Entities
{
    public class Todo
    {


        public int Id { get; set; }
        public string Text { get; set; }
        public bool isDone { get; set; } = false;
        public Workblog Workblog { get; set; }
    }
}
