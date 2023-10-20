using System;
using System.Collections.Generic;

class Graph
{
    public
      int V;
    public
      List<int>[] adj;

    public
      Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public
      void addEdges(int a, int b)
    {
        adj[a].Add(b);
        adj[b].Add(a);
    }

    public
      void dfs(int i, bool[] visited, List<int> connection)
    {
        visited[i] = true;
        connection.Add(i);
        foreach (int item in adj[i])
        {
            if (!visited[item])
            {
                dfs(item, visited, connection);
            }
        }
    }

    public
      void connectionComponnets()
    {
        bool[] visited = new bool[V];
        List<List<int>> commponet = new List<List<int>>();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                List<int> temp = new List<int>();
                dfs(i, visited, temp);
                commponet.Add(temp);
            }
        }

        foreach (List<int> comp in commponet)
        {
            Console.WriteLine(string.Join(" ", comp));
        }
    }
}

public class HelloWorld
{
    public
      static void Main(string[] args)
    {
        Graph gr = new Graph(6);
        gr.addEdges(0, 2);
        gr.addEdges(2, 3);
        gr.addEdges(2, 5);

        gr.connectionComponnets();
    }
}