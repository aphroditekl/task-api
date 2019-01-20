namespace taskAPI.Model
{
    //Create the attributes of a task i.e. item 
    public class Item
    {  
    //identifier for a specific task
       public string Id {get; set;}
    //name of the task
       public string Title {get; set;}
    //description of the task
       public string Desc {get; set;}
    //state of the task
       public int State {get; set;}
    }
}