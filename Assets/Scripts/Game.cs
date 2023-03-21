using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Game : MonoBehaviour
{
    private bool theGameEndedDrawn = false;
    public bool TheGameEndedDrawn
    {
        set { theGameEndedDrawn = value; }
        get { return theGameEndedDrawn; }
    }

    private int numberOfPlayersPassed = 2;
    public int NumberOfPlayersPassed
    {
        set { numberOfPlayersPassed = value; }
        get { return numberOfPlayersPassed; }
    }
    private bool isDoublerPassed = false;
    public bool IsDoublerPassed
    {
        set { isDoublerPassed = value; }
        get { return isDoublerPassed; }
    }
    private int numberOfMove = 0;
    public int NumberOfMove
    {
        set { numberOfMove = value; }
        get { return numberOfMove; }
    }

    private List<Player> players;
    public List<Player> Players
    {
        set { players = value; }
        get { return players; }
    }

    private readonly float spacing = 100;
    private Vector2 bottomCenter;
    private Vector2 topCenter;
    private Vector2 centerLeft;
    private Vector2 centerRight;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bottomCenter = Camera.main.ViewportToWorldPoint(new Vector2(-37, -75));
        topCenter = Camera.main.ViewportToWorldPoint(new Vector2(-37, 75));
        centerLeft = Camera.main.ViewportToWorldPoint(new Vector2(-75, -19));
        centerRight = Camera.main.ViewportToWorldPoint(new Vector2(88, -19));

        NumberOfPlayersPassed = PlayerPrefs.GetInt("numberOfPlayers", 2);
        IsDoublerPassed = PlayerPrefs.GetInt("doubleToggleValue", 0) == 1;
        StartTheGame(theGameEndedDrawn);
    }

    private void StartTheGame(bool theGameEndedDrawn)
    {
        GameTable gameTable = new GameTable(numberOfPlayersPassed, isDoublerPassed, theGameEndedDrawn);
        players = new List<Player>();

        Dominoes d = new Dominoes();
        Domino[] dominoes = d.generateDominoes();

        Canvas[] canvases = FindObjectsOfType<Canvas>();

        Canvas highestPriorityCanvas = canvases[0];

        foreach (Canvas canvas in canvases)
        {
            if (highestPriorityCanvas.sortingOrder < canvas.sortingOrder)
            {
                highestPriorityCanvas = canvas;
            }
        }

        float canvasHeight = highestPriorityCanvas.GetComponent<RectTransform>().rect.height;
        float canvasWidth = highestPriorityCanvas.GetComponent<RectTransform>().rect.width;
        float aspectRatio = canvasWidth / canvasHeight;

        Camera camera = Camera.main;
        camera.orthographicSize = canvasHeight / 2;
        camera.aspect = aspectRatio;

        Vector3 cameraPos = new Vector3(canvasWidth / 2, canvasHeight / 2, -10f);
        camera.transform.position = cameraPos;

        for (int i = 0; i < numberOfPlayersPassed; i++)
        {
            Player player;

            if (i == 0)
            {
                player = new HumanPlayer();
            }
            else
            {
                player = new ComputerPlayer();
            }

            for (int j = 0; j < 5; j++)
            {
                Domino domino = dominoes[i * 5 + j];

                GameObject dominoObject = new GameObject(domino.ToString());
                DominoObject dominoObjectScript = dominoObject.AddComponent<DominoObject>();

                dominoObjectScript.Domino = domino;

                player.addDomino(dominoObjectScript);
            }

            player.sort();

            for (int j = 0; j < 5; j++)
            {
                DominoObject dominoObjectScript = player.PlayerDominoes[j];

                dominoObjectScript.gameObject.transform.SetParent(highestPriorityCanvas.transform);
                dominoObjectScript.gameObject.AddComponent<RectTransform>();

                if (i == 0)
                {
                    Sprite sprite = Sprite.Create(dominoObjectScript.Texture, new Rect(0, 0, dominoObjectScript.Texture.width, dominoObjectScript.Texture.height), Vector2.zero);

                    SpriteRenderer renderer = dominoObjectScript.gameObject.AddComponent<SpriteRenderer>();
                    renderer.sprite = sprite;
                    renderer.sortingOrder = 1;
                    dominoObjectScript.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(204, 304);
                    dominoObjectScript.gameObject.GetComponent<RectTransform>().anchoredPosition = bottomCenter;
                    dominoObjectScript.gameObject.GetComponent<RectTransform>().localScale = new Vector2(40, 40);

                    bottomCenter.x += spacing;
                }
                else
                {
                    Sprite sprite = Sprite.Create(dominoObjectScript.HiddenTexture, new Rect(0, 0, dominoObjectScript.Texture.width, dominoObjectScript.Texture.height), Vector2.zero);

                    SpriteRenderer renderer = dominoObjectScript.gameObject.AddComponent<SpriteRenderer>();
                    renderer.sprite = sprite;
                    renderer.sortingOrder = 1;

                    dominoObjectScript.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(204, 304);
                    dominoObjectScript.gameObject.GetComponent<RectTransform>().localScale = new Vector2(40, 40);
                    if (i == 1)
                    {
                        dominoObjectScript.gameObject.GetComponent<RectTransform>().anchoredPosition = topCenter;
                        topCenter.x += spacing;
                    }
                    else if (i == 2)
                    {
                        dominoObjectScript.gameObject.GetComponent<RectTransform>().anchoredPosition = centerLeft;
                        dominoObjectScript.gameObject.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90); // Rotate the sprite 90 degrees to the right
                        centerLeft.y += spacing;
                    }
                    else if (i == 3)
                    {
                        dominoObjectScript.gameObject.GetComponent<RectTransform>().anchoredPosition = centerRight;
                        dominoObjectScript.gameObject.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90); // Rotate the sprite 90 degrees to the right
                        centerRight.y += spacing;
                    }
                }
            }

            players.Add(player);
        }


        // TO DO

        // 1) Attach click logic to Human Dominoes

        // 3) Work the logic of the game
    }
}
