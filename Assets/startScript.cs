using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem paritclesWoosh;
    public Animator effectanim;

    // Update is called once per frame
    public void startWink()
    {
        paritclesWoosh.Play();
        effectanim.SetTrigger("go");
    }
}
