﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Configuration;
using osu.Game.Rulesets.Mania.Objects.Types;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Mania.Objects
{
    public abstract class ManiaHitObject : HitObject, IHasColumn
    {
        public readonly Bindable<int> ColumnBindable = new Bindable<int>();

        public virtual int Column
        {
            get => ColumnBindable;
            set => ColumnBindable.Value = value;
        }

        protected override HitWindows CreateHitWindows() => new ManiaHitWindows();
    }
}
