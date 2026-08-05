using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>고양이 한 마리의 식별 정보와 성향 스탯을 저장합니다.</summary>
public class CatData : IData
{
    public int id;              // 고양이를 구분하는 고유 ID입니다.
    public string name;         // 화면에 표시할 고양이 이름입니다.
    public int closeness;       // 집사와 가까이 지내려는 성향입니다.
    public int activity;        // 고양이의 활동적인 정도입니다.
    public int independence;    // 고양이의 독립적인 정도입니다.

    /// <summary>목록 UI 등에 표시할 고양이 이름을 반환합니다.</summary>
    public string GetName()
    {
        return name;
    }
}

[System.Serializable]
/// <summary>JSON에서 불러온 고양이 데이터 목록을 보관합니다.</summary>
public class CatDatabase
{
<<<<<<< Updated upstream
    public List<CatData> cats;  // 게임에 등록된 모든 고양이 데이터입니다.
}
=======
    public List<CatData> cats;
}

>>>>>>> Stashed changes
