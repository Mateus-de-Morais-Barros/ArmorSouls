using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Items.Souls
{
    public class AdamantiteSoul : ArmorSoulBase
    {
        public override int BodyPieceID => ItemID.AdamantiteBreastplate;
        public override int LegPieceID => ItemID.AdamantiteLeggings;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 2, silver: 70);
        }

        public override void ApplySoulEffects(Player player)
        {
            // Bônus do Elmo Melee: +20% de velocidade de ataque e movimento
            player.GetAttackSpeed(DamageClass.Melee) += 0.20f;
            player.moveSpeed += 0.20f;

            // Bônus da Máscara Ranged: 25% de chance de economizar munição
            player.ammoCost75 = true;

            // Bônus do Capuz Magic: 19% de redução no custo de mana
            player.manaCost -= 0.19f;
        }

        public override bool HasPieceDamageBonuses => true;

        public override void ApplyPieceDamageBonuses(Player player)
        {
            // Elmo + Peitoral + Calças (melee)
            player.GetDamage(DamageClass.Melee) += 0.22f;
            player.GetCritChance(DamageClass.Melee) += 14f;

            // Máscara + Peitoral + Calças (ranged)
            player.GetDamage(DamageClass.Ranged) += 0.22f;
            player.GetCritChance(DamageClass.Ranged) += 17f;

            // Capuz + Peitoral + Calças (magic)
            player.GetDamage(DamageClass.Magic) += 0.20f;
            player.GetCritChance(DamageClass.Magic) += 19f;
            player.statManaMax2 += 80;

            // Bônus de movimento das Calças (comum às 3 variantes)
            player.moveSpeed += 0.05f;
        }

        public override bool IsFullArmorSetEquipped(Player player)
        {
            bool hasBody = player.armor[1].type == BodyPieceID;
            bool hasLegs = player.armor[2].type == LegPieceID;
            bool hasAnyHead = player.armor[0].type == ItemID.AdamantiteHelmet ||
                              player.armor[0].type == ItemID.AdamantiteMask ||
                              player.armor[0].type == ItemID.AdamantiteHeadgear;

            return hasBody && hasLegs && hasAnyHead;
        }

        public override void AddRecipes()
        {
            short[] adamantiteHelmets = new[]
            {
                ItemID.AdamantiteHelmet,
                ItemID.AdamantiteMask,
                ItemID.AdamantiteHeadgear
            };

            // Permite craftar com qualquer um dos 3 elmos na Bigorna de Mythril/Orichalcum
            foreach (short helmet in adamantiteHelmets)
            {
                CreateRecipe()
                    .AddIngredient(helmet)
                    .AddIngredient(ItemID.AdamantiteBreastplate)
                    .AddIngredient(ItemID.AdamantiteLeggings)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
}