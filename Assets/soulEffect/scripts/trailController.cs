using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailController : MonoBehaviour
{
    public ParticleSystem startPart,endPart;
    public fadeInScript ghostFadeRef;
    public Transform goalPoint;
    public Transform startPoint;
    public float goalRadius;
    public float startRadius;
    public float speed;
    public Vector3 mov;
    public int phase = 0;
    public float winkel;
    public float upMult;
    public float downMult;
    private Transform nowGoal;
    private float runtime=0;
    // Start is called before the first frame update
    void Start()
    {
        mov = transform.forward;
        this.transform.position += new Vector3(0.1f,0,0);
        nowGoal = startPoint;
        Invoke("moveThing", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
        {
            Vector3 mypos = this.transform.position;
            mypos.y = 0;
            Vector3 midpos = nowGoal.position;
            midpos.y = 0;
            mov = (mypos - midpos).normalized;
            mov = Quaternion.AngleAxis(180f-getRotVec(speed,startRadius), this.transform.right) * mov;
            this.transform.position += mov*(speed/2);
            this.transform.position += this.transform.up * upMult;
            runtime += Time.deltaTime;
            if (runtime > 1.5f)
            {
                phase = 2;
                nowGoal = goalPoint;
            }
            //mov = Quaternion.AngleAxis(tang,this.transform.up) * mov;
        }
        if (phase == 2)
        {
            this.transform.position += (nowGoal.position - this.transform.position).normalized*(speed/2);
            if (Vector3.Distance(this.transform.position, nowGoal.position) < goalRadius)
            {
                phase = 3;
                runtime = 0;
                endPart.Play();
                ghostFadeRef.startDissolve();
                //animref.SetTrigger("wonder");
            }
        }
        if (phase == 3)
        {
            Vector3 mypos = this.transform.position;
            mypos.y = 0;
            Vector3 midpos = nowGoal.position;
            midpos.y = 0;
            mov = (mypos - midpos).normalized;
            mov = Quaternion.AngleAxis(180f - getRotVec(speed, startRadius), this.transform.up) * mov;
            this.transform.position += mov * (speed / 2);
            this.transform.position += this.transform.up * -downMult;
            runtime += Time.deltaTime;
            if (runtime > 1.5f)
            {
                phase = 4;
                //Invoke("moveThing", 1);
            }
        }
    }
    public void moveThing()
    {
        startPart.Play();
        phase = 1;
        runtime = 0;
        nowGoal = startPoint;
        this.transform.position = nowGoal.position + new Vector3(0.1f,0,0);
    }
    private float getRotVec(float _speed, float _radius)
    {
        float ankat = _speed / 2;
        float hypo = _radius;
        float win = Mathf.Acos(ankat / hypo) * (180 / Mathf.PI);
        
        return win;
    }
}
