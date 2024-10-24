namespace JohnBPearson.KeyBindingButler.Model
{
    public interface IKeyInfo
    {
        char Key
        {
            get;
            set;
        }

        string ToString();
    }
}