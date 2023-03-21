using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Dominoes
{
    private readonly Domino[] listOfDominoes = {
        new Domino(0, 0),
        new Domino(0, 1), new Domino(1, 1),
        new Domino(0, 2), new Domino(1, 2), new Domino(2, 2),
        new Domino(0, 3), new Domino(1, 3), new Domino(2, 3), new Domino(3, 3),
        new Domino(0, 4), new Domino(1, 4), new Domino(2, 4), new Domino(3, 4), new Domino(4, 4),
        new Domino(0, 5), new Domino(1, 5), new Domino(2, 5), new Domino(3, 5), new Domino(4, 5), new Domino(5, 5),
        new Domino(0, 6), new Domino(1, 6), new Domino(2, 6), new Domino(3, 6), new Domino(4, 6), new Domino(5, 6), new Domino(6, 6)
        };

    public Dominoes()
    {

    }

    public Domino[] generateDominoes()
    {
        Domino[] dominoesToPlay = (Domino[]) listOfDominoes.Clone();

        System.Random rng = new System.Random();
        int n = dominoesToPlay.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Domino value = dominoesToPlay[k];
            dominoesToPlay[k] = dominoesToPlay[n];
            dominoesToPlay[n] = value;
        }

        return dominoesToPlay;
    }

}
