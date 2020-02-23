public class Fact
{
    private string description;

    public string Description { get => description; set => description = value; }

    public Fact(string description)
    {
        Description = description;
    }
}
