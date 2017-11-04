using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickScript : MonoBehaviour {


    StickColors colors;
    float x, y, width, height;

    public Sprite stick;


	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        width = stick.rect.width;
        height = stick.rect.height;

        colors = new StickColors(x, y, width, height);



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}


class StickColors
{
    StickColor green, redL, orangeL, redR, orangeR;

    public StickColors(float x, float y, float width, float height)
    {
        redL = new StickColor(x, y, 0.125f * width, height, new Color(255, 0, 0));
        //redR = new StickColor(x+ width - , y, 0.125f * width, height, new Color(255, 0, 0));
    }

    void draw()
    {
        redL.draw();
       // red.draw();
       // orangeYellow.draw();
    }
}

class StickColor
{
    float x, y;
    float width, height;
    Color color;

    public void draw()
    {
        Texture2D texture = new Texture2D((int)width, (int)height);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(new Rect(new Vector2(x, y), new Vector2(width, height)), GUIContent.none);
    }

    public StickColor(float x, float y, float width, float height, Color color)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public float getX()
    {
        return x;
    }
    public float getY()
    {
        return y;
    }

    public float getWidth()
    {
        return width;
    }

    public float getHeight()
    {
        return height;
    }

    public void setX(float x)
    {
        this.x = x;
    }

    public void setY(float y)
    {
        this.y = y;
    }

    public void setWidth(float width)
    {
        this.width = width;
    }

    public void setHeight(float height)
    {
        this.height = height;
    }

    public void setColor(Color color)
    {
        this.color = color;
    }
}