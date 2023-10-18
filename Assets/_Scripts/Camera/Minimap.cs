using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public GameObject img;


    void Start()
    {
        Camera camera = Camera.main;
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        Vector3 map = new Vector3(40, 30);

        float tiledai = map.x / (2 * p.x);
        float tilerong = map.y / (2 * p.y);

        int pixeldai = (int)(gameObject.GetComponent<Camera>().pixelWidth / tiledai);
        int pixelrong = (int)(gameObject.GetComponent<Camera>().pixelHeight / tilerong);

        Debug.Log(tiledai + " " + tilerong);
        Debug.Log(pixeldai + " " + pixelrong);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
