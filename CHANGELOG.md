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