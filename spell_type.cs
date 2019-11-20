using System.Collections.Generic;

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
                "none"
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
        struct fake_spell
        {
            string id;
            int max_level;
            int level;
            bool self;
        }

        class spell_value_member
        {
            public spell_value_member(string name)
            {
                name_ = name;
            }
            public void update_values( int min, float increment, int max )
            {
                min_ = min;
                increment_ = increment;
                max_ = max;
            }
            public void update_min( int min )
            {
                min_ = min;
            }
            public void update_increment( float increment )
            {
                increment_ = increment;
            }
            public void update_max( int max )
            {
                max_ = max;
            }

            public string create_json()
            {
                const string spacing = "    ";
                string ret = "";

                if( max_ == 0 )
                {
                    return ret;
                }

                ret += "\n" + spacing + "\"min_" + name_ + "\": " + min_.ToString() + ",";
                ret += "\n" + spacing + "\"max_" + name_ + "\": " + max_.ToString() + ",";

                if( increment_ != 0.0f )
                {
                    ret += "\n" + spacing + "\"" + name_ + "_increment\": " + increment_.ToString() + ",";
                }

                return ret;
            }

            string name_;
            int min_ = 0;
            float increment_ = 0.0f;
            int max_ = 0;
        }

        class spell_type
        {
            public spell_type() { }

            public string id = "";
            public string name = "";
            public string description = "";
            public string message = "You cast %s!";
            public string sound_description = "an explosion";
            public string sound_type = "combat";
            public bool sound_ambient = false;
            public string sound_id = "";
            public string sound_variant = "default";
            public string effect = "none";
            public string effect_str = "";
            public List<fake_spell> additional_spells;
            public string field = "";
            public int field_chance = 1;

            public spell_value_member field_intensity = new spell_value_member("field_intensity");

            public float field_intensity_variance = 0.0f;

            public spell_value_member damage = new spell_value_member("damage");
            public spell_value_member range = new spell_value_member("range");
            public spell_value_member aoe = new spell_value_member("aoe");
            public spell_value_member dot = new spell_value_member("dot");
            public spell_value_member pierce = new spell_value_member("pierce");

            public int min_duration = 0;
            public int duration_increment = 0;
            public int max_duration = 0;

            public int base_energy_cost = 0;
            public float energy_increment = 0.0f;
            public int final_energy_cost = 0;

            public string spell_class = "NONE";

            public int difficulty = 0;
            public int max_level = 0;

            public int base_casting_time = 0;
            public float casting_time_increment = 0.0f;
            public int final_casting_time = 0;

            public Dictionary<string, int> learn_spells;

            public string energy_source = "NONE";
            public string dmg_type = "NONE";

            public List<string> effect_targets = new List<string> { };
            public List<string> valid_targets = new List<string> { };
            public List<string> affected_bps = new List<string> { };
            public List<string> spell_tags = new List<string> { };
            
            public string jsonize_as_array(List<string> string_list)
            {
                string ret = "";

                if (string_list.Count == 0)
                {
                    return ret;
                }
                ret = "[ ";
                for (int i = 0; i < string_list.Count; i++)
                {
                    ret += "\"" + string_list[i] + "\"";
                    if (i < string_list.Count - 1)
                    {
                        ret += ", ";
                    }
                }
                ret += " ]";

                return ret;
            }

            public string create_json()
            {
                string ret = "  {";

                const string begin = "\n    \"";

                ret += begin + "id\": \"" + id + "\",";
                ret += begin + "type\": \"SPELL\",";
                ret += begin + "name\": \"" + name + "\",";
                ret += begin + "description\": \"" + description + "\",";
                ret += begin + "effect\": \"" + effect + "\",";
                if (effect_str != "")
                {
                    ret += begin + "effect_str\": \"" + effect_str + "\",";
                }
                if (spell_class != "NONE")
                {
                    ret += begin + "spell_class\": \"" + spell_class + "\",";
                }
                if (difficulty != 0)
                {
                    ret += begin + "difficulty\": " + difficulty.ToString() + ",";
                }
                if(max_level != 0)
                {
                    ret += begin + "max_level\": " + max_level.ToString() + ",";
                }

                if(energy_source != "NONE")
                {
                    ret += begin + "energy_source\": \"" + energy_source + "\",";
                }

                ret += begin + "base_casting_time\": " + base_casting_time.ToString() + ",";
                if (casting_time_increment != 0.0f) 
                {
                    ret += begin + "casting_time_increment\": " + casting_time_increment.ToString() + ",";
                }
                ret += begin + "final_casting_time\": " + final_casting_time.ToString() + ",";

                ret += damage.create_json();
                ret += range.create_json();
                ret += aoe.create_json();

                if (field.Length > 0)
                {
                    ret += begin + "field_id\": \"" + field + "\",";
                    ret += field_intensity.create_json();
                    ret += begin + "field_intensity_variance\": " + field_intensity_variance.ToString() + ",";
                    ret += begin + "field_chance\": " + field_chance.ToString() + ",";
                }

                if (sound_id.Length > 0)
                {
                    ret += begin + "sound_id\": \"" + sound_id + "\",";
                }
                if (sound_description != "an explosion")
                {
                    ret += begin + "sound_description\": \"" + sound_description + "\",";
                }
                if(sound_type != "combat")
                {
                    ret += begin + "sound_type\": \"" + sound_type + "\",";
                }
                if(sound_variant != "default")
                {
                    ret += begin + "sound_variant\": \"" + sound_variant + "\",";
                }
                if (sound_ambient)
                {
                    ret += begin + "sound_ambient\": true,";
                }

                if( affected_bps.Count != 0)
                {
                    ret += begin + "affected_body_parts\": " + jsonize_as_array(affected_bps) + ",";
                }
                // flags
                if (spell_tags.Count != 0)
                {
                    ret += begin + "flags\": " + jsonize_as_array(spell_tags) + ",";
                }
                ret += begin + "valid_targets\": " + jsonize_as_array(valid_targets);

                ret += "\n  }";
                return ret;
            }
        }
    }
}