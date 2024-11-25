using UnityEngine;

public class DuchSI : MonoBehaviour
{
    private MenadzerFal menadzerFal;

    private float predkosc = 4f;
    public int zycie = 70;
    public Transform gracz;
    public float czasDoNastepnegoAtaku = 0;
    private bool czyZabity = false;
    private void Start()
    {
        menadzerFal = GetComponentInParent<MenadzerFal>();
        GameObject graczObiekt = GameObject.FindWithTag("gracz");
        gracz = graczObiekt.transform;
    }
    void Update()
    {
        PodazajZaGraczem();
        SprawdzAtak();

    }

    void PodazajZaGraczem()
    {
        Vector3 kierunek = (gracz.position - transform.position).normalized;
        Quaternion nowyObrot = Quaternion.LookRotation(new Vector3(kierunek.x, 0, kierunek.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, nowyObrot, Time.deltaTime * 5);

        transform.Translate(kierunek * predkosc * Time.deltaTime, Space.World);
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

    void SprawdzAtak()
    {
        if (Vector3.Distance(transform.position, gracz.position) <= 2f)
        {
            if (Time.time >= czasDoNastepnegoAtaku)
            {
                czasDoNastepnegoAtaku = Time.time + 2f;
                gracz.GetComponent<Player>()?.otrzymanoObrazenia(10);
            }
        }
    }
}
