using System;
using Microsoft.Xna.Framework.Graphics;

namespace InputAndAnimationGame;
    
/// <summary>
/// Represents a cel animated texture.
/// In other words, represents a spritesheet
/// </summary>
public class CelAnimationSequenceMultiRow
{
    // The texture containing the animation sequence...
    protected Texture2D texture;

    // The length of time a cel is displayed...
    protected float celTime;

    // Sequence metrics
    protected int celWidth;
    protected int celHeight;

    // Calculated count of cels in the sequence
    protected int celColumnCount;
    protected int celRowCount;

    /// <summary>
    /// Constructs a new CelAnimationSequence.
    /// </summary>        
    public CelAnimationSequenceMultiRow(Texture2D texture, int celWidth, int celHeight, float celTime)
    {
        this.texture = texture;
        this.celWidth = celWidth;
        this.celHeight = celHeight;
        this.celTime = celTime;
        celColumnCount = Texture.Width / celWidth;
        celRowCount = Texture.Height / celHeight;
    }

    /// <summary>
    /// All frames in the animation arranged horizontally.
    /// </summary>
    public Texture2D Texture
    {
        get { return texture; }
    }

    /// <summary>
    /// Duration of time to show each cel.
    /// </summary>
    public float CelTime
    {
        get { return celTime; }
    }

    /// <summary>
    /// Gets the number of cel columns in the animation.
    /// </summary>
    public int CelColumnCount
    {
        get { return celColumnCount; }
    }

    /// <summary>
    /// Gets the number of cel rows in the animation.
    /// </summary>
    public int CelRowCount
    {
        get { return celRowCount; }
    }
    

    /// <summary>
    /// Gets the width of a frame in the animation.
    /// </summary>
    public int CelWidth
    {
        get { return celWidth; }
    }

    /// <summary>
    /// Gets the height of a frame in the animation.
    /// </summary>
    public int CelHeight
    {
        get { return celHeight; }
    }
}
