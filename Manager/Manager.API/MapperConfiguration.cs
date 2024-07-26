
internal class MapperConfiguration
{
    private Action<object> value;

    public MapperConfiguration(Action<object> value)
    {
        this.value = value;
    }
}