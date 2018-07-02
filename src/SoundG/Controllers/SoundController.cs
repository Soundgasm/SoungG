using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using SoundG.Models;

namespace SoundG.Controllers {
    internal class SoundController {
        private readonly HtmlDocument doc;

        public SoundController(string url) {
            HtmlWeb web = new HtmlWeb();
            doc = web.Load(url);
        }

        public List<Sound> GetSounds() {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div");
            List<Sound> sounds = new List<Sound>(nodes.Count);

            for (int i = 0; i < nodes.Count; i++) {
                HtmlNode node = nodes[i];
                Sound sound = new Sound { Id = (uint) (i + 1) };
                try {
                    sound.Title = GetTitle(node);
                }
                catch (Exception) {
                    sound.Title = $"ERROR:{i}";
                }

                try {
                    sound.Url = GetUrl(node);
                }
                catch (Exception) {
                    sound.Url = new Uri($"ERROR:{i}");
                }

                try {
                    sound.Description = GetDescription(node);
                }
                catch (Exception) {
                    sound.Description = $"ERROR:{i}";
                }

                try {
                    sound.PlayCount = GetPlayCount(node);
                }
                catch (Exception) {
                    sound.PlayCount = 0;
                }

                sounds.Add(sound);
            }

            return sounds;
        }

        private static uint GetPlayCount(HtmlNode node) {
            return ParsePlayCount(node.FirstChild.NextSibling.NextSibling.InnerText);
        }

        private static string GetDescription(HtmlNode node) {
            return node.FirstChild.NextSibling.InnerText;
        }

        private static Uri GetUrl(HtmlNode node) {
            return new Uri(node.FirstChild.Attributes[0].Value);
        }

        private static string GetTitle(HtmlNode node) {
            return node.FirstChild.InnerText;
        }

        private static uint ParsePlayCount(string value) {
            //Play Count: 12345
            // [0]  [1]    [2]
            string s = value.Split(' ')[2];
            return uint.Parse(s);
        }
    }
}