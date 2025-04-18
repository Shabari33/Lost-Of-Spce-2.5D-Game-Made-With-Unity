using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Rotation : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(0, 180, 0*10f*Time.deltaTime);
        
    }
}
