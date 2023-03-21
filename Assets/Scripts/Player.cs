using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Player
{
    List<DominoObject> playerDominoes;

    public List<DominoObject> PlayerDominoes
    {
        get { return playerDominoes; }
    }

    private uint handPoints;

    public Player()
    {
        playerDominoes = new List<DominoObject>();
    }

    public uint HandPoints
    {
        get { return handPoints; }
    }

    public void addDomino(DominoObject d)
    {
        playerDominoes.Add(d);
        handPoints += d.Points;
    }

    public DominoObject removeDomino(DominoObject d)
    {
        playerDominoes.Remove(d);
        handPoints -= d.Points;
        if (playerDominoes.Count == 1)
        {
            DominoObject dominoToCheck = playerDominoes[0];
            if (dominoToCheck.Head == 0 && dominoToCheck.Tail == 0)
            {
                handPoints = 10;
            }
            else
            {
                handPoints = dominoToCheck.Points;
            }
        }

        return d;
    }

    public bool isHandEmpty()
    {
        return playerDominoes.Count == 0;
    }

    public uint numberOfDoubles()
    {
        if (!isHandEmpty())
        {
            uint DoublesNumber = 0;
            foreach (DominoObject d in playerDominoes)
            {
                if (d.IsDouble)
                {
                    DoublesNumber++;
                }
            }

            return DoublesNumber;
        }
        else
        {
            throw new Exception("The hand is empty!");
        }
    }

    public List<DominoObject> availableMoves(bool isStarted, uint head, uint tail)
    {
        if (!isStarted)
        {
            return playerDominoes;
        }
        else
        {
            List<DominoObject> availableDominoes = new List<DominoObject>();
            foreach (DominoObject d in playerDominoes)
            {
                if ((d.Head == head) || (d.Tail == tail) || (d.Head == tail) || (d.Tail == head))
                {
                    availableDominoes.Add(d);
                }
            }
            return availableDominoes;
        }
    }

    public void sort()
    {
        playerDominoes.Sort(new DominoObjectComparer());
    }
}
