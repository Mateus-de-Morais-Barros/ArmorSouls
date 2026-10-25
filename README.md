# Armor Souls

A [tModLoader](https://github.com/tModLoader/tModLoader) mod for Terraria that lets you keep an armor's **set bonus** without wearing the armor.

Craft a full armor set into a **Soul**. The soul grants that set's bonus, so you can wear whatever armor you like and still keep the effects you rely on from earlier sets.

## How it works

1. **Craft a soul.** Combine the helmet, chestplate and leggings of an armor set at the right crafting station:
   - Early sets: Work Bench or Anvil
   - Molten: Hellforge
   - Hardmode sets: Mythril/Orichalcum Anvil
   - Lunar sets: Ancient Manipulator
2. **Equip the soul in a Soul Slot.** Souls have their own accessory slots, next to your regular accessories. You start with 1 Soul Slot and unlock another after each of these milestones in your world:
   - Skeletron
   - Wall of Flesh
   - Any Mechanical Boss
   - Plantera
   - Moon Lord

   That's up to 6 slots by the end of the game. Right-clicking a soul equips it straight into a free Soul Slot.
3. **No double-dipping.** A soul does nothing while you're wearing the full armor set it came from, so you can't stack a set bonus with itself. Extra copies of the same soul don't stack either.

If you'd rather not be limited by Soul Slots, you can turn them off in the config. Souls then work in regular accessory slots and in your Piggy Bank (and, optionally, your other storages) without using up accessory slots.

### Hiding visuals

Some set bonuses show up on your character: the Stardust Guardian, the Leaf Crystal, the Beetle orbs and the Solar shield. Toggle the visibility (eye) icon on the soul's slot to hide them. The effect stays active; the Stardust Guardian and Leaf Crystal keep attacking, just invisibly.

## Souls

| Tier | Souls |
|---|---|
| Pre-Hardmode (basic) | Wood, Cactus, Copper, Tin, Iron, Lead, Silver, Tungsten, Gold, Platinum, Pumpkin, Mining, Ninja, Gladiator, Fossil, Obsidian |
| Pre-Hardmode (advanced) | Bee, Jungle, Meteor, Necro, Shadow, Crimson, Molten |
| Hardmode (ore) | Cobalt, Palladium, Mythril, Orichalcum, Adamantite, Titanium |
| Hardmode (other) | Frost, Forbidden, Spider, Hallowed, Chlorophyte, Turtle, Beetle, Shroomite, Spectre, Tiki, Spooky |
| Lunar | Solar, Vortex, Nebula, Stardust |

### Sets with more than one helmet

Where an armor set has several class-specific helmets (such as Cobalt's Helmet, Mask and Hat), any of them can be used in the recipe. The soul then grants **the set bonuses of every variant**. For example, the Beetle Soul grants both the Beetle Shell and Beetle Scale Mail bonuses, and the Spectre Soul grants both the Hood's healing and the Mask's damage bonus.

## Configuration

Options are under **Settings → Mod Configuration → Armor Souls Config**. The config is server-side, so in multiplayer everyone follows the host's settings.

### Soul Slots

| Option | Default | Effect |
|---|---|---|
| Enable Soul Slots | On | Souls can only be equipped in dedicated Soul Slots. They can't go in regular accessory slots, and souls in storage have no effect. Turn it off to equip souls like any accessory and use them from storage. |
| Progressive Soul Slots | On | Soul Slots unlock as the world progresses (see [How it works](#how-it-works)). Turn it off to have every Soul Slot available from the start. |
| Soul Slot Count | 6 | Maximum number of Soul Slots (1 to 10). With progression on, it caps how many slots the milestones can unlock. |

### Soul Storage

These only apply when Soul Slots are off. Souls in an enabled storage grant their effects without being equipped.

| Option | Default |
|---|---|
| Souls Work in Piggy Bank | On |
| Souls Work in Safe | Off |
| Souls Work in Defender's Forge | Off |
| Souls Work in Void Vault | Off |

### Soul Bonuses

| Option | Default | Effect |
|---|---|---|
| Include Individual Piece Damage Bonuses | On | Souls of multi-helmet sets (Cobalt, Mythril, Palladium, Orichalcum, Adamantite, Titanium, Chlorophyte, Shroomite, Hallowed) also grant the flat damage, crit and speed bonuses of the individual armor pieces. Turn it off if you want souls to give only the set-bonus effect, which makes them simpler and weaker. |

When this option is off, affected souls say so in their tooltip.

## Installation

### From source
1. Clone this repository into your tModLoader `ModSources` folder:
   ```
   Documents/My Games/Terraria/tModLoader/ModSources/ArmorSouls
   ```
2. Launch tModLoader, open **Workshop → Develop Mods**, and click **Build + Reload** next to Armor Souls.

## Project structure

```
ArmorSouls/
├── ArmorSouls.cs                     # Mod entry point
├── Common/
│   ├── Configs/ArmorSoulsServerConfig.cs  # Mod config (soul slots, storage, piece bonuses)
│   ├── Slots/SoulAccessorySlot.cs         # Soul Slots and their progression
│   └── Players/
│       ├── SoulBankPlayer.cs              # Applies souls kept in storage (Piggy Bank, Safe, ...)
│       ├── SoulVisualsPlayer.cs           # Hides set bonus visuals when the slot is hidden
│       └── StardustSoulPlayer.cs          # Summons the Stardust Guardian
├── Items/Souls/
│   ├── ArmorSoulBase.cs              # Shared soul logic (effects, full-set check, tooltips)
│   └── *Soul.cs / *Soul.png          # One class + sprite per armor set
└── Localization/                     # Item names, tooltips and config text
```

### Adding a new soul

Create a class that inherits from `ArmorSoulBase`, then:

- Set `HeadPieceID`, `BodyPieceID` and `LegPieceID` to the armor's item IDs. If the set has several helmets, override `IsFullArmorSetEquipped` instead.
- Put the set bonus in `ApplySoulEffects`.
- Optionally, put per-piece stat bonuses in `ApplyPieceDamageBonuses` and return `true` from `HasPieceDamageBonuses`.
- If the set bonus has a visual, hide it in `HideSoulVisuals` (see `SoulVisualsPlayer`).
- Add a recipe in `AddRecipes`, and a sprite and localization entry for the item.

## Author

TheMathews
