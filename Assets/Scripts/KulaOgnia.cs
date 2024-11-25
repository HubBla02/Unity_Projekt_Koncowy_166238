using UnityEngine;

public class KulaOgnia : MonoBehaviour
{
    public float predkoscKuli = 20f;
    private int obrazenia = 30;
    private bool zadanoObrazenia = false;

    private void Start()
    {
        Invoke(nameof(Zniszcz), 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, predkoscKuli * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (zadanoObrazenia) return;

        Player gracz = other.GetComponent<Player>();
        if (gracz != null)
        {
            gracz.otrzymanoObrazenia(obrazenia);
            zadanoObrazenia = true; 
            Zniszcz(); 
        }
    }

    public void Zniszcz()
    {
        Destroy(this.gameObject);
    }
}
