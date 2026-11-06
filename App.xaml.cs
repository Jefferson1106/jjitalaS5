using jjitalaS5.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace jjitalaS5
{
    public partial class App : Application
    {
        public static PersonRepository _personRepo { get; set; }
        public App(PersonRepository repo)
        {
            InitializeComponent();
            _personRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}