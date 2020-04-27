using UnityEngine;

public class RustRandomTest : MonoBehaviour
{
    private void Awake()
    {
        RustRandom.Initialize();
    }

    private void Start()
    {
        Debug.Log("Random number: " + RustRandom.GetRandomInt());
    }

    private void OnDestroy()
    {
        RustRandom.Dispose();
    }
}
