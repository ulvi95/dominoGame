using System;
using System.Collections.Generic;
using UnityEngine;

public class DominoObject : MonoBehaviour
{
    private bool dominoIsSet = false;

    private Domino domino;
    public Domino Domino
    {
        get { return domino; }
        set
        {
            if (!dominoIsSet)
            {
                domino = value;
                dominoIsSet = true;
            }
        }
    }

    public uint Head { get { return Domino.Head; } }
    public uint Tail { get { return Domino.Tail; } }
    public bool IsDouble { get { return Domino.IsDouble; } }
    public uint Points { get { return Domino.Points; } }
    public Texture2D Texture { get { return Domino.Texture; } }
    public Texture2D HiddenTexture { get { return Domino.HiddenTexture; } }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}