using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SceneSwitch
{
    public Transform player;
    public float posX;
    public float posY;
    public float posX1;
    public float posY1;
    public float posX2;
    public float posY2;
    public float posX3;
    public float posY3;
    public float posX4;
    public float posY4;
    public float posX5;
    public float posY5;
    public float posX6;
    public float posY6;
    public string previous;
    public string previous1;
    public string previous2;
    public string previous3;
    public string previous4;
    public string previous5;
    public string previous6;
    public Transform Camera;
    public float camPos;


    public override void Start()
    {
        base.Start();

        if(prevScene == previous)
        {
            player.position = new Vector2(posX, posY);
            Camera.position = new Vector2(posX, posY + camPos);
        }
        else if(prevScene == previous1)
        { 
            player.position = new Vector2(posX1, posY1);
            Camera.position = new Vector2(posX1, posY1 + camPos);
        }
        else if (prevScene == previous2)
        {
            player.position = new Vector2(posX2, posY2);
            Camera.position = new Vector2(posX2, posY2 + camPos);
        }
        else if (prevScene == previous3)
        {
            player.position = new Vector2(posX3, posY3);
            Camera.position = new Vector2(posX3, posY3 + camPos);
        }
        else if (prevScene == previous4)
        {
            player.position = new Vector2(posX4, posY4);
            Camera.position = new Vector2(posX4, posY4 + camPos);
        }
        else if (prevScene == previous5)
        {
            player.position = new Vector2(posX5, posY5);
            Camera.position = new Vector2(posX5, posY5 + camPos);
        }
        else if (prevScene == previous6)
        {
            player.position = new Vector2(posX6, posY6);
            Camera.position = new Vector2(posX6, posY6 + camPos);
        }
    }
}
