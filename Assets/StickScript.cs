using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickScript : MonoBehaviour {


    StickColors colors;


	// Use this for initialization
	void Start () {
        colors();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


class StickColors
{
    StickColor green, red, orangeYellow;

    StickColors(int width, int height)
    {

    }

    void draw()
    {
        green.draw();
        red.draw();
        orangeYellow.draw();
    }
}

class StickColor
{
    int x, y;
    int width, height;
    Color color;

    public void draw()
    {
        Texture2D texture = new Texture2D(width, height);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(new Rect(new Vector2(x, y), new Vector2(width, height)), GUIContent.none);
    }

    public StickColor(int x, int y, int width, int height, Color color)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    public void setX(int x)
    {
        this.x = x;
    }

    public void setY(int y)
    {
        this.y = y;
    }

    public void setWidth(int width)
    {
        this.width = width;
    }

    public void setHeight(int height)
    {
        this.height = height;
    }

    public void setColor(Color color)
    {
        this.color = color;
    }
}