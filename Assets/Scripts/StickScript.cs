using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour {

    public GameObject red;
    public GameObject orange;
    public GameObject green;
    public GameObject pointer;
    [SerializeField]
    public GameObject gameManager;

    private bool gameOver = true;

    public static float height = 70;
    public static float decrement = 5f;

    private float greenWidth;
    private float orangeWidth;
    private float redWidth;

    private float speed;
    private int direction;
    private float position;
    public static float maxPos = 2.44f;

    System.Random rand;

	void Start ()
    {
        greenWidth = green.transform.localScale.x;
        orangeWidth = orange.transform.localScale.x;
        redWidth = red.transform.localScale.x;
        direction = -1;
        position = pointer.transform.position.x;
        speed = 2;

        rand = new System.Random();

    }
	
	void Update ()
    {
        if (gameOver)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                gameOver = false;
        }
        else
        {
            //update width
            updateWidth();
            //update objects
            green.transform.localScale = new Vector3(greenWidth, height, 1);
            orange.transform.localScale = new Vector3(orangeWidth, height, 1);
            //update pointer
            updatePointer();
            pointer.transform.position = new Vector3(position, pointer.transform.position.y, 1);
            // Debug.Log("green Width: " + greenWidth);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchAssessment();
            }

        }
    }

    private void updateWidth()
    {
        greenWidth -= (greenWidth / decrement * Time.deltaTime);
        orangeWidth = redWidth - (redWidth - greenWidth) / 2;
    }

    private void updatePointer()
    {
        if (direction == 1 && position >= maxPos || direction == -1 && position <= -maxPos)
        {
            direction *= -1;
        }

        position += speed * Time.deltaTime * direction;
    }

    public void move()
    {
        speed += 0.25f;
        if(rand.Next(0, 2) > 0)
        {
            direction = 1;
            position = 2.44f;
        } else
        {
            direction = -1;
            position = -2.44f;
        }

        gameManager.GetComponent<GameManagerScript>().AddHighscore();

        greenWidth = 250;
        orangeWidth = 375;
        
    }

    void ResetValues()
    {
        speed = 2f;
        greenWidth = 250;
        orangeWidth = 375;

        position = 2.44f;
        direction = 1;
        
        green.transform.localScale = new Vector3(greenWidth, height, 1);
        orange.transform.localScale = new Vector3(orangeWidth, height, 1);
        
        pointer.transform.position = new Vector3(position, pointer.transform.position.y, 1);
    }

    void touchAssessment()
    {
        float courserPos = Mathf.Abs(((position * 500) / 2.44f));

        Debug.Log(courserPos.ToString("0.00"));
        //Debug.Break();

        if (courserPos < orangeWidth)
        {
            move();
        }
        else
        {
            ResetValues();
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        gameManager.GetComponent<GameManagerScript>().GameOver();
    }
}
