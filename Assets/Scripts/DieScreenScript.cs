using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DieScreenScript : MonoBehaviour
{
    public GameObject textMesh;
    public GameObject layer;
    public float timer;

    private float time;
    private Renderer layerRenderer;
    private TextMeshProUGUI textMeshRenderer;

    void Start()
    {
        time = timer;
        layerRenderer = layer.GetComponent<Renderer>();
        layerRenderer.material.color = new Color(layerRenderer.material.color.r, layerRenderer.material.color.g, layerRenderer.material.color.b, 0.0f);
        textMeshRenderer = textMesh.GetComponent<TextMeshProUGUI>();
        textMeshRenderer.color = new Color(textMeshRenderer.color.r, textMeshRenderer.color.g, textMeshRenderer.color.b, 0f);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
        layerRenderer.material.color = new Color(layerRenderer.material.color.r, layerRenderer.material.color.g, layerRenderer.material.color.b, Mathf.Sqrt((timer - time) / timer));
        textMeshRenderer.color = new Color(textMeshRenderer.color.r, textMeshRenderer.color.g, textMeshRenderer.color.b, Mathf.Sqrt((timer - time) / timer));
    }
}
