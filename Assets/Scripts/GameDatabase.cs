using UnityEngine;

public class GameDatabase : Singleton<GameDatabase>
{
    public CatDatabase Cats { get; private set; }
    public ItemDatabase Items { get; private set; }
    public ApplicantDatabase Applicants { get; private set; }
    public Sprite[] spritesCats { get; private set; }
    public Sprite[] spritesApplicants { get; private set; }

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
