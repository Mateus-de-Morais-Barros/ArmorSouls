using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArmorSouls.Common.Players
{
    // Parte dos set bonuses vanilla só funciona dentro do UpdateArmorSets, que roda depois dos acessórios
    // e ainda desfaz alguns efeitos quando o set não está vestido. Esta classe refaz essa lógica em PostUpdateEquips.
    public class SoulSetBonusPlayer : ModPlayer
    {
        public bool chlorophyteSoul;
        public bool beetleSoul;
        public bool solarSoul;
        public bool vortexSoul;
        public bool nebulaSoul;
        public bool forbiddenSoul;

        // Estado do Vortex Stealth antes do UpdateArmorSets desligá-lo
        public bool vortexStealthWasActive;

        // O solarCounter vanilla é zerado todo frame sem o set, então usamos um contador próprio
        private int solarCounter;

        public override void ResetEffects()
        {
            chlorophyteSoul = false;
            beetleSoul = false;
            solarSoul = false;
            vortexSoul = false;
            nebulaSoul = false;
            forbiddenSoul = false;
        }

        public override void PostUpdateEquips()
        {
            if (chlorophyteSoul)
            {
                // ChlorophyteSoul desliga crystalLeaf antes do UpdateArmorSets para ele não apagar o buff (o que fazia o cristal piscar)
                Player.crystalLeaf = true;
                Player.AddBuff(BuffID.LeafCrystal, 18000);
            }

            if (beetleSoul)
            {
                UpdateBeetleEndurance();
            }

            if (solarSoul)
            {
                UpdateSolarShields();
            }
            else
            {
                solarCounter = 0;
            }

            if (vortexSoul)
            {
                Player.vortexStealthActive = vortexStealthWasActive;
            }

            if (nebulaSoul && Player.nebulaCD > 0)
            {
                Player.nebulaCD--;
            }

            if (forbiddenSoul)
            {
                Player.UpdateForbiddenSetLock();
                Lighting.AddLight(Player.Center, 0.8f, 0.7f, 0.2f);
            }
        }

        // Mesma lógica do Beetle Shell vanilla: um besouro a mais a cada 3 segundos, até 3
        private void UpdateBeetleEndurance()
        {
            const int beetleTime = 180;

            Player.beetleCounter++;
            if (Player.beetleCounter < beetleTime)
                return;

            if (Player.beetleOrbs > 0 && Player.beetleOrbs < 3)
            {
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    if (Player.buffType[i] >= BuffID.BeetleEndurance1 && Player.buffType[i] <= BuffID.BeetleEndurance2)
                    {
                        Player.DelBuff(i);
                    }
                }
            }

            if (Player.beetleOrbs < 3)
            {
                Player.AddBuff(BuffID.BeetleEndurance1 + Player.beetleOrbs, 5, quiet: false);
                Player.beetleCounter = 0f;
            }
            else
            {
                Player.beetleCounter = beetleTime;
            }
        }

        // Mesma lógica do Solar Flare vanilla: escudos a cada 3 segundos, posição dos escudos e Solar Dash
        private void UpdateSolarShields()
        {
            const int shieldTime = 180;

            solarCounter++;
            if (solarCounter >= shieldTime)
            {
                if (Player.solarShields > 0 && Player.solarShields < 3)
                {
                    for (int i = 0; i < Player.MaxBuffs; i++)
                    {
                        if (Player.buffType[i] >= BuffID.SolarShield1 && Player.buffType[i] <= BuffID.SolarShield2)
                        {
                            Player.DelBuff(i);
                        }
                    }
                }

                if (Player.solarShields < 3)
                {
                    Player.AddBuff(BuffID.SolarShield1 + Player.solarShields, 5, quiet: false);

                    for (int i = 0; i < 16; i++)
                    {
                        Dust dust = Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, DustID.Torch, 0f, 0f, 100)];
                        dust.noGravity = true;
                        dust.scale = 1.7f;
                        dust.fadeIn = 0.5f;
                        dust.velocity *= 5f;
                        dust.shader = GameShaders.Armor.GetSecondaryShader(Player.ArmorSetDye(), Player);
                    }

                    solarCounter = 0;
                }
                else
                {
                    solarCounter = shieldTime;
                }
            }

            for (int i = Player.solarShields; i < 3; i++)
            {
                Player.solarShieldPos[i] = Vector2.Zero;
            }

            for (int i = 0; i < Player.solarShields; i++)
            {
                Player.solarShieldPos[i] += Player.solarShieldVel[i];
                Vector2 target = ((float)Player.miscCounter / 100f * MathHelper.TwoPi + i * (MathHelper.TwoPi / Player.solarShields)).ToRotationVector2() * 6f;
                target.X = Player.direction * 20;
                if (Player.mount.Active && Player.mount.Type == MountID.Wolf)
                {
                    target.X = Player.direction * 50;
                }
                Player.solarShieldVel[i] = (target - Player.solarShieldPos[i]) * 0.2f;
            }

            if (Player.dashDelay >= 0)
            {
                Player.solarDashing = false;
                Player.solarDashConsumedFlare = false;
            }

            bool dashing = Player.solarDashing && Player.dashDelay < 0;
            if (Player.solarShields > 0 || dashing)
            {
                Player.dashType = 3;
            }
        }
    }
}
