
using UnityEngine;

public class oscillation : MonoBehaviour
{
   Vector3   startingpoint;
    [SerializeField] Vector3 endingpoint;
     float movementvector;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
     startingpoint=transform.position;
    
    }

    // Update is called once per frame
    void Update()
    { movementvector = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startingpoint, endingpoint, movementvector);
        
    }
}
