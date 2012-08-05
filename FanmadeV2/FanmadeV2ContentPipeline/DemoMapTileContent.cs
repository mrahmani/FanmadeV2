using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace FanmadeV2ContentPipeline
{
    [ContentSerializerRuntimeType("FanmadeV2.Tile, FanmadeV2")]
    public class DemoMapTileContent
    {
        public ExternalReference<Texture2DContent> Texture;
        public Rectangle SourceRectangle;
        public SpriteEffects SpriteEffects;
    }
}