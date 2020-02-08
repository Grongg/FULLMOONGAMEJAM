using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushAndAttract : MonoBehaviour
{   
    [SerializeField]
    private Transform player;

    private int distanceX, distanceY;
    public bool state;
    private bool lastState;

    private void Start()
    {
        lastState = DataCollector.State;
    }
    private void Update()
    {
        if (lastState != DataCollector.State)
        {
            if (state == true)
                state = false;
            else
                state = true;
            lastState = DataCollector.State;
        }
        distanceX = (int)transform.position.x - (int)player.transform.position.x;
        distanceY = (int)transform.position.y - (int)player.transform.position.y;
        //Debug.Log(transform.position.y.ToString() + " - " + player.transform.position.y.ToString() + " = " + distanceY.ToString());
        if (distanceX <= 10 && distanceX >= 3)
        {
            if (state)
            {
            //distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            }
            else if (state == false)
            {
            //distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            }
        }
        if (distanceX >= -10 && distanceX <= -3)
        {
            if (state)
            {
              //  distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            }
            else if (state == false)
            {
                //distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            }
        }
        if (distanceY <= 10 && distanceY >= 3)
        {
            if (state)
            {
            //    distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }
            else if (state == false)
            {
             //   distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
            }
        }
        if (distanceY >= -10 && distanceY <= -3)
        {
            if (state)
            {
               // distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x , transform.position.y - 0.2f);
            }
            else if (state == false)
            {
                //distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }
        }
    }
}
