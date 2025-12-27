using BreakpointConflictTracker.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static BreakpointConflictTracker.Models.Item;

namespace BreakpointConflictTracker
{
    public class XMLHelper
    {
        public string _itemsXmlPath { get; set; }
        public XmlDocument _itemsXmlCache { get; private set; } = new XmlDocument();
        public List<Item> _itemsCache { get; private set; } = new List<Item>();

        public XMLHelper(string xmlFilePath) 
        {
            _itemsXmlPath = xmlFilePath;
        }

        public bool LoadItems()
        {

            if (!File.Exists(_itemsXmlPath))
            {
                if (!CreateNewItemsXmlFile())
                    throw new Exception("Failed to create new configuration file.");
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_itemsXmlPath);
                _itemsXmlCache = xmlDoc;

                XmlNodeList? itemNodes = xmlDoc.SelectNodes("/Items/Item");

                if (itemNodes == null)
                {
                    throw new Exception("No Item nodes found in the XML.");
                }

                foreach (XmlNode userNode in itemNodes)
                {
                    string? type = userNode.Attributes?["name"]?.Value;
                    string? name = userNode.Attributes?["name"]?.Value;

                    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name))
                    {
                        throw new Exception("Item node is missing required attributes.");
                    }

                    Item newItem = new Item(Enum.Parse<ItemType>("Weapon"), name);
                    _itemsCache.Add(newItem);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Items: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CreateNewItemsXmlFile()
        {
            try
            {
                string? dir = Path.GetDirectoryName(_itemsXmlPath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);

                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = "BreakpointConflictTracker.Resources.items.xml";

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    throw new Exception("Failed to load embedded resource for default configuration.");
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);
                xmlDoc.Save(_itemsXmlPath);

                _itemsXmlCache = xmlDoc;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Items file: {ex.Message}", "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
