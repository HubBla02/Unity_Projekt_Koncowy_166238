using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float czulosc = 1.5f;
    public float min = -45f;
    public float max = 45f;
    private float rotacjaX = 0f;
    private float rotacjaY = 0f;

    private void Update()
    {
        rotacjaX -= Input.GetAxis("Mouse Y") * czulosc;
        rotacjaX = Mathf.Clamp(rotacjaX, min, max);

        rotacjaY = Input.GetAxis("Mouse X") * czulosc;

        float rotacja = transform.localEulerAngles.y + rotacjaY;

        transform.localEulerAngles = new Vector3(rotacjaX, rotacja, 0f);

    }
}
