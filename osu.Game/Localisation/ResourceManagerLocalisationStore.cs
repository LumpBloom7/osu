// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading.Tasks;
using osu.Framework.Localisation;

namespace osu.Game.Localisation
{
    public class ResourceManagerLocalisationStore : ILocalisationStore
    {
        private readonly Dictionary<string, ResourceManager> resourceManagers = new Dictionary<string, ResourceManager>();

        public ResourceManagerLocalisationStore(string cultureCode)
        {
            EffectiveCulture = new CultureInfo(cultureCode);
        }

        public void Dispose()
        {
        }

        public string Get(string lookup)
        {
            var split = lookup.Split(':');

            string ns = split[0];
            string key = split[1];

            if (!resourceManagers.TryGetValue(ns, out var manager))
                resourceManagers[ns] = manager = new ResourceManager(ns, GetType().Assembly);

            try
            {
                return manager.GetString(key, EffectiveCulture);
            }
            catch (MissingManifestResourceException)
            {
                // in the case the manifest is missing, it is likely that the user is adding code-first implementations of new localisation namespaces.
                // it's fine to ignore this as localisation will fallback to default values.
                return null;
            }
        }

        public Task<string> GetAsync(string lookup)
        {
            return Task.FromResult(Get(lookup));
        }

        public Stream GetStream(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAvailableResources()
        {
            throw new NotImplementedException();
        }

        public CultureInfo EffectiveCulture { get; }
    }
}
