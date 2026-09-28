using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class FossilSoul : ArmorSoulBase
    {
        public override int HeadPieceID => ItemID.FossilHelm;
        public override int BodyPieceID => ItemID.FossilShirt;
        public override int LegPieceID => ItemID.FossilPants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: 20% de chance de economizar munição
            player.ammoCost80 = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FossilHelm)
                .AddIngredient(ItemID.FossilShirt)
                .AddIngredient(ItemID.FossilPants)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}