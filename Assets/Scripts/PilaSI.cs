using UnityEngine;
using UnityEngine.Rendering;

public class PilaSI : MonoBehaviour
{
    public float predkosc = 10;
    public float dystans = 1;
    public int obrazenia = 50;
    public int zycie = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, predkosc * Time.deltaTime);
        Ray promien = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(promien, 0.15f, out hit) && (hit.collider.gameObject.tag == "sciana"))
        {
            if (hit.distance < dystans)
            {
                transform.Rotate(0, 180, 0);
            }
        };
    }

    public void otrzymajObrazenia(int ile)
    {
        zycie -= ile;
        if (zycie < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.otrzymanoObrazenia(obrazenia);
        }
    }
}
