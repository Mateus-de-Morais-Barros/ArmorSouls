using Terraria;
using Terraria.ID;

namespace ArmorSouls.Items.Souls
{
    public class TinSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.TinHelmet;
        public override int BodyPieceID => ItemID.TinChainmail;
        public override int LegPieceID => ItemID.TinGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
        }

        public override void ApplySoulEffects(Player player)
        {
            player.statDefense += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TinHelmet)
                .AddIngredient(ItemID.TinChainmail)
                .AddIngredient(ItemID.TinGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}