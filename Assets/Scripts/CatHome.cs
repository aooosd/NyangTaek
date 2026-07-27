using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHome : MonoBehaviour
{
    CatData currentCat; // ���� ���õ� �����
    ApplicantData currentApplicant; // ���� ���õ� ����
    public int servantId; // ���� ���õ� �������� ID (���� �� Ž����)

    public TextMeshProUGUI servantNameText; // �ӽ� UI �ؽ�Ʈ, ���� ���ӿ����� �ٸ� UI ��ҷ� ��ü�� �� ����
    GameState gameState;

    public Image imageCat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = FindAnyObjectByType<GameState>();
        servantId = 1; // �ӽ÷� 1(������)�� ����, �����δ� ���� ���¿� ���� �ٸ��� ������ �� ���� 
    }

    // Update is called once per frame
    void Update()
    {
        if (servantId >= 0 && servantId < gameState.ownedApplicants.Count)
        {
            servantNameText.text = "현재 집사\n" + gameState.ownedApplicants[servantId].GetName();
        }
    }
}
