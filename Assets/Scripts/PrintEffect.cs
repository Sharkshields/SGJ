using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintEffect : MonoBehaviour
{
    // скрипт для выода текста о законе Мерфи
    // в начале с эффетком печатующей машинки

    private string text;

    private void Start()
    {
        text = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach(char abc in text) // цикл для прохода по каждой букве
        {
            GetComponent<Text>().text += abc;
            yield return new WaitForSeconds(0.1f); // задаем интервал между каждой буквой во времени
        }
    }
}
