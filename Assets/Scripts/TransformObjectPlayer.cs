using UnityEngine;

public class TransformObjectPlayer : MonoBehaviour
{
    [SerializeField] private Transform _obj;
    public float distanceFromCamera = 5f; // Расстояние от камеры

    [SerializeField] private float maxScrollCounter = 10f;
    [Range(1f, 35f)]
    [SerializeField] private float scrollCounter = 1f;
    
    [SerializeField] private Vector3 _startPosObj = Vector3.zero;
    [Range(1f, 6f)]
    [SerializeField] private float coofizientPos = 5.43f; //5.43 провера в update 
    private void Start()
    {
        _startPosObj = _obj.position;
        
    }
    void Update()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        scrollCounter += mouseScroll;
        scrollCounter = Mathf.Clamp(scrollCounter, 1f, maxScrollCounter);
        _obj.localScale = new Vector3(scrollCounter, scrollCounter, scrollCounter);
        _obj.position = _startPosObj + new Vector3(0f, 0f, scrollCounter - 1f) * coofizientPos;
        Debug.Log(scrollCounter);
    }
}
