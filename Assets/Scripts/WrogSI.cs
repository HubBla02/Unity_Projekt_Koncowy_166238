using UnityEngine;

public class WrogSI : MonoBehaviour
{
    private MenadzerFal menadzerFal;

    private float predkosc = 4f;
    public int zycie = 50;
    public float dystans = 1;
    public float zasiegWidzenia = 10;
    public float katWidzenia = 40;
    public Transform gracz;
    private bool podazaZaGraczem = false;
    private float czasDoNastepnegoAtaku = 0;
    private bool czyZabity = false;

    private void Start()
    {
        menadzerFal = GetComponentInParent<MenadzerFal>();
        GameObject graczObiekt = GameObject.FindWithTag("gracz");
        gracz = graczObiekt.transform;
    }

    void Update()
    {
        if (podazaZaGraczem)
        {
            PodazajZaGraczem();
            SprawdzAtak();
        }
        else
        {
            SwobodnePoruszanie();
        }

        WykryjGracza();
    }

    void SwobodnePoruszanie()
    {
        transform.Translate(0, 0, predkosc * Time.deltaTime);
        Ray promien = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(promien, 0.5f, out hit))
        {
            if (hit.distance < dystans)
            {
                float obrot = Random.Range(-110, 110);
                transform.Rotate(0, obrot, 0);
            }
        }
    }

    void PodazajZaGraczem()
    {
        Vector3 kierunek = (gracz.position - transform.position).normalized;
        Quaternion nowyObrot = Quaternion.LookRotation(new Vector3(kierunek.x, 0, kierunek.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, nowyObrot, Time.deltaTime * 5);
        transform.Translate(0, 0, predkosc * Time.deltaTime);
    }

    void WykryjGracza()
    {
        Vector3 kierunekDoGracza = (gracz.position - transform.position).normalized;
        float katDoGracza = Vector3.Angle(transform.forward, kierunekDoGracza);

        if (katDoGracza < katWidzenia && Vector3.Distance(transform.position, gracz.position) <= zasiegWidzenia)
        {
            Ray promien = new Ray(transform.position, kierunekDoGracza);
            RaycastHit hit;

            if (Physics.Raycast(promien, out hit, zasiegWidzenia))
            {
                if (hit.transform.CompareTag("gracz"))
                {
                    podazaZaGraczem = true;
                }
            }
        }
    }

    void SprawdzAtak()
    {
        if (Vector3.Distance(transform.position, gracz.position) <= 5f)
        {
            if (Time.time >= czasDoNastepnegoAtaku)
            {
                czasDoNastepnegoAtaku = Time.time + 2f;
                gracz.GetComponent<Player>()?.otrzymanoObrazenia(10);
            }
        }
    }

    public void otrzymajObrazenia(int ile)
    {
        if (czyZabity) return;

        zycie -= ile;
        if (zycie <= 0)
        {
            czyZabity = true; 
            if (menadzerFal.fale[menadzerFal.aktualnaFala].iluWrogowZostalo > 0)
            {
                menadzerFal.fale[menadzerFal.aktualnaFala].iluWrogowZostalo--;
            }
            Destroy(this.gameObject);
        }
    }
}
