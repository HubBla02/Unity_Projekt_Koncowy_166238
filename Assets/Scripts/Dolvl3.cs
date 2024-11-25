using UnityEngine;
using UnityEngine.SceneManagement;

public class Dollvl3 : MonoBehaviour
{
    public AudioSource dzwiek;
    public AudioClip wygrana;
    public AudioClip hover;
    private void Start()
    {
        dzwiek.clip = wygrana;
        dzwiek.Play();
    }
    public void lvl3()
    {
        SceneManager.LoadScene("Level 3");
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
