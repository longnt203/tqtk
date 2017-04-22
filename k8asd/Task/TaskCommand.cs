﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public static class TaskCommand {
        /// <summary>
        /// Lấy danh sách nhiệm vụ.
        /// </summary>
        public static async Task<TaskBoard> RefreshListQuestAsync(this IPacketWriter writer) {
            var packet = await writer.SendCommandAsync("44301");
            if (packet == null) {
                return null;
            }
            return TaskBoard.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Lấy số sao của nhiệm vụ.
        /// </summary>
        /// <param name="idQuest">ID nhiêm vụ.</param>
        public static async Task<TaskDetail> GetStartOfQuestAsync(this IPacketWriter writer, int idQuest) {
            var packet = await writer.SendCommandAsync("44201", idQuest.ToString());
            if (packet == null) {
                return null;
            }
            return TaskDetail.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Nhận nhiệm vụ.
        /// </summary>
        /// <param name="idQuest">ID nhiêm vụ.</param>
        public static async Task<Packet> AcceptQuestAsync(this IPacketWriter writer, int idQuest) {
            return await writer.SendCommandAsync("44101", idQuest.ToString());
        }

        /// <summary>
        /// Hoàn thành nhiệm vụ.
        /// </summary>
        /// <param name="idQuest">ID nhiêm vụ.</param>
        public static async Task<Packet> CompleteQuestAsync(this IPacketWriter writer, int idQuest) {
            return await writer.SendCommandAsync("44103", idQuest.ToString());
        }

        /// <summary>
        /// Hủy nhiệm vụ.
        /// </summary>
        /// <param name="idQuest">ID nhiêm vụ.</param>
        public static async Task<Packet> CancelQuestAsync(this IPacketWriter writer, int idQuest) {
            return await writer.SendCommandAsync("44102", idQuest.ToString());
        }

        /// <summary>
        /// Bán lúa.
        /// </summary>
        public static async Task<Packet> SalePaddyAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("13101", "1", "1");
        }

        /// <summary>
        /// Mua lúa.
        /// </summary>s
        public static async Task<Packet> BuyPaddyAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("13101", "0", "1");
        }

        /// <summary>
        /// Mua lúa chợ đen.
        /// </summary>s
        public static async Task<Packet> BuyPaddyInMaketAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("13101", "2", "1");
        }

        /// <summary>
        /// Thu thuế.
        /// </summary>s
        public static async Task<Packet> CollectTaxAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("12401", "0", "0");
        }

        /// <summary>
        /// Tăng cường Thu thuế.
        /// </summary>s
        public static async Task<Packet> IncreaseTaxAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("12401", "1", "1");
        }

        /// <summary>
        /// Lấy danh sách tướng quân để chọn ID tướng quân cải tiến.
        /// </summary>s
        public static async Task<Packet> GetListHeroAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("41100", "0");
        }

        /// <summary>
        /// Cải tiến.
        /// </summary>s
        public static async Task<Packet> HeroImproveAsync(this IPacketWriter writer, int idHero) {
            return await writer.SendCommandAsync("41301", idHero.ToString(), "0");
        }

        /// <summary>
        /// Giữ gải tiến.
        /// </summary>s
        public static async Task<Packet> NotUpdateHeroImproveAsync(this IPacketWriter writer, int idHero) {
            return await writer.SendCommandAsync("41303", idHero.ToString(), "0");
        }

        /// <summary>
        /// Lấy danh sách vũ khí trắng.
        /// </summary>s
        public static async Task<Packet> GetListWeaponsAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("39301", "1", "0", "10");
        }

        /// <summary>
        /// Hạ cấp vũ khí.
        /// </summary>s
        public static async Task<Packet> DownGradeWeaponsAsync(this IPacketWriter writer, string idWeapon)
        {
            return await writer.SendCommandAsync("39402", idWeapon);
        }

        /// <summary>
        /// Nâng cấp vũ khí.
        /// </summary>s
        public static async Task<Packet> UpGradeWeaponsAsync(this IPacketWriter writer, string idWeapon, string magic)
        {
            return await writer.SendCommandAsync("39302", idWeapon, "0", magic);
        }

        /// <summary>
        /// Chinh chiến Ngụy Tục - Lữ Bố.
        /// </summary>s
        public static async Task<Packet> BattleNguyTucAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("33101", "2214", "0");
        }

        /// <summary>
        /// Ủy phái ngựa 1.
        /// </summary>s
        public static async Task<Packet> CommissionAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("40102", "1", "0");
        }

        /// <summary>
        /// Nhận vật phẩm ủy phái.
        /// </summary>s
        public static async Task<Packet> AcceptCommissionAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("40103");
        }

        /// <summary>
        /// phá băng ủy phái.
        /// </summary>s
        public static async Task<Packet> BreakIceCommissionAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("11301", "8", "0");
        }
    }
}