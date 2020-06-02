// Searches

public class Search()
{
    List<State> visited;

    Director director_;

    public Search(Director director)
    {
        director_ = director;

        visited = new List<State>();
    }

    /////////
    // DFS //
    /////////

    public bool DFS()
    {
        return recursiveDFS(director_, director_.getInitState());
    }

    public bool recursiveDFS(Director director, State state)
    {
        if (director.isGoal(state))
        {
            return true; // Hay un camino a GOAL
        }
        else
        {
            List<State> sucessors = director.sucessors(state);

            foreach(State s in sucessors)
            {
                return recursiveDFS(director, s);
            }
        }

        visited.Add(state);
    }
}