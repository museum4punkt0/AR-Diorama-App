using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasisScript : MonoBehaviour
{
    public touchInputManager uimanager;
    public holzboyscript holzboywalk;
    private bool foundTarget = false;
    public GameObject ground;
    public float timeold;
    private bool stopse = false;
    public WaypointScript birds;
    private bool fly = false;

    // Start is called before the first frame update
    void Start()
    {
        ground.SetActive(false);
        timeold = 0;
    }
    private void startFly()
    {
        birds.startBirds();
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundTarget)
        {
            if(GameObject.Find("SampleTarget(Clone)") != null)
            {
                GameObject target = GameObject.Find("SampleTarget(Clone)");
                this.transform.position = target.transform.position;
                this.transform.rotation = target.transform.rotation;
                this.transform.Rotate(new Vector3(90, 0, 0));
                foundTarget = true;
                timeold += 1;
                holzboywalk.speed = 0.01f;
                ground.SetActive(true);
                if (!fly)
                {
                    fly = true;
                    Invoke("startFly", 5);
                    uimanager.start3Found();
                }
            }
        }
        if (timeold<10)
        {
            if (!stopse)
            {
                foundTarget = false;
            }
        }
    }

    public void stopSearch()
    {
        stopse = true;
    }
    public void research()
    {
        fly = false;
        stopse = false;
        foundTarget = false;
        timeold = 0;
    }
}
