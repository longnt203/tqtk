﻿using System;

namespace k8asd {
    public interface ICooldownModel {
        int ImposeCooldown { get; }
        int GuideCooldown { get; }
        int UpgradeCooldown { get; }
        int AppointCooldown { get; }
        int TechCooldown { get; }
        int WeaveCooldown { get; }
        int DrillCooldown { get; }

        event EventHandler<int> ImposeCooldownChanged;
        event EventHandler<int> GuideCooldownChanged;
        event EventHandler<int> UpgradeCooldownChanged;
        event EventHandler<int> AppointCooldownChanged;
        event EventHandler<int> TechCooldownChanged;
        event EventHandler<int> WeaveCooldownChanged;
        event EventHandler<int> DrillCooldownChanged;
    }
}
