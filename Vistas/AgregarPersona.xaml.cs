using gguachaminS5_2.Modelos;

namespace gguachaminS5_2.Vistas;

public partial class AgregarPersona : ContentPage
{
	public AgregarPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        App.personaRepo.AddNewPersona(txtNombre.Text);
        lblStatusMessage.Text = App.personaRepo.StatusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        List<Persona> personas = App.personaRepo.GetAllPeople();
        listPersonas.ItemsSource = personas;
    }
}