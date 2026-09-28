using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class NebulaSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.NebulaHelmet;
        public override int BodyPieceID => ItemID.NebulaBreastplate;
        public override int LegPieceID => ItemID.NebulaLeggings;

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
            // Set Bonus vanilla: Danificar inimigos gera Boosters de Nebulosa (Dano, Vida e Mana)
            player.setNebula = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.NebulaHelmet)
                .AddIngredient(ItemID.NebulaBreastplate)
                .AddIngredient(ItemID.NebulaLeggings)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}