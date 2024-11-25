using UnityEngine;
using UnityEngine.SceneManagement;

public class Wygrana : MonoBehaviour
{
    public AudioSource dzwiek;
    public AudioClip wygrana;
    public AudioClip hover;

    private void Start()
    {
        dzwiek.clip = wygrana;
        dzwiek.Play();
    }
    public void menu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("MainMenu");
    }
    public void dzwiekNajechania()
    {
        dzwiek.clip = hover;
        dzwiek.Play();
    }
}
