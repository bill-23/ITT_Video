using System;
using UnityEngine;

public class GameMoveJSON
{
    public string email;
    public string suggestedMove;
    public string satisfaction;
    public int blockToMove;
    public int count;

    public GameMoveJSON() { }

    public GameMoveJSON(string email, int blockToMove, string suggestedMove, string satisfaction, int count) {
        this.email = email;
        this.blockToMove = blockToMove;
        this.suggestedMove = suggestedMove;
        this.satisfaction = satisfaction;
        this.count = count;
    }

}

