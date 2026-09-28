using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class CactusSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.CactusHelmet;
        public override int BodyPieceID => ItemID.CactusBreastplate;
        public override int LegPieceID => ItemID.CactusLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 10);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Reflete dano recebido de volta aos inimigos
            player.thorns = 1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CactusHelmet)
                .AddIngredient(ItemID.CactusBreastplate)
                .AddIngredient(ItemID.CactusLeggings)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}