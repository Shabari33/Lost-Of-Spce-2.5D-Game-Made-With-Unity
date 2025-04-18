
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playermovement : MonoBehaviour

{
    public bool iscollider=false;   
    Rigidbody rb;
    [SerializeField] InputAction up;
    [SerializeField] float speed;        
    [SerializeField] InputAction roatate;
    [SerializeField] float rotationspeed;
    
    //public bool ispressed=false;
    AudioSource AudioSource;
    [SerializeField] AudioClip engineboost;
    [SerializeField] AudioClip succes, failed;
    public ParticleSystem succesparticle, crashparticle,mainengineparticle,Rightengineparticle,leftengineparticle;
    // Start is called before the first frame update
   
    public static playermovement instance;
    public GameObject launchpad;
    float timer = 0.3f;
    float inerval;
    private void Awake()
    {
        instance = this;    
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    private void OnEnable()
    {
        up.Enable();
        roatate.Enable();   
    }
    private void FixedUpdate()
    {
        Thrustings();

        Rotation();

    }

    public void Rotation()
    {
        if (roatate.IsPressed())
        {
            float rot = roatate.ReadValue<float>();
            Debug.Log(rot);
            if (rot < 0f)
            {

                rb.freezeRotation = true;
                transform.Rotate(Vector3.forward * rotationspeed * Time.fixedDeltaTime);
            
                rb.freezeRotation = false;
                if (!leftengineparticle.isPlaying)
                {
                    leftengineparticle.Play();
                }
                Rightengineparticle.Stop();



            }
            else if (rot > 0f)
            {
                rb.freezeRotation = true;
                leftengineparticle.Stop();
                transform.Rotate(Vector3.forward * -rotationspeed * Time.fixedDeltaTime);
            
                rb.freezeRotation = false;
                if (!Rightengineparticle.isPlaying)
                {
                    Rightengineparticle.Play();
                }
            }
            else
            {
                Debug.Log("Entered");
                leftengineparticle.Stop();
                Rightengineparticle.Stop();
            }

        }
    }

    public void Thrustings()
    {
        if (up.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.fixedDeltaTime);
            if (!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
            if (!mainengineparticle.isPlaying)
            {
                mainengineparticle.Play();
            }

            else
            {
                mainengineparticle.Stop();
                AudioSource.Stop();
            }
        }
    }

    

    private void OnDisable()
    {
        up.Disable();
        roatate.Disable();  
    }
  

   
}
