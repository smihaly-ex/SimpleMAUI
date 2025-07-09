namespace SimpleMAUI.Maui.Extension
{
    public class TranslateExtension : IMarkupExtension
    {
        public string Key { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Source = Translator.Instance,
                Path = $"[{Key}]"
            };
            return binding;
        }
    }
}
