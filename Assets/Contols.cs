
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contols : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            SceneManager.LoadScene("Mainmenu");
        }
    }
}
