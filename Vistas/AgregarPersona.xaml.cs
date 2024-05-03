using gguachaminS5_2.Modelos;

namespace gguachaminS5_2.Vistas;

public partial class AgregarPersona : ContentPage
{
    int idGlobal = 0;
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

    private void listPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string nombreseleccionado = (e.CurrentSelection.FirstOrDefault() as Persona)?.Name;
        int idseleccionado = (int)((e.CurrentSelection.FirstOrDefault() as Persona)?.Id);
        idGlobal = idseleccionado;
        txtNombreActualizado.Text = nombreseleccionado;
        txtNombreEliminar.Text = nombreseleccionado;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if(idGlobal != 0)
        {
            lblStatusMessage.Text = "";

            App.personaRepo.UpdatePersona(idGlobal, txtNombreActualizado.Text);
            lblStatusMessage.Text = App.personaRepo.StatusMessage;
            txtNombreActualizado.Text = "";
            txtNombreEliminar.Text = "";
            idGlobal = 0;
            DisplayAlert("Alerta", "Registro actualizado correctamente!", "Cerrar");
        }
        else
        {
            DisplayAlert("Alerta Validación", "Debe seleccionar un nombre!", "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (idGlobal != 0)
        {
            lblStatusMessage.Text = "";

            App.personaRepo.DeletePersona(idGlobal);
            lblStatusMessage.Text = App.personaRepo.StatusMessage;
            txtNombreActualizado.Text = "";
            txtNombreEliminar.Text = "";
            idGlobal = 0;
            DisplayAlert("Alerta", "Registro eliminado correctamente!", "Cerrar");
        }
        else
        {
            DisplayAlert("Alerta Validación", "Debe seleccionar un nombre!", "Cerrar");
        }
    }
}