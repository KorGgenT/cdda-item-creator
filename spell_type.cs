using System.Collections.Generic;
using System.ComponentModel;

namespace cdda_item_creator
{

    namespace spell
    {
        static class allowed_strings
        {
            public static string[] spell_flags =
            {
                "PERMANENT",
                "IGNORE_WALLS",
                "HOSTILE_SUMMON",
                "HOSTILE_50",
                "SILENT",
                "LOUD",
                "VERBAL",
                "SOMATIC",
                "NO_HANDS",
                "UNSAFE_TELEPORT",
                "NO_LEGS",
                "CONCENTRATE",
                "RANDOM_AOE",
                "RANDOM_DAMAGE",
                "RANDOM_DURATION",
                "RANDOM_TARGET",
                "MUTATE_TRAIT",
                "WONDER"
            };
            // flag, description
            public static Dictionary<string, string> spell_flags_description = new Dictionary<string, string> 
            {
                { "PERMANENT", "items or creatures spawned with this spell do not disappear and die as normal" },
                { "IGNORE_WALLS", "spell's aoe goes through walls" },
                { "HOSTILE_SUMMON", "summon spell always spawns a hostile monster" },
                { "HOSTILE_50", "summoned monster spawns friendly 50% of the time" },
                { "SILENT", "spell makes no noise at target" },
                { "LOUD", "spell makes extra noise at target" },
                { "VERBAL", "spell makes noise at caster location, mouth encumbrance affects fail %" },
                { "SOMATIC", "arm encumbrance affects fail % and casting time (slightly)" },
                { "NO_HANDS", "hands do not affect spell energy cost" },
                { "UNSAFE_TELEPORT", "teleport spell risks killing the caster or others" },
                { "NO_LEGS", "focus affects spell fail %" },
                { "CONCENTRATE", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_AOE", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_DAMAGE", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_DURATION", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_TARGET", "picks a random valid target within your range instead of normal behavior" },
                { "MUTATE_TRAIT", "overrides the mutate spell_effect to use a specific trait_id instead of a category" },
                { "WONDER", "instead of casting each of the extra_spells, it picks N of them and casts them (where N is std::min( damage(), number_of_spells ))" }
            };
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
            // allowed spell effects
            public static string[] effects =
            {
                "pain_split",
                "target_attack",
                "projectile_attack",
                "cone_attack",
                "line_attack",
                "area_pull",
                "area_push",
                "spawn_item",
                "teleport_random",
                "recover_energy",
                "ter_transform",
                "vomit",
                "timed_event",
                "explosion",
                "flashbang",
                "mod_moves",
                "map",
                "morale",
                "charm_monster",
                "mutate",
                "bash",
                "none"
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
            public static Dictionary<string, string> effect_descriptions = new Dictionary<string, string>
            {
                { "pain_split", "makes all of your limbs' damage even out" },
                { "target_attack", "deals damage to a target (ignores walls). If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts. Any aoe will manifest as a circular area centered on the target, and will only deal damage to valid_targets. (aoe does not ignore walls)" },
                { "projectile_attack", "similar to target_attack, except the projectile you shoot will stop short at impassable terrain. If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts." },
                { "cone_attack", "fires a cone toward the target up to your range. The arc of the cone in degrees is aoe. Stops at walls. If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts." },
                { "line_attack", "fires a line with width aoe toward the target, being blocked by walls on the way. If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts." },
                { "area_pull", "pulls effect filtered targets toward the epicenter" },
                { "area_push", "pushes effect filtered targets away from the epicenter" },
                { "spawn_item", "spawns an item that disappear at the end of its duration. default duration is 0." },
                { "teleport_random", "teleports the player randomly range spaces with aoe variation" },
                { "recover_energy", "recovers an energy source (defined in the effect_str) equal to damage of the spell" },
                { "ter_transform", "transform the terrain and furniture in an area centered at the target. The chance of any one of the points in the area of effect changing is one_in( damage ). The effect_str is the id of a ter_furn_transform." },
                { "vomit", "any creature within its area of effect will instantly vomit, if it's able to do so." },
                { "timed_event", "adds a timed event to the player only. NOTE: This was added only for artifact active effects. support is limited, use at your own risk" },
                { "explosion", "an explosion is centered on the target, with power damage() and factor aoe()/10" },
                { "flashbang", "a flashbang effect is centered on the target, with poewr damage() and factor aoe()/10" },
                { "mod_moves", "adds damage() moves to the target. can be negative to freeze the target for that amount of time" },
                { "map", "maps the overmap centered on the player out to a radius of aoe()" },
                { "morale", "gives a morale effect to all npcs or avatar within aoe, with value damage(). decay_start is duration() / 10." },
                { "charm_monster", "charms a monster that has less hp than damage() for approximately duration()" },
                { "mutate", "mutates the target(s). if effect_str is defined, mutates toward that category instead of picking at random. the MUTATE_TRAIT flag allows effect_str to be a specific trait instead of a category. damage() / 100 is the percent chance the mutation will be successful (a value of 10000 represents 100.00%)" },
                { "bash", "bashes the terrain at the target. uses damage() as the strength of the bash." },
                { "none", "please select a spell effect" }
            };
        }
        public struct fake_spell
        {
            string id;
            int max_level;
            int level;
            bool self;
        }

