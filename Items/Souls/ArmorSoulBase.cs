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

        // Esconde o visual do set bonus (ex: Stardust Guardian) sem remover o efeito
        // Chamado quando o "esconder visual" do slot está ativo
        public virtual void HideSoulVisuals(Player player) { }

        public void ApplyEffects(Player player, bool hideVisual = false)
        {
            ApplySoulEffects(player);

            if (hideVisual)
            {
                HideSoulVisuals(player);
            }

            if (HasPieceDamageBonuses && ModContent.GetInstance<ArmorSoulsServerConfig>().IncludePieceDamageBonuses)
            {
                ApplyPieceDamageBonuses(player);
            }
        }

        // Quando ativo, almas só funcionam nos slots próprios de alma
        public static bool SoulSlotsEnabled => ModContent.GetInstance<ArmorSoulsServerConfig>().EnableSoulSlots;

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            // Bloqueia os slots de acessório vanilla; os slots de alma filtram o resto em CanAcceptItem
            return !SoulSlotsEnabled || modded;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Almas que já estavam em slots vanilla antes de ativar a opção ficam sem efeito
            if (SoulSlotsEnabled && IsInVanillaAccessorySlot(player))
            {
                return;
            }

            // Só aplica se o jogador NÃO estiver com a armadura completa vestida
            if (!IsFullArmorSetEquipped(player))
            {
                ApplyEffects(player, hideVisual);
            }
        }

        private bool IsInVanillaAccessorySlot(Player player)
        {
            // player.armor[3..9] são os slots funcionais de acessório vanilla
            for (int i = 3; i < 10; i++)
            {
                if (player.armor[i] == Item)
                {
                    return true;
                }
            }

            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (SoulSlotsEnabled)
            {
                tooltips.Add(new TooltipLine(Mod, "SoulSlotOnly", "Can only be equipped in a Soul Slot")
                {
                    OverrideColor = new Microsoft.Xna.Framework.Color(150, 150, 150)
                });
            }

            if (HasPieceDamageBonuses && !ModContent.GetInstance<ArmorSoulsServerConfig>().IncludePieceDamageBonuses)
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