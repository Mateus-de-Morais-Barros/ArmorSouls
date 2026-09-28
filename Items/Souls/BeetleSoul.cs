using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            // Bônus Scale Mail: Beetle Might (dano e velocidade melee crescentes)
            player.beetleOffense = true;

            // Bônus Shell: Beetle Endurance (besouros defensivos que reduzem dano)
            player.beetleBuff = true;
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
            var beetleChests = new[]
            {
                ItemID.BeetleScaleMail,
                ItemID.BeetleShell
            };

            foreach (short chest in beetleChests)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.BeetleHelmet)
                    .AddIngredient(chest)
                    .AddIngredient(ItemID.BeetleLeggings)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}