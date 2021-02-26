using System.Xml;

namespace DockingLibrary
{
    public delegate DockableContent GetContentFromTypeString(string type);

    interface ILayoutSerializable
    {
        void Serialize(XmlDocument doc, XmlNode parentNode);

        void Deserialize(DockManager managerToAttach, XmlNode node, GetContentFromTypeString getObjectHandler);
    }
}
