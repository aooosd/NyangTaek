using UnityEngine;
using UnityEngine.UI;

public class CatHome : MonoBehaviour
{
    CatData currentCat; // 현재 선택된 고양이
    ApplicantData currentApplicant; // 현재 선택된 집사
    public int servantId; // 현재 선택된 지원자의 ID (개발 시 탐색용)

    public Text servantNameText; // 임시 UI 텍스트, 실제 게임에서는 다른 UI 요소로 대체될 수 있음
    GameState gameState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = FindAnyObjectByType<GameState>();
        servantId = 1; // 임시로 1(이유나)로 설정, 실제로는 게임 상태에 따라 다르게 설정될 수 있음 
    }

    // Update is called once per frame
    void Update()
    {
        /*if (servantId >= 0 && servantId < gameState.ownedApplicants.Count)
        {
            servantNameText.text = gameState.ownedApplicants[servantId].GetName();
        }*/
    }
}
