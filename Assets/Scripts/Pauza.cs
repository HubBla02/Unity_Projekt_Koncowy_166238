using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauza : MonoBehaviour
{
    public GameObject MenuPauzy;
    public static bool czyPauza;
    public AudioSource dzwiek;
    public AudioClip dzwiekNajechania;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuPauzy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (czyPauza)
            {
                Cursor.lockState = CursorLockMode.Locked;
                grajDalej();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                pauza();
            }
        }
        
    }

    public void pauza()
    {
        MenuPauzy.SetActive(true);
        Time.timeScale = 0.0f;
        czyPauza = true;
    }

    public void grajDalej()
    {
        MenuPauzy.SetActive(false);
        Time.timeScale = 1.0f;
        czyPauza = false;
    }

    public void menu()
    {
        Time.timeScale = 1.0f;
        czyPauza = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void odwtorzDzwiek()
    {
        dzwiek.clip = dzwiekNajechania;
        dzwiek.Play();
    }
}
