using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maksZycie = 100;
    public int zycie;
    public int obrazenia;
    public int obrazeniaPila;
    public TMP_Text wyswietlZycie;
    public Porazka oknoPorazki;
    private AudioSource dzwiek;
    public AudioClip dzwiekObrazen;
    public AudioClip dzwiekLeczenia;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        dzwiek = GetComponent<AudioSource>();
        zycie = maksZycie;
        obrazenia = 20;
        obrazeniaPila = 10;
        GameObject wyswietlaczZycia = GameObject.FindWithTag("zycie");
        if (wyswietlaczZycia != null)
        {
            wyswietlZycie = wyswietlaczZycia.GetComponent<TMP_Text>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (zycie <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("Przegrana");
        }
    }

    public void otrzymanoObrazenia(int ile)
    {
        dzwiek.clip = dzwiekObrazen;
        dzwiek.Play();
        zycie -= ile;
        wyswietlZycie.text = zycie.ToString();
    }

    public void ulecz(int ile)
    {
        dzwiek.clip = dzwiekLeczenia;
        dzwiek.Play();
        zycie += ile;
        if (zycie > maksZycie)
        {
            zycie = maksZycie;
        }
        wyswietlZycie.text = zycie.ToString();
    }
}
