using System.Collections;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.Steam
{
    public static class SteamUtilities
    {
        public static IEnumerator FetchSteamInfo(this Image image, CSteamID cSteamId)
        {
            uint width;
            uint height;
            var rect = new Rect(0, 0, 184, 184);
            var pivot = new Vector2(0.5f, 0.5f);
            var avatarInt = SteamFriends.GetLargeFriendAvatar(cSteamId);

            while (avatarInt == -1)
                yield return null;

            if (avatarInt <= 0)
                yield break;

            SteamUtils.GetImageSize(avatarInt, out width, out height);
            var avatarStream = new byte[4 * (int)width * (int)height];
            SteamUtils.GetImageRGBA(avatarInt, avatarStream, 4 * (int)width * (int)height);
            var texture2D = new Texture2D((int)width, (int)height, TextureFormat.RGBA32, false);
            texture2D.LoadRawTextureData(avatarStream);
            texture2D.Apply();

            image.sprite = Sprite.Create(texture2D, rect, pivot);
        }
    }
}