using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace JoJoStands.Items.Hamon
{
	public class CaesarHamon : HamonDamageClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesar's Hamon");
			Tooltip.SetDefault("Shoot controllable bubbles! \nExperience goes up after each conquer... \nRight-click requires more than 3 hamon");
		}
		public override void SafeSetDefaults()
		{
			item.damage = 15;
			item.width = 30;
			item.height = 8;        //hitbox's width and height when the item is in the world
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 3;
			item.maxStack = 1;
			item.knockBack = 1;
			item.rare = 6;
            item.UseSound = SoundID.Item85;
            item.shoot = mod.ProjectileType("HamonBubble");
			item.shootSpeed = 4f;
            item.useTurn = true;
            item.noWet = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.GetModPlayer<MyPlayer>().HamonCounter >= 3)
            {
                item.damage = 17;
                item.ranged = true;
                item.width = 30;
                item.height = 18;
                item.useTime = 12;
                item.useAnimation = 12;
                item.useStyle = 3;
                item.knockBack = 3;
                item.autoReuse = false;
                item.shoot = mod.ProjectileType("CutterHamonBubble");
                item.shootSpeed = 7f;
                player.GetModPlayer<MyPlayer>().HamonCounter -= 3;
            }
            if (player.altFunctionUse == 2 && player.GetModPlayer<MyPlayer>().HamonCounter <= 3)
            {
                return false;
            }
            if (player.altFunctionUse != 2)
            {
                item.damage = 15;
                item.ranged = true;
                item.width = 30;
                item.height = 30;
                item.useTime = 8;
                item.useAnimation = 8;
                item.useStyle = 3;
                item.knockBack = 1;
                item.autoReuse = false;
                item.shoot = mod.ProjectileType("HamonBubble");
                item.shootSpeed = 10f;
            }
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.statLife <= 50)
            {
                item.shoot = mod.ProjectileType("HamonBloodBubble");
                item.shootSpeed = 5f;
                item.damage += 24;
                player.GetModPlayer<MyPlayer>().HamonCounter -= 1;
            }
            else
            {
                item.shoot = mod.ProjectileType("HamonBubble");
                item.shootSpeed = 30f;
                player.GetModPlayer<MyPlayer>().HamonCounter -= 1;
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void HoldItem(Player player)
        {
            //Dust.NewDust(player.position,  player.width, player.height, 169);    the old dust, it was unwanted
            player.waterWalk = true;
            player.waterWalk2 = true;
		}

        public override void ModifyHitPvp(Player player, Player target, ref int damage, ref bool crit)
        {
            if (target.HasBuff(mod.BuffType("Vampire")))
            {
                target.AddBuff(mod.BuffType("Sunburn"), 80);
            }
        }

        public override bool UseItem(Player player)
        {
            return base.UseItem(player);
        }

        public override bool UseItemFrame(Player player)
        {
            return base.UseItemFrame(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SunDroplet"), 14);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
