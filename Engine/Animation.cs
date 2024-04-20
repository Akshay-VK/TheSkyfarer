using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine;

public class AnimationFrame{
    public Rectangle rectangle;
    public double duration;
    public AnimationFrame(Rectangle rect, double dur){
        rectangle=rect;
        duration=dur;
    }
}

public class Animation{
    readonly Texture2D image;
    readonly AnimationFrame[] frames;

    public double totalDuration=0;
    private double currentTimer;
    private int currentFrameIndex=0;
    public bool active=false;
    public Animation(ref Texture2D image, AnimationFrame[] frames){
        this.image=image;
        this.frames=frames;
        foreach(AnimationFrame frame in this.frames){
            totalDuration+=frame.duration;
        }
        currentTimer=this.frames[0].duration;
    }
    public void Update(GameTime gameTime){
        if(active){
            currentTimer-=gameTime.ElapsedGameTime.TotalSeconds;
            if(currentTimer<=0){
                currentFrameIndex=(currentFrameIndex+1)%frames.Length;
                currentTimer=frames[currentFrameIndex].duration;

            }
        }
    }
    public void Draw(GameTime gameTime, SpriteBatch _spriteBatch, Vector2 position){
        _spriteBatch.Draw(image,position,frames[currentFrameIndex].rectangle,Color.White);
    }
}