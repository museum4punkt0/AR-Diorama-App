using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastTap : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public fadeInScript krugFrau, hackePeter, topferTyp;
    public GameObject ofenOpen, ofenClosed;
    public touchInputManager uiMan;
    public startScript zeitrTyp;
    void Start()
    {
        //Invoke("test", 4);
    }
    private void test()
    {
        uiMan.openInfo(1);
    }
    private void toggleOfen()
    {
        if (ofenClosed.activeSelf)
        {
            ofenClosed.SetActive(false);
            ofenOpen.SetActive(true);
        }
        else
        {
            ofenClosed.SetActive(true);
            ofenOpen.SetActive(false);
            uiMan.closeInfo();
        }
    }
    public void closeOfen()
    {
        ofenClosed.SetActive(true);
        ofenOpen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit hit;
                //ofen,krug,ton,topfer,zeitr
                if (Physics.Raycast(ray,out hit))
                {
                    if (hit.transform.name == "krugTrigger")
                    {
                        krugFrau.startDissolve();
                        uiMan.openInfo(1);
                    }
                    if (hit.transform.name == "hackTrigger")
                    {
                        hackePeter.startDissolve();
                        uiMan.openInfo(2);
                    }
                    if (hit.transform.name == "topferTrigger")
                    {
                        topferTyp.startDissolve();
                        uiMan.openInfo(3);
                    }
                    if (hit.transform.name == "zeitrTrigger")
                    {
                        zeitrTyp.startWink();
                        uiMan.openInfo(4);
                    }
                    if (hit.transform.name == "ofen")
                    {
                        uiMan.openInfo(0);
                        toggleOfen();
                    }
                    if (hit.transform.name == "krugreset")
                    {
                        krugFrau.resetandstart();
                    }
                    if (hit.transform.name == "tonreset")
                    {
                        hackePeter.resetandstart();
                    }
                    if (hit.transform.name == "topfreset")
                    {
                        topferTyp.resetandstart();
                    }
                }
            }
        }
    }
}
