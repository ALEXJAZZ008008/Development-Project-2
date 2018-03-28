using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour
{
    public GameObject choicePrefab;

    private List<GameObject> choiceList;

    void Awake()
    {
        choiceList = new List<GameObject>();
    }

    void OnEnable()
    {
        int angle = 360 / Scenarios.m_Choices.Count;

        int currentAngle = 0;

        for (int i = 0; i < Scenarios.m_Choices.Count; i++)
        {
            choiceList.Add(Instantiate(choicePrefab));

            choiceList[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Scenarios.m_Choices[i].GetChoiceText();

            choiceList[i].transform.RotateAround(Vector3.zero, Vector3.up, currentAngle);

            currentAngle += angle;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        for (int i = 0; i < choiceList.Count; i++)
        {
            Destroy(choiceList[i]);
        }

        choiceList.Clear();
    }
}
