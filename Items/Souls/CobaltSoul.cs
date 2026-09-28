using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class CobaltSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.CobaltBreastplate;
        public override int LegPieceID => ItemID.CobaltLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1, silver: 80);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Bônus do Elmo Melee: +15% de velocidade de ataque
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;

            // Bônus da Máscara Ranged: 20% de chance de economizar munição
            player.ammoCost80 = true;

            // Bônus do Capuz Magic: 14% de redução no custo de mana
            player.manaCost -= 0.14f;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Elmo + Peitoral + Calças (melee): dano melee, crítico e velocidade de movimento
            player.GetDamage(DamageClass.Melee) += 0.18f;
            player.GetCritChance(DamageClass.Melee) += 5f;
            player.moveSpeed += 0.20f;

            // Máscara + Peitoral + Calças (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.13f;
            player.GetCritChance(DamageClass.Ranged) += 15f;

            // Chapéu + Peitoral + Calças (magic)
            player.GetDamage(DamageClass.Magic) += 0.13f;
            player.GetCritChance(DamageClass.Magic) += 14f;
            player.statManaMax2 += 40;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.CobaltHelmet ||
                              player.armor[0].type == ItemID.CobaltMask ||
                              player.armor[0].type == ItemID.CobaltHat;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] cobaltHelmets = new[]
            {
                ItemID.CobaltHelmet,
                ItemID.CobaltMask,
                ItemID.CobaltHat
            };

            // Permite craftar com qualquer um dos 3 elmos
            foreach (short helmet in cobaltHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.CobaltBreastplate)
                    .AddIngredient(ItemID.CobaltLeggings)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
}