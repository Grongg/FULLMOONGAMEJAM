using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushAndAttract : MonoBehaviour
{
    public bool push = false;
    public bool pull = false;
    
    [SerializeField]
    private Transform checkpoint;
    
    [SerializeField]
    private TextMeshProUGUI distanceText;

    private int distanceX, distanceY;

    private void Update()
    {
        distanceX = (int)checkpoint.transform.position.x - (int)transform.position.x;
        distanceY = (int)checkpoint.transform.position.y - (int)transform.position.y;
        Debug.Log(checkpoint.transform.position.y.ToString() + " - " + transform.position.y.ToString() + " = " + distanceY.ToString());

        if (distanceX <= 10 && distanceX >= 3)
        {
            if (push)
            {
            distanceText.text = "Push";
            checkpoint.transform.position = new Vector2(checkpoint.transform.position.x + 0.3f, checkpoint.transform.position.y);
            }
            else if (pull)
            {
            distanceText.text = "Pull";
            checkpoint.transform.position = new Vector2(checkpoint.transform.position.x - 0.3f, checkpoint.transform.position.y);
            }
        }
        if (distanceX >= -10 && distanceX <= -3)
        {
            if (push)
            {
                distanceText.text = "Push";
                checkpoint.transform.position = new Vector2(checkpoint.transform.position.x - 0.3f, checkpoint.transform.position.y);
            }
            else if (pull)
            {
                distanceText.text = "Push";
                checkpoint.transform.position = new Vector2(checkpoint.transform.position.x + 0.3f, checkpoint.transform.position.y);
            }
        }
        if (distanceY <= 10 && distanceY >= 3)
        {
            if (push)
            {
                distanceText.text = "Push";
                checkpoint.transform.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y + 0.3f);
            }
            else if (pull)
            {
                distanceText.text = "Pull";
                checkpoint.transform.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y - 0.3f);
            }
        }
        if (distanceY >= -10 && distanceY <= -3)
        {
            if (push)
            {
                distanceText.text = "Push";
                checkpoint.transform.position = new Vector2(checkpoint.transform.position.x , checkpoint.transform.position.y - 0.3f);
            }
            else if (pull)
            {
                distanceText.text = "Pull";
                checkpoint.transform.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y + 0.3f);
            }
        }
    }
}
