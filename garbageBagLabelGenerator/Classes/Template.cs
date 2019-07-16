using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace garbageBagLabelGenerator.Classes
{
    class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Page Page { get; set; }
        public Label Label { get; set; }
        public List<Content> ContentList { get; set; }

        string Path = "templates//label1.xml";

        public bool importFromXML()
        {
            try
            {
                XDocument doc = XDocument.Load(Path);
                XElement elemTemplate = doc.Element("Template");
                XElement elemPage = elemTemplate.Element("Page");
                XElement elemLabel = elemTemplate.Element("Label");
                XElement elemContent = elemTemplate.Element("Contents");

                Name = getName(elemTemplate);
                Page = getPage(elemPage);
                Label = getLabel(elemLabel);
                ContentList = getContentList(elemContent);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        string getName(XElement elemTemplate)
        {
            return elemTemplate.Attribute("Name").Value;
        }

        Page getPage(XElement elemPage)
        {
            Page page = new Page();
            Size pageSize = new Size();
            pageSize.Width = Int32.Parse(elemPage.Attribute("Width").Value);
            pageSize.Height = Int32.Parse(elemPage.Attribute("Height").Value);
            page.Size = pageSize;
            page.Columns = Int32.Parse(elemPage.Attribute("Columns").Value);
            page.Rows = Int32.Parse(elemPage.Attribute("Rows").Value);
            page.MarginTop = Int32.Parse(elemPage.Attribute("MarginTop").Value);
            page.MarginBottom = Int32.Parse(elemPage.Attribute("MarginBottom").Value);
            page.MarginLeft = Int32.Parse(elemPage.Attribute("MarginLeft").Value);
            page.MarginRight = Int32.Parse(elemPage.Attribute("MarginRight").Value);

            return page;
        }

        Label getLabel(XElement elemLabel)
        {
            Label label = new Label();
            Size labelSize = new Size();
            labelSize.Width = Int32.Parse(elemLabel.Attribute("Width").Value);
            labelSize.Height = Int32.Parse(elemLabel.Attribute("Height").Value);
            label.Size = labelSize;

            return label;
        }

        List<Content> getContentList(XElement elemContent)
        {
            List<Content> contentList = new List<Content>();

            foreach (XElement elem in elemContent.Elements("Content"))
            {
                Content content = new Content();
                content.Id = Int32.Parse(elem.Attribute("Id").Value);
                content.Text = elem.Attribute("Text").Value;
                content.Font = elem.Attribute("Font").Value;
                content.FontSize = Int32.Parse(elem.Attribute("FontSize").Value);
                content.MarginTop = Int32.Parse(elem.Attribute("MarginTop").Value);
                content.TextAlignment = elem.Attribute("TextAlignment").Value;
                content.Bold = bool.Parse(elem.Attribute("Bold").Value);
                content.Cursive = bool.Parse(elem.Attribute("Cursive").Value);
                content.Underline = bool.Parse(elem.Attribute("Underline").Value);

                contentList.Add(content);
            }

            return contentList;
        }
    }
}