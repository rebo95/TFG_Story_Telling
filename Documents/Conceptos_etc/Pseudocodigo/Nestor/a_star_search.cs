
namespace Search.Informed.AStar
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class State : IEquatable<State>
	{
		public int X { get; private set; }
		public int Y { get; private set; }
	
		public State(int x, int y) 
		{
			this.X = x;
			this.Y = y; 
		}
	
		public override bool Equals(object obj)
		{
			return this.Equals(obj as State);
		}
	
		public bool Equals(State s)
		{
			if (Object.ReferenceEquals(s, null)) return false;
			if (Object.ReferenceEquals(this, s)) return true;
			if (this.GetType() != s.GetType()) return false;
	
			return (X == s.X) && (Y == s.Y);
		}
	
		public override int GetHashCode()
		{
			return X * 0x00010000 + Y;
		}

		public static bool operator==(State lhs, State rhs)
		{
			if (Object.ReferenceEquals(lhs, null))
			{
				if (Object.ReferenceEquals(rhs, null) return true;
				return false;
			}

			return lhs.Equals(rhs);
		}

		public static bool operator!=(State lhs, State rhs)
		{
			return !(lhs == rhs);
		}
	}

	public class Action
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		
		public Action(int x, int y) 
		{
			this.X = x;
			this.Y = y;
		}
	}

	public static class Environment
	{
		public static int MaxWidth { get; set; }
		public static int MaxHeight { get; set; }
		public static State GoalState { get; set; }
		public static Dictionary<string, Action> Actions;

		public static void RegisterAction(string name, Action a)
		{
			actions[name] = a;
		}

		public static bool IsLegal(State s, Action a, out State r)
		{
			if (s == null || a == null) return false;
		
			r.X = s.X + a.X;
			r.Y = s.Y + a.Y;	
		
			if (r.X >= MaxWidth || r.X < 0) return false;
			if (r.Y >= MaxHeight || r.Y < 0) return false;
			
			return true;
		}

		public static double GetHeuristicCost(State s)
		{
			return Heuristic.CalculateHeuristicCost(s, GoalState);
		}
	}

	public static class Heuristic
	{
		public static enum Heuristics { Euclidean, Manhattan };
		public static Heuristics CurrentHeuristic { get; set; };

		public static double CalculateHeuristicCost(State s, State g)
		{
			if (s == null || g == null) return Mathf.Infinity;
			else if (s == g) return 0.0;

			if (CurrentHeuristic == Heuristics.Euclidean)
			{
				double sqrDistance = Mathf.Pow(g.X - s.X, 2.0f) + Mathf.Pow(g.y - s.Y, 2.0f);
				return Mathf.Sqrt(sqrDistance);
			}
			else
			{
				double distance = Mathf.Abs(g.X - s.X) + Mathf.Abs(g.y - s.Y);
				return distance;
			}
		}
	}

	public class Problem
	{
		public State InitialState { get; private set; }

		public Problem(State s)
		{
			this.InitialState = s;
			Environment.Actions = new Dictionary<Operator, Action>;
			Environment.RegisterAction("Left",	new Action(-1,  0));
			Environment.RegisterAction("Right",	new Action( 1,  0));
			Environment.RegisterAction("Up",	new Action( 0, -1));
			Environment.RegisterAction("Down",	new Action( 0,  1));
		}

		public List<(Action, State)> Successors(State s)
		{
			List<(Action, State)> successors = new List<(Action, State)>;
			
			foreach (var v in Environment.actions)
			{
				State r;
				if (Environment.IsLegal(s, v.Value, r)) 
				{
					successors.Add((v.Value, r));
				}
			}

			return successors;
		}

		public bool GoalTest(State s)
		{
			return s == Environment.GoalState;
		}

		public double StepCost(State s, Action a, State r)
		{
			if (a == null) return 0.0;
			if (s == r) return 0.0;
			return 1.0;
		}

		public double HeuristicCost(State s)
		{
			return Environment.GetHeuristicCost(s);
		}
	}

	public class Node
	{
		public State  S { get; set; }
		public Action A { get; set; }
		public Node   N { get; set; }
		public double G { get; set; }
		public double F { get; set; }

		public Node(State s)
		{
			this.S = s;
			this.A = null;
			this.N = null;
		}
	}

	public Node Search(Problem problem)
	{
		HashSet<State> closedList = new HashSet<State>;
		PriorityQueue<Node> frontier = new PriorityQueue<Node>;

		Node root = new Node(problem.InitialState);
		root.G = 0.0;
		root.F = problem.HeuristicCost(root.S);
		frontier.Add(root.F, root);

		while (frontier.Count() > 0)
		{
			Node node = frontier.Pop();
			if (problem.GoalTest(node.S)) return node;

			if (!closedList.Contains(node.S))
			{
				closedList.Add(node.S);
				Expand(node, problem, frontier);
			}
		}
	}

	private List<Node> Expand(Node node, Problem problem, PriorityQueue<double, Node> frontier)
	{
		List<Node> neighbours = new List<Node>;

		foreach (Tuple<Action, State> pair in problem.Successors(node.S))
		{
			Node s = new Node(pair.Value);
			double gScoreEstimation = node.G + problem.StepCost(node, pair.Key, r);
			if (closedList.Contains(s.S)) continue;
			if (!frontier.Contains(s)) neighbours.Add(s);
			else if (frontier.Contains(s) && gScoreEstimation >= frontier[s].G) continue;
			s.A = pair.Key;
			s.G = gScoreEstimation;
			s.F = s.G + problem.HeuristicCost(s);
		}

		return neighbours;
	}

	public void Solution(Node n, out List<State> stateSequence, out List<Action> actionSequence)
	{
		stateSequence = new List<State>;
		actionSequence = new List<Action>;

		Node node = n; 
		while (node != null)
		{
			stateSequence.Add(node.S);
			actionSequence.Add(node.A);
			node = node.N;
		}
	}
}
