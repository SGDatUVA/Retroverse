﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Retroverse
{
    static class TextureManager
    {
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public static ContentManager content = null;

        public static Texture2D Get(string key)
        {
            if (!textures.ContainsKey(key))
                throw new Exception("tried to get a texture that didn't exist!");
            return textures[key];
        }

        public static void Add(string key)
        {
            try
            {
                textures.Add(key, content.Load<Texture2D>("Sprites/" + key));
            }
            catch (ArgumentException e) { }
        }

        public static void Add(string key, int frames)
        {
            try
            {
                for (int i = 0; i < frames; i++)
                    textures.Add(key + (i + 1), content.Load<Texture2D>("Sprites/" + key + (i + 1)));
            }
            catch (ArgumentException e) { }
        }

        public static void LoadSprites(ContentManager content)
        {
            TextureManager.content = content;
            FileInfo[] filePaths = new DirectoryInfo(content.RootDirectory + "\\Sprites").GetFiles("*.*");
            foreach (FileInfo file in filePaths)
            {
                string key = file.Name.Split('.')[0];
                textures.Add(key, content.Load<Texture2D>("Sprites\\" + file.Name.Split('.')[0]));
            }
        }
    }
}
