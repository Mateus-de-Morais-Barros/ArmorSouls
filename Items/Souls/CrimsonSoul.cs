using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class CrimsonSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.CrimsonHelmet;
        public override int BodyPieceID => ItemID.CrimsonScalemail;
        public override int LegPieceID => ItemID.CrimsonGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Regeneração de vida bastante aumentada
            player.crimsonRegen = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimsonHelmet)
                .AddIngredient(ItemID.CrimsonScalemail)
                .AddIngredient(ItemID.CrimsonGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}