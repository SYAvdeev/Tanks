using Common.Collections;

namespace Features
{
    public class ViewLogicCollection : TypedCollection<IViewLogic>
    {
        public ViewLogicCollection(int count) : base(count)
        {
        }
    }
}