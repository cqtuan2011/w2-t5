﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinningWheel : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;

    private float anglePerPos;

    private const float Wheel = 360f;
    private const int numberOfPos = 9;

    private float startAngle;

    private float timer;

    private int playerInput;

    public int numberOfCircle = 2;
    public float timeRotate = 5;

    private GameObject[] gift = new GameObject[numberOfPos];

    private void Start()
    {
        anglePerPos = Wheel / numberOfPos;

        for (int i = 0; i < numberOfPos; i++)
        {
            gift[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
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

        ClaimReward();
    }

    private void Update()
    {
        CheckInput();
    }

    IEnumerator Sequence()
    {
        yield return StartCoroutine(Rotate());
        yield return StartCoroutine(LoadNewScene());
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerInput = 1;
            StartCoroutine(Sequence());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerInput = 2;
            StartCoroutine(Sequence());
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerInput = 3;
            StartCoroutine(Sequence());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerInput = 4;
            StartCoroutine(Sequence());
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerInput = 5;
            StartCoroutine(Sequence());
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerInput = 6;
            StartCoroutine(Sequence());
        }

        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            playerInput = 7;
            StartCoroutine(Sequence());
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            playerInput = 8;
            StartCoroutine(Sequence());
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerInput = 9;
            StartCoroutine(Sequence());
        }
    }
    void ClaimReward()
    {
        Debug.Log($"Player wins {playerInput} hearts and {playerInput} golds");

        int childCount = gift[playerInput - 1].transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            gift[playerInput - 1].transform.GetChild(i).GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(playerInput);
    }
}
