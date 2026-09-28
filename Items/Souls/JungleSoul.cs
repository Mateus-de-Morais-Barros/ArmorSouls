using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class JungleSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.JungleHat;
        public override int BodyPieceID => ItemID.JungleShirt;
        public override int LegPieceID => ItemID.JunglePants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Reduz o consumo de mana em 16%
            player.manaCost -= 0.16f;
        }

        public override void AddRecipes()
        {
            // Receita padrão (Jungle Armor)
            CreateRecipe()
                .AddIngredient(ItemID.JungleHat)
                .AddIngredient(ItemID.JungleShirt)
                .AddIngredient(ItemID.JunglePants)
                .AddTile(TileID.Anvils)
                .Register();

            // Receita alternativa (Ancient Cobalt Armor)
            CreateRecipe()
                .AddIngredient(ItemID.AncientCobaltHelmet)
                .AddIngredient(ItemID.AncientCobaltBreastplate)
                .AddIngredient(ItemID.AncientCobaltLeggings)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}