using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.AccessoryBuff
{
    public class SpaceFreeze : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Space Freeze!");
            Description.SetDefault("You went too high and are now going to stay in space for the rest of eternity... Have a good time!");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity.Y += -0.2f;
            player.velocity.X += -0.2f;
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 120;
            player.moveSpeed *= 0.5f;
        }
    }
}