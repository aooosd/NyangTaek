using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>목록 UI에 표시할 데이터가 이름을 제공하도록 정의합니다.</summary>
public interface IData
{
    /// <summary>UI에 표시할 데이터 이름을 반환합니다.</summary>
    string GetName();

}

/// <summary>마을 화면의 버튼 입력과 고양이 선택 화면 전환을 관리합니다.</summary>
public class TownMgr : MonoBehaviour
{
    public Button InterviewBtn; // 면접 화면 진입에 사용할 버튼입니다.
    [Header("Cat List")]
    public Button CatListBtn;          // 고양이 목록을 여는 버튼입니다.
    public GameObject CatListPanel;    // 고양이 목록 패널입니다.

    [Header("Furniture List")]
    public Button FurnitureListBtn;       // 가구 목록을 여는 버튼입니다.
    public GameObject FurnitureListPanel; // 가구 목록 패널입니다.


    [Header("Owner List")]
    public Button OwnerListBtn;          // 집사 목록을 여는 버튼입니다.
    public GameObject OwnerListPanel;    // 집사 목록 패널입니다.
    List<int> OwnerList = new List<int>(); // 집사 ID를 보관하기 위한 목록입니다.

    public GameObject TownMain;       // 마을의 기본 화면 루트입니다.
    public GameObject ListItemPrefab; // 일반 목록 항목 생성에 사용할 프리팹입니다.
    public GameObject OwnerItemPrefab;// 집사 목록 항목 생성에 사용할 프리팹입니다.

    public Button buttonCat; // 공통 고양이 선택 버튼 참조입니다.
    public CatHome catHome;  // 선택한 고양이의 집 화면입니다.

    [Header("Cat Sprites")]
    public Image imageCat; // 선택한 고양이 이미지를 표시합니다.

    public Button buttonRagdollCat; // 랙돌 고양이 선택 버튼입니다.
    public Button buttonCheeseCat;  // 치즈 고양이 선택 버튼입니다.
    public Button buttonFishCat;    // 생선 고양이 선택 버튼입니다.

    /// <summary>면접 버튼 클릭 이벤트를 연결합니다.</summary>
    void Awake()
    {
        
        InterviewBtn.onClick.AddListener(OnInterviewBtnClick);
    }

    /// <summary>각 고양이 선택 버튼의 클릭 이벤트를 연결합니다.</summary>
    void Start()
    {
        Debug.Log("start");
        buttonFishCat.onClick.AddListener(OnClickFishCat);
        buttonCheeseCat.onClick.AddListener(OnClickCheeseCat);
        buttonRagdollCat.onClick.AddListener(OnClickRagdollCat);
    }

    /// <summary>첫 번째 고양이를 선택하고 고양이 집 화면을 엽니다.</summary>
    void OnClickFishCat()
    {
        TownMain.SetActive(false);
        catHome.SetId(1);
    }
    
    /// <summary>두 번째 고양이를 선택하고 고양이 집 화면을 엽니다.</summary>
    void OnClickCheeseCat()
    {
        TownMain.SetActive(false);
        catHome.SetId(2);
    }
    
    /// <summary>세 번째 고양이를 선택하고 고양이 집 화면을 엽니다.</summary>
    void OnClickRagdollCat()
    {
        TownMain.SetActive(false);
        catHome.SetId(3);
    }
    
    /// <summary>면접 화면 진입 버튼이 눌렸을 때 호출됩니다.</summary>
    void OnInterviewBtnClick()
    {
        //SceneManager.LoadScene("InterviewScene");
    }

    /// <summary>전달받은 목록 패널을 닫고 마을 기본 화면을 다시 표시합니다.</summary>
    public void CloseList(GameObject listPanel)
    {
        listPanel.SetActive(false);
        TownMain.SetActive(true);
    }


}
