using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ArmorSouls.Common.Players;

namespace ArmorSouls.Items.Souls
{
    public class BeetleSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.BeetleHelmet;
        public override int LegPieceID => ItemID.BeetleLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 7);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Bônus Shell: Beetle Endurance (besouros defensivos que reduzem dano)
            // Beetle Might (Scale Mail) usa o mesmo contador e os mesmos besouros, então não pode ser combinado
            player.beetleDefense = true;
            player.GetModPlayer<SoulSetBonusPlayer>().beetleSoul = true;
        }

        public override void HideSoulVisuals(Player player)
        {
            player.GetModPlayer<SoulVisualsPlayer>().hideBeetleOrbs = true;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasHead = player.armor[0].type == HeadPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyChest = player.armor[1].type == ItemID.BeetleScaleMail ||
                               player.armor[1].type == ItemID.BeetleShell;

            return hasHead && hasLegs && hasAnyChest;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BeetleHelmet)
                .AddIngredient(ItemID.BeetleShell)
                .AddIngredient(ItemID.BeetleLeggings)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}