using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public interface IData
{
    string GetName();

}

public class TownMgr : MonoBehaviour
{
    public Button InterviewBtn;
    [Header("Cat List")]
    public Button CatListBtn;
    public GameObject CatListPanel;

    [Header("Furniture List")]
    public Button FurnitureListBtn;
    public GameObject FurnitureListPanel;


    [Header("Owner List")]
    public Button OwnerListBtn;
    public GameObject OwnerListPanel;
    List<int> OwnerList = new List<int>();

    public GameObject TownMain;
    public GameObject ListItemPrefab;
    public GameObject OwnerItemPrefab;

    public Button buttonCat;
    public CatHome catHome;

    [Header("Cat Sprites")]
    public Image imageCat;

    public Button buttonRagdollCat;
    public Button buttonCheeseCat;
    public Button buttonFishCat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        buttonFishCat.onClick.AddListener(OnClickFishCat);
        buttonCheeseCat.onClick.AddListener(OnClickCheeseCat);
        buttonRagdollCat.onClick.AddListener(OnClickRagdollCat);
        InterviewBtn.onClick.AddListener(OnInterviewBtnClick);
    }

    void Start()
    {
        Debug.Log("start");
        
    }

    void OnClickFishCat()
    {
        TownMain.SetActive(false);
        catHome.Initialize(GameDatabase.Instance.spritesCats[0], GameDatabase.Instance.Cats.cats[0].name);
    }
    
    void OnClickCheeseCat()
    {
        TownMain.SetActive(false);
        catHome.Initialize(GameDatabase.Instance.spritesCats[1], GameDatabase.Instance.Cats.cats[1].name);
    }
    
    void OnClickRagdollCat()
    {
        TownMain.SetActive(false);
        catHome.Initialize(GameDatabase.Instance.spritesCats[2], GameDatabase.Instance.Cats.cats[2].name);
    }
    
    void OnInterviewBtnClick()
    {
        //SceneManager.LoadScene("InterviewScene");
    }

    public void CloseList(GameObject listPanel)
    {
        listPanel.SetActive(false);
        TownMain.SetActive(true);
    }


}
