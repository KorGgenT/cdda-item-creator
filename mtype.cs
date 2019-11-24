using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cdda_item_creator
{
    class MonsterNameStrings
    {
        [DefaultValue("")]
        public string name { get; set; } = "";
        [DefaultValue("")]
        public string name_plural { get; set; } = "";
    }

    class path_settings
    {
        public int max_dist { get; set; }
        [DefaultValue(-1)]
        public int max_length { get; set; }
        [DefaultValue(-1)]
        public int bash_strength { get; set; }
        [DefaultValue(false)]
        public bool allow_open_doors { get; set; }
        [DefaultValue(false)]
        public bool avoid_traps { get; set; }
        [DefaultValue(true)]
        public bool allow_climb_stairs { get; set; }
    }

    // this is a class that is supposed to be a carbon-copy of mtype from C:DDA
    // intended to be able to be written to JSON easily
    class mtype
    {
        public const string type = "MONSTER";

        [DefaultValue("")]
        public string id { get; set; }
        public MonsterNameStrings name { get; set; }
        [DefaultValue("")]
        public string description { get; set; }
        [DefaultValue("")]
        public string default_faction { get; set; } = "";
        [DefaultValue("")]
        public string looks_like { get; set; } = "";
        public int hp { get; set; }
        public int speed { get; set; }
        public char symbol { get; set; }
        public int diff { get; set; }
        public int aggression { get; set; }
        public int morale { get; set; }
        public float mountable_weight_ratio { get; set; }
        public int attack_cost { get; set; }
        public int melee_skill { get; set; }
        public int melee_dice { get; set; }
        public int melee_dice_sides { get; set; }
        public int grab_strength { get; set; }
        public int dodge { get; set; }
        public int armor_bash { get; set; }
        public int armor_cut { get; set; }
        public int armor_stab { get; set; }
        public int armor_acid { get; set; }
        public int armor_fire { get; set; }
        public int vision_day { get; set; }
        public int vision_night { get; set; }
        public float luminance { get; set; }

        [DefaultValue("")]
        public string revert_to_itype { get; set; }
        [DefaultValue("")]
        public string mech_weapon { get; set; } = "";
        public int mech_str_bonus { get; set; }
        [DefaultValue("")]
        public string mech_battery { get; set; } = "";
        public int melee_cut { get; set; }
        // mandatory json member
        public string harvest { get; set; } = "";
        [DefaultValue("")]
        public string burn_into { get; set; } = "";
        [DefaultValue(-1)]
        public int bash_skill { get; set; } = -1;
    }
}
