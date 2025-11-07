using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform);    
    }
    
}
