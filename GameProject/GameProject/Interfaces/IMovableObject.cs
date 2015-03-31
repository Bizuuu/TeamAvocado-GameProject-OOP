
namespace GameProject.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IMovableObject
    {
         Texture2D Texture { get; }
         Vector2 Position { get; }
         int Speed{get;}
    }
}
