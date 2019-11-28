using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cdda_item_creator
{
    class Translation
    {
        [DefaultValue("")]
        public string Str { get; set; } = "";
        [DefaultValue("")]
        public string StrPl { get; set; } = "";
    }

    class PathSettingsData
    {
        public int MaxDist { get; set; }
        [DefaultValue(-1)]
        public int MaxLength { get; set; }
        [DefaultValue(-1)]
        public int BashStrength { get; set; }
        [DefaultValue(false)]
        public bool AllowOpenDoors { get; set; }
        [DefaultValue(false)]
        public bool AvoidTraps { get; set; }
        [DefaultValue(true)]
        public bool AllowClimbStairs { get; set; }
    }

    // this is a class that is supposed to be a carbon-copy of mtype from C:DDA
    // intended to be able to be written to JSON easily
    class Mtype
    {
        public const string Type = "MONSTER";

        [DefaultValue("")]
        public string Id { get; set; } = "";
        public Translation Name { get; set; } = new Translation { };
        [DefaultValue("")]
        public string Description { get; set; } = "";
        [DefaultValue("")]
        public string DefaultFaction { get; set; } = "";
        [DefaultValue("")]
        public string LooksLike { get; set; } = "";
        public int Hp { get; set; }
        public int Speed { get; set; }
        public char Symbol { get; set; }
        public int Diff { get; set; }
        public int Aggression { get; set; }
        public int Morale { get; set; }
        public float MountableWeightRatio { get; set; }
        public int AttackCost { get; set; }
        public int MeleeSkill { get; set; }
        public int MeleeDice { get; set; }
        public int MeleeDiceSides { get; set; }
        public int GrabStrength { get; set; }
        public int Dodge { get; set; }
        public int ArmorBash { get; set; }
        public int ArmorCut { get; set; }
        public int ArmorStab { get; set; }
        public int ArmorAcid { get; set; }
        public int ArmorFire { get; set; }
        public int VisionDay { get; set; }
        public int VisionNight { get; set; }
        public float Luminance { get; set; }

        [DefaultValue("")]
        public string RevertToItype { get; set; } = "";
        [DefaultValue("")]
        public string MechWeapon { get; set; } = "";
        public int MechStrBonus { get; set; }
        [DefaultValue("")]
        public string MechBattery { get; set; } = "";
        public int MeleeCut { get; set; }
        // mandatory json member
        public string Harvest { get; set; } = "";
        [DefaultValue("")]
        public string BurnInto { get; set; } = "";
        [DefaultValue(-1)]
        public int BashSkill { get; set; } = -1;
        public PathSettingsData PathSettings { get; set; }
    }
}
