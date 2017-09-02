using Contents;

namespace Game.Talk
{
    interface ITalkService
    {
        Entity GetAvailableTalk(string tag);
        void RunTalk(Entity talk);
    }
}
