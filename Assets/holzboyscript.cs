using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holzboyscript : MonoBehaviour
{
    public Animator myanim;
    public Animator walkanim;
    public float timeer;
    public float redo;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        timeer = 0;
        //speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        timeer += speed;
        if (timeer > redo)
        {
            myanim.SetTrigger("go");
            walkanim.SetTrigger("go");
            timeer = 0;
        }
    }
}
