using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
/// <summary>저장 파일로 직렬화할 플레이어의 진행 정보를 모아 둡니다.</summary>
public class GameSaveData
{
    public List<int> ownedCatIds = new List<int>();       // 보유한 고양이의 ID 목록입니다.
    public List<int> ownedFurnitureIds = new List<int>(); // 보유한 가구의 ID 목록입니다.
    public List<int> ownedApplicantIds = new List<int>(); // 고용한 집사 지원자의 ID 목록입니다.
    public int coin = 0;                                  // 플레이어가 보유한 재화입니다.
}

