using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class DynamicAppConfig : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new DynamicStringProperty(getString(binder.Name));
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            setString(binder.Name, value.ToString());
            return true;
        }
        private string getString(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
        private void setString(string key, string val)
        {
            var path = System.Reflection.Assembly.GetEntryAssembly().Location;
            var config = ConfigurationManager.OpenExeConfiguration(path);

            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, val);

            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
