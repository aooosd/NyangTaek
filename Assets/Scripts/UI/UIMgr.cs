using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 데이터 목록을 바탕으로 스크롤뷰의 셀을 생성하고 기존 셀을 정리합니다.
/// </summary>
public class UIMgr : Singleton<UIMgr>
{
    /// <summary>UIMgr 싱글턴 인스턴스를 등록합니다.</summary>
    protected override void Awake()
    {
        base.Awake();
        
    }
 

    /// <summary>기존 셀을 모두 제거하고 전달받은 데이터로 목록을 다시 채웁니다.</summary>
    /// <typeparam name="T">이름을 제공하는 데이터 형식입니다.</typeparam>
    /// <param name="list">화면에 표시할 데이터 목록입니다.</param>
    /// <param name="content">생성된 셀을 배치할 부모 Transform입니다.</param>
    /// <param name="cellPrefab">목록 셀 생성에 사용할 프리팹입니다.</param>
    public void RefreshList<T>(List<T> list, Transform content, GameObject cellPrefab)
        where T : IData
    {
        DeleteList(content);
        FillList(list, content, cellPrefab);
    }

    /// <summary>데이터 종류에 맞는 이미지와 이름을 사용하여 셀을 하나씩 생성합니다.</summary>
    void FillList<T>(List<T> list, Transform content, GameObject cellPrefab)
        where T : IData
    {
        int i = 0; // 보유 ID 목록과 스프라이트 배열을 함께 조회하기 위한 인덱스입니다.
        foreach (var obj in list)
        {
            GameObject cell = Instantiate(cellPrefab, content); // 현재 데이터용으로 생성한 셀입니다.
            if (obj is CatData)
            {
                cell.GetComponent<Cell>().Initialize(GameDatabase.Instance.spritesCats[GameState.Instance.ownedCatIds[i] - 1], obj.GetName());
            }
            else if (obj is ApplicantData)
            {
                cell.GetComponent<Cell>().Initialize(GameDatabase.Instance.spritesApplicants[GameState.Instance.ownedApplicantIds[i] - 1], obj.GetName());
            }
            else if (obj is ItemData)
            {

            }

            Debug.Log("Added item: " + obj.GetName());

            i++;
        }
    }

    /// <summary>Content 아래에 생성되어 있던 모든 기존 셀을 제거합니다.</summary>
    void DeleteList(Transform content)
    {
        if (content != null && content.childCount > 0)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
