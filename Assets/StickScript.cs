using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour {

    public GameObject red;
    public GameObject orange;
    public GameObject green;

    public static float height = 70;
    public static float decrement = 0.5f;

    private float greenWidth;
    private float orangeWidth;

	void Start ()
    {
        greenWidth = green.transform.localScale.x;
        orangeWidth = orange.transform.localScale.x;
	}
	
	void Update ()
    {
        //update width
        //update objects
        green.transform.localScale = new Vector3(greenWidth, height, 1);
        orange.transform.localScale = new Vector3(orangeWidth, height, 1);
        //update pointer

    }

    void updateWidth()
    {
        green.
    }

    public void move()
    {

    }
}
