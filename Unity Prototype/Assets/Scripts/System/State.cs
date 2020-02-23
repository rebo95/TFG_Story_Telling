using System.Collections;
using System.Collections.Generic;

public class State
{
    List<Character> characters;

    public State(List<Character> characters)
    {
        this.Characters = characters;
    }

    public List<Character> Characters { get => characters; set => characters = value; }
}
