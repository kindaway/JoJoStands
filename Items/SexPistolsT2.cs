using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace JoJoStands.Items
{
	public class SexPistolsT2 : ModItem
	{
        public int reloadCounter = 0;
        public int reloadStart = 0;

        public override string Texture
        {
            get { return mod.Name + "/Items/SexPistolsT1"; }
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sex Pistols (Tier 2)");
			Tooltip.SetDefault("Shoot homing bullets at your enemies!");
		}

		public override void SetDefaults()
		{
			item.damage = 74;
			item.ranged = true;
			item.width = 100;
			item.height = 8;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 6;
			item.UseSound = SexPistolsFinal.usesound;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("SPBullet");
            item.useAmmo = AmmoID.Bullet;
            item.maxStack = 1;
            item.shootSpeed = 30f;
			item.channel = true;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            SexPistolsFinal.bulletCount += 1;
            if (type != mod.ProjectileType("SPBullet"))
            {
                type = mod.ProjectileType("SPBullet");
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void HoldItem(Player player)
        {
            reloadCounter--;
            if (SexPistolsFinal.bulletCount == 6)       //do you really need this line?
            {
                reloadStart++;
            }
            if (SexPistolsFinal.bulletCount != 6)
            {
                reloadStart = 0;
            }
            if (reloadStart == 1)
            {
                if (MyPlayer.Sounds)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/sound/Reload180"));
                }
                reloadCounter = 180;
            }
            if (JoJoStands.ItemHotKey.JustPressed && reloadCounter <= 1 && player.whoAmI == Main.myPlayer)
            {
                if (MyPlayer.Sounds)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/sound/Reload120"));
                }
                reloadCounter = 120;
            }
            if (reloadCounter <= 0)
            {
                reloadCounter = 0;
            }
            if (reloadCounter == 1)
            {
                SexPistolsFinal.bulletCount = 0;
            }
            UI.BulletCounter.Visible = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (reloadCounter >= 1)
            {
                return false;
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SexPistolsT1"));
            recipe.AddIngredient(ItemID.HellstoneBar, 2);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}