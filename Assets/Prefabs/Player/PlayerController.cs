using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterContoller;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float angleMaxYCamera = 60f;
    [SerializeField] private float Sensitivity = 100f;
    [SerializeField] private float _cameraHor = 0f;
    [SerializeField] private float _cameraVer = 0f;
    [SerializeField] private float _speedCamera = 0.1f;
    private void Start()
    {
        _characterContoller = GetComponent<CharacterController>();
        _cameraTransform = transform.GetChild(0).GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        MoveLogic();
    }
    private void LateUpdate()
    {
        CameraLogic();
    }

    private void CameraLogic()
    {
        float hor = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float ver = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        _cameraVer -= ver;
        _cameraHor += hor;
        

        _cameraVer = Mathf.Clamp(_cameraVer, -angleMaxYCamera, angleMaxYCamera);
        _cameraTransform.localRotation = Quaternion.Lerp(_cameraTransform.localRotation, Quaternion.Euler(_cameraVer, 0f, 0f), _speedCamera);
        transform.localRotation = Quaternion.Lerp(_cameraTransform.localRotation, Quaternion.Euler(0f, _cameraHor, 0f), _speedCamera);
    }

    private void MoveLogic()
    {
        _characterContoller.Move(_movement * speed * Time.deltaTime);
    }

    private Vector3 _movement
    {
        get
        {
            float hor = Input.GetAxis("Horizontal") ;
            float ver = Input.GetAxis("Vertical") ;

            Vector3 move = transform.right * hor + transform.forward * ver;
            return move;
        }
    }
}
