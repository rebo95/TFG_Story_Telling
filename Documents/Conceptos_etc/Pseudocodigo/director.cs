// Director (problem)

class Director 
{
    List<Tuple<int, int>> StateOperators;
    State InitState;

    public Director()
    {
        StateOperators = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

        InitState = new State();
        InitState.init(0, 1, 3, 4); // Random crap - - - - -
    }

    public State getInitState()
    {
        return InitState;
    }

    public void setInitState(State init)
    {
        InitState = init;
    }
    
    // Digamos que se acaba cuando al menos un personaje tiene dinero
    public bool isGoal(State state)
    {
        // Comprueba si en ese estado el personaje recoge dinero
        if(state.money.posX == state.character.posX && state.money.posY == state.character.posY)
        {
            state.money.pickUp();
            state.character.getMoney();
        }

        return state.character.hasMoney();
    }

    // Aplica los operadores y devuelve los hijos del nodo que recibe (estados)
    public List<State> sucessors(State state)
    {
        List<State> stateSucessors = new List<State>();

        // TODO: Comprobar si se sale del entorno ------------------------------------------------------------------------------
        foreach(Tuple<int, int> op in StateOperators) // Aplica todos los operadores
        {
            State newState = new State();
            newState.init(state.character.posX + op.First, state.character.posY + op.Second, state.money.posX, state.money.posY);

            stateSucessors.Add(newState);
        }

        return stateSucessors;
    }
}