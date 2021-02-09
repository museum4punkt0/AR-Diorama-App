using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class touchInputManager : MonoBehaviour
{
    public fadeInScript krug, ton, topfing;
    public GameObject startscreen1, startscreen2, startscreen3,impressoScreen,arScreen,datenschScreen,impressumScreen, rescan;
    [SerializeField]
    private bool infoShown=false;
    [SerializeField]
    private int infoModul = 2;
    public Animator infoInOut,infoScroll,bigInfoInOut,menueInOut;
    public GameObject[] scrollPoints;
    public RectTransform contentrect;
    private Vector2 newpiv = new Vector2(0.5f, 0);
    [SerializeField]
    private float swipeSpeed = 0;
    public float swipeSlowing;
    public float deltaX, deltaY;
    private RectTransform screen;
    private int activeID=-1;
    public TextMeshProUGUI infoContentL, infoContentM, infoContentR;
    public TextMeshProUGUI headerContentL, headerContentM, headerContentR;
    public TextMeshProUGUI stationContent;
    public GameObject[] biginfoContent = new GameObject[5];
    private List<string[]> infoTexte = new List<string[]>();
    private bool swiped = false;
    private bool scrollback = false;
    public rayCastTap rayRef;
    private float screen1timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        screen = gameObject.GetComponent<RectTransform>();
        Invoke("aktivethis", 0.01f);
        this.gameObject.SetActive(false);
        //                       station            headerL          headerM         headerR                 contentL                 contentM contentR
        string[] ofenTexte = { "Schachtofen", "Ganz schön heiß!", "Aufbau des Ofens", "Scherben verhindern Unglück", "Dies ist ein sogenannter Schachtofen. Mit seiner Hilfe brennt man Ton und Keramik. Hauptsächlich werden Schüsseln, Krüge und Töpfe hergestellt.", "Der Ofen teilt sich auf in Bedienungsgruben, Heizkammer und Brennkammer.", "Tonscherben decken den Ofen ab, um die Hitze darin zu stauen - und auch, um vor regen zu schützen."};
        string[] krugTexte = { "Krug Frau", "Schüssel-Momente", "Regenschutz", "Fehlerquote", "Es werden überwiegend Schüsseln und Krüge produziert", "Als Regenschutz werden Tonscherben als Abdeckung auf den Ofen gelegt.", "Zahlreiche verbrannte Produkte wurden in Erdgruben geworfen." };
        string[] tonTexte = { "Ton Lager", "Ressourcen vor Ort", "Ordnung ist alles", "Offen für die Kraft der Natur", "Der Schwemmkegel aus Lösslehm wird in Form von Gruben abgebaut.", "Der Lösslehm wird in unterschiedlichen Qualitäten getrennt aufbewahrt.", "Der Lehm wird bewusst dem Wetter ausgesetzt. So wird er geschmeidig und bearbeitbar." };
        string[] topferTexte = { "Töpferscheibe", "Fleißige Fußarbeit", "Zeit zum Durchatmen", "Typische Farbgebung", "Die Töpferscheibe wird mit dem rechten Fuß bedient.", "Die fertige Töpferarbeit wird direkt an der Luft getrocknet.", "Die typische rote Farbe kommt durch die Begussmasse aus Lehm-Schlick." };
        string[] zeitrTexte = { "Dioramabau", "Ganz schön echt", "Miniaturholz", "Viel Liebe zum Detail", "Die Dachschindeln, auf denen ich mich hier ausruhe, sind einzeln und aus Gips gefertigt.", "Für eine naturalistische Abbildung sorgen die Holzscheite aus Astholz.", "Alle Figuren im Diorama sind handgefertigte Unikate aus Gips." };
        infoTexte.Add(ofenTexte);
        infoTexte.Add(krugTexte);
        infoTexte.Add(tonTexte);
        infoTexte.Add(topferTexte);
        infoTexte.Add(zeitrTexte);
        impressoScreen.SetActive(false);
        arScreen.SetActive(false);
        datenschScreen.SetActive(false);
        impressoScreen.SetActive(false);
        startscreen1.SetActive(true);
        startscreen2.SetActive(true);
        startscreen3.SetActive(true);
        //ofen,krug,ton,topfer,zeitr
        screen1timer = Time.time;
    }
    private void aktivethis()
    {
        this.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > screen1timer + 2)
        {
            start1Tapp();
        }
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            deltaY += Input.GetTouch(0).deltaPosition.y;
            scrollBigInfo(Input.GetTouch(0).deltaPosition.y);
        }     */
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (!swiped)
            {
                if (Input.GetTouch(0).deltaPosition.x > 2f)
                {
                    infoSwipeRight();
                    swiped = true;
                }
                if (Input.GetTouch(0).deltaPosition.x < -2f)
                {
                    infoSwipeLeft();
                    swiped = true;
                }
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            swiped = false;
        }
        if (scrollback)
        {
            contentrect.localPosition += new Vector3(0, -20, 0);
        }
    }
    public void bigInfoIn()
    {
        bigInfoInOut.SetBool("infoIn",true);
        infoInOut.SetBool("infoMore", true);
        scrollback = true;
        Invoke("backscroll", 1f);
    }
    public void bigInfoOut()
    {
        scrollback = true;
        Invoke("backscroll", 1f);
        bigInfoInOut.SetBool("infoIn",false);
        infoInOut.SetBool("infoMore", false);
    }
    private void backscroll()
    {
        //contentrect.localPosition += new Vector3(0, -700, 0);
        scrollback = false;
    }

    public void menueOut()
    {
        menueInOut.SetBool("menueIn", false);
    }
    public void menueIn()
    {
        if (menueInOut.GetBool("menueIn"))
        {
            menueOut();
        }
        else
        {
            menueInOut.SetBool("menueIn", true);
            Invoke("menueOut", 2);
        }
    }

    public void start1Tapp()
    {
        startscreen1.SetActive(false);
    }
    public void start2Tapp()
    {
        startscreen2.SetActive(false);
    }
    public void start3Found()
    {
        startscreen3.SetActive(false);
        menueOut();
        rescan.SetActive(true);
    }

    private void infoSwipeRight()
    {
        infoScroll.SetTrigger("right");
        infoModul += 1;
        if (infoModul > 3)
        {
            infoModul = 1;
        }
        updateScrollPoints();
    }
    private void infoSwipeLeft()
    {
        infoScroll.SetTrigger("left");
        infoModul -= 1;
        if (infoModul <1)
        {
            infoModul = 3;
        }
        updateScrollPoints();
    }
    private void updateScrollPoints()
    {
        scrollPoints[0].SetActive(false);
        scrollPoints[1].SetActive(false);
        scrollPoints[2].SetActive(false);
        scrollPoints[infoModul - 1].SetActive(true);
    }
    public void closeInfo()
    {
        infoInOut.SetBool("infoSichtbar", false);
        krug.closeThisStation();
        ton.closeThisStation();
        topfing.closeThisStation();
        rayRef.closeOfen();

    }
    public void openInfo(int id)
    {
        if (activeID != id)
        {
            stationContent.text = infoTexte[id][0];
            headerContentL.text = infoTexte[id][1];
            headerContentM.text = infoTexte[id][2];
            headerContentR.text = infoTexte[id][3];
            infoContentL.text = infoTexte[id][4];
            infoContentM.text = infoTexte[id][5];
            infoContentR.text = infoTexte[id][6];
            if (activeID >= 0)
            {
                biginfoContent[activeID].SetActive(false);
            }
            biginfoContent[id].SetActive(true);
            activeID = id;
        }
        infoInOut.SetBool("infoSichtbar", true);
    }

    public void impressoIn()
    {
        impressoScreen.SetActive(true);
    }
    public void impressoOut()
    {
        impressoScreen.SetActive(false);
    }
    
    public void arScreenIn()
    {
        arScreen.SetActive(true);
    }
    public void datenschutzScreenIn()
    {
        datenschScreen.SetActive(true);
    }
    public void impressumScreenIn()
    {
        impressumScreen.SetActive(true);
    }
    public void arScreenOut()
    {
        arScreen.SetActive(false);
    }
    public void datenschutzScreenOut()
    {
        datenschScreen.SetActive(false);
    }
    public void impressumScreenOut()
    {
        impressumScreen.SetActive(false);
    }
}
