using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Vector3 hoch = new Vector3(0,20f,0);
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag != "bird")
        {
            this.GetComponent<Rigidbody>().AddForce(hoch);
        }
    }
}
