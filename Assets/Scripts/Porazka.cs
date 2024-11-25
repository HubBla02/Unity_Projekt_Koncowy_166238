using UnityEngine;
using UnityEngine.SceneManagement;

public class Porazka : MonoBehaviour
{
    public AudioSource dzwiek;
    public AudioClip porazka;
    public AudioClip hover;

    private void Start()
    {
        dzwiek.clip = porazka;
        dzwiek.Play();
    }
    public void restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void dzwiekNajechania()
    {
        dzwiek.clip = hover;
        dzwiek.Play();
    }

}
