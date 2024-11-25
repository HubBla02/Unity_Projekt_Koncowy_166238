using UnityEngine;
using UnityEngine.SceneManagement;

public class Dollvl2 : MonoBehaviour
{
    public AudioSource dzwiek;
    public AudioClip wygrana;
    public AudioClip hover;

    private void Start()
    {
        dzwiek.clip = wygrana;
        dzwiek.Play();
    }
    public void lvl2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void dzwiekNajechania()
    {
        dzwiek.clip = hover;
        dzwiek.Play();
    }
}
