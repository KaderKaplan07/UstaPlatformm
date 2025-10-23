// UstaPlatform.App/Engine/RuleLoader.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.App.Engine
{
    public class RuleLoader
    {
        public List<IPricingRule> LoadRules(string pluginPath)
        {
            var rules = new List<IPricingRule>();
            Console.WriteLine("[Loader] Plug-in'ler yükleniyor...");

            if (!Directory.Exists(pluginPath)) Directory.CreateDirectory(pluginPath);

            foreach (var dllFile in Directory.GetFiles(pluginPath, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    var ruleTypes = assembly.GetTypes()
                        .Where(t => typeof(IPricingRule).IsAssignableFrom(t) && !t.IsInterface);

                    foreach (var type in ruleTypes)
                    {
                        IPricingRule rule = (IPricingRule)Activator.CreateInstance(type);
                        rules.Add(rule);
                        Console.WriteLine($"[Loader] KURAL YÜKLENDİ: {rule.RuleName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Loader] HATA: {Path.GetFileName(dllFile)} yüklenemedi. {ex.Message}");
                }
            }
            Console.WriteLine($"[Loader] Toplam {rules.Count} kural yüklendi.");
            return rules;
        }
    }
}