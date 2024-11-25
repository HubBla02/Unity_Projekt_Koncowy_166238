using UnityEngine;

public class Apteczka : MonoBehaviour
{
     private float predkoscObrotu = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float kat = predkoscObrotu * Time.deltaTime;
        transform.Rotate(kat, kat, kat);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.ulecz(100);
        }
        Destroy(this.gameObject);
    }
}
