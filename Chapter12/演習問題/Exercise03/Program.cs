using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var employees = Deserialize("employees.json");
            ToXmlFile(employees);
        }

        static Employee[] Deserialize(string filePath) {

            var text = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var emp = JsonSerializer.Deserialize<Employee[]>(text, options);
            return emp ?? [];

        }

        static void ToXmlFile(Employee[] employees) {
            using (var writer = XmlWriter.Create("employees.xml")) {
                XmlRootAttribute xRoot = new XmlRootAttribute {
                    ElementName = "Employees"
                };
                var serializer = new XmlSerializer(employees.GetType(),xRoot);
                //var serializer = new XmlSerializer(typeof(Employee),xRoot);
                serializer.Serialize(writer, employees);
            }

        }
}

    public record Employee {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }
    }
}
