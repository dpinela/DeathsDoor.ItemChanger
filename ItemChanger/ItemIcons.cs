using UE = UnityEngine;
using IO = System.IO;
using CG = System.Collections.Generic;

namespace DDoor.ItemChanger;

public static class ItemIcons
{
    private static CG.Dictionary<string, UE.Sprite> sprites = new();

    private static CG.List<string> iconPaths = new()
    {
        IO.Path.GetDirectoryName(typeof(ItemIcons).Assembly.Location)
    };

    public static void AddPath(string dir)
    {
        iconPaths.Add(dir);
    }

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
        foreach (var p in iconPaths)
        {
            var loc = IO.Path.Combine(p, name);
            byte[] imageData;
            try
            {
                imageData = IO.File.ReadAllBytes(loc);
            }
            catch (IO.FileNotFoundException)
            {
                continue;
            }
            var tex = new UE.Texture2D(1, 1, UE.TextureFormat.RGBA32, false);
            UE.ImageConversion.LoadImage(tex, imageData, true);
            tex.filterMode = UE.FilterMode.Bilinear;
            return UE.Sprite.Create(tex, new UE.Rect(0, 0, tex.width, tex.height), new UE.Vector2(.5f, .5f));
        }
        throw new System.InvalidOperationException($"sprite {name} not found");
    }
}