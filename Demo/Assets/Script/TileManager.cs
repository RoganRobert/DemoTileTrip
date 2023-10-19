using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    [SerializeField] private ImgData[] answerWordList;     
    [SerializeField] private ImgData[] optionsWordList;
    public bool isMatch = false;
    public GameObject gameOver;

    private List<int> selectedWordsIndex;
    private string nameI;
    public List<GameObject> listI;
    public List<GameObject> ListA;
    private int currentAnswerIndex = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        nameI = gameObject.name;
        selectedWordsIndex = new List<int>();
        Debug.Log("" + selectedWordsIndex);
        ListAnswer();
        //ClearPic();
    }

    private void Update()
    {
        //CheckM();
        //ExecuteAnswer();
        GameOver();
    }

    public void SelectedOption(ImgData imgData)
    {
        //if (currentAnswerIndex >= answerWord.Length) return;
        answerWordList[currentAnswerIndex].SetImg(imgData.imValue);
        imgData.gameObject.SetActive(false);
        currentAnswerIndex++;

    }

    public void ListAnswer()
    {
        for (int i = 0; i < answerWordList.Length; i++)
        {
            if (ListA.Contains(answerWordList[i].gameObject) == false)
            {
                ListA.Add(answerWordList[i].gameObject);

            }
        }
    }

    public void ExecuteAnswer()
    {
        for (int i = 2; i < ListA.Count; i++)
        {
            ListA[i - 1].gameObject.SetActive(false);
            ListA.Remove(ListA[i - 1]);
            ListA[i].gameObject.SetActive(false);
            ListA.Remove(ListA[i]);
            ListA[i + 1].gameObject.SetActive(false);
            ListA.Remove(ListA[i + 1]);
            
            

        }
    }

    public void GameOver()
    {
        Debug.Log(optionsWordList);
        for (int i = 0; i < optionsWordList.Length; i++)
        {
            
            if (optionsWordList[i].gameObject.activeSelf == false)
            {
                if (listI.Contains(optionsWordList[i].gameObject) == false)
                {
                    
                    listI.Add(optionsWordList[i].gameObject);
                    CheckM();
                }

            }
        }
        if (listI.Count() == optionsWordList.Count())
        {
            gameOver.SetActive(true);
        }
    }

    public void CheckM()
    {
        for (int i = 1; i < listI.Count; i++)
        {
            
            if(i > 0 && i <= i - 1)
            {
                if (optionsWordList[i - 1].gameObject.tag == optionsWordList[i].gameObject.tag && optionsWordList[i].gameObject.tag == optionsWordList[i + 1].gameObject.tag)
                {
                    Debug.Log("a");
                    listI.Remove(listI[i - 1]);
                    listI.Remove(listI[i]);
/*                    if (listI[i].name == "chicken")
                    {
                        Debug.Log("a");
                    }*/

/*                    listI.Remove(listI[i]);
                    listI.Remove(listI[i - 1]);
                    listI.Remove(listI[i + 1]);
                    ExecuteAnswer();*/
                }

            }

        }
    }
}

public class IData
{
    public string chara;
}
