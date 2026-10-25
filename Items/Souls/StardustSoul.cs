using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ArmorSouls.Common.Players;

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
            player.GetModPlayer<StardustSoulPlayer>().stardustSoul = true;
        }

        public override void HideSoulVisuals(Player player)
        {
            player.GetModPlayer<SoulVisualsPlayer>().hideStardustGuardian = true;
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