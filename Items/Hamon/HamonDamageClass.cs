using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace JoJoStands.Items.Hamon
{
    // This class handles everything for our custom damage class
    // Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
    public abstract class HamonDamageClass : ModItem        //the main reason this class was made was so that things like the aja stone and hamon increasing items can affect all of them at once.
    {
        // Custom items should override this to set their defaults
        public virtual void SafeSetDefaults()
        {}

        // By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
        // We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            // all vanilla damage types must be false for custom damage types to work
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what langauge the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.text.Split(' ');
                // Change the tooltip text
                tt.text = splitText.First() + " Hamon " + splitText.Last();
            }
        }

        // As a modder, you could also opt to make the Get overrides also sealed. Up to the modder
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult)       //when making the base damage values, make sure they are around the 10-20's cause otherwise, at MoonLord they'd go over 250
        {
            if (player.GetModPlayer<MyPlayer>().AjaStone)
            {
                mult *= 1.5f;
            }
            if (NPC.downedBoss1)    //eye of cthulu
            {
                add += 1.15f;     //this is 14%
            }
            if (NPC.downedBoss2)      //the crimson/corruption bosses
            {
                add += 1.17f;
            }
            if (NPC.downedBoss3)       //skeletron
            {
                add += 1.13f;
            }
            if (Main.hardMode)      //wall of flesh
            {
                mult *= 1.3f;
            }
            if (NPC.downedMechBoss1)        //any mechboss orders
            {
                add += 1.18f;
            }
            if (NPC.downedMechBoss2)
            {
                add += 1.16f;
            }
            if (NPC.downedMechBoss3)
            {
                add += 1.18f;
            }
            if (NPC.downedPlantBoss)       //plantera
            {
                add += 1.19f;
            }
            if (NPC.downedGolemBoss)        //golem
            {
                add += 1.19f;
            }
            if (NPC.downedMoonlord)     //moon lord
            {
                add += 1.29f;
            }
            if (player.GetModPlayer<MyPlayer>().HamonCounter >= player.GetModPlayer<MyPlayer>().maxHamon / 2)     //more than half of maxHamon
            {
                mult *= 1.5f;
            }
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            // Adds knockback bonuses
            if (player.GetModPlayer<MyPlayer>().AjaStone)
            {
                knockback *= 1.5f;
            }
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            // Adds crit bonuses
            if (player.GetModPlayer<MyPlayer>().AjaStone)
            {
                crit *= (int)1.5;
            }
        }
    }
}