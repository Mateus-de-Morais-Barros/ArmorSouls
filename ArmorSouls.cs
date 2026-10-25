using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using ArmorSouls.Common.Configs;
using ArmorSouls.Common.Slots;

namespace ArmorSouls
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class ArmorSouls : Mod
	{
		public override void Load()
		{
			// Registra o máximo de slots; a config controla quantos ficam habilitados
			for (int i = 0; i < ArmorSoulsServerConfig.MaxSoulSlots; i++)
			{
				AddContent(new SoulAccessorySlot(i));
			}
		}
	}
}
