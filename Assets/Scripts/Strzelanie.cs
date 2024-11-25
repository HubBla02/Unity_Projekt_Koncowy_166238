using UnityEngine;

public class Strzelanie : MonoBehaviour
{
    public Camera kamera;
    public Transform drzwi;
    public Player gracz;
    public bool otwarte = false; 
    public float katOtwarcia = -90f; 
    public float czasOtwarcia = 0.5f;
    private WrogSI trafionyWrog;
    private DuchSI trafionyDuch;
    private BossSI trafionyBoss;
    private PilaSI trafionaPila;
    private Quaternion zamknietaRotacja;
    private Quaternion otwartaRotacja; 
    private bool animacjaWTrakcie = false;
    private AudioSource dzwiek;
    public AudioClip dzwiekStrzalu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dzwiek = GetComponent<AudioSource>();
        kamera = Camera.main;
        gracz = transform.GetComponent<Player>();
        GameObject drzwiObiekt = GameObject.FindWithTag("drzwi");
        if (drzwiObiekt != null)
        {
            drzwi = drzwiObiekt.transform;

            zamknietaRotacja = drzwi.rotation;
            otwartaRotacja = zamknietaRotacja * Quaternion.Euler(0, katOtwarcia, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pauza.czyPauza)
        {
            Vector3 celownik = new Vector3(kamera.pixelWidth / 2, kamera.pixelHeight / 2, 0f);
            Ray promien = kamera.ScreenPointToRay(celownik);
            RaycastHit cel;

            if (Physics.Raycast(promien, out cel))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    dzwiek.clip = dzwiekStrzalu;
                    dzwiek.Play();
                }
                if (Input.GetMouseButtonDown(0) && cel.transform != null && cel.transform.CompareTag("wrog"))
                {
                    WrogSI wrog = cel.transform.GetComponent<WrogSI>();
                    if (wrog != null)
                    {
                        trafionyWrog = wrog;
                        if (gracz != null)
                        {
                            trafionyWrog.otrzymajObrazenia(gracz.obrazenia);
                        }
                    }
                }

                if (Input.GetMouseButtonDown(0) && cel.transform != null && cel.transform.CompareTag("duch"))
                {
                    DuchSI wrog = cel.transform.GetComponent<DuchSI>();
                    if (wrog != null)
                    {
                        trafionyDuch = wrog;
                        if (gracz != null)
                        {
                            trafionyDuch.otrzymajObrazenia(gracz.obrazenia);
                        }
                    }
                }

                if (Input.GetMouseButtonDown(0) && cel.transform != null && cel.transform.CompareTag("boss"))
                {
                    BossSI wrog = cel.transform.GetComponent<BossSI>();
                    if (wrog != null)
                    {
                        trafionyBoss = wrog;
                        if (gracz != null)
                        {
                            trafionyBoss.otrzymajObrazenia(gracz.obrazenia);
                        }
                    }
                }

                if (Input.GetMouseButtonDown(0) && cel.transform.CompareTag("pila"))
                {
                    PilaSI pila = cel.transform.GetComponent<PilaSI>();
                    if (pila != null)
                    {
                        trafionaPila = pila;
                        trafionaPila.otrzymajObrazenia(gracz.obrazeniaPila);
                    }
                }

                if (cel.transform.CompareTag("obrot") && Input.GetKeyDown(KeyCode.E))
                {
                    PrzelaczDrzwi();
                }
            }
        }
    }


    public void PrzelaczDrzwi()
    {
        if (animacjaWTrakcie) return; 

        otwarte = !otwarte;
        StartCoroutine(ObracajDrzwi(otwarte ? otwartaRotacja : zamknietaRotacja));
    }

    private System.Collections.IEnumerator ObracajDrzwi(Quaternion docelowaRotacja)
    {
        animacjaWTrakcie = true;
        float czas = 0;

        Quaternion poczatkowaRotacja = drzwi.rotation;

        while (czas < czasOtwarcia)
        {
            drzwi.rotation = Quaternion.Slerp(poczatkowaRotacja, docelowaRotacja, czas / czasOtwarcia);
            czas += Time.deltaTime;
            yield return null;
        }

        drzwi.rotation = docelowaRotacja;
        animacjaWTrakcie = false;
    }
}
