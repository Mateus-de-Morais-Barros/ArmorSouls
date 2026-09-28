using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class SpiderSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.SpiderMask;
        public override int BodyPieceID => ItemID.SpiderBreastplate;
        public override int LegPieceID => ItemID.SpiderGreaves;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1, silver: 50);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: +12% de dano para lacaios (minions)
            player.GetDamage(DamageClass.Summon) += 0.12f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpiderMask)
                .AddIngredient(ItemID.SpiderBreastplate)
                .AddIngredient(ItemID.SpiderGreaves)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}