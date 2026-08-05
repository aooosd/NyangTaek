using UnityEngine;

/// <summary>게임의 정적 JSON 데이터와 이미지 리소스를 한 번만 불러와 제공합니다.</summary>
public class GameDatabase : Singleton<GameDatabase>
{
    public CatDatabase Cats { get; private set; }                  // 전체 고양이 데이터입니다.
    public ItemDatabase Items { get; private set; }                // 전체 아이템 데이터입니다.
    public ApplicantDatabase Applicants { get; private set; }     // 전체 지원자 데이터입니다.
    public Sprite[] spritesCats { get; private set; }              // 고양이 이미지 배열입니다.
    public Sprite[] spritesApplicants { get; private set; }        // 지원자 이미지 배열입니다.

    /// <summary>싱글턴을 등록하고 게임 데이터와 스프라이트를 메모리에 불러옵니다.</summary>
    protected override void Awake()
    {
        base.Awake();
        Cats = JsonLoader.LoadData<CatDatabase>("CatData");
        Items = JsonLoader.LoadData<ItemDatabase>("ItemData");
        Applicants = JsonLoader.LoadData<ApplicantDatabase>("ApplicantData");
        spritesApplicants = SpriteLoader.Instance.LoadApplicantSprites();
        spritesCats = SpriteLoader.Instance.LoadCatSprites();
        Debug.Log("GameDatabase loaded successfully.");
    }

}