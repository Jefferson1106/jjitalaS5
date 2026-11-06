using jjitalaS5.Models;

namespace jjitalaS5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        App._personRepo.AddNewPerson(txtName.Text);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

    }

    private void btnVerPersonas_Clicked(object sender, EventArgs e)
    {
        CargarPersonas();
    }

    private void EliminarPersona_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Persona persona)
        {
            App._personRepo.DeletePerson(persona.Id);
            lblStatusMessage.Text = App._personRepo.StatusMessage;
            CargarPersonas();
        }
    }

    private void CargarPersonas()
    {
        List<Persona> people = App._personRepo.GetAllPersons();
        listaPersonas.ItemsSource = people;
    }
}