using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() // Fonction that is attached to QuitButton to quit game
    {
        Debug.Log("QUIT"); // log "Quit" to see that it's work in the unity creator
        Application.Quit(); // quit the game
    }
}
