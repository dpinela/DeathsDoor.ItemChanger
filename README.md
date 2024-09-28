This is a Death's Door mod for changing item pickups to give other items.

# Pickups that can be changed

- Avarices
- Silent Servants
- Weapons
- Giant Souls
- Shrines
- Shiny Things
- Life Seeds
- Soul Orbs
- Levers
- Doors
- Keys
- Crow Souls

The full list of modifiable locations, and of predefined items that can be
placed at those locations, can be found in the [Predefined.cs][]
file.

Changed pickups retain their original appearance in-game, but
interacting with them gives the new item.

[Predefined.cs]: ./ItemChanger/Predefined.cs

# How to use

To change an item pickup, start by calling `SaveData.Open()` at some
point after the start of `SaveSlot.LoadSave` but before it ends; the
delegate that the [AlternativeGameModes][AGM] mod accepts is one
such point. Then, call `Place` on
the returned `SaveData` object. Here is an example:

    using AGM = DDoor.AlternativeGameModes;
    using IC = DDoor.ItemChanger;

    AGM.AlternativeGameModes.Add("IC EXAMPLE", () =>
    {
        var data = IC.SaveData.Open();
        data.Place("Hookshot", "Discarded Umbrella");
    });
  
`Place` accepts either the name of a predefined item, or a JSON-serializable
implementation of the `Item` interface.

[AGM]: https://github.com/dpinela/DeathsDoor.AlternativeGameModes#how-to-add-modes

# Changed vanilla behaviours

- If the Grove of Spirits door has been replaced with another item,
  Darwin wakes up the first time the player returns to Hall of Doors
  after the Chandler cutscene completes, so that they can upgrade
  stats before reaching Demonic Forest Spirit.
  The roped-off area leading to Bomb Avarice opens at the same time.
- If any pickups were replaced with a different item, most respawn
  points that are not doors are disabled; exiting to the main menu
  and returning will always return the player to Hall of Doors or
  to an open door, in order to prevent softlocks.
- If any pickups were replaced with a different item, the pink key
  beside Grey Crow is obtainable without having to watch the initial
  Grey Crow cutscene first, so that getting all three Giant Souls
  or the Truth Ending does not make it permanently unreachable.
- If placed with this mod, the pink Ancient Tablet of Knowledge
  exists as a single item instead of in 3 shards, for symmetry with
  the other tablets. The three owl locations can still be changed
  independently.

# How to build

To build this mod, you will need to place the game's DLLs (or
symlinks/hardlinks to them) in the `ItemChanger/Deps` directory. You
will also need a publicized version of Assembly-CSharp; if you use
[BepInEx's publicizer][beppub], the following command will generate
one:

    assembly-publicizer Assembly-CSharp.dll --strip -o Assembly-CSharp-publicized.dll

The publicized assembly is only required to build the mod; it is
still compatible with the standard game assembly.

This mod also uses [Newtonsoft.JSON][nsjson], which it imports from
NuGet.
The version included in the releases should be the version for
`netstandard2.0`, as the version that NuGet provides for `net472`
does not work under the Unity Mono runtime DD uses.

[beppub]: https://github.com/BepInEx/BepInEx.AssemblyPublicizer
[nsjson]: https://www.nuget.org/packages/Newtonsoft.Json