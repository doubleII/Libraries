namespace DockingLibrary
{
    public class DocumentContent : ManagedContent
    {
        public DocumentContent(DockManager manager) : base(manager)
        {
        }

        public DocumentContent() { }

        public override void Show()
        {
            DockManager.AddDocument(this);
        }
    }
}
