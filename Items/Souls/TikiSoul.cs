using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class TikiSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.TikiMask;
        public override int BodyPieceID => ItemID.TikiShirt;
        public override int LegPieceID => ItemID.TikiPants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +1 minion máximo e +20% de alcance de chicotes
            player.maxMinions += 1;
            player.whipRangeMultiplier += 0.20f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TikiMask)
                .AddIngredient(ItemID.TikiShirt)
                .AddIngredient(ItemID.TikiPants)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}