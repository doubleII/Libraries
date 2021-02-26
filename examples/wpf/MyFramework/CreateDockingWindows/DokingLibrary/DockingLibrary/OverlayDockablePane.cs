using System.Windows.Controls;
using System.Windows.Media;

namespace DockingLibrary
{
    class OverlayDockablePane : DockablePane
    {
        public readonly DockablePane ReferencedPane;
        public readonly DockableContent ReferencedContent;

        public OverlayDockablePane(DockManager dockManager, DockableContent content, Dock initialDock) : base(dockManager, initialDock)
        {
            btnAutoHide.LayoutTransform = new RotateTransform(90);
            ReferencedPane = content.ContainerPane as DockablePane;
            ReferencedContent = content;
            Add(ReferencedContent);
            Show(ReferencedContent);
            ReferencedContent.SetContainerPane(ReferencedPane);

            _state = PaneState.AutoHide;
        }

        public override void Show()
        {
            ChangeState(PaneState.Docked);
        }

        public override void Close()
        {
            ChangeState(PaneState.Hidden);
        }

        public override void Close(DockableContent content)
        {
            ChangeState(PaneState.Hidden);
        }
     }
}
