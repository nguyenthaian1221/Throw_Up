using JetBrains.Annotations;
using UnityEngine;


public class CoreGameplay : MonoBehaviour
{

    public float windForce;

    public static CoreGameplay Instance { get; private set; }

    private void Awake()
    {
        Instance ??= this;
    }


}
