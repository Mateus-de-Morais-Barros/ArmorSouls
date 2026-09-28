using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class NinjaSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.NinjaHood;
        public override int BodyPieceID => ItemID.NinjaShirt;
        public override int LegPieceID => ItemID.NinjaPants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 60);
        }

        public override void ApplySoulEffects(Player player)
        {
            player.moveSpeed += 0.20f;
            player.blackBelt = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.NinjaHood)
                .AddIngredient(ItemID.NinjaShirt)
                .AddIngredient(ItemID.NinjaPants)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}