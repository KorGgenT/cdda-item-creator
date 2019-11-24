using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace cdda_item_creator
{

    namespace spell
    {
        class StaticDataLoader
        {
            public void loadAll()
            {
                loadFlags();
                loadEffects();
            }
            public void loadFlags()
            {
                string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\spell_flags.json";
                string flag_file_text = File.ReadAllText(flag_path);
                JObject o1 = JObject.Parse(flag_file_text);
                allowed_strings.spell_flags_description = o1.ToObject<Dictionary<string, string>>();
            }
            public void loadEffects()
            {
                string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\spell_effects.json";
                string flag_file_text = File.ReadAllText(flag_path);
                JObject o1 = JObject.Parse(flag_file_text);
                allowed_strings.effect_descriptions = o1.ToObject<Dictionary<string, string>>();
            }
        }
        static class allowed_strings
        {
            // flag, description
            public static Dictionary<string, string> spell_flags_description = new Dictionary<string, string> 
            { };
            public static string[] energy_types = 
            {
                "NONE",
                "HP",
                "MANA",
                "STAMINA",
                "BIONIC",
                "FATGIUE"
            };
            public static string[] valid_targets =
            {
                "ally",
                "hostile",
                "self",
                "ground",
                "none",
                "item",
                "fd_fire",
                "fd_blood"
            };
            public static string[] damage_types =
            {
                "fire",
                "acid",
                "bash",
                "bio",
                "cold",
                "cut",
                "electric",
                "stab",
                "NONE"
            };
            // available options for recover_energy effect
            public static string[] recover_energy_types =
            {
                "MANA",
                "STAMINA",
                "FATIGUE",
                "PAIN",
                "BIONIC"
            };
            // available options for timed_event effect
            public static string[] timed_event =
            {
                "help",
                "wanted",
                "robot_attack",
                "spawn_wyrms",
                "amigara",
                "roots_die",
                "temple_open",
                "temple_flood",
                "temple_spawn",
                "dim",
                "artifact_light"
            };
            public static string[] body_parts =
            {
                "TORSO",
                "HEAD",
                "EYES",
                "MOUTH",
                "ARM_L",
                "ARM_R",
                "HAND_L",
                "HAND_R",
                "LEG_L",
                "LEG_R",
                "FOOT_L",
                "FOOT_R"
            };
            public static string[] sound_types =
            {
                "background",
                "weather",
                "music",
                "movement",
                "speech",
                "movement",
                "speech",
                "activity",
                "destructive_activity",
                "alarm",
                "combat",
                "alert",
                "order"
            };
            // effect, description
            public static Dictionary<string, string> effect_descriptions = new Dictionary<string, string> { };
        }
        public class FakeSpell
        {
            // mandatory member
            public string Id { get; set; } = "";
            [DefaultValue(-1)]
            public int MaxLevel { get; set; }
            public int Level { get; set; }
            [DefaultValue(false)]
            public bool Self { get; set; }
        }

        public class spell_type
        {
            public spell_type() { }

            public string Id { get; set; } = "";
            public const string Type = "SPELL";
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";

            [DefaultValue("You cast %s!")]
            public string Message { get; set; } = "You cast %s!";

            [DefaultValue("an explosion")]
            public string SoundDescription { get; set; } = "an explosion";

            [DefaultValue("combat")]
            public string SoundType { get; set; } = "combat";

            public bool SoundAmbient { get; set; } = false;

            [DefaultValue("")]
            public string SoundId { get; set; } = "";

            [DefaultValue("default")]
            public string SoundVariant { get; set; } = "default";
            public string Effect { get; set; } = "none";

            [DefaultValue("")]
            public string EffectStr { get; set; } = "";

            [DefaultValue(default(List<FakeSpell>))]
            public List<FakeSpell> AdditionalSpells { get; set; }

            [DefaultValue("none")]
            public string FieldId { get; set; } = "none";

            [DefaultValue(1)]
            public int FieldChance { get; set; } = 1;

            public int MinFieldIntensity { get; set; }
            public float FieldIntensityIncrement { get; set; }
            public int MaxFieldIntensity { get; set; }

            public float FieldIntensityVariance { get; set; }

            public int MinDamage { get; set; }
            public float DamageIncrement { get; set; }
            public int MaxDamage { get; set; }

            public int MinRange { get; set; }
            public float RangeIncrement { get; set; }
            public int MaxRange { get; set; }

            public int MinAoe { get; set; }
            public float AoeIncrement { get; set; }
            public int MaxAoe { get; set; }

            public int MinDot { get; set; }
            public float DotIncrement { get; set; }
            public int MaxDot { get; set; }

            public int MinPierce { get; set; }
            public float PierceIncrement { get; set; }
            public int MaxPierce { get; set; }

            public int MinDuration { get; set; }
            public int DurationIncrement { get; set; }
            public int MaxDuration { get; set; }

            public int BaseEnergyCost { get; set; }
            public float EnergyIncrement { get; set; }
            public int FinalEnergyCost { get; set; }


            [DefaultValue("NONE")]
            public string SpellClass { get; set; } = "NONE";

            public int Difficulty { get; set; }
            public int MaxLevel { get; set; }

            public int BaseCastingTime { get; set; }
            public float CastingTimeIncrement { get; set; }
            public int FinalCastingTime { get; set; }

            [DefaultValue(default(Dictionary<string, int>))]
            public Dictionary<string, int> LearnSpells { get; set; }

            [DefaultValue("NONE")]
            public string EnergySource { get; set; } = "NONE";

            [DefaultValue("NONE")]
            public string DamageType { get; set; } = "NONE";
            public bool ShouldSerializeEffectTargets() => EffectTargets.Count > 0;

            [DefaultValue(default(List<string>))]
            public List<string> EffectTargets { get; set; }

            [DefaultValue(default(List<string>))]
            public List<string> ValidTargets { get; set; }
            public bool ShouldSerializeAffectedBps() => AffectedBps.Count > 0;

            [DefaultValue(default(List<string>))]
            public List<string> AffectedBps { get; set; }
            public bool ShouldSerializeFlags() => Flags.Count > 0;

            [DefaultValue(default(List<string>))]
            public List<string> Flags { get; set; }
        }
    }
}