using System.Collections;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.Steam
{
    public static class SteamUtilitys
    {
        public static IEnumerator FetchSteamInfo(Image avatarImage, CSteamID steamId)
        {
            uint width;
            uint height;
            var rect = new Rect(0, 0, 184, 184);
            var pivot = new Vector2(0.5f, 0.5f);
            var avatarInt = SteamFriends.GetLargeFriendAvatar(steamId);

            while (avatarInt == -1)
                yield return null;

            if (avatarInt <= 0)
                yield break;

            SteamUtils.GetImageSize(avatarInt, out width, out height);
            var avatarStream = new byte[4 * (int)width * (int)height];
            SteamUtils.GetImageRGBA(avatarInt, avatarStream, 4 * (int)width * (int)height);
            var avatar = new Texture2D((int)width, (int)height, TextureFormat.RGBA32, false);
            avatar.LoadRawTextureData(avatarStream);
            avatar.Apply();


            avatarImage.sprite = Sprite.Create(avatar, rect, pivot);
        }
    }
}
