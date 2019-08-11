using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float downSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        transform.Translate(0, -downSpeed * Time.deltaTime, 0);
    }
}
