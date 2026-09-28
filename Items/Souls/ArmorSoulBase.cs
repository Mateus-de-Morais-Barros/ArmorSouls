using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ArmorSouls.Common.Configs;

namespace ArmorSouls.Items.Souls
{
    public abstract class ArmorSoulBase : ModItem
    {
        // IDs das peças da armadura correspondente
        public virtual int HeadPieceID => -1;
        public virtual int BodyPieceID => -1;
        public virtual int LegPieceID => -1;

        // Efeito único do conjunto (set bonus vanilla) - sempre ativo
        public virtual void ApplySoulEffects(Player player) { }

        // Bônus de dano/crítico/velocidade de cada peça individual (variantes de elmo por classe)
        // Só é aplicado se a opção estiver ativa no mod config
        public virtual void ApplyPieceDamageBonuses(Player player) { }

        // Sobrescrito por almas que possuem bônus de peça, para exibir o aviso na tooltip quando desativado
        public virtual bool HasPieceDamageBonuses => false;

        public void ApplyEffects(Player player)
        {
            ApplySoulEffects(player);

            if (HasPieceDamageBonuses && ModContent.GetInstance<ArmorSoulsConfig>().IncludePieceDamageBonuses)
            {
                ApplyPieceDamageBonuses(player);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Só aplica se o jogador NÃO estiver com a armadura completa vestida
            if (!IsFullArmorSetEquipped(player))
            {
                ApplyEffects(player);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (HasPieceDamageBonuses && !ModContent.GetInstance<ArmorSoulsConfig>().IncludePieceDamageBonuses)
            {
                tooltips.Add(new TooltipLine(Mod, "PieceDamageBonusDisabled",
                    "Individual piece damage bonuses are disabled in the mod config")
                {
                    OverrideColor = new Microsoft.Xna.Framework.Color(150, 150, 150)
                });
            }
        }

        // Verifica se os 3 slots de armadura do player contêm as peças deste set
        public virtual bool IsFullArmorSetEquipped(Player player)
        {
            bool hasHead = HeadPieceID != -1 && player.armor[0].type == HeadPieceID;
            bool hasBody = BodyPieceID != -1 && player.armor[1].type == BodyPieceID;
            bool hasLegs = LegPieceID != -1 && player.armor[2].type == LegPieceID;

            return hasHead && hasBody && hasLegs;
        }
    }
}