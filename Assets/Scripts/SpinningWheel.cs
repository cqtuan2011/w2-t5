using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinningWheel : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;

    private float anglePerPos;

    private const float Wheel = 360f;
    private const float numberOfPos = 9;

    private float startAngle;

    private float timer;

    private int playerInput;

    public int numberOfCircle = 2;
    public float timeRotate = 5;

    private void Start()
    {
        anglePerPos = Wheel / numberOfPos;
    }
    
    IEnumerator Rotate()
    {
        startAngle = transform.eulerAngles.z;
        timer = 0;

        float angleWant = (numberOfCircle * Wheel) + anglePerPos * playerInput - startAngle - 10;
        
        while (timer < timeRotate)
        {
            yield return new WaitForEndOfFrame();

            timer += Time.deltaTime;

            float angleCurrent = angleWant * curve.Evaluate(timer / timeRotate);

            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent + startAngle);
        }

        Debug.Log($"Player wins {playerInput} hearts and {playerInput} golds");
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerInput = 1;
            StartCoroutine(Rotate());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerInput = 2;
            StartCoroutine(Rotate());
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerInput = 3;
            StartCoroutine(Rotate());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerInput = 4;
            StartCoroutine(Rotate());
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerInput = 5;
            StartCoroutine(Rotate());
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerInput = 6;
            StartCoroutine(Rotate());
        }

        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            playerInput = 7;
            StartCoroutine(Rotate());
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            playerInput = 8;
            StartCoroutine(Rotate());
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerInput = 9;
            StartCoroutine(Rotate());
        }
    }
}
