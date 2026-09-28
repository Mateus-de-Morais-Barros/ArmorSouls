using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class NecroSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.NecroHelmet;
        public override int BodyPieceID => ItemID.NecroBreastplate;
        public override int LegPieceID => ItemID.NecroGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 1, silver: 50);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: 20% de chance de economizar munição
            player.ammoCost80 = true;
        }

        public override void AddRecipes()
        {
            // Receita padrão (Necro Armor)
            CreateRecipe()
                .AddIngredient(ItemID.NecroHelmet)
                .AddIngredient(ItemID.NecroBreastplate)
                .AddIngredient(ItemID.NecroGreaves)
                .AddTile(TileID.WorkBenches)
                .Register();

            // Receita alternativa (Ancient Necro Helmet)
            CreateRecipe()
                .AddIngredient(ItemID.AncientNecroHelmet)
                .AddIngredient(ItemID.NecroBreastplate)
                .AddIngredient(ItemID.NecroGreaves)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}