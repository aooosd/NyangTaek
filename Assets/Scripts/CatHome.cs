using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHome : MonoBehaviour
{
    CatData currentCat; // ���� ���õ� �����
    ApplicantData currentApplicant; // ���� ���õ� ����
    public int servantId; // ���� ���õ� �������� ID (���� �� Ž����)

    public TextMeshProUGUI servantNameText; // �ӽ� UI �ؽ�Ʈ, ���� ���ӿ����� �ٸ� UI ��ҷ� ��ü�� �� ����

    public Image imageCat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        servantId = 0; // �ӽ÷� 1(������)�� ����, �����δ� ���� ���¿� ���� �ٸ��� ������ �� ���� 
    }

    // Update is called once per frame
    void Update()
    {
        if (servantId >= 0 && servantId < GameState.Instance.ownedApplicants.Count)
        {
            servantNameText.text = "현재 집사\n" + GameState.Instance.ownedApplicants[servantId].GetName();
        }
    }
}
