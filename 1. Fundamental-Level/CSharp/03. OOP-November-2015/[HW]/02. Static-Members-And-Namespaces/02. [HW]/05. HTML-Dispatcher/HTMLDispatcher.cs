using System;

public static class HTMLDispatcher
{
    public static string CreateImage(string imageSource, string alt, string title)
    {
        ElementBuilder elementBuilder = new ElementBuilder("img");

        elementBuilder.AddAttribute("src", imageSource);
        elementBuilder.AddAttribute("alt", alt);
        elementBuilder.AddAttribute("title", title);

        return elementBuilder.ToString();
    }

    public static string CreateURL(string URL, string title, string text)
    {
        ElementBuilder elementBuilder = new ElementBuilder("a");

        elementBuilder.AddAttribute("URL", URL);
        elementBuilder.AddAttribute("title", title);
        elementBuilder.AddContent(text);

        return elementBuilder.ToString();
    }

    public static string CreateInput(string inputType, string name, string value)
    {
        ElementBuilder elementBuilder = new ElementBuilder("input");

        elementBuilder.AddAttribute("type", inputType);
        elementBuilder.AddAttribute("name", name);
        elementBuilder.AddAttribute("value", value);

        return elementBuilder.ToString();
    }
}