using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text fNumTxt;
    public static string op;
    public Text operatorTxt;
    public Text sNumTxt;
    public Text feedBackTxt;
    public Text questText;

    public Button nextQuestBtn;
    public List<Button> ansChoices;

    int answer;

    // Start is called before the first frame update
    void Start()
    {
        RandQuest();

        foreach (Button btn in ansChoices)
        {
            btn.onClick.AddListener(delegate { CheckAnswer(btn); });
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandQuest()
    {
        int fNum = Random.Range(0, 11);
        int sNum = Random.Range(0, 11);

        switch (op)
        {
            case "+":
                operatorTxt.text = "+";
                answer = fNum + sNum;
                break;
            case "-":
                operatorTxt.text = "-";
                answer = fNum - sNum;
                break;

            default:
                break;
        }

        fNumTxt.text = fNum.ToString();
        sNumTxt.text = sNum.ToString();

        AssignChoiceValues();

    }

    void AssignChoiceValues()
    {
        List<int> randQList = new List<int>();
        for (int i = 0; i < ansChoices.Count; i++)
        {
            while (true)
            {
                int randNum = Random.Range(0, 11);
                if (randNum == answer || (randQList.Contains(randNum)))
                {
                    continue;
                }
                randQList.Add(randNum);
                ansChoices[i].GetComponentInChildren<Text>().text = randNum.ToString();
                break;
            }

        }
        ansChoices[Random.Range(0, ansChoices.Count)].GetComponentInChildren<Text>().text = answer.ToString(); //assigns the correct answer randomly
    }

    void CheckAnswer(Button btn)
    {
        if (btn.GetComponentInChildren<Text>().text == answer.ToString())
        {
            feedBackTxt.text = "Yay!!!";
            questText.text = answer.ToString();
            nextQuestBtn.gameObject.SetActive(true);

            foreach (var elm in ansChoices)
            {
                elm.gameObject.SetActive(false);
            }
        }
        else
        {
            feedBackTxt.text = "Try Again !!!";
            questText.text = "?";
            nextQuestBtn.gameObject.SetActive(false);
        }
    }
}
