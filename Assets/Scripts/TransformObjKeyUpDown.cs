using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObjKeyUpDown : MonoBehaviour
{
    public Camera mainCamera; // Ссылка на основную камеру
    public float scalingSpeed = 1f; // Скорость изменения размера
    public float distanceFromCamera = 5f; // Изначальное расстояние от камеры

    private Vector3 initialScale; // Исходный размер объекта

    void Start()
    {
        initialScale = transform.localScale; // Сохраняем исходный размер объекта
        UpdatePosition(); // Устанавливаем начальную позицию
    }

    void Update()
    {
        // Проверка нажатия клавиш для изменения размера
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ScaleObject(1); // Увеличение размера
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ScaleObject(-1); // Уменьшение размера
        }

        // Устанавливаем позицию объекта, чтобы он оставался на одном расстоянии
        UpdatePosition();
    }

    private void ScaleObject(int direction)
    {
        // Рассчитываем новый размер объекта
        float newScale = transform.localScale.x + direction * scalingSpeed * Time.deltaTime;
        transform.localScale = new Vector3(newScale, newScale, newScale);

        // Устанавливаем позицию объекта на основе изменения размера
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        // Рассчитываем новую позицию объекта на основании расстояния и изменения размера
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 direction = (transform.position - cameraPosition).normalized;
        transform.position = cameraPosition + direction * distanceFromCamera * transform.localScale.x / initialScale.x;
    }
}
