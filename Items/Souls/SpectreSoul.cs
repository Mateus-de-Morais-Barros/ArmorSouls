using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class SpectreSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.SpectreRobe;
        public override int LegPieceID => ItemID.SpectrePants;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 7, silver: 50);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Bônus do Spectre Hood: Dano mágico gera orbes de cura
            player.ghostHeal = true;

            // Bônus da Spectre Mask: Dano mágico gera orbes de ataque teleguiados
            player.ghostHurt = true;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.SpectreHood ||
                              player.armor[0].type == ItemID.SpectreMask;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] spectreHelmets = new[]
            {
                ItemID.SpectreHood,
                ItemID.SpectreMask
            };

            // Permite craftar com o Capuz ou com a Máscara
            foreach (short helmet in spectreHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.SpectreRobe)
                    .AddIngredient(ItemID.SpectrePants)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}