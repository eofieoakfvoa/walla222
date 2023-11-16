using System;
using Raylib_cs;

public class TextureManager
{
    /*
    en dictionary fungerar igenom att du skriver <Key, Value> som 2 typer av objects I de här fallet string, Texture2D
    detta gör så du kan lägga till som i en lista en string fast den har ett värde, som i de här fallet är en Texture2D
    I det här fallet så kollar den ifall det finns en sak I listan som heter texture filen 
    ifall den finns så ger den tillbaka texturen, annars så lägger den till den i dictionariet
    Detta är bra eftersom jag slipper göra massa Raylib.LoadTexture() som tar mycket performance, och nu bara behöver göra en gång
    Dictionaries är också i O(1) tillskillnad från listor som är i O(N), där O(N) betyder att den kollar baserat på storleken på listan tillskillad från 0(1) som fungerar som en Hashmap
    */
    Dictionary<string, Texture2D> TexturesList = new Dictionary<string,Texture2D>();
    public Texture2D LoadTexture(string fileName)
    {

        if (TexturesList.ContainsKey(fileName))
        {
            return TexturesList[fileName];
        }
        else
        {
            Texture2D texture = Raylib.LoadTexture(fileName);
            TexturesList[fileName] = texture;
            return texture;
        }
    }
}
