using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ArmorSouls.Common.Players;

namespace ArmorSouls.Items.Souls
{
    public class ForbiddenSoul : ArmorSoulBase
    {
        // Peças necessárias para a trava anti-duplicação
        public override int HeadPieceID => ItemID.AncientBattleArmorHat; // Forbidden Mask
        public override int BodyPieceID => ItemID.AncientBattleArmorShirt; // Forbidden Robes
        public override int LegPieceID => ItemID.AncientBattleArmorPants; // Forbidden Treads

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Set Bonus vanilla: Invoca o Forbidden Sign e permite conjurar a tempestade de areia antiga
            player.setForbidden = true;
            player.GetModPlayer<SoulSetBonusPlayer>().forbiddenSoul = true;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Máscara: +15% de dano mágico e de summon
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;

            // Vestes: +40 de mana, +10% de dano de summon e +1 lacaio
            // Botas: +40 de mana, +10% de dano mágico e +1 lacaio
            player.statManaMax2 += 80;
            player.GetDamage(DamageClass.Magic) += 0.10f;
            player.GetDamage(DamageClass.Summon) += 0.10f;
            player.maxMinions += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AncientBattleArmorHat)
                .AddIngredient(ItemID.AncientBattleArmorShirt)
                .AddIngredient(ItemID.AncientBattleArmorPants)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}