using UnityEngine;
using UnityEngine.UI;

public class PasekZycia : MonoBehaviour
{
    [SerializeField] private Image pasekZycia;
    private Camera kamera;

    private void Start()
    {
        kamera = Camera.main;
    }

    public void aktualizuj(float maks, float aktualne)
    {
        pasekZycia.fillAmount = aktualne / maks;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - kamera.transform.position);
    }
}
