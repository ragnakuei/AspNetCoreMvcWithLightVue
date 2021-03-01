namespace AspNetCoreMvcWithLightVue.Infra
{
    public class SelectOptionItem<T>
    {
        public string Text { get; set; }

        public T Value { get; set; }
    }
}
