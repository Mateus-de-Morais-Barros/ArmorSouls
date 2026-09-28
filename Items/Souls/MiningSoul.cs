using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class MiningSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.MiningHelmet;
        public override int BodyPieceID => ItemID.MiningShirt;
        public override int LegPieceID => ItemID.MiningPants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +30% de velocidade de mineração
            player.pickSpeed -= 0.30f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MiningHelmet)
                .AddIngredient(ItemID.MiningShirt)
                .AddIngredient(ItemID.MiningPants)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}