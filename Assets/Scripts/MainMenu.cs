using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject sterowanie;
    public GameObject opis;
    public GameObject credits;
    public AudioSource dzwiek;
    public AudioClip hover;
    public AudioClip pressed;

    void Start()
    {
       Cursor.lockState = CursorLockMode.Confined;
    }
    public void Graj()
    {
        dzwiekWcisniecia();
        SceneManager.LoadScene("Level 1");
    }

    public void Wyjscie()
    {
        dzwiekWcisniecia();
        Application.Quit();
    }

    public void PokazSterowanie(bool wlacz)
    {
        dzwiekWcisniecia();
        sterowanie.SetActive(wlacz);
    } 
    public void Opis(bool wlacz)
    {
        dzwiekWcisniecia();
        opis.SetActive(wlacz);
    }

    public void Credits(bool wlacz)
    {
        dzwiekWcisniecia();
        credits.SetActive(wlacz);
    }


    public void dzwiekNajechania()
    {
        dzwiek.clip = hover;
        dzwiek.Play();
    }    
    private void dzwiekWcisniecia()
    {
        dzwiek.clip = pressed;
        dzwiek.Play();
    }
}
