using System;
using System.Text;
using System.Collections.Generic;

public class ElementBuilder
{
    private string elementName;
    private Dictionary<string, string> attributes; 

    public ElementBuilder(string elementName)
    {
        this.ElementName = elementName;

        this.attributes = new Dictionary<string, string>();
    }

    public string ElementName
    {
        get { return this.elementName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The element name cannot be empty.");
            }

            this.elementName = value;
        }
    }

    public string Content { get; set; }

    public void AddAttribute(string attribute, string value)
    {
        if (string.IsNullOrEmpty(attribute))
        {
            throw new ArgumentNullException("The attribute cannot be empty.");
        }

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("The value cannot be empty.");
        }

        this.attributes.Add(attribute, value);
    }

    public void AddContent(string content)
    {
        this.Content += content;
    }

    public static string operator *(ElementBuilder elementBuilder, int n)
    {
        StringBuilder multipliedOutput = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            multipliedOutput.Append(elementBuilder.ToString());
        }

        return multipliedOutput.ToString();
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        output.AppendFormat("<{0}", this.ElementName);
        foreach (var pair in this.attributes)
        {
            output.AppendFormat(" {0}={1}", pair.Key, pair.Value);
        }
        output.AppendFormat(">{0}<{1}/>", this.Content, this.ElementName);

        return output.ToString();
    }
}