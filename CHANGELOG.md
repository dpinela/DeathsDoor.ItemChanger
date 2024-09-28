# 1.5 (29 September 2024)

New features:

- Non-predefined items can be placed by passing an implementation of Item
  directly to SaveData.Place.
- Additional icon lookup paths can be added.
- The tracker log can now record items given at virtual locations
  (locations that don't actually exist in the game).

# 1.4 (16 June 2024)

New features:

- The 12 crow soul locations can be replaced.
- There are 12 corresponding crow soul items available for placement.
- It is possible to create multi-shard (magic or vitality) items by requesting "Vitality Shard xN" or "Magic Shard xN", where N is the desired number of shards.
- The cap on magic points is removed, allowing the use of extra
  shards beyond the vanilla 8.
- There is an option to change the number of planted pots required to open
  the Green Tablet door, from the default of 50.

Name changes:

- Locations whose names contained "Crow 2" now read "Rightmost Crow" instead.
- The Lever-Lockstone Secret West item and location are now known as
  Lever-Lockstone Shrine.

# 1.3 (29 April 2024)

New features:

- It is possible to create multi-seed items by requesting "Life Seed xN", where N is the
  desired number of seeds.

Bug fixes:

- The area for the Soul Orb and the levers in the Estate access crypt is reported as Cemetery,
  instead of Estate.

# 1.2 (7 April 2024)

New features:

- The 12 key locations can be replaced.
- There are Green, Pink and Yellow Key items available for placement.
- The starting weapon can be changed using the `SaveData.StartingWeapon` property.
- All locations have an Area attribute, denoting which area of the game they
  are in, for display and classification purposes.
- Lever locations and items all begin with "Lever-" instead of ending with "Lever"
  for more consistency with other location types.
  The old names are still accepted as aliases to the same locations and items.

Bug fixes:

- The key location besides Grey Crow is collectible even if the initial
  Grey Crow cutscene is no longer watchable - as can happen if the player
  obtains all Giant Souls.
- Progressive items (such as spells) given from the Avarice cutscenes will
  now show the correct level in the text box that appears after the cutscene.
- The Avarice in Overgrown Ruins now sends the player all the way back
  to Hall of Doors if exited without having the Ruins door unlocked.
  This prevents a softlock that could previously occur under those circumstances.

# 1.1 (20 January 2024)

New features:

- Tracker log: an ordered and timestamped list of obtained items, stored
  with the save file. Can be used to display lists of obtained items in
  various formats.
- All items have been given dedicated icons, which appear in the popup
  when one is obtained and can be fetched by other mods using the ItemIcons
  class.

Bug fixes:

- Forest Mother requires the actual Magical Forest Horn _item_ to open the
  door, instead of checking whether you checked the Horn _location_.
- Jefferson analogously checks for the Ink-Covered Teddy Bear _item_
  instead of the _location_.
- Entering Castle Lockstone for the first time from above without Hookshot
  no longer hardlocks the player.