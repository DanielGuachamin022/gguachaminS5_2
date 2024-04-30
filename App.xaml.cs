namespace gguachaminS5_2
{
    public partial class App : Application
    {
        public static PersonaRepository personaRepo { get; set; }
        public App(PersonaRepository personaRepository)
        {
            InitializeComponent();

            MainPage = new Vistas.AgregarPersona();
            personaRepo = personaRepository;
        }
    }
}
