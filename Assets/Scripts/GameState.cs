using System.Collections.Generic;
using UnityEngine;

/// <summary>플레이 도중 변경되는 보유 데이터, 재화, 면접 진행 상태를 관리합니다.</summary>
public class GameState : Singleton<GameState>
{
    public List<CatData> ownedCats = new List<CatData>();                 // 보유 ID로 조회한 고양이 데이터입니다.
    public List<ItemData> ownedItems = new List<ItemData>();             // 보유 ID로 조회한 아이템 데이터입니다.
    public List<ApplicantData> ownedApplicants = new List<ApplicantData>(); // 고용한 지원자 데이터입니다.

    public List<int> ownedCatIds = new List<int>();          // 보유 고양이의 원본 데이터 ID입니다.
    public List<int> ownedItemIds = new List<int>();         // 보유 아이템의 원본 데이터 ID입니다.
    public List<int> ownedApplicantIds = new List<int>();    // 고용한 지원자의 원본 데이터 ID입니다.

    public int interviewIndex = 0; // 현재 면접할 지원자의 배열 인덱스입니다.
    public int coin = 0;           // 플레이어가 보유한 재화입니다.

    /// <summary>GameState 싱글턴 인스턴스를 등록합니다.</summary>
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>테스트용 초기 보유 ID를 설정하고 실제 데이터 목록을 갱신합니다.</summary>
    private void Start()
    {
        ownedCats.Clear();
        ownedItems.Clear();
        ownedApplicants.Clear();

        ownedCatIds.Add(1);
        ownedCatIds.Add(2);
        ownedCatIds.Add(3);

        ownedApplicantIds.Add(1); 
        //ownedApplicantIds.Add(2);
        RefreshOwnedList();
        Debug.Log("Owned Cats: " + ownedCats.Count);
    }

    /// <summary>보유 ID를 데이터베이스에서 찾아 실제 데이터 객체 목록으로 다시 구성합니다.</summary>
    public void RefreshOwnedList()
    {         
        ownedCats.Clear();
        ownedItems.Clear();
        ownedApplicants.Clear();
        foreach (int catId in ownedCatIds)
        {
            CatData cat = GameDatabase.Instance.Cats.cats.Find(c => c.id == catId); // ID와 일치하는 고양이입니다.
            if (cat != null)
            {
                ownedCats.Add(cat);
            }
        }
        /*foreach (int itemId in ownedItemIds)
        {
            ItemData item = GameDatabase.Instance.Items.items.Find(i => i.id == itemId);
            if (item != null)
            {
                ownedItems.Add(item);
            }
        }*/
        foreach (int applicantId in ownedApplicantIds)
        {
            ApplicantData applicant = GameDatabase.Instance.Applicants.applicants.Find(a => a.id == applicantId); // ID와 일치하는 지원자입니다.
            if (applicant != null)
            {
                ownedApplicants.Add(applicant);
            }
        }
    }
}
