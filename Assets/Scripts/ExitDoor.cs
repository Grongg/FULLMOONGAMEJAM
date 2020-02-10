using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && DataCollector.iSPressed == true)
        {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }
}
