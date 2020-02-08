using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushAndAttract : MonoBehaviour
{
    public bool push = false;
    public bool pull = false;
    
    [SerializeField]
    private Transform player;

    private int distanceX, distanceY;

    private void Update()
    {
        distanceX = (int)transform.position.x - (int)player.transform.position.x;
        distanceY = (int)transform.position.y - (int)player.transform.position.y;
        Debug.Log(transform.position.y.ToString() + " - " + player.transform.position.y.ToString() + " = " + distanceY.ToString());

        if (distanceX <= 10 && distanceX >= 3)
        {
            if (push)
            {
            //distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
            }
            else if (pull)
            {
            //distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y);
            }
        }
        if (distanceX >= -10 && distanceX <= -3)
        {
            if (push)
            {
              //  distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y);
            }
            else if (pull)
            {
                //distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
            }
        }
        if (distanceY <= 10 && distanceY >= 3)
        {
            if (push)
            {
            //    distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
            }
            else if (pull)
            {
             //   distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
            }
        }
        if (distanceY >= -10 && distanceY <= -3)
        {
            if (push)
            {
               // distanceText.text = "Push";
                transform.position = new Vector2(transform.position.x , transform.position.y - 0.3f);
            }
            else if (pull)
            {
                //distanceText.text = "Pull";
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
            }
        }
    }
}
