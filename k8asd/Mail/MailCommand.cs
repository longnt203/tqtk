﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace k8asd
{
    public static class MailCommand{
        /// <summary>
        /// Nhận liên thắng.
        /// </summary>
        /// <param name="year">năm nhận liên thắng.</param>
        /// <param name="lt">số liên thắng.</param>
        public static async Task<Packet> GetMailLTAsync(this IPacketWriter writer, int year, int lt){
            return await writer.SendCommandAsync(60603, "12", "0", year.ToString() + lt.ToString("000"), lt.ToString());
        }
        /// <summary>
        /// Nhận liên thắng.
        /// </summary>
        /// <param name="year">năm nhận liên thắng.</param>
        /// <param name="lt">số liên thắng.</param>
        public static async Task<Packet> GetMailTTCAsync(this IPacketWriter writer, int year, int boss){
            var packet = await writer.SendCommandAsync(60601, boss.ToString(), year.ToString());
            if (packet == null)
            {
                return null;
            }
            string str = "";
            JToken token = JToken.Parse(packet.Message);
            if (token.ToString() != "\"\"" && token.ToString() != "")
            {
                Console.WriteLine(token.ToString());
                JArray array = (JArray)token["goodsDtoList"];
                
                for (int i = 0; i < array.Count; i++)
                {
                    JObject obj = (JObject)array[i];
                    str += obj["id"].ToString().Replace("\"", "") + ",";
                }
            }
            return await writer.SendCommandAsync(60603, boss.ToString(), str, year.ToString(), "0");
        }

        /// <summary>
        /// Làm mới kỹ năng.
        /// </summary>
        /// <param name="year">năm nhận liên thắng.</param>
        /// <param name="lt">số liên thắng.</param>
        public static async Task<Packet> GetNewSkillAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync(66010, "1");
        }
    }
}
