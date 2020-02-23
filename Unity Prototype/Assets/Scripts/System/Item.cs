public class Item
{
    string name;
    int id;
    bool used;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public bool Used { get => used; set => used = value; }

    public Item(string name, int id, bool used)
    {
        Name = name;
        Id = id;
        Used = used;
    }
}
