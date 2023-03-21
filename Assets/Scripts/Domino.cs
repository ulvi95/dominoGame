using System;
using UnityEngine;

public class Domino
{
    private uint head;
    private uint tail;
    private bool isDouble;
	private Texture2D texture;
    private Texture2D hiddenTexture;

    public uint Head
    {
        get { return head; }
    }

    public uint Tail
    {
        get { return tail; }
    }    

    public bool IsDouble
    {
        get { return isDouble; }
    }
	
	public uint Points
    {
        get { return head+tail; }
    }

    public Texture2D Texture
    {
        get { return texture; }
    }

    public Texture2D HiddenTexture
    {
        get { return hiddenTexture; }
    }

    // Constructor to create a domino tail.

    public Domino(uint head, uint tail)
    {
        if(head >= 0 && head <= 6 && tail >= 0 && tail<=6 )
        {
            this.head = head;
            this.tail = tail;
            this.isDouble = (head == tail);
			
			string fileName = head.ToString() + "-" + tail.ToString() + ".png";
			string filePath = "Assets//Images//DominoTilesImages//"+fileName;
			byte[] imageData = System.IO.File.ReadAllBytes(filePath);
			texture = new Texture2D(204, 304);
			texture.LoadImage(imageData);

            string fileNameHidden = "HiddenTile.png";
            string filePathHidden = "Assets//Images//DominoTilesImages//" + fileNameHidden;
            byte[] imageDataHidden = System.IO.File.ReadAllBytes(filePathHidden);
            hiddenTexture = new Texture2D(204, 304);
            hiddenTexture.LoadImage(imageDataHidden);
        }
        else
        {
            throw new Exception("Error - Both the head and tail must be between 0 and 6 inclusive [0, 1, 2, 3, 4, 5, 6]");
        }
    }
	
	public override string ToString()
    {
        return head + "-" + tail;
    }
}
