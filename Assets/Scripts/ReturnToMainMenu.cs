using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public float timer;

    private float time;

    void Start()
    {
        time = timer;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
