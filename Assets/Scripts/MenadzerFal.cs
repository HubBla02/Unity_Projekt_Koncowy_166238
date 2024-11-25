using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenadzerFal : MonoBehaviour
{
    [SerializeField] private GameObject PunktWzywania;
    [SerializeField] private GameObject PWDuch;
    public Fala[] fale;
    public int aktualnaFala = 0;

    private void Start()
    {
        for (int i = 0; i < fale.Length; i++)
        {
            fale[i].iluWrogowZostalo = fale[i].podstawowi.Length + fale[i].duchy.Length;
        }

        StartCoroutine(wezwijFale());
    }

    void Update()
    {
        
        if (aktualnaFala >= fale.Length)
        {
            string scena = SceneManager.GetActiveScene().name;
            Cursor.lockState = CursorLockMode.Confined;
            if (scena == "Level 1")
            {
                SceneManager.LoadScene("Level 1 wygrany");
            } 
            if (scena == "Level 2")
            {
                SceneManager.LoadScene("Level 2 wygrany");
            }
            return;
        }

        if (fale[aktualnaFala].iluWrogowZostalo == 0)
        {
            aktualnaFala++;
            if (aktualnaFala < fale.Length)
            {
                StartCoroutine(wezwijFale());
            }
        }
    }

    public IEnumerator wezwijFale()
    {
        if (aktualnaFala < fale.Length)
        {
            for (int i = 0; i < fale[aktualnaFala].podstawowi.Length; i++)
            {
                WrogSI wrog = Instantiate(fale[aktualnaFala].podstawowi[i], PunktWzywania.transform);
                wrog.transform.SetParent(PunktWzywania.transform);
                yield return new WaitForSeconds(fale[aktualnaFala].czasDoNastepengo);
            }

            for (int i = 0; i < fale[aktualnaFala].duchy.Length; i++)
            {
                DuchSI duch = Instantiate(fale[aktualnaFala].duchy[i], PWDuch.transform);
                duch.transform.SetParent(PWDuch.transform);
                yield return new WaitForSeconds(fale[aktualnaFala].nastepnyDuch);
            }
        }
    }
}

[System.Serializable]
public class Fala
{
    public WrogSI[] podstawowi;
    public DuchSI[] duchy;
    public float czasDoNastepengo = 1f;
    public float nastepnyDuch = 1f;
    [HideInInspector] public int iluWrogowZostalo;
}

