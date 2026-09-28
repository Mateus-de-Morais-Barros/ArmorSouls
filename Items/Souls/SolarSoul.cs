using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class SolarSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.SolarFlareHelmet;
        public override int BodyPieceID => ItemID.SolarFlareBreastplate;
        public override int LegPieceID => ItemID.SolarFlareLeggings;

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
            // Set Bonus vanilla: Escudo protetor solar (redução de dano) e Solar Dash explosivo
            player.setSolar = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SolarFlareHelmet)
                .AddIngredient(ItemID.SolarFlareBreastplate)
                .AddIngredient(ItemID.SolarFlareLeggings)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}