using System.Collections.ObjectModel;
using System.Reflection;
using Newtonsoft.Json;
using RPS.Core.Models;

namespace RPS.UI.BL;

public class PtInMemoryContext
{
    string resourceNameItems = "RPS.BL.GenData.fs-items.json";
    string resourceNameUsers = "RPS.BL.GenData.fs-users.json";

    ObservableCollection<PtItem> items;
    List<PtUser> users;

    public ObservableCollection<PtItem> PtItems { get { return items; } }
    public List<PtUser> PtUsers { get { return users; } }

    public PtInMemoryContext()
    {
        var assembly = Assembly.GetExecutingAssembly();

        /*
        string contentsItems = "[]";

        using (Stream stream = assembly.GetManifestResourceStream(resourceNameItems))
        using (StreamReader file = new StreamReader(stream))
        {
            contentsItems = file.ReadToEnd();
        }
        */

        var contentsItems = LoadMauiAsset("fs-items.json");

        var itemList = JsonConvert.DeserializeObject<List<PtItem>>(contentsItems);
        ModifyItemDates(itemList);
        items = new ObservableCollection<PtItem>(itemList);

        /*
        string contentsUsers = "[]";

        using (Stream stream = assembly.GetManifestResourceStream(resourceNameUsers))
        using (StreamReader file = new StreamReader(stream))
        {
            contentsUsers = file.ReadToEnd();
        }
        */
        var contentsUsers = LoadMauiAsset("fs-users.json");

        users = JsonConvert.DeserializeObject<List<PtUser>>(contentsUsers);
    }

    private string LoadMauiAsset(string fileName)
    {
        try
        {
            using var stream = FileSystem.OpenAppPackageFileAsync(fileName);
            using var reader = new StreamReader(stream.Result);

            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "[]";
        }
    }

    private void ModifyItemDates(List<PtItem> items)
    {
        var startDate = DateTime.Now.AddYears(-1);
        var endDate = DateTime.Now.AddDays(-1);
        var randomTest = new Random();

        TimeSpan timeSpan = endDate - startDate;


        items.ForEach(i => 
        {
            TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = startDate + newSpan;

            i.DateCreated = newDate;
            i.DateModified = newDate;
        });
    }
}