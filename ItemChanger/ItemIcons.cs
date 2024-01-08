using UE = UnityEngine;
using IO = System.IO;
using Collections = System.Collections.Generic;

namespace DDoor.ItemChanger;

public static class ItemIcons
{
    private static Collections.Dictionary<string, UE.Sprite> sprites = new();

    public static UE.Sprite Get(string name)
    {
        name += ".png";
        if (sprites.TryGetValue(name, out var sprite))
        {
            return sprite;
        }
        sprite = LoadSprite(name);
        sprites[name] = sprite;
        return sprite;
    }

    private static UE.Sprite LoadSprite(string name)
    {
        var loc = IO.Path.Combine(IO.Path.GetDirectoryName(typeof(ItemIcons).Assembly.Location), name);
        var imageData = IO.File.ReadAllBytes(loc);
        var tex = new UE.Texture2D(1, 1, UE.TextureFormat.RGBA32, false);
        UE.ImageConversion.LoadImage(tex, imageData, true);
        tex.filterMode = UE.FilterMode.Bilinear;
        return UE.Sprite.Create(tex, new UE.Rect(0, 0, tex.width, tex.height), new UE.Vector2(.5f, .5f));
    }
}