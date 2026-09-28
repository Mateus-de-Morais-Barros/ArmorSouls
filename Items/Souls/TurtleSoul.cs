using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class TurtleSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.TurtleHelmet;
        public override int BodyPieceID => ItemID.TurtleScaleMail;
        public override int LegPieceID => ItemID.TurtleLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Reflete dano duplicado contra agressores em combate corpo a corpo
            player.turtleThorns = true;

            // Set Bonus vanilla (1.4+): Reduz o dano recebido em 15%
            player.endurance += 0.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TurtleHelmet)
                .AddIngredient(ItemID.TurtleScaleMail)
                .AddIngredient(ItemID.TurtleLeggings)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}