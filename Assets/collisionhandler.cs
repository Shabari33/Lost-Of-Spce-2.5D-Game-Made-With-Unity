
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionhandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip engineboost;
    [SerializeField] AudioClip succes, failed;
    [SerializeField] ParticleSystem succesparticle, crashparticle;
    [SerializeField] GameObject levelcompletion;
    public bool iscontrallable = true;
    playermovement Playermovement;
    bool ispreddes = false;
    [SerializeField] TextMeshProUGUI paused;
    bool textshown;
    float interval = 0.5f;
    float next;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Playermovement = GetComponent<playermovement>();

    }
    private void Update()
    {
        pause();
        int sc = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(sc);
           
        }
        Quit();
    }

    private static void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (iscontrallable)
        {


            switch (collision.gameObject.tag)
            {

                case "Res":
                    Debug.Log("Res");
                    Newlevelling();

                    break;

                case "Obstacles":
                    audioSource.Stop();
                    audioSource.PlayOneShot(failed);
                    Playermovement.enabled = false;
                    playermovement.instance.mainengineparticle.Stop();
                    Invoke("Reloadscene", 2f);
                    iscontrallable = false;


                    Debug.Log("timedelay");

                    crashparticle.Play();

                    break;
                case "Final":
                    audioSource.Stop();
                    audioSource.PlayOneShot(succes);
                    succesparticle.Play();
                    Playermovement.enabled = false;
                    Invoke("Restart", 2f); 
                    break;



            }

        }
        else
        {
            return;
        }
    }


    private void Newlevelling()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(succes);
        Playermovement.enabled = false;

        succesparticle.Play();

        iscontrallable = false;

        Invoke("Newlevel", 2f);
    }

    private void Newlevel()
    {
        levelcompletion.SetActive(true);
    }

    public void Restart()
    {
        int se = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(se);
        SceneManager.LoadScene(se);
    }

    public void Reloadscene()
    {

        int sc = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sc);
    }

    private void Reloadings()
    {


    }
    public void quit()
    {
        Application.Quit();
    }
    public void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ispreddes == false)
        {
            Time.timeScale = 0f;
            paused.enabled = true;
            ispreddes = true;
            paused.text = "Game Has been Paused Press Esc to Resume";
            textshown = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispreddes && textshown==true)
        {
            Time.timeScale = 1f;
            paused.text = "Play.....";
            ispreddes = false;
            textshown = false;
            StartCoroutine(frrrrr());
            }
            
           
            }
    IEnumerator frrrrr()
    {
        yield return new WaitForSeconds(0.5f);
        paused.enabled = false; 
    }
   
      
             

             

            }
        
    

