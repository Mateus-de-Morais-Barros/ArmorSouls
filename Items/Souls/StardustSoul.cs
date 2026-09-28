using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class StardustSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.StardustHelmet;
        public override int BodyPieceID => ItemID.StardustBreastplate;
        public override int LegPieceID => ItemID.StardustLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 10);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Invoca o Stardust Guardian para lutar ao lado do jogador
            player.setStardust = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.StardustHelmet)
                .AddIngredient(ItemID.StardustBreastplate)
                .AddIngredient(ItemID.StardustLeggings)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}