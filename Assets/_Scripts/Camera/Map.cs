using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //[SerializeField]
    //private GameObject _ground;
    [SerializeField]
    private GameObject _backGround;

    public Vector2 SizeOfBackground;

    public static Map Instance { get; private set; }

    private void Awake()
    {
        Instance ??= this;
    }
    void Start()
    {
        SizeOfBackground = _backGround.GetComponent<Renderer>().bounds.size;
    }


}
