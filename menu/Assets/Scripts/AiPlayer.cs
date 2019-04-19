using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void RunAi()
    {

        Debug.Log("AI Starting");

        int[] puzzle = {1,2,4,3,0,5,7,6,8};

        int[] goalNode = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        Node root = new Node(puzzle); //Create the root node
        Node GoalNode = new Node(goalNode); //Create the goal node

        UninformedSearch ui = new UninformedSearch();

        //List<Node> solution = ui.BreadthFirstSearch(root);

        List<Node> faster_solution = ui.AStarSearch(root, GoalNode);

        Debug.Log("Number of moves" + faster_solution.Count);

        if (faster_solution.Count > 0)
        {
            for (int i = 0; i < faster_solution.Count; i++)
            {
                faster_solution[i].MakeList();
            }

        }
        else
        {
            Debug.Log("No Path to solution was found");
            //Console.WriteLine("No Path to solution was found");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
