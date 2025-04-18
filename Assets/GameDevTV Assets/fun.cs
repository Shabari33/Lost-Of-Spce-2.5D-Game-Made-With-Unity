using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fun : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI funtext,credits;
 
    // Start is called before the first frame update
    void Start()
    {
        funtext.text = "Your System has been Hacked";
        StartCoroutine(str());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){ 
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    
    }
    IEnumerator str()
    {
        yield return new WaitForSeconds(3f);
           
        funtext.text = "Just Kidding Thanks For Playing!";
    

    }
}
