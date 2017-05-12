using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {


    int num;

    bool open_start = false;
    bool close_start = false;

    bool is_opening = false;
    bool is_closing = false; 

    public bool open = false;
    public bool close = false;

    float timer = 0;

    bool start_timer = false;

    public AudioClip open_box;
    public AudioClip empty;
    public AudioClip success;

    AudioSource ad;

    public GameObject obj;
    bool desobj = false;

    public GameObject shine;



    public GameObject parti;

    bool clearsound = false;
    // Use this for initialization
    void Start () {
        ad = GetComponent<AudioSource>();



    }
	
	// Update is called once per frame
	void Update () {

        if (open == true && close == false)
        {
            if(is_opening == false)
                open_start = true;
        }
		
        if(open_start == true)
        {
            //Debug.Log(transform.rotation.x);
           
            if (transform.rotation.x <0.8f)
            {
                this.transform.Rotate(-50 * Time.deltaTime, 0, 0);
                is_opening = true;

                
            }

            else
            {
                ad.Stop();


                if (clearsound == true)
                {
                    ad.clip = success;
                    clearsound = false;
                }


                else
                    ad.clip = empty;

                if (desobj == true)
                    parti.SetActive(true);

                ad.Play();
                open_start = false;
                is_opening = false;
                open = false;
                start_timer = true;
                
            }

        }

        if (start_timer == true)
        {
            timer += Time.deltaTime;
            if (timer > 2.5f)
            {
                //Debug.Log(timer);

                if (desobj == true)
                    destroyobj();

                ad.Stop();
                close = true;
                timer = 0.0f;
                start_timer = false;

            }
        }


        if (close == true && open == false)
        {
            //Debug.Log("안냥");

            if (is_closing == false)
                close_start = true;
        }

        if (close_start == true)
        {
            //Debug.Log(transform.rotation.x);
            if (transform.rotation.x > 0)
            {
                this.transform.Rotate(100 * Time.deltaTime, 0, 0);
                is_closing = true;


            }

            else
            {
                
                close_start = false;
                is_closing = false;
                close = false;
             

            }

        }



    }

  
    void bool_change()
    {
        ad.clip = open_box;
        ad.Play();
        open = true;
    }

    void destroyobj()
    {
        gameObject.tag = "Box";
        Destroy(obj.gameObject,0.5f);
        if(shine.GetComponent<ParticleSystem>()!= null)
            Destroy(shine.GetComponent<ParticleSystem>());
        if (parti.GetComponent<ParticleSystem>() != null)
            Destroy(parti.GetComponent<ParticleSystem>());
    }

    void desbool()
    {
        desobj = true;
        
    }

    void activeshine()
    {
        shine.SetActive(true);
    }

    void disactiveshine()
    {
        shine.SetActive(false);
    }

    
    void playsound(bool clear)
    {
        if (clear == true)
            clearsound = true;
        else
            clearsound = false;
    }
}
