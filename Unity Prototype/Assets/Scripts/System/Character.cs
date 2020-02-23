using System.Collections;
using System.Collections.Generic;

public class Character
{
    string[] dialogue;
    List<Item> inventory;
    Place currenLocation;

    string name;
    int id;

    public Character(string[] dialogue, List<Item> inventory, Place currenLocation, string name, int id)
    {
        this.Dialogue = dialogue;
        this.Inventory = inventory;
        this.CurrenLocation = currenLocation;
        this.Name = name;
        this.Id = id;
    }

    public string[] Dialogue { get => dialogue; set => dialogue = value; }
    public List<Item> Inventory { get => inventory; set => inventory = value; }
    public Place CurrenLocation { get => currenLocation; set => currenLocation = value; }
    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
}
