# Armor Souls

A [tModLoader](https://github.com/tModLoader/tModLoader) mod for Terraria that lets you keep an armor's **set bonus** without wearing the armor.

Craft a full armor set into a **Soul**. The soul grants that set's bonus, so you can wear whatever armor you like and still keep the effects you rely on from earlier sets.

## How it works

1. **Craft a soul.** Combine the helmet, chestplate and leggings of an armor set at the right crafting station:
   - Early sets: Work Bench or Anvil
   - Molten: Hellforge
   - Hardmode sets: Mythril/Orichalcum Anvil
   - Lunar sets: Ancient Manipulator
2. **Use the soul** in either of two ways:
   - **Equip it as an accessory**, or
   - **Put it in your Piggy Bank.** Souls there are active as long as they're in the bank, so they don't use up accessory slots.
3. **No double-dipping.** A soul does nothing while you're wearing the full armor set it came from, so you can't stack a set bonus with itself. Extra copies of the same soul in the Piggy Bank don't stack either.

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

The mod has one client-side option, under **Settings → Mod Configuration → Armor Souls Config**:

| Option | Default | Effect |
|---|---|---|
| Include Individual Piece Damage Bonuses | On | Souls of multi-helmet sets (Cobalt, Mythril, Palladium, Orichalcum, Adamantite, Titanium, Chlorophyte, Shroomite, Hallowed) also grant the flat damage, crit and speed bonuses of the individual armor pieces. Turn it off if you want souls to give only the set-bonus effect, which makes them simpler and weaker. |

When the option is off, affected souls say so in their tooltip.

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
│   ├── Configs/ArmorSoulsConfig.cs   # Mod config (piece damage bonus toggle)
│   └── Players/SoulBankPlayer.cs     # Applies souls stored in the Piggy Bank
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
- Add a recipe in `AddRecipes`, and a sprite and localization entry for the item.

## Author

TheMathews
