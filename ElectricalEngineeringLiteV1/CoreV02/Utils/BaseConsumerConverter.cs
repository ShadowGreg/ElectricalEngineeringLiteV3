using System.Collections.Generic;
using System.Reflection;
using CoreV01.Feeder;

namespace CoreV01.Properties.Utils {
    public class BaseConsumerConverter {
        public Dictionary<string, object> ConvertToDictionary(BaseConsumer consumer) {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            PropertyInfo[] properties = typeof(BaseConsumer).GetProperties();
            foreach (var property in properties) dictionary[property.Name] = property.GetValue(consumer);

            return dictionary;
        }

        public BaseConsumer CreateFromDictionary(Dictionary<string, object> dictionary) {
            var consumer = new BaseConsumer();
            PropertyInfo[] properties = typeof(BaseConsumer).GetProperties();
            foreach (var property in properties)
                if (dictionary.ContainsKey(property.Name))
                    property.SetValue(consumer, dictionary[property.Name]);

            return consumer;
        }
    }
}