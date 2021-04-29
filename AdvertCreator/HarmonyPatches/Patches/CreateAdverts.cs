using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
namespace AdvertCreator.HarmonyPatches.Patches
{
    [HarmonyPatch(typeof(MenuInstaller))]
    [HarmonyPatch("InstallBindings", 0)]

    internal class AdvertPatch
    {
        private static void Postfix()
        {
            GameObject musicPack = null;
            foreach(GameObject tempGameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (tempGameObject.name.Contains("MusicPackPromoBanner"))
                {
                    musicPack = tempGameObject;
                }
            }
            if (musicPack)
            {
                for(int i = 0; i < 28; i++)
                {
                    GameObject newMusic = UnityEngine.Object.Instantiate(musicPack);
                    newMusic.transform.SetParent(musicPack.transform.parent);
                    newMusic.transform.localPosition = musicPack.transform.localPosition + new Vector3(0, 0.1f * (i+1), 5f);
                    newMusic.transform.localScale = musicPack.transform.localScale;
                }

                for (int j = 0; j < 40; j++)
                {
                    for (int i = 0; i < 36; i++)
                    {
                        GameObject newMusic = UnityEngine.Object.Instantiate(musicPack);
                        newMusic.transform.SetParent(musicPack.transform.parent);
                        newMusic.transform.localPosition = musicPack.transform.localPosition + new Vector3((j+1)*8f + (21f * (i + 1)), 100f + 50*j, 5f);
                        newMusic.transform.localScale = musicPack.transform.localScale;
                        newMusic.transform.SetParent(musicPack.transform.parent.parent);
                    }
                }
                for (int i = 0; i < 36; i++)
                {
                    GameObject newMusic = UnityEngine.Object.Instantiate(musicPack);
                    newMusic.transform.SetParent(musicPack.transform.parent);
                    newMusic.transform.localPosition = musicPack.transform.localPosition + new Vector3(8f + (21f * (i + 1)), 0f, 5f);
                    newMusic.transform.localScale = musicPack.transform.localScale;
                    newMusic.transform.SetParent(musicPack.transform.parent.parent);
                }
            }
        }
    }
}
