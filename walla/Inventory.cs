using System;
using Raylib_cs;
/*
Här har jag allt för hur inventoryt ska fungera, jag tror jag skulle kunna använda en dictionary för allt
men två blev lättare
*/
public class Inventory
{
    public Dictionary<string, items> itemsInInventory = new Dictionary<string, items>();
    public Dictionary<int, string> InventorySlots = new Dictionary<int, string>();
    int inventoryLength = 6;
    public Inventory()
    {
        for (var i = 0; i < inventoryLength; i++)
        {
        
        InventorySlots.Add(i, "Empty");

        }
    }
    /*
    här kollar jag ifall itemet finns i dictionary ifall den finns så kollar den ifall den är stackable och lägger till ifall möjligt
    ifall den inte är med så läggs den till i dictionariet
    */
    public void addToInvetory(string item, items ItemData, int Amount){
        if (itemsInInventory.ContainsKey(item))
        {
            if (ItemData.Stackable == true)
            {
                ItemData.Stacks += Amount;
            }
        }
        else
        {

            int UsableSlot = findFirstEmptySlot();  
            InventorySlots.Remove(UsableSlot);
            InventorySlots.Add(UsableSlot, ItemData.Name);
            itemsInInventory.Add(ItemData.Name, ItemData);

        }
    }
    /*
    fungerar inte just nu
    */
    public void RemoveFromInventory(int slot)
    {
        InventorySlots[slot] = "Empty";
    }
    /*
    här har jag en for loop som kollar i inventoriet för att hitta den första slot i inventoriet som är tomt,
    fungerar genom att jag kollar ifall I I är tomt eller inte, ifall den är tom så returnar den och funktionen slutar
    */
    public int findFirstEmptySlot()
    {
        for (var i = 0; i < inventoryLength; i++)
        {
            if (InventorySlots[i] == "Empty")
            {
                return i;
            }
            continue;
        }
        return -1;
    }
    
}
