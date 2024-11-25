using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSI : MonoBehaviour
{
    public Transform gracz;
    private float maxPredkoscObrotu = 360f;

    private int maksZycie = 1200;
    private int zycie;
    private int obrazenia = 30;
    public AudioSource dzwiekLeczenia;
    public AudioSource dzwiekStrzalu;
    public AudioClip leczenie;
    public AudioClip strzal;

    private GameObject pocisk;
    public GameObject pociskPrefab;

    [SerializeField] private PasekZycia pasekZycia;

    private Rigidbody graczRigidbody;

    void Start()
    {
        zycie = maksZycie;
        pasekZycia.aktualizuj(maksZycie, zycie);
        if (gracz != null)
        {
            graczRigidbody = gracz.GetComponent<Rigidbody>();
        }

        InvokeRepeating(nameof(ulecz), 5f, 10f);
        InvokeRepeating(nameof(strzel), 1f, 1f);
    }

    void Update()
    {
        if (gracz == null || graczRigidbody == null)
            return;

        Vector3 kierunekDoGracza = (gracz.position - transform.position).normalized;
        float predkoscObrotu = 50f;

        Quaternion docelowyObrot = Quaternion.LookRotation(kierunekDoGracza, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, docelowyObrot, predkoscObrotu * Time.deltaTime);
    }

    public void otrzymajObrazenia(int ile)
    {
        zycie -= ile;
        pasekZycia.aktualizuj(maksZycie, zycie);
        if (zycie < 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("Wygrana");
        }
    }

    public void ulecz()
    {
        dzwiekLeczenia.clip = leczenie;
        dzwiekLeczenia.Play();
        zycie += 100;
        pasekZycia.aktualizuj(maksZycie, zycie);
        if (zycie > maksZycie)
        {
            zycie = maksZycie;
        }
    }

    public void strzel()
    {
        dzwiekStrzalu.clip = strzal;
        dzwiekStrzalu.Play();

        pocisk = Instantiate(pociskPrefab) as GameObject;
        Vector3 offset = transform.forward * 2f; 
        offset.y = 1f; 

        pocisk.transform.position = transform.position + offset;  
        pocisk.transform.rotation = transform.rotation;  
    }
}
