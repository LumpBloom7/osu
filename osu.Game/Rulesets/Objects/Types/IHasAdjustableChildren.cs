// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using System.Collections.Generic;

namespace osu.Game.Rulesets.Objects.Types
{
    /// <summary>
    /// A special type of HitObject, that contains child HitObjects that can be individually modified via the editor
    /// </summary>
    public interface IHasAdjustibleChildren
    {
        /// <summary>
        /// Children HitObjects that can be adjusted as if they are a separate hitobject
        /// </summary>
        IList<HitObject> AdjustibleHitObjects { get; }
    }
}
