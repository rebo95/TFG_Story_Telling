public class Place
{
    string name;
    int index;

    public string Name { get => name; set => name = value; }
    public int Index { get => index; set => index = value; }

    public Place(string name, int index)
    {
        Name = name;
        Index = index;
    }
}
