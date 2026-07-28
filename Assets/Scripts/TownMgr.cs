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
    Sprite[] spritesCats;

    public Button buttonRagdollCat;
    public Button buttonCheeseCat;
    public Button buttonFishCat;

    [Header("Applicant Sprites")]
    Sprite[] spritesApplicants;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        buttonFishCat.onClick.AddListener(OnClickFishCat);
        buttonCheeseCat.onClick.AddListener(OnClickCheeseCat);
        buttonRagdollCat.onClick.AddListener(OnClickRagdollCat);
        InterviewBtn.onClick.AddListener(OnInterviewBtnClick);
        CatListBtn.onClick.AddListener(ShowCatList);
        FurnitureListBtn.onClick.AddListener(ShowItemList);
        OwnerListBtn.onClick.AddListener(ShowOwnerList);

        spritesCats = SpriteLoader.Instance.LoadCatSprites();
        spritesApplicants = SpriteLoader.Instance.LoadApplicantSprites();
    }

    void Start()
    {
        Debug.Log("start");
        
    }

    void OnClickFishCat()
    {
        TownMain.SetActive(false);
        catHome.gameObject.SetActive(true);
        catHome.imageCat.sprite = spritesCats[0];
    }
    
    void OnClickCheeseCat()
    {
        TownMain.SetActive(false);
        catHome.gameObject.SetActive(true);
        catHome.imageCat.sprite = spritesCats[1];
    }
    
    void OnClickRagdollCat()
    {
        TownMain.SetActive(false);
        catHome.gameObject.SetActive(true);
        catHome.imageCat.sprite = spritesCats[2];
    }
    
    void OnInterviewBtnClick()
    {
        SceneManager.LoadScene("InterviewScene");
    }

    public void ShowCatList()
    {
        TownMain.SetActive(false);
        RefreshList(GameState.Instance.ownedCats, CatListPanel.transform.Find("Scroll View/Viewport/Content"), OwnerItemPrefab);
        CatListPanel.SetActive(true);
    }

    public void ShowOwnerList()
    {
        TownMain.SetActive(false);
        RefreshList(GameState.Instance.ownedApplicants, OwnerListPanel.transform.Find("Scroll View/Viewport/Content"), OwnerItemPrefab);
        OwnerListPanel.SetActive(true);
    }

    public void ShowItemList()
    {
        TownMain.SetActive(false);
        RefreshList(GameState.Instance.ownedItems, FurnitureListPanel.transform.Find("Scroll View/Viewport/Content"), ListItemPrefab);
        FurnitureListPanel.SetActive(true);
    }


    void RefreshList<T>(List<T> list, Transform content, GameObject listItemPrefab)
        where T : IData
    {
        if (content != null && content.childCount > 0)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
        FillList(list, content, listItemPrefab);
    }

    void FillList<T>(List<T> list, Transform content, GameObject listItemPrefab)
        where T : IData
    {
        int i = 0;
        foreach (var obj in list)
        {
            GameObject item = Instantiate(listItemPrefab, content);
            item.transform.Find("Button/Name").GetComponent<Text>().text = obj.GetName();
            if (obj is CatData)
            {
                item.transform.Find("Image").GetComponent<Image>().sprite = spritesCats[GameState.Instance.ownedCatIds[i]-1];
            }
            else if (obj is ApplicantData)
            { 
                item.transform.Find("Image").GetComponent<Image>().sprite = spritesApplicants[GameState.Instance.ownedApplicantIds[i]-1];
            }
            //item.transform.Find("Stability").GetComponent<Text>().text = "Stability: " + obj.stability;
            Debug.Log("Added item: " + obj.GetName());

            i++;
        }
    }

    public void CloseList(GameObject listPanel)
    {
        listPanel.SetActive(false);
        TownMain.SetActive(true);
    }


}