        public class spell_type
        {
            public spell_type() { }

            public string id { get; set; } = "";
            public const string type = "SPELL";
            public string name { get; set; } = "";
            public string description { get; set; } = "";

            [DefaultValue("You cast %s!")]
            public string message { get; set; } = "You cast %s!";

            [DefaultValue("an explosion")]
            public string sound_description = "an explosion";

            [DefaultValue("combat")]
            public string sound_type { get; set; } = "combat";

            public bool sound_ambient = false;

            [DefaultValue("")]
            public string sound_id { get; set; } = "";

            [DefaultValue("default")]
            public string sound_variant { get; set; } = "default";

            [DefaultValue("none")]
            public string effect { get; set; } = "none";

            [DefaultValue("")]
            public string effect_str { get; set; } = "";

            public List<fake_spell> additional_spells { get; set; } = new List<fake_spell>();

            [DefaultValue("none")]
            public string field = "none";

            [DefaultValue(1)]
            public int field_chance { get; set; } = 1;

            public int min_field_intensity { get; set; }
            public float field_intensity_increment { get; set; }
            public int max_field_intensity { get; set; }

            public float field_intensity_variance { get; set; }

            public int min_damage { get; set; }
            public float damage_increment { get; set; }
            public int max_damage { get; set; }

            public int min_range { get; set; }
            public float range_increment { get; set; }
            public int max_range { get; set; }

            public int min_aoe { get; set; }
            public float aoe_increment { get; set; }
            public int max_aoe { get; set; }

            public int min_dot { get; set; }
            public float dot_increment { get; set; }
            public int max_dot { get; set; }

            public int min_pierce { get; set; }
            public float pierce_increment { get; set; }
            public int max_pierce { get; set; }

            public int min_duration { get; set; }
            public int duration_increment { get; set; }
            public int max_duration { get; set; }

            public int base_energy_cost { get; set; }
            public float energy_increment { get; set; }
            public int final_energy_cost { get; set; }


            [DefaultValue("NONE")]
            public string spell_class { get; set; } = "NONE";

            public int difficulty { get; set; }
            public int max_level { get; set; }

            public int base_casting_time { get; set; }
            public float casting_time_increment { get; set; }
            public int final_casting_time { get; set; }

            public Dictionary<string, int> learn_spells { get; set; } = new Dictionary<string, int>();

            [DefaultValue("NONE")]
            public string energy_source { get; set; } = "NONE";

            [DefaultValue("NONE")]
            public string damage_type { get; set; } = "NONE";

            public List<string> effect_targets { get; set; } = new List<string> { };
            public List<string> valid_targets { get; set; } = new List<string> { };
            public List<string> affected_bps { get; set; } = new List<string> { };
            public List<string> spell_tags { get; set; } = new List<string> { };
        }
    }
}