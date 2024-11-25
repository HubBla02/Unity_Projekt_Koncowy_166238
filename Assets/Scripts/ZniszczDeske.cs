using UnityEngine;

public class ZniszczDeske : MonoBehaviour
{
    public float czasDoZniszczenia = 2f;
    private float czasNaObiekcie = 0f;
    private bool graczNaObiekcie = false;

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
            czasNaObiekcie = 0f;
        }
    }

    private void Update()
    {
        if (graczNaObiekcie)
        {
            czasNaObiekcie += Time.deltaTime;

            if (czasNaObiekcie >= czasDoZniszczenia)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
