using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float predkosc = 6f;
    public float grawitacja = -20f; 
    public float skok = 10f;     

    private UnityEngine.CharacterController kontroler;
    private float predkoscPionowa;
    private Vector3 ruch;

    void Start()
    {
        kontroler = GetComponent<UnityEngine.CharacterController>();
    }

    void Update()
    {
        float osX = Input.GetAxis("Horizontal");
        float osZ = Input.GetAxis("Vertical");

        Vector3 ruchPoziomy = transform.right * osX + transform.forward * osZ;
        ruchPoziomy *= predkosc;

        if (kontroler.isGrounded)
        {
            predkoscPionowa = -1f; 

            if (Input.GetButtonDown("Jump"))
            {
                predkoscPionowa = Mathf.Sqrt(skok * -2f * grawitacja);
            }
        }
        else
        {
            predkoscPionowa += grawitacja * Time.deltaTime;
        }

        ruch = ruchPoziomy;
        ruch.y = predkoscPionowa;

        kontroler.Move(ruch * Time.deltaTime);
    }
}
