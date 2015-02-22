using System;
using System.Collections.Generic;

namespace Fearfry {
    public delegate void Interact();
    public abstract class InSceneObject {
        public event Interact InteractEvent;
        public abstract void Update();
        public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch);
    }
}
