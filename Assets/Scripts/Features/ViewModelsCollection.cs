using Common.Collections;

namespace Features
{
    public class ViewModelsCollection : TypedCollection<BaseViewModel>
    {
        public ViewModelsCollection(int count) : base(count)
        {
        }
    }
}