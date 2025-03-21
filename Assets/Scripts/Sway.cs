using UnityEngine;

public class Sway : MonoBehaviour
{
    public float rotateAmount = 1.0f;
    public float maxRotateAmount = 4.0f;
    public float smoothRotate = 2.0f;
    float tiltY;
    float tiltX;
    public static bool isRotate = true;

    public static Vector3 startPosition = Vector3.zero;
    private Vector3 defaultPosition;

    void Start()
    {
        isRotate = true;
        startPosition = transform.localPosition;
        defaultPosition = transform.localPosition;
    }

    void Update()
    {
        if (isRotate)
        {
            tiltY = Mathf.Lerp(tiltY, (Input.GetAxis("Mouse Y")) * rotateAmount, Time.deltaTime * 15f);
            tiltX = Mathf.Lerp(tiltX, (Input.GetAxis("Mouse X")) * rotateAmount, Time.deltaTime * 15f);

            if (tiltY > maxRotateAmount)
            {
                tiltY = maxRotateAmount;
            }

            if (tiltY < -maxRotateAmount)
            {
                tiltY = -maxRotateAmount;
            }

            if (tiltX > maxRotateAmount)
            {
                tiltX = maxRotateAmount;
            }

            if (tiltX < -maxRotateAmount)
            {
                tiltX = -maxRotateAmount;
            }

            Vector3 targetPos = new Vector3(defaultPosition.x + tiltX, defaultPosition.y + tiltY, startPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * smoothRotate);
        }
    }
}