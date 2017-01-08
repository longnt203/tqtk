﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class CooldownModel : ICooldownModel, IPacketReader {
        private int imposeCooldown;
        private int guideCooldown;
        private int upgradeCooldown;
        private int appointCooldown;
        private int techCooldown;
        private int weaveCooldown;

        public event EventHandler<int> ImposeCooldownChanged;
        public event EventHandler<int> GuideCooldownChanged;
        public event EventHandler<int> UpgradeCooldownChanged;
        public event EventHandler<int> AppointCooldownChanged;
        public event EventHandler<int> TechCooldownChanged;
        public event EventHandler<int> WeaveCooldownChanged;

        public int ImposeCooldown {
            get { return imposeCooldown; }
            set {
                imposeCooldown = value;
                ImposeCooldownChanged(this, value);
            }
        }

        public int GuideCooldown {
            get { return guideCooldown; }
            set {
                guideCooldown = value;
                GuideCooldownChanged(this, value);
            }
        }

        public int UpgradeCooldown {
            get { return upgradeCooldown; }
            set {
                upgradeCooldown = value;
                UpgradeCooldownChanged(this, value);
            }
        }

        public int AppointCooldown {
            get { return appointCooldown; }
            set {
                appointCooldown = value;
                AppointCooldownChanged(this, value);
            }
        }

        public int TechCooldown {
            get { return techCooldown; }
            set {
                techCooldown = value;
                TechCooldownChanged(this, value);
            }
        }

        public int WeaveCooldown {
            get { return weaveCooldown; }
            set {
                weaveCooldown = value;
                WeaveCooldownChanged(this, value);
            }
        }

        public void OnPacketReceived(Packet packet) {
            // FIXME.
        }
    }
}
