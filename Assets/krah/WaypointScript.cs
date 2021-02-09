using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public bool starttrigger=false;
    public List<GameObject> birds;
    public List<Transform> pointsInOrder;
    public List<Outline> stationsInOrder;
    public Transform goal;
    [SerializeField]
    private int toGoal;
    public float speed;
    public float teiler;
    private Vector3 no;
    public float abstand;
    // Start is called before the first frame update
    void Start()
    {
        no = new Vector3(0, 0, 0);
        goal = pointsInOrder[9];
        toGoal = 9;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject b in birds)
        {
            Vector3 follow = goal.position - b.transform.position;
            Rigidbody r = b.GetComponent<Rigidbody>();
            r.velocity = r.velocity/teiler;
            r.AddForce(follow.normalized * speed);

            Vector3 relativePos = goal.position - b.transform.position;
            // the second argument, upwards, defaults to Vector3.up
            Vector3 oldrot = b.transform.eulerAngles;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Quaternion roto = Quaternion.Lerp(b.transform.rotation, rotation, Time.deltaTime*4f);
            float diff = oldrot.y - roto.eulerAngles.y;
            roto *= Quaternion.Euler(0, 0, diff);
            b.transform.rotation = roto;
            
        }
        if (Vector3.Distance(birds[0].transform.position, goal.position) < abstand && Vector3.Distance(birds[1].transform.position,goal.position) < abstand && Vector3.Distance(birds[2].transform.position, goal.position) < abstand && Vector3.Distance(birds[3].transform.position, goal.position) < abstand && Vector3.Distance(birds[4].transform.position, goal.position) < abstand)
        {
            if (stationsInOrder.Count <= toGoal && stationsInOrder[toGoal] != null)
            {
                stationsInOrder[toGoal].startBlink();
            }
            toGoal += 1;
            if (toGoal > pointsInOrder.Count-1)
            {
                toGoal = toGoal-1;
                stopBirds();
            }
            goal = pointsInOrder[toGoal];
        }
    }
    public void startBirds()
    {
        goal = pointsInOrder[0];
        toGoal = -1;
        foreach (GameObject b in birds)
        {
            b.SetActive(true);
        }
    }
    public void stopBirds()
    {
        foreach (GameObject b in birds)
        {
            b.SetActive(false);
        }
    }
}
