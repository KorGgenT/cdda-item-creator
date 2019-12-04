using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace cdda_item_creator
{
    public class Translation
    {
        [DefaultValue("")]
        public string Str { get; set; } = "";
        [DefaultValue("")]
        public string StrPl { get; set; } = "";
        public Translation() { }
        public Translation(string str)
        {
            Str = str;
        }
        public Translation(string str, string strpl)
        {
            Str = str;
            StrPl = strpl;
        }
        public static explicit operator Translation(string str) => new Translation(str);
    }

    public class PathSettingsData
    {
        public int MaxDist { get; set; }
        [DefaultValue(-1)]
        public int MaxLength { get; set; } = -1;
        [DefaultValue(-1)]
        public int BashStrength { get; set; } = -1;
        [DefaultValue(false)]
        public bool AllowOpenDoors { get; set; }
        [DefaultValue(false)]
        public bool AvoidTraps { get; set; }
        [DefaultValue(true)]
        public bool AllowClimbStairs { get; set; } = true;
    }

    public class DamageUnit
    {
        [JsonProperty("damage_type")]
        public string Type;
        public float Amount;
        public int ArmorPenetration;
        [DefaultValue(1.0f)]
        public float ArmorMultiplier = 1.0f;
        [DefaultValue(1.0f)]
        public float DamageMultiplier = 1.0f;
    }

    public class DamageInstance
    {
        public List<DamageUnit> Values = new List<DamageUnit> { };
        public void Add(DamageUnit du_add)
        {
            Values.Add(du_add);
        }
    }

    // this is a class that is supposed to be a carbon-copy of mtype from C:DDA
    // intended to be able to be written to JSON easily
    public class Mtype : INotifyPropertyChanged
    {
        public Mtype()
        {
            Id = "";
            Name = new Translation { };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Type { get; } = "MONSTER";
        [JsonIgnore]
        public string IdValue = "";

        [DefaultValue("")]
        public string Id 
        {
            get { 
                return IdValue; 
            }
            set { 
                if (value != IdValue) 
                { 
                    IdValue = value;
                    NotifyPropertyChanged(); 
                } 
            } 
        }
        [JsonConverter(typeof(TranslationConverter<Translation>))]
        public Translation Name { get; set; }
        [JsonIgnore]
        public string NamePlural { get; set; }
        [DefaultValue("")]
        public string Description { get; set; } = "";
        [DefaultValue("")]
        public string DefaultFaction { get; set; } = "";
        [DefaultValue("")]
        public string LooksLike { get; set; } = "";
        public int Hp { get; set; }
        [DefaultValue("")]
        [JsonConverter(typeof(VolumeConverter<string>))]
        public string Volume { get; set; } = "";
        public string Color { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Material { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Species { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Categories { get; set; }
        [DefaultValue("")]
        [JsonConverter(typeof(WeightConverter<string>))]
        public string Weight { get; set; } = "";
        public int Speed { get; set; }
        public char Symbol { get; set; }
        public int Diff { get; set; }
        public int Aggression { get; set; }
        public int Morale { get; set; }
        public float MountableWeightRatio { get; set; }
        public int AttackCost { get; set; }
        public int MeleeSkill { get; set; }
        public int MeleeDice { get; set; } = 1;
        public int MeleeDiceSides { get; set; } = 1;
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
        [JsonConverter(typeof(DamageInstanceConverter<DamageInstance>))]
        public DamageInstance MeleeDamage;
        public int MeleeCut { get; set; }
        // mandatory json member
        public string Harvest { get; set; } = "";
        [DefaultValue("")]
        public string BurnInto { get; set; } = "";
        [DefaultValue(-1)]
        public int BashSkill { get; set; } = -1;
        public PathSettingsData PathSettings { get; set; } = new PathSettingsData { };
        public List<string> Flags { get; set; }
        public List<MonsterAttack> SpecialAttacks { get; set; }

        public void UpdateVolume( int num_part, string unit )
        {
            Volume = num_part.ToString() + " " + unit;
        }

        public void UpdateWeight( int num_part, string unit )
        {
            Weight = num_part.ToString() + " " + unit;
        }

        public int Difficulty()
        {
            int difficulty = (int)((MeleeSkill + 1) * MeleeDice * (MeleeCut + MeleeDiceSides) * 0.04 +
                (Dodge + 1) * (3 + ArmorBash + ArmorCut) * 0.04 +
                (Diff /* + special_attacks.size() + 8 * emit_fields.size() */));
            difficulty = (int)( difficulty * (Hp + Speed - AttackCost + (Morale + Aggression) * 0.1) * 0.01 +
                (VisionDay + 2 * VisionNight) * 0.01);
            return difficulty;
        }
    }
}
