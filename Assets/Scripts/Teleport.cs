using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float czasDoWyrzutu = 3f;
    private float silaWyrzutu = 100000f;
    private float czasNaObiekcie = 0f;
    private bool graczNaObiekcie = false;
    public AudioClip dzwiekOczekiwania;
    public AudioClip dzwiekWyrzutu;
    public AudioSource audioSource;
    public GameObject gracz;
    public GameObject cel;
    private float czasDoDzwieku = 1f;
    private float czasOstatniegoDzwieku = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("gracz"))
        {
            graczNaObiekcie = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("gracz"))
        {
            graczNaObiekcie = false;
            czasOstatniegoDzwieku = 0f;
            czasNaObiekcie = 0f;
        }
    }

    private void Update()
    {
        if (graczNaObiekcie)
        {
            czasNaObiekcie += Time.deltaTime;

            if (czasNaObiekcie - czasOstatniegoDzwieku >= czasDoDzwieku && czasNaObiekcie < czasDoWyrzutu)
            {
                OdtworzDzwiek(dzwiekOczekiwania);
                czasOstatniegoDzwieku = czasNaObiekcie;
            }

            if (czasNaObiekcie >= czasDoWyrzutu)
            {
                Teleportuj();
                graczNaObiekcie = false;
                czasNaObiekcie = 0f;
            }
        }
    }

    private void Teleportuj()
    {
        Rigidbody graczRigidbody = gracz.GetComponent<Rigidbody>();
        if (graczRigidbody != null)
        {
            Vector3 gdzie = new Vector3(0, 2, 0);
            gracz.transform.position = cel.transform.position + gdzie;
            OdtworzDzwiek(dzwiekWyrzutu);
        }
    }

    private void OdtworzDzwiek(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
