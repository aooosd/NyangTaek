using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    private Sprite[] spritesCats;
    private Sprite[] spritesApplicants;


    protected override void Awake()
    {
        base.Awake();
        spritesApplicants = SpriteLoader.Instance.LoadApplicantSprites();
        spritesCats = SpriteLoader.Instance.LoadCatSprites();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshList<T>(List<T> list, Transform content, GameObject cellPrefab)
        where T : IData
    {
        DeleteList(content);
        FillList(list, content, cellPrefab);
    }

    void FillList<T>(List<T> list, Transform content, GameObject cellPrefab)
        where T : IData
    {
        int i = 0;
        foreach (var obj in list)
        {
            GameObject cell = Instantiate(cellPrefab, content);
            if (obj is CatData)
            {
                cell.GetComponent<Cell>().Initialize(spritesCats[GameState.Instance.ownedCatIds[i] - 1], obj.GetName());
            }
            else if (obj is ApplicantData)
            {
                cell.GetComponent<Cell>().Initialize(spritesApplicants[GameState.Instance.ownedApplicantIds[i] - 1], obj.GetName());
            }
            else if (obj is ItemData)
            {

            }

            //item.transform.Find("Stability").GetComponent<Text>().text = "Stability: " + obj.stability;
            Debug.Log("Added item: " + obj.GetName());

            i++;
        }
    }

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
