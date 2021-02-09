using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInScript : MonoBehaviour
{
    [SerializeField]
    private bool running = false;
    public Material trans;
    private Material cutmat;
    public List<GameObject> additionalObjects;
    public float heightMask;
    private float disAmout = 1;
    private float disSpeed = 0;
    public float speed = 0.02f;
    private Renderer myrend;
    
    private float glow;
    private float timer;
    public float startDisAfter;
    private bool started = false;
    public Animator effectanim;
    public ParticleSystem effectPartic;
    public float verzog;
    public Animator ghostAnimator;
    public float startAnimDelay;
    public float AnimDauerTillReset;
    public GameObject restartButton;

    public bool waitforReady = false;

    private void Start()
    {
        myrend = GetComponent<Renderer>();
        cutmat = myrend.material;
        //disSpeed = speed;
        timer = -1;
        //Invoke("startDissolve", 2);
        restartButton.SetActive(false);
    }

    private void Update()
    {
        if (started)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                //aufbauen von oben nach unten
                UpdateShaderProperties(disAmout);
                disAmout -= disSpeed;
                if (timer <= 0.2)
                {
                    foreach (GameObject o in additionalObjects)
                    {
                        o.SetActive(true);
                    }
                }
                if (timer < 0)
                {
                    myrend.material = trans;
                    glow = 0.01f;
                }
            }
            else
            {
                Color old = myrend.material.color;
                if (glow<0.6f)
                {
                    glow += 0.03f;
                    myrend.material.SetColor("_EmissionColor", old * glow);
                }
                else
                {
                    //reset
                }
            }
        }
    }

    public void startDissolve()
    {
        if (!running)
        {
            running = true;
            resetStation();
            effectanim.SetTrigger("go");
            effectPartic.Play();
            Invoke("goBlendin", verzog);
            waitforReady = true;
        }
    }
    public void goBlendin()
    {
        disSpeed = speed;
        timer = startDisAfter;
        started = true;
        if (ghostAnimator != null)
        {
            Invoke("startAnimGhost", startAnimDelay);
        }
    }
    private void startAnimGhost()
    {
        ghostAnimator.SetTrigger("go");
        Invoke("restartButtonShow", AnimDauerTillReset);
        //Invoke("resetStation", AnimDauerTillReset);
        //Invoke("openStation", AnimDauerTillReset + 0.5f);
        //Invoke("startDissolve", AnimDauerTillReset+5);
    }
    public void restartButtonShow()
    {
        if (waitforReady == true)
        {
            restartButton.SetActive(true);
        }
    }
    private void openStation()
    {
        running = false;
    }
    public void resetStation()
    {
        waitforReady = false;
        myrend.material = cutmat;
        disAmout = 1;
        UpdateShaderProperties(disAmout);
        ghostAnimator.SetTrigger("reset");
        foreach (GameObject o in additionalObjects)
        {
            o.SetActive(false);
        }
        Invoke("openStation", 1.5f);
    }
    public void closeThisStation()
    {
        if (waitforReady)
        {
            restartButton.SetActive(false);
            resetStation();
        }
    }
    public void resetandstart()
    {
        restartButton.SetActive(false);
        resetStation();
        Invoke("startDissolve", 0.5f);
    }

    private void UpdateShaderProperties(float perc)
    {
        float _height = heightMask * perc;
        Vector3 position= new Vector3(0,_height,0);
        myrend.material.SetVector("_PlanePosition", position);
    }
}
