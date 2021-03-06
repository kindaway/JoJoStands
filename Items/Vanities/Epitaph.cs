using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;


namespace JoJoStands.Items.Vanities
{
	[AutoloadEquip(EquipType.Head)]
	public class Epitaph : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Wearing this makes you want to use a frog as a phone");
		}

		public override void SetDefaults()
        {
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 8;
            item.vanity = true;
		}

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            base.DrawHair(ref drawHair, ref drawAltHair);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}