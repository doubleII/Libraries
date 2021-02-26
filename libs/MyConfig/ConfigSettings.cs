using System.Configuration;
using System.Linq;

namespace SchedEventConfig
{
    public class MyConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public MyConfigInstanceCollection Instances
        {
            get => (MyConfigInstanceCollection)this[""];
            set { this[""] = value; }
        }
    }
    public class MyConfigInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            => new MyConfigInstanceElement();

        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((MyConfigInstanceElement)element).Key;
        }

        public new MyConfigInstanceElement this[string elementName]
            => this.OfType<MyConfigInstanceElement>().FirstOrDefault(item => item.Key == elementName);
    }

    public class MyConfigInstanceElement : ConfigurationElement
    {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get => (string)base["key"];
            set => base["key"] = value;
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get => (string)base["value"];
            set => base["value"] = value;
        }
    }
}
