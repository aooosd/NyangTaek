using UnityEngine;

public class SpriteLoader : Singleton<SpriteLoader>
{
    public Sprite[] LoadCatSprites()
    {
        Sprite[] sprites;
        sprites = Resources.LoadAll<Sprite>("Sprites/Cats");
        
        return sprites;
    }

    public Sprite[] LoadApplicantSprites()
    {
        Sprite[] sprites;
        sprites = Resources.LoadAll<Sprite>("Sprites/Applicants");

        return sprites;
    }
}
