using UnityEngine;
using System.Collections;

public class Bomb_MediumFuse : MonoBehaviour
{

    public GameObject FuseCentre;
    public Light FuseLight;
    public ParticleSystem ExplodeVideoParticles;
    public ParticleSystem SparkTrailsParticles;
    public ParticleSystem SparkParticles;
    public AudioSource ExplodeAudio;
    public GameObject Bomb;
    public GameObject FuseObject;
    public GameObject BombExplode;
    public AnimationClip BombExplodeAnim;
    public AudioSource BurningFuseAudio;
    public Light ExplodeLight;

    private float offset = 0f;
    private float fuselightintensity = 0.4f;
    private float explodeset = 0f;
    private float explodehalt = 0f;
    private float nobomb = 0f;
    private float fadeStart = 0.5f;
    private float fadeEnd = 0f;
    private float fadeTime = 0.3f;
    private float t = 0.0f;
    private float fuseLit = 0f;




    private Rigidbody rb;
    public float power;

    bool explo = false;

    float size = 0.0f;

    bool stopmoving = false;

    AudioSource ad;
    // Use this for initialization
    void Start()
    {
        ad = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        ExplodeLight.intensity = 0;
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (explo == true ) //check to see if the left mouse was pressed - lights fuse
        {
            explo= false;
            stopmoving = true;
            if (nobomb != 1)
            {

                if (fuseLit != 1)
                {
                    offset = 0;
                    StartCoroutine(Fuse());
                    BurningFuseAudio.Play();
                    FuseCentre.SetActive(true);
                    explodehalt = 0;
                    explodeset = 0;
                }

            }

        }
       
        if(stopmoving == false)
            rb.AddForce(-this.transform.up * power);
        

        //if (Input.GetButtonDown("Fire2")) //check to see if the right mouse was pushed - resets bomb
        //{

        //    explodehalt = 1;
        //    explodeset = 0;
        //    offset = 0.5f;
        //    Bomb.SetActive(true);
        //    FuseObject.SetActive(true);
        //    FuseCentre.SetActive(false);
        //    BombExplode.SetActive(false);
        //    fuselightintensity = 0;
        //    FuseObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, 0));
        //    ExplodeVideoParticles.Clear();
        //    SparkParticles.Clear();
        //    SparkTrailsParticles.Clear();
        //    BurningFuseAudio.Stop();
        //    ExplodeLight.intensity = 0;
        //    nobomb = 0;
        //    fuseLit = 0;

        //}



        fuselightintensity = (Random.Range(0.2f, 0.4f));
        FuseLight.intensity = fuselightintensity;


        if (explodeset == 1)
        {
            Debug.Log("들어옴 bomb");
            Explosion();
        }

       

    }


    IEnumerator Fuse()
    {
        Debug.Log("들어옴 ie");
        while (offset < 0.02f)
        {
            offset += (Time.deltaTime * 0.11f);
            FuseObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            fuseLit = 1;
            yield return null;
        }

        if (explodehalt != 1)
        {
            explodeset = 1;
        }

        offset = 0;

    }

    void Explosion()
    {
     
        Debug.Log("들어옴 ex");
        FuseCentre.SetActive(false);
        Bomb.SetActive(false);
        BombExplode.SetActive(true);
        explodeset = 0;
        ExplodeVideoParticles.Play();
        SparkParticles.Play();
        SparkTrailsParticles.Play();
        ExplodeAudio.Play();
        StartCoroutine(FadeLight());
        
        Destroy(this.gameObject, 3f);

        // nobomb = 1; 
    }

    IEnumerator FadeLight()
    {
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            ExplodeLight.intensity = Mathf.Lerp(fadeStart, fadeEnd, t / fadeTime);
            yield return null;
        }

        t = 0;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            ad.Play();
           
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            explo = true;
            GameObject grand = other.transform.parent.gameObject;
            Destroy(grand.transform.parent.gameObject);
            Destroy(other.gameObject);
        }
    }
}